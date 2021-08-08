﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    // TODO: именование. Класс именуется Tests в множественном числе, так как класс содержит много тестов.+
    // А методы именуются в единственном числе
	[TestFixture]
	public class ProjectManagerTests
	{
        // TODO: почему всё равно поднимаешься на три папки выше? 
        // Нужно работать с файлами в папке компиляции, а не из папки с исходным кодом!
		// TODO: именование не по RSDN
		private static string _commonDataFilePath = "..\\..\\..\\";

		// TODO: именование не по RSDN
		// TODO: грамошибка в названии - почему не пользуешь Spell Checker?
        // TODO: почему не добавить папку TestData в переменную выше, чтобы не прописывать здесь и ниже?
		private string _currentDataFilename = $"{_commonDataFilePath}TestData\\TestData.txt";

        // TODO: именование не по RSDN
		private string _damagedDataFilename = $"{_commonDataFilePath}TestData\\damagedData.txt";


        // TODO: NonExistedFile - лишняя 'e', не хватает окончания 'ed'+
		[Test(Description = "Проверка сохранения проекта, когда файла не существует")]
		public void TestSave_NonExistedFile()
		{
			//Setup
            // TODO: почему не используешь готовую статическую переменную с путем?
			Directory.CreateDirectory(@"..\..\..\TestData");
			var project = new Project();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));
			var usedPath = @"..\..\..\TestData\testData.txt";

			//Testing
			ProjectManager.SaveToFile(project, usedPath);

			var fileStatus = File.Exists(_currentDataFilename);
			var expected = true;
			var actualLoadProject = ProjectManager.LoadFromFile(usedPath);

			//Assert
			Assert.Multiple(() =>
			{
				Assert.AreEqual(fileStatus, expected, "Файл не создан");
				Assert.AreEqual
					(project.Notes.Count, actualLoadProject.Notes.Count);
			});

			var expectedNote = project.Notes[0];
			var actualNote = actualLoadProject.Notes[0];

			Assert.AreEqual(expectedNote.Equals(actualNote), true);
		}

		[Test(Description = "Проверка загрузки проекта из целого файла")]
		public void TestLoadFile_CorrectData()
		{
			//Setup
			var expectedNoteName = "Name";
			var expectedNoteText = "Text";
			var expectedNoteCategory = Category.Documents;
			var expectedNote = new Note(expectedNoteName, expectedNoteCategory, expectedNoteText);
			var usedPath = @"TestData\TestData.txt";

			//Testing
			var project = ProjectManager.LoadFromFile(usedPath);
			var actualNote = project.Notes[0];

			//Assert
			Assert.IsNotNull(project.Notes[0]);
			Assert.AreEqual(actualNote.Equals(expectedNote), true);
		}

		[Test(Description = "Проверка загрузки проекта из несуществующего файла")]
		public void TestLoadNoneFile()
		{
			//Setup
			var usedPath = @"TestData\noneData.txt";

			//Testing
			var project = ProjectManager.LoadFromFile(usedPath);

			//Assert
			Assert.IsNotNull(project, "Проект не создан");

            // TODO: почему здесь Multiply, а ниже в тесте нет?+
			Assert.Multiple(() =>
				{
                    // TODO: AssertMessage писать не нужно. Суть теста должна быть понятна из именования метода или тест-кейса+
					Assert.IsNotNull(project.Notes);
					Assert.IsEmpty(project.Notes);
				}
				);
			
		}

		[Test(Description = "Проверка загрузки проекта из поврежденного файла")]
		public void TestLoadFile_DamagedData()
		{
			//Setup
			var usedPath = @"TestData\damagedData.txt";

			//Testing
			var project = ProjectManager.LoadFromFile(usedPath);

			// TODO: AssertMessage писать не нужно. Суть теста должна быть понятна из именования метода или тест-кейса+
			// TODO: порядок обращения не совпадает с порядком выше - почему?+
			//Assert
			Assert.Multiple(() =>
				{
					Assert.IsNotNull(project.Notes);
					Assert.IsEmpty(project.Notes);
				}
			);
		}
	}
}