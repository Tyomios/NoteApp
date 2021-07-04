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
		private Note note;
		
		/// <summary>
		/// Свойство note
		/// </summary>
		public Note Note
		{
			get => note;
			set
			{
				if(note == null)
				{
					note = new Note();
					return;
				}

				note = value;
				SetDataFields();
			}
		}

		/// <summary>
		/// Внутреняя заметка, для проверки поля названия
		/// </summary>
		private Note SafetyNote { get; set; }

		/// <summary>
		/// Устанавливает значения полей из данных редактируемой заметки
		/// </summary>
		private void SetDataFields()
		{
			NameTextBox.Text = Note.Name;
			CategoryComboBox.SelectedItem = Note.Category;
			NoteTextRichTextBox.Text = Note.Text;
		}

		/// <summary>
		/// Конструктор формы
		/// </summary>
		public NoteForm()
		{
			InitializeComponent();
			Note = new Note();
			SafetyNote = new Note();
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				CategoryComboBox.Items.Add(category);
			}
			CategoryComboBox.SelectedItem = Category.Documents;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			Category category = (Category)CategoryComboBox.SelectedItem;

			if (SafetyNote.Name == "")
			{
				SafetyNote.Name = "Без названия";
			}
			note.Name = SafetyNote.Name;
			note.Category = category;
			note.Text = NoteTextRichTextBox.Text;
			note.LastEditTime = DateTime.Now;
			note.СreationTime = Note.СreationTime;

			note = new Note(SafetyNote.Name, category, NoteTextRichTextBox.Text);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void NameTextBox_TextChanged(object sender, EventArgs e)
		{
			Color blackColor = Color.Black;
			Color redColor = Color.Red;

			SafetyNote = (Note)note.Clone();

			if (NameTextBox.Text.Length < 50)
			{
				NameTextBox.ForeColor = blackColor;
				OKButton.Enabled = true;
				longNameWarningLabel.Text = "";
				longNameWarningLabel.ForeColor = NoteForm.DefaultBackColor;

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
