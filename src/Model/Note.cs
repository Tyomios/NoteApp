using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    // TODO: в конце комментариев добавлять точку - это конец предложения.
	/// <summary>
	/// Заметка
	/// </summary>
	public class Note : ICloneable
	{
        // TODO: в конце комментариев добавлять точку - это конец предложения.
		/// <summary>
		/// Название
		/// </summary>
		private string _name;

        // TODO: в конце комментариев добавлять точку - это конец предложения.
		///<summary>
		/// Категория
		/// </summary>
		private Category _category;

        // TODO: в конце комментариев добавлять точку - это конец предложения.
		/// <summary>
		/// Содержание
		/// </summary>
		private string _text;

        // TODO: в конце комментариев добавлять точку - это конец предложения.
		/// <summary>
		/// Время создания
		/// </summary>
		public DateTime СreationTime { get; set; }

        // TODO: в конце комментариев добавлять точку - это конец предложения.
		/// <summary>
		/// Время последнего изменения
		/// </summary>
		public DateTime LastEditTime { get; set; }

		// TODO: в конце комментариев добавлять точку - это конец предложения.
		// TODO: комментарии не должны содержать имен закрытых членов класса, надо объяснять назначение, а не механику работы.
        // TODO: комментарий для свойства начинается с фразы "Возвращает или задает ...". Например, "Возвращает или задает название заметки."
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

		// TODO: в конце комментариев добавлять точку - это конец предложения.
		// TODO: комментарии не должны содержать имен закрытых членов класса, надо объяснять назначение, а не механику работы.
        // TODO: комментарий для свойства начинается с фразы "Возвращает или задает ...". Например, "Возвращает или задает название заметки."
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

		// TODO: в конце комментариев добавлять точку - это конец предложения.
		// TODO: комментарии не должны содержать имен закрытых членов класса, надо объяснять назначение, а не механику работы.
        // TODO: комментарий для свойства начинается с фразы "Возвращает или задает ...". Например, "Возвращает или задает название заметки."
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

		// TODO: в конце комментариев добавлять точку - это конец предложения.
		// TODO: в комментарии синтаксическая ошибка, поэтому он не работает. Поправить
        // TODO: комментарий для конструктора формируется из фразы "Создает экземпляр <see cref="название класса">".
		/// <summary>
		//// Конструктор
		/// </summary>
		/// // TODO: что за пустая строка?
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

		// TODO: в конце комментариев добавлять точку - это конец предложения.
        // TODO: комментарий для конструктора формируется из фразы "Создает экземпляр <see cref="название класса">".
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

		// TODO: лучше использовать object вместо Object
		// TODO: в конце комментариев добавлять точку - это конец предложения.
        // TODO: это переопределенный стандартный метод. Нельзя отнаследовать документацию с помощью inheritdoc?
		/// <summary>
		/// Метод для клонирования заметки
		/// </summary>
		/// <returns>
		/// Заметку с теми же данными // TODO: returns оформляется в одну строку
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
