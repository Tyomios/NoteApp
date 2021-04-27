
namespace NoteAppUI
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.addButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.categoryBox = new System.Windows.Forms.ComboBox();
			this.categoryLabel = new System.Windows.Forms.Label();
			this.noteText = new System.Windows.Forms.RichTextBox();
			this.noteName = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// addButton
			// 
			this.addButton.BackColor = System.Drawing.Color.Transparent;
			this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.addButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.addButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.addButton.Location = new System.Drawing.Point(32, 684);
			this.addButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(45, 47);
			this.addButton.TabIndex = 0;
			this.addButton.Text = "➕";
			this.addButton.UseVisualStyleBackColor = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.BackColor = System.Drawing.Color.Transparent;
			this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.deleteButton.ForeColor = System.Drawing.Color.Red;
			this.deleteButton.Location = new System.Drawing.Point(160, 686);
			this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(42, 45);
			this.deleteButton.TabIndex = 1;
			this.deleteButton.Text = "❌";
			this.deleteButton.UseVisualStyleBackColor = false;
			// 
			// editButton
			// 
			this.editButton.BackColor = System.Drawing.Color.Transparent;
			this.editButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.editButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.editButton.Location = new System.Drawing.Point(98, 685);
			this.editButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(40, 45);
			this.editButton.TabIndex = 2;
			this.editButton.Text = "🖊";
			this.editButton.UseVisualStyleBackColor = false;
			// 
			// categoryBox
			// 
			this.categoryBox.BackColor = System.Drawing.SystemColors.HighlightText;
			this.categoryBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.categoryBox.ForeColor = System.Drawing.SystemColors.MenuBar;
			this.categoryBox.FormattingEnabled = true;
			this.categoryBox.Location = new System.Drawing.Point(175, 60);
			this.categoryBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.categoryBox.Name = "categoryBox";
			this.categoryBox.Size = new System.Drawing.Size(151, 33);
			this.categoryBox.TabIndex = 3;
			// 
			// categoryLabel
			// 
			this.categoryLabel.AutoSize = true;
			this.categoryLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.categoryLabel.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.categoryLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.categoryLabel.Location = new System.Drawing.Point(32, 61);
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(97, 28);
			this.categoryLabel.TabIndex = 4;
			this.categoryLabel.Text = "Category";
			// 
			// noteText
			// 
			this.noteText.BackColor = System.Drawing.Color.Snow;
			this.noteText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.noteText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.noteText.Location = new System.Drawing.Point(389, 184);
			this.noteText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.noteText.Name = "noteText";
			this.noteText.Size = new System.Drawing.Size(584, 547);
			this.noteText.TabIndex = 5;
			this.noteText.Text = "";
			// 
			// noteName
			// 
			this.noteName.AutoSize = true;
			this.noteName.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.noteName.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.noteName.Location = new System.Drawing.Point(389, 71);
			this.noteName.Name = "noteName";
			this.noteName.Size = new System.Drawing.Size(205, 81);
			this.noteName.TabIndex = 6;
			this.noteName.Text = "Пусто";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 20;
			this.listBox1.Location = new System.Drawing.Point(32, 184);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(294, 464);
			this.listBox1.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(1010, 748);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.noteName);
			this.Controls.Add(this.noteText);
			this.Controls.Add(this.categoryLabel);
			this.Controls.Add(this.categoryBox);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.Text = "NoteApp";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.ComboBox categoryBox;
		private System.Windows.Forms.Label categoryLabel;
		private System.Windows.Forms.RichTextBox noteText;
		private System.Windows.Forms.Label noteName;
		private System.Windows.Forms.ListBox listBox1;
	}
}

