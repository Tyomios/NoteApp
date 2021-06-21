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
		/// <summary>
		/// Сохранение заметок
		/// </summary>
		/// <param name="projectNotes"> Заметки </param>
		/// <param name="filename"> Название файла </param>
		public static void SaveToFile(Project projectNotes, string filename)
		{
			JsonSerializer serializer = new JsonSerializer();
			serializer.Formatting = Formatting.Indented;

			using (StreamWriter streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
																						"\\" + filename + ".txt"))
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
		public static Project LoadFromFile(string filename)
		{
			JsonSerializer serializer = new JsonSerializer();

			if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
			                 "\\" + filename + ".txt"))
			{
				Project project = new Project();
				return project;
			}

			using (StreamReader streamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + 
																					 "\\" + filename + ".txt"))
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
