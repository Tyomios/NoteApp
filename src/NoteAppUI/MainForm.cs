using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NoteApp;

namespace NoteApp.UI
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Название элемента categoryComboBox.
		/// </summary>
		private const string _comboBoxCategoryAll = "All";
        //TODO: SpellChecker показывает грамматическую ошибку в комментарии
		/// <summary>
		/// Обьект, хранящий список заметок.
		/// </summary>
		public Project _project = new Project();

		/// <summary>
		/// Список заметок для выбранной категории заметок.
		/// </summary>
		private List<Note> _showedNotesByCategory = new List<Note>();

		/// <summary>
		/// Создает экземпляр <see cref="Form">.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			categoryComboBox.Items.Add(_comboBoxCategoryAll);
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				categoryComboBox.Items.Add(category);
			}

			_project = ProjectManager.LoadFromFile(ProjectManager.defaultPath);
			categoryComboBox.SelectedItem = _comboBoxCategoryAll;
			FilterNotesSelector();
		}

		/// <summary>
		/// Заполняет информационное окно данными заметки.
		/// </summary>
		/// <param name="note"> Заметка </param>
		private void FillNoteInfoPanel(Note note)
		{
			noteNameLabel.Text = note.Name;
			noteTextRichBox.Text = note.Text;
			createTimeTextBox.Text = note.CreationTime.ToShortDateString();
			updateTimeTextBox.Text = note.LastEditTime.ToShortDateString();
            // TODO: чтобы каждый раз не добавлять этот текст перед категорией,
            // его можно вынести в отдельный лейбл
			noteCategoryLabel.Text = $"Category: {note.Category}";
		}

		/// <summary>
		/// Cлужебный метод отчистки данных заметки в лейблах и боксах.
		/// </summary>
		private void ClearNoteInfoPanel()
		{
			noteNameLabel.Text = "";
			noteTextRichBox.Text = "";
			createTimeTextBox.Text = "";
			updateTimeTextBox.Text = "";
			noteCategoryLabel.Text = "Category:";
		}

		/// <summary>
		/// Заполняет список заметок и информацию заметки на главной форме.
		/// </summary>
		private void FillMainFormPanels()
		{
			if (_showedNotesByCategory.Count == 0)
			{
				listNoteListBox.Items.Clear();
				ClearNoteInfoPanel();
				return;
			}

			int listIndex = 0;
			for (int i = 0; i < _showedNotesByCategory.Count; i++)
			{
				listNoteListBox.Items.Insert(listIndex, _showedNotesByCategory[listIndex].Name);
				++listIndex;
			}

			listNoteListBox.SelectedIndex = SearchNoteIndex(_showedNotesByCategory);

			var selectedIndex = listNoteListBox.SelectedIndex;

			if (selectedIndex == -1)
			{
				selectedIndex = 0; //listNoteListBox.Items.Count - 1 для выбора последней заметки
			}
			FillNoteInfoPanel(_showedNotesByCategory[selectedIndex]);
		}

        /// <summary>
		/// Поиск индекса выбранной заметки в коллекции.
		/// </summary>
		/// <param name="notes"> Список заметок </param>
		/// <returns>
		/// Индекс заметки
		/// Возврат значения -1 в случае, если заметка не найдена
		/// </returns>
		private int SearchNoteIndex(List<Note> notes)
		{
			if (_project.CurrentNote == null)
			{
				return 0;
			}

            return notes.IndexOf(_project.CurrentNote);
        }

        /// <summary>
		/// Фильтрация заметок в списке _showedNotesByCategory по категории.
		/// </summary>
		/// <param name="category"> Категория </param>
		private void FilterNotesByCategory(Category category)
        {
	        listNoteListBox.Items.Clear();
			_showedNotesByCategory.Clear();
			_showedNotesByCategory = _project.FilterByCategory(category);
			
			FillMainFormPanels();
		}

		/// <summary>
		/// Проверка заметки на null, в случае если заметка null - удаляет ее.
		/// </summary>
		/// <param name="notes"> Список заметок </param>
		private void RemoveLastNullNoteInList(List<Note> notes)
		{
			var lastNote = notes[notes.Count - 1];
			//TODO: Что это за случай, когда имя в заметки пустое, и нужно её удалить?
			if (lastNote == null || lastNote.Name == "")
			{
				notes.Remove(lastNote);
			}
		}

		// TODO: именование. Что за Action?+ UPD: просто AddNote(). Зачем сложности?
		/// <summary>
		/// Создание заметки.
		/// </summary>
		private void StartOperationAddNote()
		{
			NoteForm addForm = new NoteForm();
			var result = addForm.ShowDialog();

			//TODO: if (result != DialogResult.OK) {return }
			// и тогда второе условие ниже уже не надо
			if (result == DialogResult.Cancel)
			{
				return;
			}

			if (result == DialogResult.OK)
			{
				_project.Notes.Add(addForm.Note);
                //TODO: Откуда вообще берется null или пустая заметка в списке? Это какой-то косяк
				RemoveLastNullNoteInList(_project.Notes);
				ProjectManager.SaveToFile(_project, ProjectManager.defaultPath);

				//TODO: почему ты уверен, что новая заметка относится к текущей категории?
				_showedNotesByCategory.Add(addForm.Note);
			}

			FilterNotesSelector();
			if (_showedNotesByCategory.Count != 0)
			{
				_project.CurrentNote = _showedNotesByCategory[0];
				FillNoteInfoPanel(_project.CurrentNote);
				listNoteListBox.SelectedItem = _project.CurrentNote;
				listNoteListBox.SelectedIndex = 0;
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			StartOperationAddNote();
		}

		/// <summary>
		/// Проверка на невыбранный элемент listBox.
		/// </summary>
		/// <param name="index"> Индекс удаляемой заметки </param>
		/// <returns>
		/// retval true - индекс равен -1
		/// retval false - индекс не равен -1
		/// </returns>
		private bool IsNoteSelected()
		{
			if (listNoteListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK);
				return true;
			}

			return false;
		}

		// TODO: именование. Что за Action?+ UPD: именование DeleteNote()
		/// <summary>
		/// Удаление заметки.
		/// </summary>
		private void StartOperationDeleteNote()
		{
			if (IsNoteSelected())
			{
				return;
			}

			var deleteNote = _showedNotesByCategory[listNoteListBox.SelectedIndex];
            //TODO: используй var вместо указания конкретного типа
			DialogResult result = MessageBox.Show
				($"Delete note {deleteNote.Name} ?", "Warning", MessageBoxButtons.OKCancel);
			if (result == DialogResult.Cancel)
			{
				return;
			}

			_project.Notes.Remove(_project.Notes[_project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(_project, ProjectManager.defaultPath);
			_showedNotesByCategory.Remove(deleteNote);

			FilterNotesSelector();
			try
			{
				listNoteListBox.SelectedIndex = 0;
			}
			catch (ArgumentOutOfRangeException e)
			{
				ClearNoteInfoPanel();
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			StartOperationDeleteNote();
		}

		// TODO: именование. Что за Action?+ UPD: именование EditNote()
		/// <summary>
		/// Редактирование заметки.
		/// </summary>
		private void StartOperationEditNote()
		{
			if (IsNoteSelected())
			{
				return;
			}

            //TODO: почему addForm?
			var addForm = new NoteForm();

			//TODO: далее по коду у тебя часто используется конструкция _showedNotesByCategory[listNoteListBox.SelectedIndex]..
			// .. вынеси и selectedIndex и заметку в локальные переменные, и используй их, так код будет лаконичнее.
			Note newEditNote = (Note)_showedNotesByCategory[listNoteListBox.SelectedIndex].Clone();
			addForm.Note = newEditNote;

			addForm.Text = "Edit Note";
			var result = addForm.ShowDialog();
			if (result == DialogResult.OK)
			{
                //TODO: почему CreationTime не копируется сам при методе Clone()? Почему приходится копировать время вручную? Исправить
				int index = _project.Notes.IndexOf(_showedNotesByCategory[listNoteListBox.SelectedIndex]);
				var oldCreationTime = _showedNotesByCategory[listNoteListBox.SelectedIndex].CreationTime;
				addForm.Note.CreationTime = oldCreationTime;

				_project.Notes.Add(addForm.Note);
				_showedNotesByCategory.Remove(_showedNotesByCategory[listNoteListBox.SelectedIndex]);
				_showedNotesByCategory.Add(addForm.Note); //TODO: две пустых строки делать не надо, может быть только одна


				_project.Notes.Remove(_project.Notes[index]);
				ProjectManager.SaveToFile(_project, ProjectManager.defaultPath);

				FilterNotesSelector();
				_project.CurrentNote = _showedNotesByCategory[0];
				listNoteListBox.SelectedIndex = 0;
			}
		}

		//TODO: что за слово Selector в именовании? Зачем оно?
		/// <summary>
		/// Выбирает какой функцией фильтровать заметки, в зависимости от categoryComboBox.SelectedItem.
		/// </summary>
		private void FilterNotesSelector()
		{
			if(categoryComboBox.SelectedItem.ToString() == _comboBoxCategoryAll)
			{
				ShowAllNotes();
				return;
			}
			FilterNotesByCategory((Category)categoryComboBox.SelectedItem);
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			StartOperationEditNote();
		}

		private void listNoteBox_SelectedIndexChanged(object sender, EventArgs e)
		{
            //TODO: != 1
			if (listNoteListBox.SelectedIndex > -1)
			{
				var currentNote = _showedNotesByCategory[listNoteListBox.SelectedIndex];
				FillNoteInfoPanel(currentNote);
				_project.CurrentNote = currentNote;
			}
			else
			{
				ClearNoteInfoPanel();
			}
		}

		private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var testCategory = categoryComboBox.SelectedItem;
			if(testCategory == _comboBoxCategoryAll)
			{
				ShowAllNotes();
				return;
			}
			FilterNotesByCategory((Category)testCategory);
		}

		/// <summary>
		/// Отображение заметок для categoryComboBox.SelectedItem = All.
		/// </summary>
		private void ShowAllNotes()
		{
			listNoteListBox.Items.Clear();
			_showedNotesByCategory.Clear();
			_showedNotesByCategory = _project.GetReverseNotesList();
			
			FillMainFormPanels();
		}

		private void AddNoteItem_Click(object sender, EventArgs e)
		{
			StartOperationAddNote();
		}

		private void EditNoteItem_Click(object sender, EventArgs e)
		{
			StartOperationEditNote();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void RemoveNoteItem_Click(object sender, EventArgs e)
		{
			StartOperationDeleteNote();
		}
	}
}