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


// TODO: именование не соответствует названию проекта+
namespace NoteApp.UI
{
	public partial class MainForm : Form
	{
		// TODO: именование не по RSDN+
		/// <summary>
		/// Название элемента categoryComboBox.
		/// </summary>
		private const string _comboBoxCategoryAll = "All";

		// TODO: именование не по RSDN+
		/// <summary>
		/// Обьект, хранящий список заметок.
		/// </summary>
		public Project _project = new Project();

        // TODO: модификаторы доступа надо прописывать явно+
		// TODO: именование не по RSDN+
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

		// TODO: порядок членов класса
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

		// TODO: модификаторы доступа надо прописывать явно+
        // TODO: порядок членов класса
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

		// TODO: порядок членов класса
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
            // TODO: у тебя и в проекте, и в showedNotes лежат одни и те же экземпляры заметок -
			// Зачем ты делаешь поиск по полям, когда можно сделать простой поиск/сравнение по ссылке
			// или даже сделать поиск linq-запросом? +
			if(_project.CurrentNote != null)
			{
				var equalNotes = (from note in notes
					where note.Equals(_project.CurrentNote)
					select note).ToList();

				return notes.IndexOf(equalNotes[0]);
			}
			
			return -1;
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

        // TODO: модификаторы доступа надо прописывать явно+
		// TODO: порядок членов класса
		/// <summary>
		/// Проверка заметки на null, в случае если заметка null - удаляет ее.
		/// </summary>
		/// <param name="notes"> Список заметок </param>
		private void RemoveLastNullNoteInList(List<Note> notes)
		{
			// TODO: именование метода. Почему метод проверки удаляет что-то из списка?+
			var lastNote = notes[notes.Count - 1];
			if (lastNote == null || lastNote.Name == "")
			{
				notes.Remove(lastNote);
			}
		}

		// TODO: порядок членов класса+
		// TODO: именование. Что за Action?+
		/// <summary>
		/// Создание заметки.
		/// </summary>
		private void StartOperationAddNote()
		{
			NoteForm addForm = new NoteForm();
			var result = addForm.ShowDialog();

			if (result == DialogResult.Cancel)
			{
				return;
			}

			if (result == DialogResult.OK)
			{
				_project.Notes.Add(addForm.Note);
				RemoveLastNullNoteInList(_project.Notes);
				ProjectManager.SaveToFile(_project, ProjectManager.defaultPath);

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

		// TODO: порядок членов класса+
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
			// TODO: метод вызывается всегда для листбокса. Может тогда определять индекс внутри метода и упростить вызов?+
			if (listNoteListBox.SelectedIndex == -1)
			{
				MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK);
				return true;
			}

			return false;
		}

		// TODO: порядок членов класса
		// TODO: именование. Что за Action?+
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

		// TODO: порядок членов класса+
		// TODO: именование. Что за Action?+
		/// <summary>
		/// Редактирование заметки.
		/// </summary>
		private void StartOperationEditNote()
		{
			if (IsNoteSelected())
			{
				return;
			}

			var addForm = new NoteForm();

			Note newEditNote = (Note)_showedNotesByCategory[listNoteListBox.SelectedIndex].Clone();
			addForm.Note = newEditNote;

			addForm.Text = "Edit Note";
			var result = addForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				int index = _project.Notes.IndexOf(_showedNotesByCategory[listNoteListBox.SelectedIndex]);
				var oldCreationTime = _showedNotesByCategory[listNoteListBox.SelectedIndex].CreationTime;
				addForm.Note.CreationTime = oldCreationTime;

				_project.Notes.Add(addForm.Note);
				_showedNotesByCategory.Remove(_showedNotesByCategory[listNoteListBox.SelectedIndex]);
				_showedNotesByCategory.Add(addForm.Note);


				_project.Notes.Remove(_project.Notes[index]);
				ProjectManager.SaveToFile(_project, ProjectManager.defaultPath);

				FilterNotesSelector();
				_project.CurrentNote = _showedNotesByCategory[0];
				listNoteListBox.SelectedIndex = 0;
			}
		}

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