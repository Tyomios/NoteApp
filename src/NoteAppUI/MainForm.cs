using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NoteApp;


// TODO: именование не соответствует названию проекта+
namespace NoteApp.UI
{
	public partial class MainForm : Form
	{
        // TODO: именование не по RSDN
		/// <summary>
		/// Обьект, хранящий список заметок
		/// </summary>
		public Project project = new Project();

        // TODO: модификаторы доступа надо прописывать явно+
		// TODO: именование не по RSDN
		/// <summary>
		/// Список заметок для выбранной категории заметок
		/// </summary>
		private List<Note> showedNotesByCategory = new List<Note>();

        // TODO: именование не по RSDN+
		/// <summary>
		/// Название элемента categoryComboBox
		/// </summary>
		private const string comboBoxCategoryAll = "All";

		// TODO: порядок членов класса
		/// <summary>
		/// Заполняет информационное окно данными заметки
		/// </summary>
		/// <param name="note"> Заметка </param>
		private void FillNoteInfoPanel(Note note)
		{
			noteNameLabel.Text = note.Name;
			noteTextRichBox.Text = note.Text;
			createTimeTextBox.Text = note.СreationTime.ToShortDateString();
			updateTimeTextBox.Text = note.LastEditTime.ToShortDateString();
            // TODO: чтобы каждый раз не добавлять этот текст перед категорией,
            // его можно вынести в отдельный лейбл
			noteCategoryLabel.Text = $"Category: {note.Category}";
		}

		// TODO: модификаторы доступа надо прописывать явно+
        // TODO: порядок членов класса
		/// <summary>
		/// служебный метод отчистки данных заметки в лейблах и боксах
		/// </summary>
		private void ClearNoteInfoPanel()
		{
			noteNameLabel.Text = "";
			noteTextRichBox.Text = "";
			createTimeTextBox.Text = "";
			updateTimeTextBox.Text = "";
			noteCategoryLabel.Text = "Category:";
		}

		// TODO: порядок членов класса
        /// <summary>
		/// Поиск индекса выбранной заметки в коллекции 
		/// </summary>
		/// <param name="notes"> Список заметок </param>
		/// <returns>
		/// Индекс заметки
		/// Возврат значения -1 в случае, если заметка не найдена
		/// </returns>
		private int SearchNoteIndex(List<Note> notes)
		{
            // TODO: у тебя и в проекте, и в showedNotes лежат одни и те же экземпляры заметок -
			// Зачем ты делаешь поиск по полям, когда можно сделать простой поиск/сравнение по ссылке
			// или даже сделать поиск linq-запросом?
			foreach (var note in notes)
			{
				if (note.Name == project.CurrentNote.Name
				    && note.СreationTime == project.CurrentNote.СreationTime
				    && note.Text == project.CurrentNote.Text)
				{
					return notes.IndexOf(note);
				}
			}

			return -1;
		}

        /// <summary>
		/// Фильтрация заметок в списке showedNotesByCategory по категории.
		/// </summary>
		/// <param name="category"> Категория </param>
		private void FilterNotesV2(Category category)
        {
	        listNoteListBox.Items.Clear();
			showedNotesByCategory.Clear();
			showedNotesByCategory = project.GetNotesWithCategory(category);

			if (showedNotesByCategory.Count == 0)
			{
				listNoteListBox.Items.Clear();
				ClearNoteInfoPanel();
				return;
			}

			int listIndex = 0;
			for (int i = 0; i < showedNotesByCategory.Count; i++)
			{
				listNoteListBox.Items.Insert(listIndex, showedNotesByCategory[listIndex].Name);
				++listIndex;
			}

			listNoteListBox.SelectedIndex = SearchNoteIndex(showedNotesByCategory);

			var selectedIndex = listNoteListBox.SelectedIndex;

			if (selectedIndex == -1)
			{
				selectedIndex = 0; //listNoteListBox.Items.Count - 1 для выбора последней заметки
			}
			FillNoteInfoPanel(showedNotesByCategory[selectedIndex]);
		}

