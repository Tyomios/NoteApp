using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
	/// <summary>
	/// Заметка
	/// </summary>
	public class Note : ICloneable
	{
		/// <summary>
		/// Название
		/// </summary>
		private string _name;

		///<summary>
		/// Категория
		/// </summary>
		private Category _category;

		/// <summary>
		/// Содержание
		/// </summary>
		private string _text;

		/// <summary>
		/// Время создания
		/// </summary>
		public DateTime СreationTime { get; set; }

		/// <summary>
		/// Время последнего изменения
		/// </summary>
		public DateTime LastEditTime { get; set; }

		/// <summary>
		/// Свойство поля _name
		/// </summary>
		public string Name
		{
			get
			{
				return this._name;
			}

			set
			{
				if (value.Length > 50)
				{
					throw new ArgumentException("Too long name");
				}

				this._name = value;
			}
		}

		/// <summary>
		/// Свойство поля _category
		/// </summary>
		public Category Category
		{
			get
			{
				return this._category;
			}

			set
			{
				this._category = value;
			}
		}

		/// <summary>
		/// Свойство поля _text
		/// </summary>
		public string Text
		{
			get
			{
				return this._text;
			}

			set
			{
				this._text = value;
			}
		}

		/// <summary>
		//// Конструктор
		/// </summary>
		/// 
		/// <param name="name"> Название </param>
		/// <param name="category"> Категория </param>
		/// <param name="text"> Содержание </param>
		public Note(string name, Category category, string text)
		{
			this.Name = name;
			this.Category = category;
			this.Text = text;
			this.СreationTime = DateTime.Now;
			this.LastEditTime = DateTime.Now;
		}

		/// <summary>
		/// Конструктор без параметров
		/// </summary>
		public Note()
		{
			Name = "";
			Category = Category.Documents;
			Text = "";
			this.СreationTime = DateTime.Now;
			this.LastEditTime = DateTime.Now;
		}

		/// <summary>
		/// Метод для клонирования заметки
		/// </summary>
		/// <returns>
		/// Заметку с теми же данными
		/// </returns>
		public Object Clone()
		{
			var note = new Note();
			note.Name = this.Name;
			note.Text = this.Text;
			note.Category = this.Category;
			note.СreationTime = this.СreationTime;
			note.LastEditTime = this.LastEditTime;
			return note;
		}
	}
}
