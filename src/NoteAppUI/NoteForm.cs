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

namespace NoteApp.UI
{
	public partial class NoteForm : Form
	{
		/// <summary>
		/// Новая или редактируемая заметка, в зависимости от действия пользователя.
		/// </summary>
		private Note _note;

		/// <summary>
		/// Возвращает заметку или задает данные для заметки. В последнем случае полученные данные используются для заполнения формы.
		/// </summary>
		public Note Note
		{
			get => _note;
			set
			{
				if(_note == null)
				{
					_note = new Note();
					return;
				}

				_note = value;
				SetDataFields();
			}
		}

        /// <summary>
		/// Возвращает или задает заметку, которая нужна для проверки поля названия.
		/// </summary>
		private Note NoteForValidation { get; set; }

		/// <summary>
		/// Устанавливает значения полей из данных редактируемой заметки.
		/// </summary>
		private void SetDataFields()
		{
			NameTextBox.Text = Note.Name;
			CategoryComboBox.SelectedItem = Note.Category;
			NoteTextRichTextBox.Text = Note.Text;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Form">.
		/// </summary>
		public NoteForm()
		{
			InitializeComponent();
			Note = new Note();
			NoteForValidation = new Note();
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

			if (NoteForValidation.Name == "")
			{
				NoteForValidation.Name = "Без названия";
			}
			_note.Name = NoteForValidation.Name;
			_note.Category = category;
			_note.Text = NoteTextRichTextBox.Text;
			_note.LastEditTime = DateTime.Now;
			_note.CreationTime = Note.CreationTime;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void NameTextBox_TextChanged(object sender, EventArgs e)
		{
			NoteForValidation = (Note)_note.Clone();

			if (NameTextBox.Text.Length < 50)
			{
				OKButton.Enabled = true;
			}

			try
			{
				NoteForValidation.Name = NameTextBox.Text;
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				NameTextBox.MaxLength = 51;
				OKButton.Enabled = false;
			}
		}
	}
}
