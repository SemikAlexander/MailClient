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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.functionalPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.UserMessagesTable = new System.Windows.Forms.DataGridView();
            this.TitleMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThemeMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuPanel.SuspendLayout();
            this.functionalPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMessagesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.button7);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Controls.Add(this.button5);
            this.menuPanel.Controls.Add(this.button4);
            this.menuPanel.Controls.Add(this.button3);
            this.menuPanel.Controls.Add(this.button2);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(180, 519);
            this.menuPanel.TabIndex = 0;
            // 
            // functionalPanel
            // 
            this.functionalPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.functionalPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.functionalPanel.Controls.Add(this.button6);
            this.functionalPanel.Controls.Add(this.button1);
            this.functionalPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.functionalPanel.Location = new System.Drawing.Point(180, 0);
            this.functionalPanel.Name = "functionalPanel";
            this.functionalPanel.Size = new System.Drawing.Size(706, 40);
            this.functionalPanel.TabIndex = 1;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.UserMessagesTable);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(180, 40);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(706, 479);
            this.contentPanel.TabIndex = 2;
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
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Right;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::MainClient.Properties.Resources.Settings;
            this.button6.Location = new System.Drawing.Point(664, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 38);
            this.button6.TabIndex = 1;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::MainClient.Properties.Resources.Menu;
            this.button1.Location = new System.Drawing.Point(-1, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Image = global::MainClient.Properties.Resources.Info;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(3, 469);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(170, 45);
            this.button7.TabIndex = 6;
            this.button7.Text = "       Справка";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Image = global::MainClient.Properties.Resources.DeleteMessage;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(3, 211);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 45);
            this.button5.TabIndex = 4;
            this.button5.Text = "        Удалённые";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Image = global::MainClient.Properties.Resources.DraftMessage;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(3, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 45);
            this.button4.TabIndex = 3;
            this.button4.Text = "       Черновик";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Image = global::MainClient.Properties.Resources.OutgoingMessage;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(3, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 45);
            this.button3.TabIndex = 2;
            this.button3.Text = "Отправленные";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "          Входящие";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // UserMessagesTable
            // 
            this.UserMessagesTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserMessagesTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.UserMessagesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserMessagesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleMessage,
            this.ThemeMessage,
            this.ContentMessage});
            this.UserMessagesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserMessagesTable.Location = new System.Drawing.Point(0, 0);
            this.UserMessagesTable.Name = "UserMessagesTable";
            this.UserMessagesTable.Size = new System.Drawing.Size(706, 479);
            this.UserMessagesTable.TabIndex = 0;
            // 
            // TitleMessage
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleMessage.DefaultCellStyle = dataGridViewCellStyle10;
            this.TitleMessage.HeaderText = "Титул";
            this.TitleMessage.Name = "TitleMessage";
            this.TitleMessage.Width = 175;
            // 
            // ThemeMessage
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ThemeMessage.DefaultCellStyle = dataGridViewCellStyle11;
            this.ThemeMessage.HeaderText = "Тема";
            this.ThemeMessage.Name = "ThemeMessage";
            this.ThemeMessage.Width = 175;
            // 
            // ContentMessage
            // 
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContentMessage.DefaultCellStyle = dataGridViewCellStyle12;
            this.ContentMessage.HeaderText = "Содержимое";
            this.ContentMessage.Name = "ContentMessage";
            this.ContentMessage.Width = 300;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 519);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.functionalPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.functionalPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserMessagesTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel functionalPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView UserMessagesTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThemeMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentMessage;
    }
}