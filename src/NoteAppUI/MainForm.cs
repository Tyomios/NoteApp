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
		List<Note> notesByCategory = new List<Note>();

		/// <summary>
		/// Фильтрация заметок по категории
		/// </summary>
		/// <param name="sortedCategory">
		/// Категория для сортировки
		/// </param>
		/// <param name="categoryNotesList">
		/// Список заметок, в котором будут храниться заметки нужной категории
		/// </param>
		private void NotesCategoryFilter(string sortedCategory, List<Note> categoryNotesList)
		{
			listNoteListBox.Items.Clear();
			categoryNotesList.Clear();
			project.GetNotesChoosenCategory(sortedCategory, categoryNotesList);
			if (categoryNotesList.Count == 0)
			{
				listNoteListBox.Items.Clear();
				return;
			}

			int listIndex = 0;

			for (int i = 0; i < categoryNotesList.Count; i++)
			{
				listNoteListBox.Items.Insert(listIndex, categoryNotesList[listIndex].Name);
				++listIndex;
			}

			listNoteListBox.SelectedIndex = listNoteListBox.Items.Count - 1;
			var selectedIndex = listNoteListBox.SelectedIndex;

			noteNameLabel.Text = listNoteListBox.Items[selectedIndex].ToString();
			noteTextRichBox.Text = categoryNotesList[selectedIndex].Text;
		}

		/// <summary>
		/// Проверка на невыбранный элемент listBox
		/// </summary>
		/// <param name="index">
		/// Индекс удаляемой заметки
		/// </param>
		/// <returns>
		/// retval true - индекс равен -1
		/// retval false - индекс не равен -1
		/// </returns>
		private bool isNoteSelected(int index)
		{
			if (index == -1)
			{
				MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Конструктор главного окна
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			categoryComboBox.Items.Add("All");
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				categoryComboBox.Items.Add(category);
			}

			project = ProjectManager.LoadFromFile();
			if (project.Notes == null)
			{
				project.Notes = new List<Note>();
			}
			
			categoryComboBox.SelectedItem = "All";
			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			NoteForm addForm = new NoteForm();
			addForm.ShowDialog();
			if (addForm.Note == null)
			{
				return;
			}

			project.Notes.Add(addForm.Note);
			ProjectManager.SaveToFile(project);

			notesByCategory.Add(addForm.Note);
			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if (isNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}
			
			Note deleteNote = notesByCategory[listNoteListBox.SelectedIndex];
			DialogResult result = MessageBox.Show
				("Delete note " + deleteNote.Name + "?", "Warning", MessageBoxButtons.OKCancel);
			if (result == DialogResult.Cancel)
			{
				return;
			}

			project.Notes.Remove(project.Notes[project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(project);
			notesByCategory.Remove(deleteNote);

			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			if (isNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}

			NoteForm addForm = new NoteForm();
			addForm.Note = notesByCategory[listNoteListBox.SelectedIndex];
			addForm.SetDataFields();
			addForm.Text = "Edit Note";
			addForm.ShowDialog();

			ProjectManager.SaveToFile(project);
			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}

		private void listNoteBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<Note> dataList = project.Notes;
			if(categoryComboBox.SelectedItem.ToString() != "All")
			{
				if (categoryComboBox == null)
				{
					return;
				}

				project.GetNotesChoosenCategory(categoryComboBox.SelectedItem.ToString(), notesByCategory);
				dataList = notesByCategory;
			}

			var currentNote = dataList[listNoteListBox.SelectedIndex];
			noteTextRichBox.Text = currentNote.Text;
			noteNameLabel.Text = currentNote.Name;
			noteCategoryLabel.Text ="Category: " + currentNote.Category.ToString();
			createTimeTextBox.Text = currentNote.СreationTime.ToShortDateString();
			updateTimeTextBox.Text = currentNote.LastEditTime.ToShortDateString();
		}

		private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedCategory = categoryComboBox.SelectedItem.ToString();
			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}

		private void AddNoteItem_Click(object sender, EventArgs e)
		{
			NoteForm addForm = new NoteForm();
			addForm.ShowDialog();
			if (addForm.Note == null)
			{
				return;
			}
			project.Notes.Add(addForm.Note);
			ProjectManager.SaveToFile(project);

			notesByCategory.Add(addForm.Note);
			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}

		private void EditNoteItem_Click(object sender, EventArgs e)
		{
			if (isNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}

			NoteForm addForm = new NoteForm();
			addForm.Note = notesByCategory[listNoteListBox.SelectedIndex];
			addForm.SetDataFields();
			addForm.Text = "Edit Note";

			addForm.ShowDialog();
			ProjectManager.SaveToFile(project);
			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void RemoveNoteItem_Click(object sender, EventArgs e)
		{
			if (isNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}

			Note deleteNote = notesByCategory[listNoteListBox.SelectedIndex];
			DialogResult result = MessageBox.Show
				("Delete note " + deleteNote.Name + "?", "Warning", MessageBoxButtons.OKCancel);

			if (result == DialogResult.Cancel)
			{
				return;
			}

			project.Notes.Remove(project.Notes[project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(project);
			notesByCategory.Remove(deleteNote);
			NotesCategoryFilter(categoryComboBox.SelectedItem.ToString(), notesByCategory);
		}
	}
}