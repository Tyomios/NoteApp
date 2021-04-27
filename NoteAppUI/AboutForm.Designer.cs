
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
			this.aboutNameLabel.Location = new System.Drawing.Point(50, 63);
			this.aboutNameLabel.Name = "aboutNameLabel";
			this.aboutNameLabel.Size = new System.Drawing.Size(147, 41);
			this.aboutNameLabel.TabIndex = 0;
			this.aboutNameLabel.Text = "NoteApp";
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point(134, 104);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(53, 20);
			this.versionLabel.TabIndex = 1;
			this.versionLabel.Text = "v. 1.0.0";
			// 
			// authorLabel
			// 
			this.authorLabel.AutoSize = true;
			this.authorLabel.Location = new System.Drawing.Point(50, 169);
			this.authorLabel.Name = "authorLabel";
			this.authorLabel.Size = new System.Drawing.Size(185, 20);
			this.authorLabel.TabIndex = 2;
			this.authorLabel.Text = "Author: Slesarenko Artyom";
			// 
			// yearLabel
			// 
			this.yearLabel.AutoSize = true;
			this.yearLabel.Location = new System.Drawing.Point(50, 341);
			this.yearLabel.Name = "yearLabel";
			this.yearLabel.Size = new System.Drawing.Size(182, 20);
			this.yearLabel.TabIndex = 3;
			this.yearLabel.Text = "2021 Slesarenko Artyom©";
			// 
			// emailLabel
			// 
			this.emailLabel.AutoSize = true;
			this.emailLabel.Location = new System.Drawing.Point(50, 210);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(143, 20);
			this.emailLabel.TabIndex = 4;
			this.emailLabel.Text = "e-mail for feedback:";
			// 
			// GitHubLabel
			// 
			this.GitHubLabel.AutoSize = true;
			this.GitHubLabel.Location = new System.Drawing.Point(50, 258);
			this.GitHubLabel.Name = "GitHubLabel";
			this.GitHubLabel.Size = new System.Drawing.Size(59, 20);
			this.GitHubLabel.TabIndex = 5;
			this.GitHubLabel.Text = "GitHub:";
			// 
			// emailLinkLabel
			// 
			this.emailLinkLabel.AutoSize = true;
			this.emailLinkLabel.Location = new System.Drawing.Point(190, 210);
			this.emailLinkLabel.Name = "emailLinkLabel";
			this.emailLinkLabel.Size = new System.Drawing.Size(121, 20);
			this.emailLinkLabel.TabIndex = 6;
			this.emailLinkLabel.TabStop = true;
			this.emailLinkLabel.Text = "tyomios@mail.ru";
			this.emailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.emailLinkLabel_LinkClicked);
			// 
			// gitHabLinkLabel
			// 
			this.gitHabLinkLabel.AutoSize = true;
			this.gitHabLinkLabel.LinkVisited = true;
			this.gitHabLinkLabel.Location = new System.Drawing.Point(111, 258);
			this.gitHabLinkLabel.Name = "gitHabLinkLabel";
			this.gitHabLinkLabel.Size = new System.Drawing.Size(260, 20);
			this.gitHabLinkLabel.TabIndex = 7;
			this.gitHabLinkLabel.TabStop = true;
			this.gitHabLinkLabel.Text = "https://github.com/Tyomios/NoteApp";
			this.gitHabLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitHabLinkLabel_LinkClicked);
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 385);
			this.Controls.Add(this.gitHabLinkLabel);
			this.Controls.Add(this.emailLinkLabel);
			this.Controls.Add(this.GitHubLabel);
			this.Controls.Add(this.emailLabel);
			this.Controls.Add(this.yearLabel);
			this.Controls.Add(this.authorLabel);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.aboutNameLabel);
			this.MaximumSize = new System.Drawing.Size(600, 432);
			this.MinimumSize = new System.Drawing.Size(600, 432);
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