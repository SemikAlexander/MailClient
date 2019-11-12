namespace MainClient
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
            this.Send = new System.Windows.Forms.Button();
            this.FileAttachment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextLetter
            // 
            this.TextLetter.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextLetter.Location = new System.Drawing.Point(12, 68);
            this.TextLetter.Multiline = true;
            this.TextLetter.Name = "TextLetter";
            this.TextLetter.Size = new System.Drawing.Size(539, 228);
            this.TextLetter.TabIndex = 14;
            // 
            // theme
            // 
            this.theme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.theme.Location = new System.Drawing.Point(63, 40);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(488, 22);
            this.theme.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Тема:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Кому:";
            // 
            // email_client
            // 
            this.email_client.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_client.Location = new System.Drawing.Point(65, 12);
            this.email_client.Name = "email_client";
            this.email_client.Size = new System.Drawing.Size(486, 22);
            this.email_client.TabIndex = 10;
            // 
            // Send
            // 
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send.Image = global::MainClient.Properties.Resources.SendMessage;
            this.Send.Location = new System.Drawing.Point(504, 302);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(47, 43);
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
            this.FileAttachment.Size = new System.Drawing.Size(47, 43);
            this.FileAttachment.TabIndex = 15;
            this.FileAttachment.UseVisualStyleBackColor = true;
            this.FileAttachment.Click += new System.EventHandler(this.button1_Click);
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(563, 357);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SendMessage_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button Send;
        public System.Windows.Forms.Button FileAttachment;
        public System.Windows.Forms.TextBox TextLetter;
        public System.Windows.Forms.TextBox theme;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox email_client;
    }
}