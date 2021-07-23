using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
	public class Project
	{
		/// <summary>
		/// Список заметок 
		/// </summary>
		public List<Note> Notes { get; set; } = new List<Note>();

		/// <summary>
		/// Метод, для заполнения списка заметками выбранной категории
		/// </summary>
		/// <param name="category">Категория</param>
		/// <param name="categoryNotes">Список, в который заносятся заметки</param>
		public void GetNotesChoosenCategory(string category, List<Note> categoryNotes)
		{
			for (int i = 0; i < Notes.Count; i++)
			{
				if (Notes[i].Category.ToString() == category || category == "All")
				{
					categoryNotes.Add(Notes[i]);
				}
			}
		}

		public Note CurrentNote { get; set; }
	}
}
