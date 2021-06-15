
using System;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.addButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.categoryComboBox = new System.Windows.Forms.ComboBox();
			this.categoryLabel = new System.Windows.Forms.Label();
			this.noteTextRichBox = new System.Windows.Forms.RichTextBox();
			this.listNoteListBox = new System.Windows.Forms.ListBox();
			this.noteNameLabel = new System.Windows.Forms.Label();
			this.noteCategoryLabel = new System.Windows.Forms.Label();
			this.createTimeTextBox = new System.Windows.Forms.TextBox();
			this.createdTimeLabel = new System.Windows.Forms.Label();
			this.updateTimeTextBox = new System.Windows.Forms.TextBox();
			this.updatetimeLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddNoteItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditNoteItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveNoteItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.addButton.BackColor = System.Drawing.Color.Transparent;
			this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.addButton.FlatAppearance.BorderSize = 0;
			this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(254)))), ((int)(((byte)(214)))));
			this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.addButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
			this.addButton.Location = new System.Drawing.Point(9, 523);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(26, 26);
			this.addButton.TabIndex = 0;
			this.addButton.UseVisualStyleBackColor = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.deleteButton.BackColor = System.Drawing.Color.Transparent;
			this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.deleteButton.FlatAppearance.BorderSize = 0;
			this.deleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(222)))));
			this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(222)))));
			this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.deleteButton.ForeColor = System.Drawing.Color.Red;
			this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
			this.deleteButton.Location = new System.Drawing.Point(73, 523);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(26, 26);
			this.deleteButton.TabIndex = 1;
			this.deleteButton.UseVisualStyleBackColor = false;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// editButton
			// 
			this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editButton.BackColor = System.Drawing.Color.Transparent;
			this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.editButton.FlatAppearance.BorderSize = 0;
			this.editButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(243)))), ((int)(((byte)(242)))));
			this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.editButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.editButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
			this.editButton.Location = new System.Drawing.Point(41, 523);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(26, 26);
			this.editButton.TabIndex = 2;
			this.editButton.UseVisualStyleBackColor = false;
			this.editButton.Click += new System.EventHandler(this.editButton_Click);
			// 
			// categoryComboBox
			// 
			this.categoryComboBox.BackColor = System.Drawing.SystemColors.HighlightText;
			this.categoryComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.categoryComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.categoryComboBox.ForeColor = System.Drawing.SystemColors.InfoText;
			this.categoryComboBox.FormattingEnabled = true;
			this.categoryComboBox.Location = new System.Drawing.Point(105, 32);
			this.categoryComboBox.Name = "categoryComboBox";
			this.categoryComboBox.Size = new System.Drawing.Size(181, 25);
			this.categoryComboBox.TabIndex = 3;
			this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryBox_SelectedIndexChanged);
			// 
			// categoryLabel
			// 
			this.categoryLabel.AutoSize = true;
			this.categoryLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.categoryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.categoryLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.categoryLabel.Location = new System.Drawing.Point(9, 37);
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(90, 15);
			this.categoryLabel.TabIndex = 4;
			this.categoryLabel.Text = "Show Category:";
			// 
			// noteTextRichBox
			// 
			this.noteTextRichBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.noteTextRichBox.BackColor = System.Drawing.SystemColors.Control;
			this.noteTextRichBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.noteTextRichBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.noteTextRichBox.Location = new System.Drawing.Point(292, 134);
			this.noteTextRichBox.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
			this.noteTextRichBox.Name = "noteTextRichBox";
			this.noteTextRichBox.ReadOnly = true;
			this.noteTextRichBox.Size = new System.Drawing.Size(581, 415);
			this.noteTextRichBox.TabIndex = 5;
			this.noteTextRichBox.Text = "";
			// 
			// listNoteListBox
			// 
			this.listNoteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listNoteListBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listNoteListBox.FormattingEnabled = true;
			this.listNoteListBox.ItemHeight = 15;
			this.listNoteListBox.Location = new System.Drawing.Point(9, 63);
			this.listNoteListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.listNoteListBox.Name = "listNoteListBox";
			this.listNoteListBox.Size = new System.Drawing.Size(277, 439);
			this.listNoteListBox.TabIndex = 7;
			this.listNoteListBox.SelectedIndexChanged += new System.EventHandler(this.listNoteBox_SelectedIndexChanged);
			// 
			// noteNameLabel
			// 
			this.noteNameLabel.AutoSize = true;
			this.noteNameLabel.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.noteNameLabel.Location = new System.Drawing.Point(292, 24);
			this.noteNameLabel.Name = "noteNameLabel";
			this.noteNameLabel.Size = new System.Drawing.Size(210, 41);
			this.noteNameLabel.TabIndex = 8;
			this.noteNameLabel.Text = "Без названия";
			// 
			// noteCategoryLabel
			// 
			this.noteCategoryLabel.AutoSize = true;
			this.noteCategoryLabel.Location = new System.Drawing.Point(292, 75);
			this.noteCategoryLabel.Name = "noteCategoryLabel";
			this.noteCategoryLabel.Size = new System.Drawing.Size(55, 15);
			this.noteCategoryLabel.TabIndex = 9;
			this.noteCategoryLabel.Text = "Category";
			// 
			// createTimeTextBox
			// 
			this.createTimeTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.createTimeTextBox.Location = new System.Drawing.Point(346, 102);
			this.createTimeTextBox.Name = "createTimeTextBox";
			this.createTimeTextBox.ReadOnly = true;
			this.createTimeTextBox.Size = new System.Drawing.Size(70, 25);
			this.createTimeTextBox.TabIndex = 10;
			// 
			// createdTimeLabel
			// 
			this.createdTimeLabel.AutoSize = true;
			this.createdTimeLabel.Location = new System.Drawing.Point(292, 108);
			this.createdTimeLabel.Name = "createdTimeLabel";
			this.createdTimeLabel.Size = new System.Drawing.Size(48, 15);
			this.createdTimeLabel.TabIndex = 11;
			this.createdTimeLabel.Text = "Created";
			// 
			// updateTimeTextBox
			// 
			this.updateTimeTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.updateTimeTextBox.Location = new System.Drawing.Point(548, 102);
			this.updateTimeTextBox.Name = "updateTimeTextBox";
			this.updateTimeTextBox.ReadOnly = true;
			this.updateTimeTextBox.Size = new System.Drawing.Size(70, 25);
			this.updateTimeTextBox.TabIndex = 12;
			// 
			// updatetimeLabel
			// 
			this.updatetimeLabel.AutoSize = true;
			this.updatetimeLabel.Location = new System.Drawing.Point(490, 108);
			this.updatetimeLabel.Name = "updatetimeLabel";
			this.updatetimeLabel.Size = new System.Drawing.Size(52, 15);
			this.updatetimeLabel.TabIndex = 13;
			this.updatetimeLabel.Text = "Updated";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(884, 24);
			this.menuStrip1.TabIndex = 14;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNoteItem,
            this.EditNoteItem,
            this.RemoveNoteItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// AddNoteItem
			// 
			this.AddNoteItem.Name = "AddNoteItem";
			this.AddNoteItem.Size = new System.Drawing.Size(144, 22);
			this.AddNoteItem.Text = "Add Note";
			this.AddNoteItem.Click += new System.EventHandler(this.AddNoteItem_Click);
			// 
			// EditNoteItem
			// 
			this.EditNoteItem.Name = "EditNoteItem";
			this.EditNoteItem.Size = new System.Drawing.Size(144, 22);
			this.EditNoteItem.Text = "Edit Item";
			this.EditNoteItem.Click += new System.EventHandler(this.EditNoteItem_Click);
			// 
			// RemoveNoteItem
			// 
			this.RemoveNoteItem.Name = "RemoveNoteItem";
			this.RemoveNoteItem.Size = new System.Drawing.Size(144, 22);
			this.RemoveNoteItem.Text = "Remove Item";
			this.RemoveNoteItem.Click += new System.EventHandler(this.RemoveNoteItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(884, 561);
			this.Controls.Add(this.updatetimeLabel);
			this.Controls.Add(this.updateTimeTextBox);
			this.Controls.Add(this.createdTimeLabel);
			this.Controls.Add(this.createTimeTextBox);
			this.Controls.Add(this.noteCategoryLabel);
			this.Controls.Add(this.noteNameLabel);
			this.Controls.Add(this.listNoteListBox);
			this.Controls.Add(this.noteTextRichBox);
			this.Controls.Add(this.categoryLabel);
			this.Controls.Add(this.categoryComboBox);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(900, 600);
			this.Name = "MainForm";
			this.Text = "NoteApp";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.ComboBox categoryComboBox;
		private System.Windows.Forms.Label categoryLabel;
		private System.Windows.Forms.RichTextBox noteTextRichBox;
		private System.Windows.Forms.ListBox listNoteListBox;
		private System.Windows.Forms.Label noteNameLabel;
		private System.Windows.Forms.Label noteCategoryLabel;
		private System.Windows.Forms.TextBox createTimeTextBox;
		private System.Windows.Forms.Label createdTimeLabel;
		private System.Windows.Forms.TextBox updateTimeTextBox;
		private System.Windows.Forms.Label updatetimeLabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AddNoteItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem EditNoteItem;
		private System.Windows.Forms.ToolStripMenuItem RemoveNoteItem;
	}
}

