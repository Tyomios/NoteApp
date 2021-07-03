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
		/// <summary>
		/// Новая или редактируемая заметка, в зависимости от действия пользователя
		/// </summary>
		public Note Note { get; set; }

		/// <summary>
		/// Внутреняя заметка, для проверки поля названия
		/// </summary>
		private Note SafetyNote { get; set; }

		/// <summary>
		/// Устанавливает значения полей из данных редактируемой заметки
		/// </summary>
		public void SetDataFields()
		{
			NameTextBox.Text = Note.Name;
			CategoryComboBox.SelectedItem = Note.Category;
			NoteTextRichTextBox.Text = Note.Text;
		}

		/// <summary>
		/// Конструктор формы
		/// </summary>
		/// <param name="editNote"> Редактируемая заметка, null в случае создания новой </param>
		public NoteForm()
		{
			InitializeComponent();
			CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				CategoryComboBox.Items.Add(category);
			}
			CategoryComboBox.SelectedItem = Category.Documents;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			Category category = (Category)CategoryComboBox.SelectedItem;

			if (Note != null)
			{
				Note.Name = SafetyNote.Name;
				Note.Category = category;
				Note.Text = NoteTextRichTextBox.Text;
				Note.LastEditTime = DateTime.Now;
				Note.СreationTime = Note.СreationTime;
				this.Close();
			}

			Note = new Note(NameTextBox.Text, category, NoteTextRichTextBox.Text);

			this.Close();
		}

		private void NameTextBox_TextChanged(object sender, EventArgs e)
		{
			Color blackColor = Color.Black;
			Color redColor = Color.Red;

			SafetyNote = (Note) Note.Clone();

			if (NameTextBox.Text.Length < 50)
			{
				NameTextBox.ForeColor = blackColor;
				OKButton.Enabled = true;
				longNameWarningLabel.Text = "";
				longNameWarningLabel.ForeColor = NoteForm.DefaultBackColor;

				if (NameTextBox.Text == "")
				{
					NameTextBox.Text = "Без названия";
				}
			}

			try
			{
				SafetyNote.Name = NameTextBox.Text;
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
				NameTextBox.ForeColor = redColor;
				OKButton.Enabled = false;
				longNameWarningLabel.Text = "Write shorter note's name";
				longNameWarningLabel.ForeColor = redColor;
			}
		}
	}
}
