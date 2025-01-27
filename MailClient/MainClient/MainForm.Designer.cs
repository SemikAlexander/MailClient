﻿namespace MainClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.JunkMessages = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteMessage = new System.Windows.Forms.Button();
            this.DraftMessages = new System.Windows.Forms.Button();
            this.OutgoingMessages = new System.Windows.Forms.Button();
            this.InboxMessages = new System.Windows.Forms.Button();
            this.functionalPanel = new System.Windows.Forms.Panel();
            this.RestoreMessageButton = new System.Windows.Forms.Button();
            this.EditMessageButton = new System.Windows.Forms.Button();
            this.DeleteMessageButton = new System.Windows.Forms.Button();
            this.WriteMessage = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.MenuBarButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.UserMessagesTable = new System.Windows.Forms.DataGridView();
            this.TitleMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThemeMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMessageSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.inboxMessageWorker = new System.ComponentModel.BackgroundWorker();
            this.MessageWorker = new System.ComponentModel.BackgroundWorker();
            this.menuPanel.SuspendLayout();
            this.functionalPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMessagesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.JunkMessages);
            this.menuPanel.Controls.Add(this.InfoButton);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Controls.Add(this.DeleteMessage);
            this.menuPanel.Controls.Add(this.DraftMessages);
            this.menuPanel.Controls.Add(this.OutgoingMessages);
            this.menuPanel.Controls.Add(this.InboxMessages);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(180, 519);
            this.menuPanel.TabIndex = 0;
            // 
            // JunkMessages
            // 
            this.JunkMessages.FlatAppearance.BorderSize = 0;
            this.JunkMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JunkMessages.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.JunkMessages.Image = global::MainClient.Properties.Resources.GetSpamMessages;
            this.JunkMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.JunkMessages.Location = new System.Drawing.Point(-1, 211);
            this.JunkMessages.Name = "JunkMessages";
            this.JunkMessages.Size = new System.Drawing.Size(180, 45);
            this.JunkMessages.TabIndex = 8;
            this.JunkMessages.Text = "       Спам";
            this.JunkMessages.UseVisualStyleBackColor = true;
            this.JunkMessages.Click += new System.EventHandler(this.JunkMessages_Click);
            // 
            // InfoButton
            // 
            this.InfoButton.FlatAppearance.BorderSize = 0;
            this.InfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoButton.Image = global::MainClient.Properties.Resources.Info;
            this.InfoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoButton.Location = new System.Drawing.Point(3, 469);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(170, 45);
            this.InfoButton.TabIndex = 6;
            this.InfoButton.Text = "       Справка";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(49, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "МЕНЮ";
            // 
            // DeleteMessage
            // 
            this.DeleteMessage.FlatAppearance.BorderSize = 0;
            this.DeleteMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteMessage.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteMessage.Image = global::MainClient.Properties.Resources.DeleteMessage;
            this.DeleteMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteMessage.Location = new System.Drawing.Point(-1, 160);
            this.DeleteMessage.Name = "DeleteMessage";
            this.DeleteMessage.Size = new System.Drawing.Size(180, 45);
            this.DeleteMessage.TabIndex = 4;
            this.DeleteMessage.Text = "        Удалённые";
            this.DeleteMessage.UseVisualStyleBackColor = true;
            this.DeleteMessage.Click += new System.EventHandler(this.DeleteMessage_Click);
            // 
            // DraftMessages
            // 
            this.DraftMessages.FlatAppearance.BorderSize = 0;
            this.DraftMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DraftMessages.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DraftMessages.Image = global::MainClient.Properties.Resources.DraftMessage;
            this.DraftMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DraftMessages.Location = new System.Drawing.Point(-1, 262);
            this.DraftMessages.Name = "DraftMessages";
            this.DraftMessages.Size = new System.Drawing.Size(180, 45);
            this.DraftMessages.TabIndex = 3;
            this.DraftMessages.Text = "       Черновик";
            this.DraftMessages.UseVisualStyleBackColor = true;
            this.DraftMessages.Click += new System.EventHandler(this.DraftMessages_Click);
            // 
            // OutgoingMessages
            // 
            this.OutgoingMessages.FlatAppearance.BorderSize = 0;
            this.OutgoingMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutgoingMessages.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutgoingMessages.Image = global::MainClient.Properties.Resources.OutgoingMessage;
            this.OutgoingMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutgoingMessages.Location = new System.Drawing.Point(-1, 109);
            this.OutgoingMessages.Name = "OutgoingMessages";
            this.OutgoingMessages.Size = new System.Drawing.Size(180, 45);
            this.OutgoingMessages.TabIndex = 2;
            this.OutgoingMessages.Text = "Отправленные";
            this.OutgoingMessages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OutgoingMessages.UseVisualStyleBackColor = true;
            this.OutgoingMessages.Click += new System.EventHandler(this.OutgoingMessages_Click);
            // 
            // InboxMessages
            // 
            this.InboxMessages.FlatAppearance.BorderSize = 0;
            this.InboxMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InboxMessages.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InboxMessages.Image = ((System.Drawing.Image)(resources.GetObject("InboxMessages.Image")));
            this.InboxMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InboxMessages.Location = new System.Drawing.Point(-1, 58);
            this.InboxMessages.Name = "InboxMessages";
            this.InboxMessages.Size = new System.Drawing.Size(180, 45);
            this.InboxMessages.TabIndex = 1;
            this.InboxMessages.Text = "          Входящие";
            this.InboxMessages.UseVisualStyleBackColor = true;
            this.InboxMessages.Click += new System.EventHandler(this.InboxMessages_Click);
            // 
            // functionalPanel
            // 
            this.functionalPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.functionalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalPanel.Controls.Add(this.RestoreMessageButton);
            this.functionalPanel.Controls.Add(this.EditMessageButton);
            this.functionalPanel.Controls.Add(this.DeleteMessageButton);
            this.functionalPanel.Controls.Add(this.WriteMessage);
            this.functionalPanel.Controls.Add(this.SettingsButton);
            this.functionalPanel.Controls.Add(this.MenuBarButton);
            this.functionalPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.functionalPanel.Location = new System.Drawing.Point(180, 0);
            this.functionalPanel.Name = "functionalPanel";
            this.functionalPanel.Size = new System.Drawing.Size(805, 40);
            this.functionalPanel.TabIndex = 1;
            // 
            // RestoreMessageButton
            // 
            this.RestoreMessageButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RestoreMessageButton.FlatAppearance.BorderSize = 0;
            this.RestoreMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoreMessageButton.Image = global::MainClient.Properties.Resources.RestoreMessage;
            this.RestoreMessageButton.Location = new System.Drawing.Point(603, 0);
            this.RestoreMessageButton.Name = "RestoreMessageButton";
            this.RestoreMessageButton.Size = new System.Drawing.Size(40, 38);
            this.RestoreMessageButton.TabIndex = 6;
            this.RestoreMessageButton.UseVisualStyleBackColor = true;
            this.RestoreMessageButton.Visible = false;
            this.RestoreMessageButton.Click += new System.EventHandler(this.RestoreMessageButton_Click);
            // 
            // EditMessageButton
            // 
            this.EditMessageButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.EditMessageButton.FlatAppearance.BorderSize = 0;
            this.EditMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditMessageButton.Image = global::MainClient.Properties.Resources.EditMessage_32;
            this.EditMessageButton.Location = new System.Drawing.Point(643, 0);
            this.EditMessageButton.Name = "EditMessageButton";
            this.EditMessageButton.Size = new System.Drawing.Size(40, 38);
            this.EditMessageButton.TabIndex = 5;
            this.EditMessageButton.UseVisualStyleBackColor = true;
            this.EditMessageButton.Visible = false;
            this.EditMessageButton.Click += new System.EventHandler(this.EditMessageButton_Click);
            // 
            // DeleteMessageButton
            // 
            this.DeleteMessageButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteMessageButton.FlatAppearance.BorderSize = 0;
            this.DeleteMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteMessageButton.Image = global::MainClient.Properties.Resources.DeleteCurrentMessage;
            this.DeleteMessageButton.Location = new System.Drawing.Point(683, 0);
            this.DeleteMessageButton.Name = "DeleteMessageButton";
            this.DeleteMessageButton.Size = new System.Drawing.Size(40, 38);
            this.DeleteMessageButton.TabIndex = 4;
            this.DeleteMessageButton.UseVisualStyleBackColor = true;
            this.DeleteMessageButton.Visible = false;
            this.DeleteMessageButton.Click += new System.EventHandler(this.DeleteMessageButton_Click);
            // 
            // WriteMessage
            // 
            this.WriteMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.WriteMessage.FlatAppearance.BorderSize = 0;
            this.WriteMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WriteMessage.Image = global::MainClient.Properties.Resources.CreateNewMessage_32;
            this.WriteMessage.Location = new System.Drawing.Point(723, 0);
            this.WriteMessage.Name = "WriteMessage";
            this.WriteMessage.Size = new System.Drawing.Size(40, 38);
            this.WriteMessage.TabIndex = 3;
            this.WriteMessage.UseVisualStyleBackColor = true;
            this.WriteMessage.Click += new System.EventHandler(this.WriteMessage_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Image = global::MainClient.Properties.Resources.Settings;
            this.SettingsButton.Location = new System.Drawing.Point(763, 0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(40, 38);
            this.SettingsButton.TabIndex = 1;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MenuBarButton
            // 
            this.MenuBarButton.FlatAppearance.BorderSize = 0;
            this.MenuBarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuBarButton.Image = global::MainClient.Properties.Resources.Menu;
            this.MenuBarButton.Location = new System.Drawing.Point(-1, -1);
            this.MenuBarButton.Name = "MenuBarButton";
            this.MenuBarButton.Size = new System.Drawing.Size(40, 40);
            this.MenuBarButton.TabIndex = 0;
            this.MenuBarButton.UseVisualStyleBackColor = true;
            this.MenuBarButton.Click += new System.EventHandler(this.MenuBarButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.toolStrip1);
            this.contentPanel.Controls.Add(this.UserMessagesTable);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(180, 40);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(805, 479);
            this.contentPanel.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 454);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(805, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 22);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // UserMessagesTable
            // 
            this.UserMessagesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserMessagesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UserMessagesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserMessagesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleMessage,
            this.ThemeMessage,
            this.ContentMessage,
            this.IDMessage,
            this.IsMessageSeen});
            this.UserMessagesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserMessagesTable.Location = new System.Drawing.Point(0, 0);
            this.UserMessagesTable.Name = "UserMessagesTable";
            this.UserMessagesTable.ReadOnly = true;
            this.UserMessagesTable.Size = new System.Drawing.Size(805, 479);
            this.UserMessagesTable.TabIndex = 0;
            this.UserMessagesTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserMessagesTable_CellContentDoubleClick);
            this.UserMessagesTable.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.UserMessagesTable_RowPrePaint);
            this.UserMessagesTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserMessagesTable_MouseClick);
            // 
            // TitleMessage
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.TitleMessage.HeaderText = "Адрес";
            this.TitleMessage.Name = "TitleMessage";
            this.TitleMessage.ReadOnly = true;
            this.TitleMessage.Width = 180;
            // 
            // ThemeMessage
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeMessage.DefaultCellStyle = dataGridViewCellStyle3;
            this.ThemeMessage.HeaderText = "Тема";
            this.ThemeMessage.Name = "ThemeMessage";
            this.ThemeMessage.ReadOnly = true;
            this.ThemeMessage.Width = 180;
            // 
            // ContentMessage
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContentMessage.DefaultCellStyle = dataGridViewCellStyle4;
            this.ContentMessage.HeaderText = "Содержимое";
            this.ContentMessage.Name = "ContentMessage";
            this.ContentMessage.ReadOnly = true;
            this.ContentMessage.Width = 400;
            // 
            // IDMessage
            // 
            this.IDMessage.HeaderText = "ID";
            this.IDMessage.Name = "IDMessage";
            this.IDMessage.ReadOnly = true;
            this.IDMessage.Visible = false;
            // 
            // IsMessageSeen
            // 
            this.IsMessageSeen.HeaderText = "SeenMess";
            this.IsMessageSeen.Name = "IsMessageSeen";
            this.IsMessageSeen.ReadOnly = true;
            this.IsMessageSeen.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // inboxMessageWorker
            // 
            this.inboxMessageWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.inboxMessageWorker_ProgressChanged);
            this.inboxMessageWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.inboxMessageWorker_RunWorkerCompleted);
            // 
            // MessageWorker
            // 
            this.MessageWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.draftMessageWorker_ProgressChanged);
            this.MessageWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.draftMessageWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 519);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.functionalPanel);
            this.Controls.Add(this.menuPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.functionalPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMessagesTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel functionalPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button MenuBarButton;
        private System.Windows.Forms.Button InboxMessages;
        private System.Windows.Forms.Button DraftMessages;
        private System.Windows.Forms.Button OutgoingMessages;
        private System.Windows.Forms.Button DeleteMessage;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InfoButton;
        private System.Windows.Forms.DataGridView UserMessagesTable;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button WriteMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button EditMessageButton;
        private System.Windows.Forms.Button DeleteMessageButton;
        private System.Windows.Forms.Button RestoreMessageButton;
        private System.ComponentModel.BackgroundWorker inboxMessageWorker;
        private System.ComponentModel.BackgroundWorker MessageWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThemeMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMessageSeen;
        private System.Windows.Forms.Button JunkMessages;
    }
}