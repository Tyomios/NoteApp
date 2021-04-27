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
using static NoteAppUI.AddForm;

namespace NoteAppUI
{
	public partial class MainForm : Form
	{
		public Project project = new Project();

		public MainForm()
		{
			InitializeComponent();
			project.Notes = ProjectManager.LoadFromFile("NoteAppDataBase");
			if (project.Notes == null)
			{
				project.Notes = new List<Note>();
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			AddForm addForm = new AddForm();
			addForm.ShowDialog();
			project.Notes.Add(addForm.addNote);
			ProjectManager.SaveToFile(project.Notes, "NoteAppDataBase");
		}
	}
}
