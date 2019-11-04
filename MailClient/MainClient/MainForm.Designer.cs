namespace MainClient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.functionalPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.UserMessagesTable = new System.Windows.Forms.DataGridView();
            this.TitleMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThemeMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.writeMessage = new System.Windows.Forms.Button();
            this.getMessages = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.MenuBarButton = new System.Windows.Forms.Button();
            this.InfoButton = new System.Windows.Forms.Button();
            this.DeleteMessage = new System.Windows.Forms.Button();
            this.DraftMessages = new System.Windows.Forms.Button();
            this.OutgoingMessages = new System.Windows.Forms.Button();
            this.InboxMessages = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.functionalPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMessagesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // functionalPanel
            // 
            this.functionalPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.functionalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalPanel.Controls.Add(this.writeMessage);
            this.functionalPanel.Controls.Add(this.getMessages);
            this.functionalPanel.Controls.Add(this.SettingsButton);
            this.functionalPanel.Controls.Add(this.MenuBarButton);
            this.functionalPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.functionalPanel.Location = new System.Drawing.Point(180, 0);
            this.functionalPanel.Name = "functionalPanel";
            this.functionalPanel.Size = new System.Drawing.Size(805, 40);
            this.functionalPanel.TabIndex = 1;
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
            this.ContentMessage});
            this.UserMessagesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserMessagesTable.Location = new System.Drawing.Point(0, 0);
            this.UserMessagesTable.Name = "UserMessagesTable";
            this.UserMessagesTable.Size = new System.Drawing.Size(805, 479);
            this.UserMessagesTable.TabIndex = 0;
            // 
            // TitleMessage
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.TitleMessage.HeaderText = "Титул";
            this.TitleMessage.Name = "TitleMessage";
            this.TitleMessage.Width = 180;
            // 
            // ThemeMessage
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeMessage.DefaultCellStyle = dataGridViewCellStyle3;
            this.ThemeMessage.HeaderText = "Тема";
            this.ThemeMessage.Name = "ThemeMessage";
            this.ThemeMessage.Width = 180;
            // 
            // ContentMessage
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContentMessage.DefaultCellStyle = dataGridViewCellStyle4;
            this.ContentMessage.HeaderText = "Содержимое";
            this.ContentMessage.Name = "ContentMessage";
            this.ContentMessage.Width = 400;
            // 
            // writeMessage
            // 
            this.writeMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.writeMessage.FlatAppearance.BorderSize = 0;
            this.writeMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeMessage.Image = global::MainClient.Properties.Resources.CreateMessage_32;
            this.writeMessage.Location = new System.Drawing.Point(683, 0);
            this.writeMessage.Name = "writeMessage";
            this.writeMessage.Size = new System.Drawing.Size(40, 38);
            this.writeMessage.TabIndex = 3;
            this.writeMessage.UseVisualStyleBackColor = true;
            this.writeMessage.Click += new System.EventHandler(this.writeMessage_Click);
            // 
            // getMessages
            // 
            this.getMessages.Dock = System.Windows.Forms.DockStyle.Right;
            this.getMessages.FlatAppearance.BorderSize = 0;
            this.getMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getMessages.Image = global::MainClient.Properties.Resources.GetMessages;
            this.getMessages.Location = new System.Drawing.Point(723, 0);
            this.getMessages.Name = "getMessages";
            this.getMessages.Size = new System.Drawing.Size(40, 38);
            this.getMessages.TabIndex = 2;
            this.getMessages.UseVisualStyleBackColor = true;
            this.getMessages.Click += new System.EventHandler(this.button1_Click_1);
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
            this.SettingsButton.Click += new System.EventHandler(this.button6_Click);
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
            this.MenuBarButton.Click += new System.EventHandler(this.button1_Click);
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
            // 
            // DeleteMessage
            // 
            this.DeleteMessage.FlatAppearance.BorderSize = 0;
            this.DeleteMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteMessage.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteMessage.Image = global::MainClient.Properties.Resources.DeleteMessage;
            this.DeleteMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteMessage.Location = new System.Drawing.Point(3, 211);
            this.DeleteMessage.Name = "DeleteMessage";
            this.DeleteMessage.Size = new System.Drawing.Size(170, 45);
            this.DeleteMessage.TabIndex = 4;
            this.DeleteMessage.Text = "        Удалённые";
            this.DeleteMessage.UseVisualStyleBackColor = true;
            // 
            // DraftMessages
            // 
            this.DraftMessages.FlatAppearance.BorderSize = 0;
            this.DraftMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DraftMessages.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DraftMessages.Image = global::MainClient.Properties.Resources.DraftMessage;
            this.DraftMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DraftMessages.Location = new System.Drawing.Point(3, 160);
            this.DraftMessages.Name = "DraftMessages";
            this.DraftMessages.Size = new System.Drawing.Size(170, 45);
            this.DraftMessages.TabIndex = 3;
            this.DraftMessages.Text = "       Черновик";
            this.DraftMessages.UseVisualStyleBackColor = true;
            // 
            // OutgoingMessages
            // 
            this.OutgoingMessages.FlatAppearance.BorderSize = 0;
            this.OutgoingMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutgoingMessages.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutgoingMessages.Image = global::MainClient.Properties.Resources.OutgoingMessage;
            this.OutgoingMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutgoingMessages.Location = new System.Drawing.Point(3, 109);
            this.OutgoingMessages.Name = "OutgoingMessages";
            this.OutgoingMessages.Size = new System.Drawing.Size(170, 45);
            this.OutgoingMessages.TabIndex = 2;
            this.OutgoingMessages.Text = "Отправленные";
            this.OutgoingMessages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OutgoingMessages.UseVisualStyleBackColor = true;
            // 
            // InboxMessages
            // 
            this.InboxMessages.FlatAppearance.BorderSize = 0;
            this.InboxMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InboxMessages.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InboxMessages.Image = ((System.Drawing.Image)(resources.GetObject("InboxMessages.Image")));
            this.InboxMessages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InboxMessages.Location = new System.Drawing.Point(3, 58);
            this.InboxMessages.Name = "InboxMessages";
            this.InboxMessages.Size = new System.Drawing.Size(170, 45);
            this.InboxMessages.TabIndex = 1;
            this.InboxMessages.Text = "          Входящие";
            this.InboxMessages.UseVisualStyleBackColor = true;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThemeMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentMessage;
        private System.Windows.Forms.Button getMessages;
        private System.Windows.Forms.Button writeMessage;
    }
}