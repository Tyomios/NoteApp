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
		private string currentDataFilePath = @"..\..\..\TestData\TestData.txt";

		private string damagedDataFilePath = @"..\..\..\TestData\damagedData.txt";
		private void DeleteTestDataFile()
		{
			if (File.Exists(currentDataFilePath))
			{
				File.Delete(currentDataFilePath);
			}
		}

		[Test(Description = "Проверка сохранения проекта, когда файла не существует")]
		public void TestSaveNoneFile()
		{
			Directory.CreateDirectory(@"..\..\\..\TestData");
			DeleteTestDataFile();

			var project = new Project();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));

			ProjectManager.SaveToFile(project, "TestData");

			var fileStatus = File.Exists(currentDataFilePath);
			var expected = true;
			Assert.AreEqual(fileStatus, expected, "Файл не создан");
		}

		[Test(Description = "Проверка загрузки проекта из целого файла")]
		public void TestLoadFile_CurrentData()
		{
			var project = ProjectManager.LoadFromFile("TestData");

			Assert.IsNotNull(project.Notes[0], "Проект не загружен");
		}

		[Test(Description = "Проверка загрузки проекта из целого файла")]
		public void TestLoadFile_DamagedData()
		{
			File.WriteAllText(damagedDataFilePath, "Wrong data");
			
			var project = ProjectManager.LoadFromFile("DamagedData");
			
			Assert.IsEmpty(project.Notes, "Исключение загрузки из поврежденного файла не обрабатывается");
		}
	}
}