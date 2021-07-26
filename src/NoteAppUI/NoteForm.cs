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

// TODO: именование не соответствует названию проекта
namespace NoteAppUI
{
	public partial class NoteForm : Form
	{
        // TODO: именование не по RSDN

		/// <summary>
		/// Новая или редактируемая заметка, в зависимости от действия пользователя
		/// </summary>
		private Note note;

        // TODO: комментарий для свойства начинается с фразы "Возвращает или задает ...". Например, "Возвращает или задает название заметки."
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

		// TODO: комментарий для свойства начинается с фразы "Возвращает или задает ...". Например, "Возвращает или задает название заметки."
        // TODO: что за название? "Заметка безопасности"? Название должно отражать назначение
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
            // TODO: инициализация в поле/свойстве
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
            // TODO: var
			Color blackColor = Color.Black;
			Color redColor = Color.Red;

			SafetyNote = (Note)note.Clone();

            // TODO: дублируется проверка из свойства бизнес-логики
			if (NameTextBox.Text.Length < 50)
			{
				NameTextBox.ForeColor = blackColor;
				OKButton.Enabled = true;
				longNameWarningLabel.Text = "";
				longNameWarningLabel.ForeColor = NoteForm.DefaultBackColor;

			}

            // TODO: зачем дважды делается валидация?
			try
			{
				SafetyNote.Name = NameTextBox.Text;
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message);
				NameTextBox.ForeColor = redColor;
				OKButton.Enabled = false;
                // TODO: текст неточен. Что значит "напишите название короче"?
                // Насколько короче? Должна быть конкретика
				longNameWarningLabel.Text = "Write shorter note's name";
				longNameWarningLabel.ForeColor = redColor;
			}
		}
	}
}
