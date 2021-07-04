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
	public class ProjectManagerTest
	{
		private static string commonDataFilePath = "..\\..\\..\\";
		
		private string currentDataFilname = $"{commonDataFilePath}TestData\\TestData.txt";

		private string damagedDataFilename = $"{commonDataFilePath}TestData\\damagedData.txt";


		[Test(Description = "Проверка сохранения проекта, когда файла не существует")]
		public void TestSave_NoneExistFile()
		{
			//Setup
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
					Assert.AreEqual(project.Notes[0].Name, expectedNoteName);
					Assert.AreEqual(project.Notes[0].Text, expectedNoteText);
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

			Assert.Multiple(() =>
				{
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
			
			//Assert
			Assert.IsEmpty(project.Notes, "Исключение загрузки из поврежденного файла не обрабатывается");
			Assert.IsNotNull(project.Notes, "Список null");
		}
	}
}