		/// <summary>
		/// Конструктор главного окна
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			categoryComboBox.Items.Add(comboBoxCategoryAll);
			foreach (var category in Enum.GetValues(typeof(Category)))
			{
				categoryComboBox.Items.Add(category);
			}

			project = ProjectManager.LoadFromFile();
			categoryComboBox.SelectedItem = comboBoxCategoryAll;
			FilterNotesUsingFunc();
		}

		// TODO: модификаторы доступа надо прописывать явно+
		// TODO: порядок членов класса
		/// <summary>
		/// Проверка заметки на null, в случае если заметка null - удаляет ее
		/// </summary>
		/// <param name="notes"> Список заметок </param>
		private void RemoveLastNullNoteInList(List<Note> notes)
		{
			// TODO: именование метода. Почему метод проверки удаляет что-то из списка?+
			var lastNote = notes[notes.Count - 1];
			if (lastNote == null || lastNote.Name == "")
			{
				notes.Remove(lastNote);
			}
		}

		// TODO: порядок членов класса+
		// TODO: именование. Что за Action?+
		/// <summary>
		/// Создание заметки
		/// </summary>
		private void StartOperationAddNote()
		{
			NoteForm addForm = new NoteForm();
			var result = addForm.ShowDialog();

			if (result == DialogResult.Cancel)
			{
				return;
			}

			if (result == DialogResult.OK)
			{
				project.Notes.Add(addForm.Note);
				RemoveLastNullNoteInList(project.Notes);
				ProjectManager.SaveToFile(project);

				showedNotesByCategory.Add(addForm.Note);
			}

			FilterNotesUsingFunc();
			project.CurrentNote = showedNotesByCategory[0];
			FillNoteInfoPanel(project.CurrentNote);
			listNoteListBox.SelectedItem = project.CurrentNote;
			listNoteListBox.SelectedIndex = 0;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			StartOperationAddNote();
		}

		// TODO: порядок членов класса+
		/// <summary>
		/// Проверка на невыбранный элемент listBox
		/// </summary>
		/// <param name="index"> Индекс удаляемой заметки </param>
		/// <returns>
		/// retval true - индекс равен -1
		/// retval false - индекс не равен -1
		/// </returns>
		private bool IsNoteSelected(int index)
		{
			// TODO: метод вызывается всегда для листбокса. Может тогда определять индекс внутри метода и упростить вызов?
			if (index == -1)
			{
				MessageBox.Show("Select note", "Warning", MessageBoxButtons.OK);
				return true;
			}

			return false;
		}

