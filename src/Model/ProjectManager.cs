using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace NoteApp
{
	/// <summary>
	/// Класс отвечающий за загрузку\сохранение заметок 
	/// </summary>
	public static class ProjectManager
	{
		private static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
		                             "\\" + "NoteAppData.txt";

		/// <summary>
		/// Сохранение заметок
		/// </summary>
		/// <param name="projectNotes"> Заметки </param>
		/// <param name="filename"> Название файла </param>
		public static void SaveToFile(Project projectNotes, string mode = "Release")
		{
			JsonSerializer serializer = new JsonSerializer();
			var usedPath = defaultPath;
			serializer.Formatting = Formatting.Indented;

			if (mode == "TestData")
			{
				usedPath = @"..\..\..\TestData\testData.txt";
			}

			using (StreamWriter streamWriter = new StreamWriter(usedPath))
			using (JsonWriter writer = new JsonTextWriter(streamWriter))
			{
				serializer.Serialize(writer, projectNotes);
			}
		}

		/// <summary>
		/// Загрузка заметок
		/// </summary>
		/// <param name="filename"> Название файла </param>
		/// <returns>Проект с сохраненными ранее заметками</returns>
		public static Project LoadFromFile(string mode = "Release")
		{
			JsonSerializer serializer = new JsonSerializer();
			var usedPath = defaultPath;
			if (mode == "TestData")
			{
				usedPath = @"..\..\..\TestData\TestData.txt";
			}
			if (mode == "DamagedData")
			{
				usedPath = @"..\..\..\TestData\damagedData.txt";
			}
			if (mode == "NoneData")
			{
				usedPath = @"..\..\..\TestData\noneData.txt";
			}

			if (!File.Exists(usedPath))
			{
				Project project = new Project();
				return project;
			}

			using (StreamReader streamReader = new StreamReader(usedPath))
				try
				{
					using (JsonReader reader = new JsonTextReader(streamReader))
					{
						Project project = (Project)serializer.Deserialize<Project>(reader);
						return project;
					}
				}
				catch (JsonException)
				{
					Project project = new Project();
					return project;
				}
		}
	}
}
