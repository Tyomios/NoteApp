using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NoteApp;
using static NoteAppUI.NoteForm;


namespace NoteAppUI
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Обьект, хранящий список заметок
		/// </summary>
		public Project project = new Project();

		/// <summary>
		/// Список заметок для выбранной категории заметок
		/// </summary>
		List<Note> showedNotesByCategory = new List<Note>();

		/// <summary>
		/// Название элемента categoryComboBox
		/// </summary>
		private const string all = "All";

		/// <summary>
		/// Проверка заметки на null, в случае если заметка null - удаляет ее
		/// </summary>
		/// <param name="notes"> Список заметок </param>
		void CheckNullNoteInList(List<Note> notes)
		{
			var lastNote = notes[notes.Count - 1];
			if (lastNote == null || lastNote.Name == "")
			{
				notes.Remove(lastNote);
			}
		}

		/// <summary>
		/// служебный метод отчистки данных заметки в лейблах и боксах
		/// </summary>
		void ClearNoteInfoPanel()
		{
			noteNameLabel.Text = "";
			noteTextRichBox.Text = "";
			createTimeTextBox.Text = "";
			updateTimeTextBox.Text = "";
			noteCategoryLabel.Text = "Category:";
		}

		/// <summary>
		/// Фильтрация заметок по категории
		/// </summary>
		/// <param name="sortedCategory"> Категория для сортировки </param>
		/// <param name="categoryNotesList"> Список заметок, 
		/// В котором будут храниться заметки нужной категории
		/// </param>
		private void FilterNotesByCategory(string sortedCategory, List<Note> categoryNotesList)
		{
			listNoteListBox.Items.Clear();
			categoryNotesList.Clear();
			project.GetNotesChoosenCategory(sortedCategory, categoryNotesList);
			if (categoryNotesList.Count == 0)
			{
				listNoteListBox.Items.Clear();
				ClearNoteInfoPanel();
				return;
			}

			int listIndex = 0;

			for (int i = 0; i < categoryNotesList.Count; i++)
			{
				listNoteListBox.Items.Insert(listIndex, categoryNotesList[listIndex].Name);
				++listIndex;
			}

			listNoteListBox.SelectedIndex = listNoteListBox.Items.Count - 1; // тут указать последнюю клик заметку
			var selectedIndex = listNoteListBox.SelectedIndex;

			noteNameLabel.Text = listNoteListBox.Items[selectedIndex].ToString();
			noteTextRichBox.Text = categoryNotesList[selectedIndex].Text;
		}

		/// <summary>
		/// Проверка на невыбранный элемент listBox
		/// </summary>
		/// <param name="index"> Индекс удаляемой заметки </param>
		/// <returns>
		/// retval true - индекс равен -1
		/// retval false - индекс не равен -1
		/// </returns>
		private bool IsNoteSelected(int index)
		{
			if (index == -1)
			{
				MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Создание заметки
		/// </summary>
		private void ActionAddNote()
		{
			NoteForm addForm = new NoteForm();
			var result = addForm.ShowDialog();

			if (result == DialogResult.Cancel)
			{
				return;
			}

			if (result == DialogResult.OK)
			{
				project.Notes.Add(addForm.Note);
				CheckNullNoteInList(project.Notes);
				ProjectManager.SaveToFile(project);

				showedNotesByCategory.Add(addForm.Note);
			}
			
			FilterNotesByCategory(categoryComboBox.SelectedItem.ToString(), showedNotesByCategory);
		}

		/// <summary>
		/// Удаление заметки
		/// </summary>
		private void ActionDeleteNote()
		{
			if (IsNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}

			var deleteNote = showedNotesByCategory[listNoteListBox.SelectedIndex];
			DialogResult result = MessageBox.Show
				($"Delete note {deleteNote.Name} ?", "Warning", MessageBoxButtons.OKCancel);
			if (result == DialogResult.Cancel)
			{
				return;
			}

			project.Notes.Remove(project.Notes[project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(project);
			showedNotesByCategory.Remove(deleteNote);

			FilterNotesByCategory(categoryComboBox.SelectedItem.ToString(), showedNotesByCategory);
		}

		/// <summary>
		/// Редактирование заметки
		/// </summary>
		private void ActionEditNote()
		{
			if (IsNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}

			var addForm = new NoteForm();

			addForm.Note = showedNotesByCategory[listNoteListBox.SelectedIndex];
			addForm.Text = "Edit Note";
			var result = addForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				ProjectManager.SaveToFile(project);
			}
			FilterNotesByCategory(categoryComboBox.SelectedItem.ToString(), showedNotesByCategory);
		}

		/// <summary>
		/// Конструктор главного окна
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			categoryComboBox.Items.Add(all);
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				categoryComboBox.Items.Add(category);
			}

			project = ProjectManager.LoadFromFile();
			categoryComboBox.SelectedItem = all;
			FilterNotesByCategory(categoryComboBox.SelectedItem.ToString(), showedNotesByCategory);
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			ActionAddNote();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			ActionDeleteNote();
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			ActionEditNote();
		}

		private void listNoteBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<Note> dataList = project.Notes;
			if (categoryComboBox.SelectedItem.ToString() != all)
			{
				project.GetNotesChoosenCategory(categoryComboBox.SelectedItem.ToString(), showedNotesByCategory);
				dataList = showedNotesByCategory;
			}

			var currentNote = dataList[listNoteListBox.SelectedIndex];
			noteTextRichBox.Text = currentNote.Text;
			noteNameLabel.Text = currentNote.Name;
			noteCategoryLabel.Text = $"Category: {currentNote.Category}";
			createTimeTextBox.Text = currentNote.СreationTime.ToShortDateString();
			updateTimeTextBox.Text = currentNote.LastEditTime.ToShortDateString();
		}

		private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedCategory = categoryComboBox.SelectedItem.ToString();
			FilterNotesByCategory(selectedCategory, showedNotesByCategory);
		}

		private void AddNoteItem_Click(object sender, EventArgs e)
		{
			ActionAddNote();
		}

		private void EditNoteItem_Click(object sender, EventArgs e)
		{
			ActionEditNote();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void RemoveNoteItem_Click(object sender, EventArgs e)
		{
			ActionDeleteNote();
		}
	}
}