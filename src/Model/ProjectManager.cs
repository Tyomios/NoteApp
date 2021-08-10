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
	/// Класс отвечающий за загрузку\сохранение заметок. 
	/// </summary>
	public static class ProjectManager
	{
		// TODO: именование не соответствует RSDN.
		public static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
		                             "\\NoteApp\\" + "NoteAppData.txt";

		/// <summary>
		/// Создает каталог для хранения заметок, в случае его отсутствия.
		/// </summary>
		private static void CreateAppFolder()
		{
			var appFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
			                    "\\NoteApp";

			if (!Directory.Exists(appFolderPath))
			{
				Directory.CreateDirectory(appFolderPath);
			}
		}

		// Пути для тестовых данных должны приходить извне, а не храниться внутри бизнес-логики+
		/// <summary>
		/// Сохранение заметок.
		/// </summary>
		/// <param name="projectNotes"> Заметки </param>
		/// <param name="filePath"> Путь к файлу </param>
		public static void SaveToFile(Project projectNotes, string filePath)
		{
			JsonSerializer serializer = new JsonSerializer();
			var usedPath = defaultPath;
			serializer.Formatting = Formatting.Indented;

			CreateAppFolder();
			using (StreamWriter streamWriter = new StreamWriter(usedPath))
			using (JsonWriter writer = new JsonTextWriter(streamWriter))
			{
				serializer.Serialize(writer, projectNotes);
			}
		}

		/// <summary>
		/// Загрузка заметок.
		/// </summary>
		/// <param name="filePath"> Путь к файлу </param>
		/// <returns>Проект с сохраненными ранее заметками</returns>
		public static Project LoadFromFile(string filePath)
		{
			JsonSerializer serializer = new JsonSerializer();

			if (!File.Exists(filePath))
			{
				Project project = new Project();
				return project;
			}

			using (StreamReader streamReader = new StreamReader(filePath)) 
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
