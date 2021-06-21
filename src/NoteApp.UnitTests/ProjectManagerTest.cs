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
		[Test(Description = "Проверка загрузки проекта из целого файла")]
		public void TestLoadFile()
		{
			var project = ProjectManager.LoadFromFile("TestData");

			Assert.IsNotNull(project.Notes[0], "Проект не загружен");
		}

		[Test(Description = "Проверка сохранения проекта, когда файла не существует")]
		public void TestSaveNunFile()
		{
			var project = new Project();
			project.Notes.Add(new Note("Name", Category.Documents, "Text"));

			ProjectManager.SaveToFile(project, "TestData");

			var fileStatus = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
			                             "\\" + "TestData.txt");
			var expected = true;
			Assert.AreEqual(fileStatus, expected, "Файл не создан");
		}
	}
}