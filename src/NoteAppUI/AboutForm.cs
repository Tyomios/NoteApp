using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NoteAppUI
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void gitHabLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				gitHabLinkLabel.LinkVisited = true;
				System.Diagnostics.Process.Start
					("https://github.com/Tyomios/NoteApp/");

			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to open link that was clicked.");
			}

		}

		private void emailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				emailLinkLabel.LinkVisited = true;
				System.Diagnostics.Process.Start("tyomios@mail.ru");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to open link that was clicked.");
			}
		}
	}
}
