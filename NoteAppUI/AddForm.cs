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
		public Note addNote;
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
			addNote = new Note(NameBox.Text, category, richTextBox.Text);
			this.Close();
		}
	}
}
