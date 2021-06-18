﻿
using NoteApp;

namespace NoteAppUI
{
	partial class NoteForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
			this.SaveButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.NameLabel = new System.Windows.Forms.Label();
			this.NoteTextRichTextBox = new System.Windows.Forms.RichTextBox();
			this.CategoryComboBox = new System.Windows.Forms.ComboBox();
			this.CategoryLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.Location = new System.Drawing.Point(396, 501);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "OK";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.Location = new System.Drawing.Point(486, 501);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// NameTextBox
			// 
			this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NameTextBox.Location = new System.Drawing.Point(75, 23);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(486, 23);
			this.NameTextBox.TabIndex = 4;
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.NameLabel.Location = new System.Drawing.Point(12, 24);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(43, 17);
			this.NameLabel.TabIndex = 5;
			this.NameLabel.Text = "Name";
			// 
			// NoteTextRichTextBox
			// 
			this.NoteTextRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NoteTextRichTextBox.Location = new System.Drawing.Point(12, 104);
			this.NoteTextRichTextBox.Name = "NoteTextRichTextBox";
			this.NoteTextRichTextBox.Size = new System.Drawing.Size(549, 391);
			this.NoteTextRichTextBox.TabIndex = 6;
			this.NoteTextRichTextBox.Text = "";
			// 
			// CategoryComboBox
			// 
			this.CategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CategoryComboBox.FormattingEnabled = true;
			this.CategoryComboBox.Location = new System.Drawing.Point(75, 62);
			this.CategoryComboBox.Name = "CategoryComboBox";
			this.CategoryComboBox.Size = new System.Drawing.Size(486, 23);
			this.CategoryComboBox.TabIndex = 7;
			// 
			// CategoryLabel
			// 
			this.CategoryLabel.AutoSize = true;
			this.CategoryLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CategoryLabel.Location = new System.Drawing.Point(12, 63);
			this.CategoryLabel.Name = "CategoryLabel";
			this.CategoryLabel.Size = new System.Drawing.Size(61, 17);
			this.CategoryLabel.TabIndex = 8;
			this.CategoryLabel.Text = "Category";
			// 
			// NoteForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(573, 536);
			this.Controls.Add(this.CategoryLabel);
			this.Controls.Add(this.CategoryComboBox);
			this.Controls.Add(this.NoteTextRichTextBox);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.NameTextBox);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.SaveButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(589, 575);
			this.Name = "NoteForm";
			this.Text = "Add new note";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.RichTextBox NoteTextRichTextBox;
		private System.Windows.Forms.ComboBox CategoryComboBox;
		private System.Windows.Forms.Label CategoryLabel;
	}
}