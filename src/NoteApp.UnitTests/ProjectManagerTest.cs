using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    // TODO: именование. Класс именуется Tests в множественном числе, так как класс содержит много тестов.
    // А методы именуются в единственном числе
	[TestFixture]
	public class ProjectManagerTest
	{
        // TODO: почему всё равно поднимаешься на три папки выше?
        // Нужно работать с файлами в папке компиляции, а не из папки с исходным кодом!
		// TODO: именование не по RSDN
		private static string commonDataFilePath = "..\\..\\..\\";

		// TODO: именование не по RSDN
		// TODO: грамошибка в названии - почему не пользуешь Spell Checker?
        // TODO: почему не добавить папку TestData в переменную выше, чтобы не прописывать здесь и ниже?
		private string currentDataFilname = $"{commonDataFilePath}TestData\\TestData.txt";

        // TODO: именование не по RSDN
		private string damagedDataFilename = $"{commonDataFilePath}TestData\\damagedData.txt";


        // TODO: NonExistedFile - лишняя 'e', не хватает окончания 'ed'
		[Test(Description = "Проверка сохранения проекта, когда файла не существует")]
		public void TestSave_NoneExistFile()
		{
			//Setup
            // TODO: почему не используешь готовую статическую переменную с путем?
			Directory.CreateDirectory(@"..\..\..\TestData");
			var project = new Project();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));

			//Testing
			ProjectManager.SaveToFile(project, "TestData");

			var fileStatus = File.Exists(currentDataFilname);
			var expected = true;
			var actualLoadProject = ProjectManager.LoadFromFile("TestLoadData");

			//Assert
			Assert.AreEqual(fileStatus, expected, "Файл не создан");

			Assert.Multiple(() =>
			{
				// TODO: вместо кучи Assert надо перегрузить Equals у класса Note
                // TODO: вынести обе заметки в переменные,
                // чтобы каждый раз не надо было обращаться к проектам/спискам и индексам.
				// Учись писать код лаконичнее
				Assert.AreEqual
					(project.Notes.Count, actualLoadProject.Notes.Count);
				Assert.AreEqual
					(project.Notes[0].Name, actualLoadProject.Notes[0].Name);
				Assert.AreEqual
					(project.Notes[0].Text, actualLoadProject.Notes[0].Text);
				Assert.AreEqual
					(project.Notes[0].Category, actualLoadProject.Notes[0].Category);
				Assert.AreEqual
					(project.Notes[0].СreationTime, actualLoadProject.Notes[0].СreationTime);
				Assert.AreEqual
					(project.Notes[0].LastEditTime, actualLoadProject.Notes[0].LastEditTime);
			});
			
		}

		[Test(Description = "Проверка загрузки проекта из целого файла")]
		public void TestLoadFile_CorrectData()
		{
			//Setup
			var expectedNoteName = "Name";
			var expectedNoteText = "Text";
			var expectedNoteCategory = 4;
			var expectedNoteCreateTime = DateTime.Now.Day.ToString();
			var expectedNoteLastEditTime = DateTime.Now.Day.ToString();

			//Testing
			var project = ProjectManager.LoadFromFile("TestData");

			//Assert
			Assert.IsNotNull(project.Notes[0]);

			Assert.Multiple(() =>
				{
                    // TODO: вместо кучи Assert надо перегрузить Equals у класса Note
					Assert.AreEqual(project.Notes[0].Name, expectedNoteName);
					Assert.AreEqual(project.Notes[0].Text, expectedNoteText);
                    // TODO: зачем преобразование в int? Перечисления сравниваются и без преобразования
					Assert.AreEqual((int)project.Notes[0].Category, expectedNoteCategory);
					Assert.AreEqual(project.Notes[0].СreationTime.Day.ToString(), expectedNoteCreateTime);
					Assert.AreEqual(project.Notes[0].LastEditTime.Day.ToString(), expectedNoteLastEditTime);
				}
				);
			
		}

		[Test(Description = "Проверка загрузки проекта из несуществующего файла")]
		public void TestLoadNoneFile()
		{
			//Testing
			var project = ProjectManager.LoadFromFile("NoneData");

			//Assert
			Assert.IsNotNull(project, "Проект не создан");

            // TODO: почему здесь Multiply, а ниже в тесте нет?
			Assert.Multiple(() =>
				{
                    // TODO: AssertMessage писать не нужно. Суть теста должна быть понятна из именования метода или тест-кейса
					Assert.IsNotNull(project.Notes, "Список null");
					Assert.IsEmpty(project.Notes, "Список не пустой");
				}
				);
			
		}

		[Test(Description = "Проверка загрузки проекта из поврежденного файла")]
		public void TestLoadFile_DamagedData()
		{
			//Testing
			var project = ProjectManager.LoadFromFile("DamagedData");

			// TODO: AssertMessage писать не нужно. Суть теста должна быть понятна из именования метода или тест-кейса
            // TODO: порядок обращения не совпадает с порядком выше - почему?
			//Assert
			Assert.IsEmpty(project.Notes, "Исключение загрузки из поврежденного файла не обрабатывается");
			Assert.IsNotNull(project.Notes, "Список null");
		}
	}
}