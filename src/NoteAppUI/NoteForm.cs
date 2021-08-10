﻿using System;
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
		//TODO: название поля не совпадает с именем свойства. +
		//TODO: по комментарию это новая ИЛИ редактируемая заметка, а по названию поля - это ТОЛЬКО новая заметка. То есть именование не отражает полного назначения поля.
        /// <summary>
		/// Новая или редактируемая заметка, в зависимости от действия пользователя.
		/// </summary>
		private Note _newOrEditNote;

		/// <summary>
		/// Возвращает заметку или задает данные для заметки. В последнем случае полученные данные используются для заполнения формы.
		/// </summary>
		public Note Note
		{
			get => _newOrEditNote;
			set
			{
				if(_newOrEditNote == null)
				{
					_newOrEditNote = new Note();
					return;
				}

				_newOrEditNote = value;
				SetDataFields();
			}
		}

        // TODO: что за название? "Заметка безопасности"? Название должно отражать назначение+
		// UPD: NoteForValidation?
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
			NameTextBox.MaxLength = 49;
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
			_newOrEditNote.Name = NoteForValidation.Name;
			_newOrEditNote.Category = category;
			_newOrEditNote.Text = NoteTextRichTextBox.Text;
			_newOrEditNote.LastEditTime = DateTime.Now;
			_newOrEditNote.CreationTime = Note.CreationTime;

			_newOrEditNote = new Note(NoteForValidation.Name, category, NoteTextRichTextBox.Text);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void NameTextBox_TextChanged(object sender, EventArgs e)
		{
			var blackColor = Color.Black;
			var redColor = Color.Red;

			NoteForValidation = (Note)_newOrEditNote.Clone();

			// TODO: и всё равно двойная проверка... НЕПРАВИЛЬНО в интерфейсе дублировать проверки из бизнес-логики,
			// если можно использовать проверку из бизнес-логики!
			if (NameTextBox.Text.Length < 50)
			{
				NameTextBox.ForeColor = blackColor;
				OKButton.Enabled = true;
				longNameWarningLabel.Text = "";
				longNameWarningLabel.ForeColor = NoteForm.DefaultBackColor;
			}

			try
			{
				NoteForValidation.Name = NameTextBox.Text;
			}
			catch (ArgumentException exception)
			{
				//MessageBox.Show(exception.Message);
				NameTextBox.ForeColor = redColor;
				OKButton.Enabled = false;
				//TODO: надо брать текст из сообщения исключения. Исключение же может вылететь не только на длину строки+
				longNameWarningLabel.Text = exception.Message;
				longNameWarningLabel.ForeColor = redColor;
			}
		}
	}
}
