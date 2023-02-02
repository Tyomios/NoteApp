using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
	/// <summary>
	/// Заметка.
	/// </summary>
	public class Note : ICloneable
	{
		/// <summary>
		/// Название.
		/// </summary>
		private string _name;

		///<summary>
		/// Категория.
		/// </summary>
		private Category _category;

		/// <summary>
		/// Содержание.
		/// </summary>
		private string _text;

		/// <summary>
		/// Время создания.
		/// </summary>
		public DateTime CreationTime { get; set; }

		/// <summary>
		/// Время последнего изменения.
		/// </summary>
		public DateTime LastEditTime { get; set; }

		/// <summary>
		/// Возвращает или задает название заметки.
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
					throw new ArgumentException("Write note's name less, then 50 symbols");
				}

				this._name = value;
			}
		}

		/// <summary>
		/// Возвращает или задает категорию заметки.
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
		/// Возвращает или задает текст заметки.
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
		/// Создает экземпляр <see cref="Note">.
		/// </summary>
		/// <param name="name"> Название </param>
		/// <param name="category"> Категория </param>
		/// <param name="text"> Содержание </param>
		public Note(string name, Category category, string text)
		{
			this.Name = name;
			this.Category = category;
			this.Text = text;
			this.CreationTime = DateTime.Now;
			this.LastEditTime = DateTime.Now;
		}

		/// <summary>
		/// Создает экземпляр <see cref="Note">.
		/// </summary>
		public Note()
		{
			Name = "";
			Category = Category.Documents;
			Text = "";
			this.CreationTime = DateTime.Now;
			this.LastEditTime = DateTime.Now;
		}

		/// <inheritdoc cref="ICloneable"/>
		public object Clone()
		{
			var note = new Note();
			note.Name = this.Name;
			note.Text = this.Text;
			note.Category = this.Category;
			note.CreationTime = this.CreationTime;
			note.LastEditTime = this.LastEditTime;
			return note;
		}

		/// <summary>
		/// Сравнение двух заметок на индентичность.
		/// </summary>
		/// <param name="otherNote"> Сравниваемая заметка </param>
		/// <returns>
		/// retval true - заметки содержат одинаковые данные
		/// retval false - заметки имеют различные данные
		/// </returns>
		public bool Equals(Note otherNote)
		{
			if (Name == otherNote.Name
			    && Text == otherNote.Text
			    && Category == otherNote.Category
			    && CreationTime.Day == otherNote.CreationTime.Day
			   )
			{
				return true;
			}

			return false;
		}
	}
}
