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
using static NoteAppUI.AddForm;


namespace NoteAppUI
{
	public partial class MainForm : Form
	{
		public Project project = new Project();
		List<Note> categoryNotesList = new List<Note>();

		private void SortNotes(Category sortedCategory, List<Note> categoryNotesList) // требует внимания
		{
			listNoteBox.Items.Clear();
			categoryNotesList.Clear();
			int listIndex = 0;

			if (sortedCategory == Category.All)
			{
				for (int i = 0; i < project.Notes.Count; i++)
				{
					categoryNotesList.Add(project.Notes[i]);
					listNoteBox.Items.Insert(listIndex, categoryNotesList[listIndex].Name);
					++listIndex;
				}
				listNoteBox.SelectedIndex = listNoteBox.Items.Count - 1;
				nameLabel.Text = listNoteBox.Items[listNoteBox.SelectedIndex].ToString();
				noteText.Text = categoryNotesList[listNoteBox.SelectedIndex].Text;

				return;
			}

			
			
			for (int i = 0; i < project.Notes.Count; i++)
			{
				if (project.Notes[i].Category == sortedCategory)
				{
					categoryNotesList.Add(project.Notes[i]);
					listNoteBox.Items.Insert(listIndex, categoryNotesList[listIndex].Name);
					++listIndex;
				}
			}

			if (listNoteBox.Items.Count == 0)
			{
				listNoteBox.Items.Clear();
				return;
			}

			listNoteBox.SelectedIndex = listNoteBox.Items.Count - 1;
			nameLabel.Text = listNoteBox.Items[listNoteBox.SelectedIndex].ToString();
			noteText.Text = categoryNotesList[listNoteBox.SelectedIndex].Text;
		}

		private void UpdateListNote()
		{
			listNoteBox.Items.Clear();
			categoryBox.SelectedItem = Category.All;
			for (int i = 0; i < project.Notes.Count; i++)
			{
				listNoteBox.Items.Insert(i, project.Notes[i].Name);
			}

			listNoteBox.SelectedIndex = project.Notes.Count - 1;
			nameLabel.Text = listNoteBox.Items[project.Notes.Count - 1].ToString();
			noteText.Text = project.Notes[listNoteBox.SelectedIndex].Text;
		}

		public MainForm()
		{
			InitializeComponent();

			categoryBox.Items.Add(Category.Work);
			categoryBox.Items.Add(Category.Other);
			categoryBox.Items.Add(Category.People);
			categoryBox.Items.Add(Category.SportAndHealth);
			categoryBox.Items.Add(Category.Home);
			categoryBox.Items.Add(Category.Finance);
			categoryBox.Items.Add(Category.Documents);
			categoryBox.Items.Add(Category.All);

			exitToolStripMenuItem.Click += exitItem_Click;
			aboutToolStripMenuItem.Click += aboutItem_Click;
			AddNoteItem.Click += addButton_Click;
			EditNoteItem.Click += editButton_Click;
			RemoveNoteItem.Click += deleteButton_Click;

			project.Notes = ProjectManager.LoadFromFile("NoteAppDataBase");
			if (project.Notes == null)
			{
				project.Notes = new List<Note>();
			}

			categoryBox.SelectedItem = Category.All;
			//UpdateListNote();
			SortNotes((Category)categoryBox.SelectedItem, categoryNotesList);
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			AddForm addForm = new AddForm();
			addForm.ShowDialog();
			if (addForm.addNote == null)
			{
				return;
			}
			project.Notes.Add(addForm.addNote);
			ProjectManager.SaveToFile(project.Notes, "NoteAppDataBase");

			categoryNotesList.Add(addForm.addNote);
			//UpdateListNote();
			SortNotes((Category)categoryBox.SelectedItem, categoryNotesList);
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			Note deleteNote = categoryNotesList[listNoteBox.SelectedIndex];
			DialogResult result = MessageBox.Show
									("Вы действительно хотите удалить заметку?"
			               + deleteNote.Name, "Внимание", MessageBoxButtons.YesNo);
			if (result == DialogResult.No)
			{
				return;
			}

			project.Notes.Remove(project.Notes[project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(project.Notes, "NoteAppDataBase");
			categoryNotesList.Remove(deleteNote);
			//UpdateListNote();
			SortNotes((Category)categoryBox.SelectedItem, categoryNotesList);
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			AddForm addForm = new AddForm(project.Notes[listNoteBox.SelectedIndex]);
			addForm.Text = "Edit Note";

			addForm.ShowDialog();
			ProjectManager.SaveToFile(project.Notes, "NoteAppDataBase");
			//UpdateListNote();
			SortNotes((Category)categoryBox.SelectedItem, categoryNotesList);
		}

		private void listNoteBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<Note> dataList = project.Notes;
			if((Category)categoryBox.SelectedItem != Category.All)
			{
				if (categoryBox == null)
				{
					return;
				}
				//dataList.Clear();
				dataList = categoryNotesList;
			}
			noteText.Text = dataList[listNoteBox.SelectedIndex].Text;
			nameLabel.Text = dataList[listNoteBox.SelectedIndex].Name;
			noteCategoryLabel.Text ="Category: " + dataList[listNoteBox.SelectedIndex].Category.ToString();
			createTimeBox.Text = dataList[listNoteBox.SelectedIndex].СreationTime.ToShortDateString();
			updateTimeBox.Text = dataList[listNoteBox.SelectedIndex].LastEditTime.ToShortDateString();
		}

		private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SortNotes((Category)categoryBox.SelectedItem, categoryNotesList);
		}

		private void exitItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void aboutItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}
	}
}
