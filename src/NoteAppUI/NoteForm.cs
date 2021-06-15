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
		public Note Note { get; set; }
		
		public NoteForm(Note editNote)
		{
			InitializeComponent();

			CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				if ((Category)category != Category.All)
				{
					CategoryComboBox.Items.Add(category);
				}
			}

			if (editNote != null)
			{
				NameTextBox.Text = editNote.Name;
				CategoryComboBox.SelectedItem = editNote.Category;
				NoteTextRichTextBox.Text = editNote.Text;
				Note = editNote;
			}
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

			if (Note != null)
			{
				Note.Name = NameTextBox.Text;
				Note.Category = category;
				Note.Text = NoteTextRichTextBox.Text;
				Note.LastEditTime = DateTime.Now;
				Note.СreationTime = Note.СreationTime;
				this.Close();
			}
			Note = new Note(NameTextBox.Text, category, NoteTextRichTextBox.Text);
			this.Close();
		}
	}
}
