using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
	// TODO: xml
    // TODO: в конце комментариев добавлять точку - это конец предложения.+
	/// <summary>
	/// Класс проекта.
	/// </summary>
	public class Project
	{
        // TODO: в конце комментариев добавлять точку - это конец предложения.+
		/// <summary>
		/// Список заметок.
		/// </summary>
		public List<Note> Notes { get; set; } = new List<Note>();

		/// <summary>
		/// Метод, для заполнения списка заметками выбранной категории.
		/// </summary>
		/// <param name="category"> Категория </param>
		/// <returns> Список с заметками, выбранной категории </returns>
		public List<Note> FilterByCategory(Category category)
		{
			List<Note> categoryNotes = new List<Note>();
			for (int i = Notes.Count - 1; i >= 0; i--)
			{
				if (Notes[i].Category == category)
				{
					categoryNotes.Add(Notes[i]);
				}
			}

			return categoryNotes;
		}

		/// <summary>
		/// Разворачивает список с заметками.
		/// </summary>
		/// <returns> Список, в котором заметки имеют обратный индекс </returns>
		public List<Note> GetReverseNotesList()
		{
			List<Note> reverseNotesList = new List<Note>();
			for (int i = Notes.Count - 1; i >= 0; i--)
			{
				reverseNotesList.Add(Notes[i]);
			}

			return reverseNotesList;
		}

        // TODO: xml+
		/// <summary>
		/// Текущая выбранная пользователем заметка.
		/// </summary>
		public Note CurrentNote { get; set; }

	
	}
}
