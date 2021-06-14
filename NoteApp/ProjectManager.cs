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
		/// <param name="listNote"> Заметки </param>
		/// <param name="filename"> Название файла </param>
		public static void SaveToFile(List<Note> listNote, string filename)
		{
			JsonSerializer serializer = new JsonSerializer();

			using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\Artem\source\repos\NoteAppDataBase\" + filename + ".txt"))
			using (JsonWriter writer = new JsonTextWriter(streamWriter))
			{
				serializer.Serialize(writer, listNote);
			}
		}

		/// <summary>
		/// Загрузка заметок
		/// </summary>
		/// <param name="filename"> Название файла </param>
		/// <returns></returns>
		public static List<Note> LoadFromFile(string filename)
		{
			JsonSerializer serializer = new JsonSerializer();

			using (StreamReader streamReader = new StreamReader(@"C:\Users\Artem\source\repos\NoteAppDataBase\" + filename + ".txt"))
			using (JsonReader reader = new JsonTextReader(streamReader))
			{
				List<Note> note = (List<Note>)serializer.Deserialize<List<Note>>(reader);
				return note;
			}
		}
	}
}
