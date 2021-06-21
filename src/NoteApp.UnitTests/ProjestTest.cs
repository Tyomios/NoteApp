using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
	[TestFixture]
	public class ProjestTest
	{
		[Test(Description = "Позитивный тест сеттера свойства Notes")]
		public void TestNoteList_CorrectValue()
		{
			Project project = new Project();
			project.Notes.Add(new Note("Имя", Category.Home, "Текст"));

			var expected = new List<Note>();
			expected.Add(project.Notes[0]);

			var actual = project;

			Assert.AreEqual(expected, actual.Notes,
				"Свойство Notes устанавливает или возвращает неправильное название");
		}
	}
}
