
namespace NoteAppUI
{
	partial class AboutForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.aboutNameLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.authorLabel = new System.Windows.Forms.Label();
			this.yearLabel = new System.Windows.Forms.Label();
			this.emailLabel = new System.Windows.Forms.Label();
			this.GitHubLabel = new System.Windows.Forms.Label();
			this.emailLinkLabel = new System.Windows.Forms.LinkLabel();
			this.gitHabLinkLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// aboutNameLabel
			// 
			this.aboutNameLabel.AutoSize = true;
			this.aboutNameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.aboutNameLabel.Location = new System.Drawing.Point(44, 47);
			this.aboutNameLabel.Name = "aboutNameLabel";
			this.aboutNameLabel.Size = new System.Drawing.Size(117, 32);
			this.aboutNameLabel.TabIndex = 0;
			this.aboutNameLabel.Text = "NoteApp";
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point(117, 78);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(43, 15);
			this.versionLabel.TabIndex = 1;
			this.versionLabel.Text = "v. 1.0.0";
			// 
			// authorLabel
			// 
			this.authorLabel.AutoSize = true;
			this.authorLabel.Location = new System.Drawing.Point(44, 127);
			this.authorLabel.Name = "authorLabel";
			this.authorLabel.Size = new System.Drawing.Size(149, 15);
			this.authorLabel.TabIndex = 2;
			this.authorLabel.Text = "Author: Slesarenko Artyom";
			// 
			// yearLabel
			// 
			this.yearLabel.AutoSize = true;
			this.yearLabel.Location = new System.Drawing.Point(44, 256);
			this.yearLabel.Name = "yearLabel";
			this.yearLabel.Size = new System.Drawing.Size(144, 15);
			this.yearLabel.TabIndex = 3;
			this.yearLabel.Text = "2021 Slesarenko Artyom©";
			// 
			// emailLabel
			// 
			this.emailLabel.AutoSize = true;
			this.emailLabel.Location = new System.Drawing.Point(44, 158);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(113, 15);
			this.emailLabel.TabIndex = 4;
			this.emailLabel.Text = "e-mail for feedback:";
			// 
			// GitHubLabel
			// 
			this.GitHubLabel.AutoSize = true;
			this.GitHubLabel.Location = new System.Drawing.Point(44, 194);
			this.GitHubLabel.Name = "GitHubLabel";
			this.GitHubLabel.Size = new System.Drawing.Size(48, 15);
			this.GitHubLabel.TabIndex = 5;
			this.GitHubLabel.Text = "GitHub:";
			// 
			// emailLinkLabel
			// 
			this.emailLinkLabel.AutoSize = true;
			this.emailLinkLabel.Location = new System.Drawing.Point(166, 158);
			this.emailLinkLabel.Name = "emailLinkLabel";
			this.emailLinkLabel.Size = new System.Drawing.Size(98, 15);
			this.emailLinkLabel.TabIndex = 6;
			this.emailLinkLabel.TabStop = true;
			this.emailLinkLabel.Text = "tyomios@mail.ru";
			this.emailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.emailLinkLabel_LinkClicked);
			// 
			// gitHabLinkLabel
			// 
			this.gitHabLinkLabel.AutoSize = true;
			this.gitHabLinkLabel.LinkVisited = true;
			this.gitHabLinkLabel.Location = new System.Drawing.Point(97, 194);
			this.gitHabLinkLabel.Name = "gitHabLinkLabel";
			this.gitHabLinkLabel.Size = new System.Drawing.Size(211, 15);
			this.gitHabLinkLabel.TabIndex = 7;
			this.gitHabLinkLabel.TabStop = true;
			this.gitHabLinkLabel.Text = "https://github.com/Tyomios/NoteApp";
			this.gitHabLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitHabLinkLabel_LinkClicked);
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(511, 295);
			this.Controls.Add(this.gitHabLinkLabel);
			this.Controls.Add(this.emailLinkLabel);
			this.Controls.Add(this.GitHubLabel);
			this.Controls.Add(this.emailLabel);
			this.Controls.Add(this.yearLabel);
			this.Controls.Add(this.authorLabel);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.aboutNameLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(527, 334);
			this.MinimumSize = new System.Drawing.Size(527, 334);
			this.Name = "AboutForm";
			this.Text = "About";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label aboutNameLabel;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label authorLabel;
		private System.Windows.Forms.Label yearLabel;
		private System.Windows.Forms.Label emailLabel;
		private System.Windows.Forms.Label GitHubLabel;
		private System.Windows.Forms.LinkLabel emailLinkLabel;
		private System.Windows.Forms.LinkLabel gitHabLinkLabel;
	}
}