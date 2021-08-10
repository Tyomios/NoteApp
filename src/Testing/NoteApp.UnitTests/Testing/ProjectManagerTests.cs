using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
	[TestFixture]
	public class ProjectManagerTests
	{
		private static string _commonDataFolder = "TestData";

		[Test(Description = "Проверка сохранения проекта, когда файла не существует")]
		public void TestSave_NonExistedFile()
		{
			//Setup
			var nonExistedDataFilePath = "..\\..\\..\\TestData";
			var newSavedDataPath = $"{nonExistedDataFilePath}\\testData.txt";
			Directory.CreateDirectory(nonExistedDataFilePath);
			var project = new Project();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));
			var usedPath = $"{nonExistedDataFilePath}\\testData.txt";

			//Testing
			ProjectManager.SaveToFile(project, usedPath);

			var fileStatus = File.Exists(newSavedDataPath);
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
			var usedPath = $"{_commonDataFolder}\\testData.txt";

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
			var usedPath = $"{_commonDataFolder}\\noneData.txt";

			//Testing
			var project = ProjectManager.LoadFromFile(usedPath);

			//Assert
			Assert.IsNotNull(project, "Проект не создан");

			Assert.Multiple(() =>
				{
					Assert.IsNotNull(project.Notes);
					Assert.IsEmpty(project.Notes);
				}
				);
			
		}

		[Test(Description = "Проверка загрузки проекта из поврежденного файла")]
		public void TestLoadFile_DamagedData()
		{
			//Setup
			var usedPath = $"{_commonDataFolder}\\damagedData.txt";

			//Testing
			var project = ProjectManager.LoadFromFile(usedPath);

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