
using NoteApp;

namespace NoteAppUI
{
	partial class AddForm
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
			this.SaveButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.TextLabel = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.NameLabel = new System.Windows.Forms.Label();
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.CategoryBox = new System.Windows.Forms.ComboBox();
			this.CategoryLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.SaveButton.Location = new System.Drawing.Point(213, 473);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 38);
			this.SaveButton.TabIndex = 1;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.CancelButton.Location = new System.Drawing.Point(408, 473);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 38);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// TextLabel
			// 
			this.TextLabel.AutoSize = true;
			this.TextLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextLabel.Location = new System.Drawing.Point(80, 193);
			this.TextLabel.Name = "TextLabel";
			this.TextLabel.Size = new System.Drawing.Size(75, 21);
			this.TextLabel.TabIndex = 3;
			this.TextLabel.Text = "Enter text";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(213, 56);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(294, 23);
			this.NameBox.TabIndex = 4;
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.NameLabel.Location = new System.Drawing.Point(80, 54);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(52, 21);
			this.NameLabel.TabIndex = 5;
			this.NameLabel.Text = "Name";
			// 
			// richTextBox
			// 
			this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox.Location = new System.Drawing.Point(213, 193);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(294, 236);
			this.richTextBox.TabIndex = 6;
			this.richTextBox.Text = "";
			// 
			// CategoryBox
			// 
			this.CategoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CategoryBox.FormattingEnabled = true;
			this.CategoryBox.Location = new System.Drawing.Point(213, 107);
			this.CategoryBox.Name = "CategoryBox";
			this.CategoryBox.Size = new System.Drawing.Size(294, 23);
			this.CategoryBox.TabIndex = 7;
			// 
			// CategoryLabel
			// 
			this.CategoryLabel.AutoSize = true;
			this.CategoryLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CategoryLabel.Location = new System.Drawing.Point(80, 109);
			this.CategoryLabel.Name = "CategoryLabel";
			this.CategoryLabel.Size = new System.Drawing.Size(73, 21);
			this.CategoryLabel.TabIndex = 8;
			this.CategoryLabel.Text = "Category";
			// 
			// AddForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(573, 536);
			this.Controls.Add(this.CategoryLabel);
			this.Controls.Add(this.CategoryBox);
			this.Controls.Add(this.richTextBox);
			this.Controls.Add(this.NameLabel);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.TextLabel);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.SaveButton);
			this.MinimumSize = new System.Drawing.Size(589, 575);
			this.Name = "AddForm";
			this.Text = "Add new note";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label TextLabel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.RichTextBox richTextBox;
		private System.Windows.Forms.ComboBox CategoryBox;
		private System.Windows.Forms.Label CategoryLabel;
	}
}