		// TODO: порядок членов класса
		// TODO: именование. Что за Action?+
		/// <summary>
		/// Удаление заметки
		/// </summary>
		private void StartOperationDeleteNote()
		{
			if (IsNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}

			var deleteNote = showedNotesByCategory[listNoteListBox.SelectedIndex];
			DialogResult result = MessageBox.Show
				($"Delete note {deleteNote.Name} ?", "Warning", MessageBoxButtons.OKCancel);
			if (result == DialogResult.Cancel)
			{
				return;
			}

			project.Notes.Remove(project.Notes[project.Notes.IndexOf(deleteNote)]);
			ProjectManager.SaveToFile(project);
			showedNotesByCategory.Remove(deleteNote);

			FilterNotesUsingFunc();
			// TODO: что за костыль? Не должно быть пустых обработчиков!+
			try
			{
				listNoteListBox.SelectedIndex = 0;
			}
			catch (ArgumentOutOfRangeException e)
			{
				ClearNoteInfoPanel();
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			StartOperationDeleteNote();
		}

		// TODO: порядок членов класса+
		// TODO: именование. Что за Action?+
		/// <summary>
		/// Редактирование заметки
		/// </summary>
		private void StartOperationEditNote()
		{
			if (IsNoteSelected(listNoteListBox.SelectedIndex))
			{
				return;
			}

			var addForm = new NoteForm();

			Note newEditNote = (Note)showedNotesByCategory[listNoteListBox.SelectedIndex].Clone();
			addForm.Note = newEditNote;

			addForm.Text = "Edit Note";
			var result = addForm.ShowDialog();
			if (result == DialogResult.OK)
			{
				int index = project.Notes.IndexOf(showedNotesByCategory[listNoteListBox.SelectedIndex]);
				project.Notes.Add(addForm.Note);
				showedNotesByCategory.Remove(showedNotesByCategory[listNoteListBox.SelectedIndex]);
				showedNotesByCategory.Add(addForm.Note);


				project.Notes.Remove(project.Notes[index]);
				ProjectManager.SaveToFile(project);

				FilterNotesUsingFunc();
				project.CurrentNote = showedNotesByCategory[0];
				listNoteListBox.SelectedIndex = 0;
			}
		}


		/// <summary>
		/// Выбирает какой функцией фильтровать заметки, в зависимости от categoryComboBox.SelectedItem.
		/// </summary>
		private void FilterNotesUsingFunc()
		{
			if(categoryComboBox.SelectedItem.ToString() == comboBoxCategoryAll)
			{
				ShowAllNotes();
				return;
			}
			FilterNotesV2((Category)categoryComboBox.SelectedItem);
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			StartOperationEditNote();
		}

		private void listNoteBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// TODO: именование
            // TODO: var+
			var dataList = project.Notes;
            // TODO: Что это и нафига? Для отображения используются 2 списка с заметками, в разных случаях
            // На старте программа работает непосредственно с заметками project.Notes, после изменения категории
            // используется второй список, индексы одной и той же заметки в 2х коллекциях разный
            // чтобы selectedIndex не выдавал -1 при смене категории я устанавливаю 2 индекса на 2 сценария использования 
            // по 1 на каждый список
            int index = dataList.Count - listNoteListBox.SelectedIndex - 1;
			if (categoryComboBox.SelectedItem.ToString() != comboBoxCategoryAll)
			{
				project.GetNotesChoosenCategory(categoryComboBox.SelectedItem.ToString(), showedNotesByCategory);
				
				dataList = showedNotesByCategory;
				if (listNoteListBox.SelectedIndex != -1)
				{
					index = listNoteListBox.SelectedIndex;
				}
				else
				{
					index = 0;
				}	
				
			}

            // TODO: вместо громоздкого и долгого try-catch нельзя проверить индекс на существование и поменять на 0?
			try
			{
				var currentNote = dataList[index]; 
				FillNoteInfoPanel(currentNote);
				project.CurrentNote = currentNote;
			}
			catch (ArgumentOutOfRangeException exception)
			{
				index = 0;
				var currentNote = dataList[index];
				FillNoteInfoPanel(currentNote);
				project.CurrentNote = currentNote;
			}
		}

		private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var testCategory = categoryComboBox.SelectedItem;
			if(testCategory == comboBoxCategoryAll)
			{
				ShowAllNotes();
				return;
			}
			FilterNotesV2((Category)testCategory);
		}


		/// <summary>
		/// Отображение заметок для categoryComboBox.SelectedItem = All.
		/// </summary>
		private void ShowAllNotes()
		{
			listNoteListBox.Items.Clear();
			showedNotesByCategory.Clear();
			showedNotesByCategory = project.GetReverseNotesList();

			if (showedNotesByCategory.Count == 0)
			{
				listNoteListBox.Items.Clear();
				ClearNoteInfoPanel();
				return;
			}

			int listIndex = 0;
			for (int i = 0; i < showedNotesByCategory.Count; i++)
			{
				listNoteListBox.Items.Insert(listIndex, showedNotesByCategory[listIndex].Name);
				++listIndex;
			}

			listNoteListBox.SelectedIndex = SearchNoteIndex(showedNotesByCategory);

			var selectedIndex = listNoteListBox.SelectedIndex;

			if (selectedIndex == -1)
			{
				selectedIndex = 0; //listNoteListBox.Items.Count - 1 для выбора последней заметки
			}
			FillNoteInfoPanel(showedNotesByCategory[selectedIndex]);
		}

		private void AddNoteItem_Click(object sender, EventArgs e)
		{
			StartOperationAddNote();
		}

		private void EditNoteItem_Click(object sender, EventArgs e)
		{
			StartOperationEditNote();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void RemoveNoteItem_Click(object sender, EventArgs e)
		{
			StartOperationDeleteNote();
		}
	}
}