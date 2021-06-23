using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
	[TestFixture]
	public class NoteTest
	{
		[Test(Description = "Позитивный тест геттера Name")]
		public void TestNameGet_CurrentValue()
		{
			var expected = "Имя";
			var note = new Note();
			note.Name = expected;
			var actual = note.Name;

			Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
		}

		[Test(Description = "Негативный тест сеттера Name с присвоением значения больше 50 символов")]
		public void TestNameSet_Negative()
		{
			var wrongName = "Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя ";
			var note = new Note();

			Assert.Throws<ArgumentException>(
				() => { note.Name = wrongName; }, "Должно сработать исключение на 50 символов");
		}

		[Test(Description = "Позитивный тест сеттера Category")]
		public void TestCategorySet_CurrentValue()
		{
			var expected = Category.Home;
			var note = new Note();
			note.Category = expected;
			var actual = note.Category;

			Assert.AreEqual(expected, actual, "Сеттер Category устанавливает неправильную категорию");
		}

		[Test(Description = "Тест сеттера Category на запрет установки категории All")]
		public void TestCategorySet_WrongValue()
		{
			var wrongCategory = Category.All;
			var note = new Note();

			Assert.Throws<ArgumentException>(
				() => { note.Category = wrongCategory; }, "Должно сработать исключение на установку категории All");
		}

		[Test(Description = "Позитивный тест геттера Category")]
		public void TestCategoryGet_CurrentValue()
		{
			var expected = Category.Home;
			var note = new Note();
			note.Category = expected;
			var actual = note.Category;

			Assert.AreEqual(expected, actual, "Геттер Category возвращает неправильную категорию");
		}

		[Test(Description = "Позитивный тест геттера Text")]
		public void TestTextGet_CurrentValue()
		{
			var expected = "Текст заметки";
			var note = new Note();
			note.Name = expected;
			var actual = note.Name;

			Assert.AreEqual(expected, actual, "Геттер Text возвращает неправильное имя");
		}

		[Test(Description = "Позитивный тест метода клонирования")]
		public void TestClone_CurrentValue()
		{
			var note = new Note("Name", Category.Home, "Text");
			Note cloneNote = (Note)note.Clone();

			Assert.AreEqual(note.Name, cloneNote.Name, "Метод клонирования устанавливает неправильное имя");
			Assert.AreEqual(note.Text, cloneNote.Text, "Метод клонирования устанавливает неправильный текст");
			Assert.AreEqual(note.Category, cloneNote.Category, 
				"Метод клонирования устанавливает неправильную категорию");
			Assert.AreEqual(note.СreationTime, cloneNote.СreationTime, 
				"Метод клонирования устанавливает неправильное время создания");
			Assert.AreEqual(note.LastEditTime, cloneNote.LastEditTime,
				"Метод клонирования устанавливает неправильное время последнего редактирования");
		}
	}
}
