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

		/// <summary>
		/// Объект, хранящий список заметок.
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

			_project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);
			categoryComboBox.SelectedItem = _comboBoxCategoryAll;
			FilterNotes();
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
            noteCategoryLabel.Text = note.Category.ToString();
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
			noteCategoryLabel.Text = "";
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
		/// Создание заметки.
		/// </summary>
		private void AddNote()
		{
			NoteForm addForm = new NoteForm();
			var result = addForm.ShowDialog();

			if (result != DialogResult.OK)
            {
                return;
            }

			_project.Notes.Add(addForm.Note);
			ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);

			FilterNotes();
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
			AddNote();
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

		/// <summary>
		/// Удаление заметки.
		/// </summary>
		private void DeleteNote()
		{
			if (IsNoteSelected())
			{
				return;
			}

			var deleteNote = _showedNotesByCategory[listNoteListBox.SelectedIndex];
			var result = MessageBox.Show
				($"Delete note {deleteNote.Name} ?", "Warning", MessageBoxButtons.OKCancel);
			if (result == DialogResult.Cancel)
			{
				return;
			}

			_project.Notes.Remove(_project.Notes[_project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
			_showedNotesByCategory.Remove(deleteNote);

			FilterNotes();
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
			DeleteNote();
		}

		/// <summary>
		/// Редактирование заметки.
		/// </summary>
		private void EditNote()
		{
			if (IsNoteSelected())
			{
				return;
			}

			var editForm = new NoteForm();
			var oldEditNote = _showedNotesByCategory[listNoteListBox.SelectedIndex];
			var selectedIndex = listNoteListBox.SelectedIndex;

			Note newEditNote = (Note)oldEditNote.Clone();
			editForm.Note = newEditNote;

			editForm.Text = "Edit Note";
			var result = editForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				int index = _project.Notes.IndexOf(oldEditNote);

				_project.Notes.Add(editForm.Note);
				_showedNotesByCategory.Remove(oldEditNote);
				_showedNotesByCategory.Add(editForm.Note);

				_project.Notes.Remove(_project.Notes[index]);
				ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);

				FilterNotes();
				_project.CurrentNote = _showedNotesByCategory[0];
				listNoteListBox.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Выбирает какой функцией фильтровать заметки, в зависимости от categoryComboBox.SelectedItem.
		/// </summary>
		private void FilterNotes()
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
			EditNote();
		}

		private void listNoteBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listNoteListBox.SelectedIndex != -1)
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
			AddNote();
		}

		private void EditNoteItem_Click(object sender, EventArgs e)
		{
			EditNote();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void RemoveNoteItem_Click(object sender, EventArgs e)
		{
			DeleteNote();
		}
	}
}