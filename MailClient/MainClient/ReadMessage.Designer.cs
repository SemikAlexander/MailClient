namespace MainClient
{
    partial class ReadMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadMessage));
            this.theme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.email_client = new System.Windows.Forms.TextBox();
            this.TextLetter = new System.Windows.Forms.RichTextBox();
            this.AttachmentFileLabel = new System.Windows.Forms.Label();
            this.FileAttachment = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // theme
            // 
            this.theme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.theme.Location = new System.Drawing.Point(71, 37);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(539, 22);
            this.theme.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Тема:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "От:";
            // 
            // email_client
            // 
            this.email_client.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_client.Location = new System.Drawing.Point(69, 9);
            this.email_client.Name = "email_client";
            this.email_client.Size = new System.Drawing.Size(541, 22);
            this.email_client.TabIndex = 15;
            // 
            // TextLetter
            // 
            this.TextLetter.Location = new System.Drawing.Point(12, 65);
            this.TextLetter.Name = "TextLetter";
            this.TextLetter.Size = new System.Drawing.Size(598, 345);
            this.TextLetter.TabIndex = 19;
            this.TextLetter.Text = "";
            // 
            // AttachmentFileLabel
            // 
            this.AttachmentFileLabel.AutoSize = true;
            this.AttachmentFileLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AttachmentFileLabel.Location = new System.Drawing.Point(65, 432);
            this.AttachmentFileLabel.Name = "AttachmentFileLabel";
            this.AttachmentFileLabel.Size = new System.Drawing.Size(0, 17);
            this.AttachmentFileLabel.TabIndex = 36;
            // 
            // FileAttachment
            // 
            this.FileAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileAttachment.Image = ((System.Drawing.Image)(resources.GetObject("FileAttachment.Image")));
            this.FileAttachment.Location = new System.Drawing.Point(12, 419);
            this.FileAttachment.Name = "FileAttachment";
            this.FileAttachment.Size = new System.Drawing.Size(47, 43);
            this.FileAttachment.TabIndex = 35;
            this.FileAttachment.UseVisualStyleBackColor = true;
            this.FileAttachment.Click += new System.EventHandler(this.FileAttachment_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(13, 65);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(597, 345);
            this.webBrowser1.TabIndex = 37;
            // 
            // ReadMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 474);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.AttachmentFileLabel);
            this.Controls.Add(this.FileAttachment);
            this.Controls.Add(this.TextLetter);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email_client);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReadMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReadMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox theme;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox email_client;
        public System.Windows.Forms.RichTextBox TextLetter;
        public System.Windows.Forms.Label AttachmentFileLabel;
        public System.Windows.Forms.Button FileAttachment;
        public System.Windows.Forms.WebBrowser webBrowser1;
    }
}