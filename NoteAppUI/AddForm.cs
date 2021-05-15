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
	public partial class AddForm : Form
	{
		public Note addNote { get; set; }
		public AddForm()
		{
			InitializeComponent();
			CategoryBox.Items.Add(Category.Work);
			CategoryBox.Items.Add(Category.Other);
			CategoryBox.Items.Add(Category.People);
			CategoryBox.Items.Add(Category.SportAndHealth);
			CategoryBox.Items.Add(Category.Home);
			CategoryBox.Items.Add(Category.Finance);
			CategoryBox.Items.Add(Category.Documents);
			
		}
		public AddForm(Note editNote)
		{
			InitializeComponent();
			CategoryBox.Items.Add(Category.Work);
			CategoryBox.Items.Add(Category.Other);
			CategoryBox.Items.Add(Category.People);
			CategoryBox.Items.Add(Category.SportAndHealth);
			CategoryBox.Items.Add(Category.Home);
			CategoryBox.Items.Add(Category.Finance);
			CategoryBox.Items.Add(Category.Documents);

			NameBox.Text = editNote.Name;
			CategoryBox.SelectedItem = editNote.Category;
			richTextBox.Text = editNote.Text;
			addNote = editNote;
		}
		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (CategoryBox.SelectedIndex == -1)
			{
				MessageBox.Show("Choose note category", "Error");
				return;
			}
			Category category = (Category)CategoryBox.SelectedItem;

			if (NameBox.Text == "")
			{
				NameBox.Text = "Без названия";
			}

			if (addNote != null)
			{
				addNote.Name = NameBox.Text;
				addNote.Category = category;
				addNote.Text = richTextBox.Text;
				addNote.LastEditTime = DateTime.Now;
				addNote.СreationTime = addNote.СreationTime;
				this.Close();
			}
			addNote = new Note(NameBox.Text, category, richTextBox.Text);
			this.Close();
		}
	}
}
