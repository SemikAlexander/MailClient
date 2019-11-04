﻿namespace MainClient
{
    partial class SendMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMessage));
            this.TextLetter = new System.Windows.Forms.TextBox();
            this.theme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.email_client = new System.Windows.Forms.TextBox();
            this.FolderAttachment = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.FileAttachment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextLetter
            // 
            this.TextLetter.Location = new System.Drawing.Point(12, 76);
            this.TextLetter.Multiline = true;
            this.TextLetter.Name = "TextLetter";
            this.TextLetter.Size = new System.Drawing.Size(478, 220);
            this.TextLetter.TabIndex = 14;
            // 
            // theme
            // 
            this.theme.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.theme.Location = new System.Drawing.Point(71, 44);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(419, 26);
            this.theme.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Тема:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Кому:";
            // 
            // email_client
            // 
            this.email_client.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_client.Location = new System.Drawing.Point(71, 12);
            this.email_client.Name = "email_client";
            this.email_client.Size = new System.Drawing.Size(419, 26);
            this.email_client.TabIndex = 10;
            // 
            // FolderAttachment
            // 
            this.FolderAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FolderAttachment.Image = ((System.Drawing.Image)(resources.GetObject("FolderAttachment.Image")));
            this.FolderAttachment.Location = new System.Drawing.Point(65, 302);
            this.FolderAttachment.Name = "FolderAttachment";
            this.FolderAttachment.Size = new System.Drawing.Size(47, 41);
            this.FolderAttachment.TabIndex = 17;
            this.FolderAttachment.UseVisualStyleBackColor = true;
            this.FolderAttachment.Click += new System.EventHandler(this.button3_Click);
            // 
            // Send
            // 
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send.Image = ((System.Drawing.Image)(resources.GetObject("Send.Image")));
            this.Send.Location = new System.Drawing.Point(443, 302);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(47, 41);
            this.Send.TabIndex = 16;
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.button2_Click);
            // 
            // FileAttachment
            // 
            this.FileAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileAttachment.Image = ((System.Drawing.Image)(resources.GetObject("FileAttachment.Image")));
            this.FileAttachment.Location = new System.Drawing.Point(12, 302);
            this.FileAttachment.Name = "FileAttachment";
            this.FileAttachment.Size = new System.Drawing.Size(47, 41);
            this.FileAttachment.TabIndex = 15;
            this.FileAttachment.UseVisualStyleBackColor = true;
            this.FileAttachment.Click += new System.EventHandler(this.button1_Click);
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 352);
            this.Controls.Add(this.FolderAttachment);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.FileAttachment);
            this.Controls.Add(this.TextLetter);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email_client);
            this.Name = "SendMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button FolderAttachment;
        public System.Windows.Forms.Button Send;
        public System.Windows.Forms.Button FileAttachment;
        public System.Windows.Forms.TextBox TextLetter;
        public System.Windows.Forms.TextBox theme;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox email_client;
    }
}