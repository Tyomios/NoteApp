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
		List<Note> categoryNotesList = new List<Note>();

		/// <summary>
		/// Сортировка заметок по категории
		/// </summary>
		/// <param name="sortedCategory">Категория для сортировки</param>
		/// <param name="categoryNotesList">Список заметок, в котором будут храниться заметки нужной категории</param>
		private void SortNotes(Category sortedCategory, List<Note> categoryNotesList)
		{
			listNoteListBox.Items.Clear();
			categoryNotesList.Clear();
			int listIndex = 0;

			for (int i = 0; i < project.Notes.Count; i++)
			{
				if (project.Notes[i].Category == sortedCategory || sortedCategory == Category.All)
				{ 
					categoryNotesList.Add(project.Notes[i]); 
					listNoteListBox.Items.Insert(listIndex, categoryNotesList[listIndex].Name); 
					++listIndex;
				}
			}
			if (categoryNotesList.Count == 0) 
			{
				listNoteListBox.Items.Clear();
				return;
			}

			listNoteListBox.SelectedIndex = listNoteListBox.Items.Count - 1;
			noteNameLabel.Text = listNoteListBox.Items[listNoteListBox.SelectedIndex].ToString();
			noteTextRichBox.Text = categoryNotesList[listNoteListBox.SelectedIndex].Text;
		}

		
		public MainForm()
		{
			InitializeComponent();

			categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				categoryComboBox.Items.Add(category);
			}

			project = ProjectManager.LoadFromFile("NoteAppDataBaseP");
			if (project.Notes == null)
			{
				project.Notes = new List<Note>();
			}
			

			categoryComboBox.SelectedItem = Category.All;
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			NoteForm addForm = new NoteForm(null);
			addForm.ShowDialog();
			if (addForm.Note == null)
			{
				return;
			}

			project.Notes.Add(addForm.Note);
			ProjectManager.SaveToFile(project, "NoteAppDataBaseP");

			categoryNotesList.Add(addForm.Note);
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			Note deleteNote = categoryNotesList[listNoteListBox.SelectedIndex];
			DialogResult result = MessageBox.Show
				("Delete note " + deleteNote.Name + "?", "Внимание", MessageBoxButtons.YesNo);
			if (result == DialogResult.No)
			{
				return;
			}

			project.Notes.Remove(project.Notes[project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(project, "NoteAppDataBaseP");
			categoryNotesList.Remove(deleteNote);
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			NoteForm addForm = new NoteForm(project.Notes[listNoteListBox.SelectedIndex]);
			addForm.Text = "Edit Note";
			addForm.ShowDialog();

			ProjectManager.SaveToFile(project, "NoteAppDataBaseP");
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}

		private void listNoteBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<Note> dataList = project.Notes;
			if((Category)categoryComboBox.SelectedItem != Category.All)
			{
				if (categoryComboBox == null)
				{
					return;
				}
				dataList = categoryNotesList;
			}
			noteTextRichBox.Text = dataList[listNoteListBox.SelectedIndex].Text;
			noteNameLabel.Text = dataList[listNoteListBox.SelectedIndex].Name;
			noteCategoryLabel.Text ="Category: " + dataList[listNoteListBox.SelectedIndex].Category.ToString();
			createTimeTextBox.Text = dataList[listNoteListBox.SelectedIndex].СreationTime.ToShortDateString();
			updateTimeTextBox.Text = dataList[listNoteListBox.SelectedIndex].LastEditTime.ToShortDateString();
		}

		private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}

		private void AddNoteItem_Click(object sender, EventArgs e)
		{
			NoteForm addForm = new NoteForm(null);
			addForm.ShowDialog();
			if (addForm.Note == null)
			{
				return;
			}
			project.Notes.Add(addForm.Note);
			ProjectManager.SaveToFile(project, "NoteAppDataBaseP");

			categoryNotesList.Add(addForm.Note);
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}

		private void EditNoteItem_Click(object sender, EventArgs e)
		{
			NoteForm addForm = new NoteForm(project.Notes[listNoteListBox.SelectedIndex]);
			addForm.Text = "Edit Note";

			addForm.ShowDialog();
			ProjectManager.SaveToFile(project, "NoteAppDataBaseP");
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void RemoveNoteItem_Click(object sender, EventArgs e)
		{
			Note deleteNote = categoryNotesList[listNoteListBox.SelectedIndex];
			DialogResult result = MessageBox.Show
				("Delete note " + deleteNote.Name + "?", "Внимание", MessageBoxButtons.YesNo);
			if (result == DialogResult.No)
			{
				return;
			}

			project.Notes.Remove(project.Notes[project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(project, "NoteAppDataBaseP");
			categoryNotesList.Remove(deleteNote);
			SortNotes((Category)categoryComboBox.SelectedItem, categoryNotesList);
		}
	}
}
