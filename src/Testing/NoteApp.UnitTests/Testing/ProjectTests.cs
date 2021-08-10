using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
	[TestFixture]
	public class ProjectTests
	{
		public bool EqualToReversed(List<Note> reversedList, List<Note> Notes)
		{
			var index = 0;
			for (int i = Notes.Count - 1; i >= 0; i--)
			{
				if (!Notes[i].Equals(reversedList[index]))
				{
					return false;
				}

				++index;
			}

			return true;
		}

		[Test(Description = "Позитивный тест сеттера свойства Notes")]
		public void TestNoteList_CorrectValue()
		{
			//Setup
			Project project = new Project();
			project.Notes.Add(new Note("Имя", Category.Home, "Текст"));

			//Testing
			var expected = new List<Note>();
			expected.Add(project.Notes[0]);

			var actual = project;

			//Assert
			Assert.AreEqual(expected, actual.Notes,
				"Свойство Notes устанавливает или возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест конструктора класса Project, с проверкой на создание списка")]
		public void TestProjectConstructorWithEmptyList()
		{
			//Testing
			var actual = new Project();

			//Assert
			Assert.IsNotNull(actual, "Проект не создан");
			Assert.IsNotNull(actual.Notes, "Список заметок не создан");
			Assert.IsEmpty(actual.Notes, "Список не пуст");
		}

		[Test(Description = "Позитивный тест метода получения заметок по категории")]
		public void TestFilterByCategory()
		{
			//Setup
			Project project = new Project();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));

			//Testing
			var expected = 2;
			var notes = project.FilterByCategory(Category.Home);
			var actual = notes.Count;

			//Assert
			Assert.AreEqual(expected, actual, "Метод возвращает неправильный список");
		}

		[Test(Description = "Позитивный тест метода получения списка заметок с обратным порядком")]
		public void TestGetReverseNotesList()
		{
			//Setup
			Project project = new Project();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));
			var reversedList = project.GetReverseNotesList();

			//Assert
			Assert.AreEqual(EqualToReversed(reversedList, project.Notes), true);
		}
	}
}
