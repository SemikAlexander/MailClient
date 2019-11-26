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
            this.label3 = new System.Windows.Forms.Label();
            this.UserFontSize = new System.Windows.Forms.NumericUpDown();
            this.BoldButton = new System.Windows.Forms.Button();
            this.ItalicButton = new System.Windows.Forms.Button();
            this.UnderlineButton = new System.Windows.Forms.Button();
            this.AlginLeft = new System.Windows.Forms.Button();
            this.AlginCenter = new System.Windows.Forms.Button();
            this.AlginRight = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.FileAttachment = new System.Windows.Forms.Button();
            this.FontsComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // TextLetter
            // 
            this.TextLetter.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextLetter.Location = new System.Drawing.Point(12, 109);
            this.TextLetter.Multiline = true;
            this.TextLetter.Name = "TextLetter";
            this.TextLetter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextLetter.Size = new System.Drawing.Size(598, 242);
            this.TextLetter.TabIndex = 14;
            // 
            // theme
            // 
            this.theme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.theme.Location = new System.Drawing.Point(63, 40);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(547, 22);
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
            this.email_client.Size = new System.Drawing.Size(545, 22);
            this.email_client.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Размер шрифта:";
            // 
            // UserFontSize
            // 
            this.UserFontSize.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserFontSize.Location = new System.Drawing.Point(129, 74);
            this.UserFontSize.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.UserFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.UserFontSize.Name = "UserFontSize";
            this.UserFontSize.Size = new System.Drawing.Size(46, 22);
            this.UserFontSize.TabIndex = 28;
            this.UserFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserFontSize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.UserFontSize.ValueChanged += new System.EventHandler(this.UserFontSize_ValueChanged);
            // 
            // BoldButton
            // 
            this.BoldButton.FlatAppearance.BorderSize = 0;
            this.BoldButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoldButton.Image = global::MainClient.Properties.Resources.Bold;
            this.BoldButton.Location = new System.Drawing.Point(523, 72);
            this.BoldButton.Name = "BoldButton";
            this.BoldButton.Size = new System.Drawing.Size(25, 25);
            this.BoldButton.TabIndex = 32;
            this.BoldButton.UseVisualStyleBackColor = true;
            this.BoldButton.Click += new System.EventHandler(this.BoldButton_Click);
            // 
            // ItalicButton
            // 
            this.ItalicButton.FlatAppearance.BorderSize = 0;
            this.ItalicButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItalicButton.Image = global::MainClient.Properties.Resources.Italic;
            this.ItalicButton.Location = new System.Drawing.Point(554, 72);
            this.ItalicButton.Name = "ItalicButton";
            this.ItalicButton.Size = new System.Drawing.Size(25, 25);
            this.ItalicButton.TabIndex = 31;
            this.ItalicButton.UseVisualStyleBackColor = true;
            this.ItalicButton.Click += new System.EventHandler(this.ItalicButton_Click);
            // 
            // UnderlineButton
            // 
            this.UnderlineButton.FlatAppearance.BorderSize = 0;
            this.UnderlineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnderlineButton.Image = global::MainClient.Properties.Resources.Underline;
            this.UnderlineButton.Location = new System.Drawing.Point(585, 72);
            this.UnderlineButton.Name = "UnderlineButton";
            this.UnderlineButton.Size = new System.Drawing.Size(25, 25);
            this.UnderlineButton.TabIndex = 30;
            this.UnderlineButton.UseVisualStyleBackColor = true;
            this.UnderlineButton.Click += new System.EventHandler(this.UnderlineButton_Click);
            // 
            // AlginLeft
            // 
            this.AlginLeft.FlatAppearance.BorderSize = 0;
            this.AlginLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlginLeft.Image = global::MainClient.Properties.Resources.AlginTextLeft;
            this.AlginLeft.Location = new System.Drawing.Point(400, 65);
            this.AlginLeft.Name = "AlginLeft";
            this.AlginLeft.Size = new System.Drawing.Size(35, 35);
            this.AlginLeft.TabIndex = 27;
            this.AlginLeft.UseVisualStyleBackColor = true;
            this.AlginLeft.Click += new System.EventHandler(this.AlginLeft_Click);
            // 
            // AlginCenter
            // 
            this.AlginCenter.FlatAppearance.BorderSize = 0;
            this.AlginCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlginCenter.Image = global::MainClient.Properties.Resources.AlginTextCenter;
            this.AlginCenter.Location = new System.Drawing.Point(441, 65);
            this.AlginCenter.Name = "AlginCenter";
            this.AlginCenter.Size = new System.Drawing.Size(35, 35);
            this.AlginCenter.TabIndex = 26;
            this.AlginCenter.UseVisualStyleBackColor = true;
            this.AlginCenter.Click += new System.EventHandler(this.AlginCenter_Click);
            // 
            // AlginRight
            // 
            this.AlginRight.FlatAppearance.BorderSize = 0;
            this.AlginRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlginRight.Image = global::MainClient.Properties.Resources.AlginTextRight;
            this.AlginRight.Location = new System.Drawing.Point(482, 65);
            this.AlginRight.Name = "AlginRight";
            this.AlginRight.Size = new System.Drawing.Size(35, 35);
            this.AlginRight.TabIndex = 25;
            this.AlginRight.UseVisualStyleBackColor = true;
            this.AlginRight.Click += new System.EventHandler(this.AlginRight_Click);
            // 
            // Send
            // 
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send.Image = global::MainClient.Properties.Resources.SendMessage;
            this.Send.Location = new System.Drawing.Point(563, 357);
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
            this.FileAttachment.Location = new System.Drawing.Point(12, 357);
            this.FileAttachment.Name = "FileAttachment";
            this.FileAttachment.Size = new System.Drawing.Size(47, 43);
            this.FileAttachment.TabIndex = 15;
            this.FileAttachment.UseVisualStyleBackColor = true;
            this.FileAttachment.Click += new System.EventHandler(this.button1_Click);
            // 
            // FontsComboBox
            // 
            this.FontsComboBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FontsComboBox.FormattingEnabled = true;
            this.FontsComboBox.Location = new System.Drawing.Point(199, 71);
            this.FontsComboBox.Name = "FontsComboBox";
            this.FontsComboBox.Size = new System.Drawing.Size(182, 25);
            this.FontsComboBox.TabIndex = 33;
            this.FontsComboBox.SelectedIndexChanged += new System.EventHandler(this.FontsComboBox_SelectedIndexChanged);
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(622, 412);
            this.Controls.Add(this.FontsComboBox);
            this.Controls.Add(this.BoldButton);
            this.Controls.Add(this.ItalicButton);
            this.Controls.Add(this.UnderlineButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserFontSize);
            this.Controls.Add(this.AlginLeft);
            this.Controls.Add(this.AlginCenter);
            this.Controls.Add(this.AlginRight);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.FileAttachment);
            this.Controls.Add(this.TextLetter);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email_client);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendMessage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SendMessage_FormClosing);
            this.Load += new System.EventHandler(this.SendMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UserFontSize)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UserFontSize;
        private System.Windows.Forms.Button AlginLeft;
        private System.Windows.Forms.Button AlginCenter;
        private System.Windows.Forms.Button AlginRight;
        private System.Windows.Forms.Button BoldButton;
        private System.Windows.Forms.Button ItalicButton;
        private System.Windows.Forms.Button UnderlineButton;
        private System.Windows.Forms.ComboBox FontsComboBox;
    }
}