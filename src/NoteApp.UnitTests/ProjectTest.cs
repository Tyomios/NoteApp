using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
	[TestFixture]
	public class ProjectTest
	{
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

		[Test(Description = "Позитивный тест фильтра заметок по выбранной категории")]
		public void Test_GetNotesWithChoosenCategory()
		{
			//Setup
			var project = new Project();
			project.Notes.Add(new Note("s", Category.Documents, "22"));
			project.Notes.Add(new Note("s3", Category.Home, "42"));
			project.Notes.Add(new Note("s34", Category.Documents, "0022"));

			var expected = new List<Note>();
			expected.Add(project.Notes[0]);
			expected.Add(project.Notes[2]);

			//Testing
			var actual = new List<Note>();
			project.GetNotesChoosenCategory(Category.Documents.ToString(), actual);

			//Assert
			Assert.AreEqual(expected, actual, "Списки не равны");
		}
	}
}
