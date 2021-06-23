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

		public List<Note> GetNotesWithChoosenCategory(Category category)
		{
			List<Note> notesWithChoosenCategory = new List<Note>();

			for (int i = 0; i < Notes.Count; i++)
			{
				if (Notes[i].Category == category || category == Category.All)
				{
					notesWithChoosenCategory.Add(Notes[i]);
					
				}
			}

			return notesWithChoosenCategory;
		}
}
}
