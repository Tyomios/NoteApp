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
	public class Note
	{
		/// <summary> Название </summary>
		private string _name;

		///<summary> Категория </summary>
		private Category _category;

		/// <summary> Содержание </summary>
		private string _text;

		/// <summary> Время создания </summary>
		private DateTime _creationTime { get;  }

		/// <summary> Время последнего изменения </summary>
		private DateTime _lastEditTime;

		public string Name
		{
			get { return this._name; }

			set
			{
				if (value.Length > 50)
				{
					throw new Exception("Too long name");
				}
				this._name = value;
			}
		}

		public Category Category
		{
			get { return this._category; }

			set { this._category = value; }
		}

		public string Text
		{
			get { return this._text; }

			set { this._text = value; }
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
			this._creationTime = DateTime.Now;
			this._lastEditTime = DateTime.Now;
		}

		///// <summary>
		///// Конструктор без параметров
		///// </summary>
		//public Note()
		//{
		//	this.Name = "Без названия";
		//	this.Category = Category.Other;
		//	this.Text = "";
		//	this._creationTime = DateTime.Now;
		//	this._lastEditTime = DateTime.Now;
		//}
	}
}
