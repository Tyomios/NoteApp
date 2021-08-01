using System;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;


namespace NoteApp.UI
{
	public partial class AboutForm : Form
	{
		/// <summary>
		/// Открытие ссылки в браузере
		/// </summary>
		/// <param name="url">Ссылка</param>
		public void launchBrowser(string url)
		{
			string browserName = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe";
			using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice"))
			{
				if (userChoiceKey != null)
				{
					object progIdValue = userChoiceKey.GetValue("Progid");
					if (progIdValue != null)
					{
						if (progIdValue.ToString().ToLower().Contains("chrome"))
							browserName = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
						else if (progIdValue.ToString().ToLower().Contains("yandex"))
							browserName = "C:\\Program Files (x86)\\Yandex\\YandexBrowser\\Application\\browser.exe";
					}
				}
			}

			Process.Start(new ProcessStartInfo(browserName, url));
		}
		public AboutForm()
		{
			InitializeComponent();
			gitHabLinkLabel.LinkVisited = true;
			emailLinkLabel.LinkVisited = true;
		}

		private void gitHabLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				launchBrowser("https://github.com/Tyomios/NoteApp/");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to open link.");
			}
			
		}

		private void emailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("MailTo:tyomios@mail.ru");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to open mail.");
			}
		}
	}
}
