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

		// TODO: в конце комментариев добавлять точку - это конец предложения.
		// TODO: метод должен возвращать новый список, а не обновлять входной.
		// Иначе это процедурное программирование
		// TODO: название метода FilterByCategory
        // TODO: метод должен принимать экземпляр перечисления, а не строку
		/// <summary>
		/// Метод, для заполнения списка заметками выбранной категории.
		/// </summary>
		/// <param name="category">Категория</param>
		/// <param name="categoryNotes">Список, в который заносятся заметки</param>
		public void GetNotesChoosenCategory(string category, List<Note> categoryNotes)
		{
			categoryNotes.Clear();
			for (int i = Notes.Count - 1; i >= 0; i--)
			{
				if (Notes[i].Category.ToString() == category || category == "All")
				{
					categoryNotes.Add(Notes[i]);
				}
			}
		}

		public List<Note> GetNotesWithCategory(Category category)
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
