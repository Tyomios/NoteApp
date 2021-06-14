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


namespace NoteAppUI
{
	public partial class NoteForm : Form
	{
		public Note addNote { get; set; }
		public NoteForm()
		{
			InitializeComponent();
			CategoryComboBox.Items.Add(Category.Work);
			CategoryComboBox.Items.Add(Category.Other);
			CategoryComboBox.Items.Add(Category.People);
			CategoryComboBox.Items.Add(Category.SportAndHealth);
			CategoryComboBox.Items.Add(Category.Home);
			CategoryComboBox.Items.Add(Category.Finance);
			CategoryComboBox.Items.Add(Category.Documents);
			
		}
		public NoteForm(Note editNote)
		{
			InitializeComponent();
			CategoryComboBox.Items.Add(Category.Work);
			CategoryComboBox.Items.Add(Category.Other);
			CategoryComboBox.Items.Add(Category.People);
			CategoryComboBox.Items.Add(Category.SportAndHealth);
			CategoryComboBox.Items.Add(Category.Home);
			CategoryComboBox.Items.Add(Category.Finance);
			CategoryComboBox.Items.Add(Category.Documents);

			NameTextBox.Text = editNote.Name;
			CategoryComboBox.SelectedItem = editNote.Category;
			NoteTextRichTextBox.Text = editNote.Text;
			addNote = editNote;
		}
		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (CategoryComboBox.SelectedIndex == -1)
			{
				MessageBox.Show("Choose note category", "Error");
				return;
			}
			Category category = (Category)CategoryComboBox.SelectedItem;

			if (NameTextBox.Text == "")
			{
				NameTextBox.Text = "Без названия";
			}

			if (addNote != null)
			{
				addNote.Name = NameTextBox.Text;
				addNote.Category = category;
				addNote.Text = NoteTextRichTextBox.Text;
				addNote.LastEditTime = DateTime.Now;
				addNote.СreationTime = addNote.СreationTime;
				this.Close();
			}
			addNote = new Note(NameTextBox.Text, category, NoteTextRichTextBox.Text);
			this.Close();
		}
	}
}
