﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

// TODO: проект с юнит-тестами положить в решении и физически в подпапку Testing+
namespace NoteApp.UnitTests
{
    // TODO: именование. Класс именуется Tests в множественном числе, так как класс содержит много тестов.+
    // А методы именуются в единственном числе
	[TestFixture]
	public class NoteTests
	{
		[Test(Description = "Позитивный тест геттера Name")]
		public void TestNameGet_CurrentValue()
		{
			//Setup
			var expected = "Имя";
			var note = new Note();

			//Testing
			note.Name = expected;
			var actual = note.Name;

			//Assert
			Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
		}

		[Test(Description = "Негативный тест сеттера Name с присвоением значения больше 50 символов")]
		public void TestNameSet_Negative()
		{
			//Setup
			var wrongName = "Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя Имя ";
			var note = new Note();

			//Assert
			Assert.Throws<ArgumentException>(
				() => { note.Name = wrongName; }, "Должно сработать исключение на 50 символов");
		}

		[Test(Description = "Позитивный тест сеттера Category")]
		public void TestCategorySet_CurrentValue()
		{
			//Setup
			var expected = Category.Home;
			var note = new Note();

			//Testing
			note.Category = expected;
			var actual = note.Category;

			//Assert
			Assert.AreEqual(expected, actual, "Сеттер Category устанавливает неправильную категорию");
		}

		[Test(Description = "Позитивный тест геттера Category")]
		public void TestCategoryGet_CurrentValue()
		{
			//Setup
			var expected = Category.Home;
			var note = new Note();

			//Testing
			note.Category = expected;
			var actual = note.Category;

			//Assert
			Assert.AreEqual(expected, actual, "Геттер Category возвращает неправильную категорию");
		}

		[Test(Description = "Позитивный тест геттера Text")]
		public void TestTextGet_CurrentValue()
		{
			//Setup
			var note = new Note();

			//Testing
			var expected = "Текст заметки";
			note.Name = expected;
			var actual = note.Name;

			//Assert
			Assert.AreEqual(expected, actual, "Геттер Text возвращает неправильное имя");
		}

		[Test(Description = "Позитивный тест метода клонирования")]
		public void TestClone_CurrentValue()
		{
			//Setup
			var note = new Note("Name", Category.Home, "Text");

			//Testing
			Note cloneNote = (Note)note.Clone();

			//Assert
			Assert.AreEqual(note.Name, cloneNote.Name, "Метод клонирования устанавливает неправильное имя");
			Assert.AreEqual(note.Text, cloneNote.Text, "Метод клонирования устанавливает неправильный текст");
			Assert.AreEqual(note.Category, cloneNote.Category, 
				"Метод клонирования устанавливает неправильную категорию");
			Assert.AreEqual(note.СreationTime, cloneNote.СreationTime, 
				"Метод клонирования устанавливает неправильное время создания");
			Assert.AreEqual(note.LastEditTime, cloneNote.LastEditTime,
				"Метод клонирования устанавливает неправильное время последнего редактирования");
		}

		[Test(Description = "Позитивный тест метода получения заметок по категории All")]
		public void TestGetNotesChoosenCategory_AllCategory()
		{
			//Setup
			Project project = new Project();
			var notes = new List<Note>();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));

			//Testing
			var expected = 3;
			project.GetNotesChoosenCategory("All", notes);
			var actual = notes.Count;

			//Assert
			Assert.AreEqual(expected, actual, "Метод возвращает неправильный список");
		}

		[Test(Description = "Позитивный тест метода получения заметок по категории All")]
		public void TestGetNotesChoosenCategory()
		{
			//Setup
			Project project = new Project();
			var notes = new List<Note>();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));
			project.Notes.Add(new Note("Name", Category.Home, "Text"));

			//Testing
			var expected = 2;
			project.GetNotesChoosenCategory("Home", notes);
			var actual = notes.Count;

			//Assert
			Assert.AreEqual(expected, actual, "Метод возвращает неправильный список");
		}
	}
}