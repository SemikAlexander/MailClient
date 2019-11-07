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
            this.TextLetter = new System.Windows.Forms.TextBox();
            this.theme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.email_client = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextLetter
            // 
            this.TextLetter.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextLetter.Location = new System.Drawing.Point(18, 65);
            this.TextLetter.Multiline = true;
            this.TextLetter.Name = "TextLetter";
            this.TextLetter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextLetter.Size = new System.Drawing.Size(478, 275);
            this.TextLetter.TabIndex = 19;
            // 
            // theme
            // 
            this.theme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.theme.Location = new System.Drawing.Point(69, 37);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(425, 22);
            this.theme.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Тема:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "От:";
            // 
            // email_client
            // 
            this.email_client.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_client.Location = new System.Drawing.Point(69, 9);
            this.email_client.Name = "email_client";
            this.email_client.Size = new System.Drawing.Size(427, 22);
            this.email_client.TabIndex = 15;
            // 
            // ReadMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 352);
            this.Controls.Add(this.TextLetter);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email_client);
            this.Name = "ReadMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReadMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TextLetter;
        public System.Windows.Forms.TextBox theme;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox email_client;
    }
}