using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace NoteApp
{
    // TODO: в конце комментариев добавлять точку - это конец предложения.
	/// <summary>
	/// Класс отвечающий за загрузку\сохранение заметок 
	/// </summary>
	public static class ProjectManager
	{
		// TODO: xml
		// TODO: должна быть подпапка с названием программы. А лучше - "название компании\название программы\имя файла"
		// Просто так в AppData ложить файлы неправильно
        // TODO: именование не соответствует RSDN.
		private static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
		                             "\\" + "NoteAppData.txt";

		// TODO: xml-комментарий неверный для параметров
		// TODO: что за mode? Бизнес-логика ничего не должна знать о юнит-тестах!
		// TODO: в конце комментариев добавлять точку - это конец предложения.
		// Пути для тестовых данных должны приходить извне, а не храниться внутри бизнес-логики
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

		// TODO: не должно быть никакого mode
		// TODO: xml-комментарии к параметрам не соотвествуют
        // TODO: в конце комментариев добавлять точку - это конец предложения.
		/// <summary>
		/// Загрузка заметок
		/// </summary>
		/// <param name="filename"> Название файла </param>
		/// <returns>Проект с сохраненными ранее заметками</returns>
		public static Project LoadFromFile(string mode = "Release")
		{
            // TODO: бизнес-логика знает файлы ВСЕХ тестовых случаев. Это НЕПРАВИЛЬНО!
			JsonSerializer serializer = new JsonSerializer();
			var usedPath = defaultPath;
			if (mode == "TestData")
			{
				usedPath = @"TestData\TestData.txt";
			}
			if (mode == "DamagedData")
			{
				usedPath = @"TestData\damagedData.txt";
			}
			if (mode == "NoneData")
			{
				usedPath = @"TestData\noneData.txt";
			}
			if (mode == "TestLoadData")
			{
				usedPath = @"..\..\..\TestData\testData.txt";
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
