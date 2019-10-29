namespace MainClient
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.connectionOptions = new System.Windows.Forms.GroupBox();
            this.IMAPPortLabel = new System.Windows.Forms.Label();
            this.imapPort = new System.Windows.Forms.TextBox();
            this.POP3PortLabel = new System.Windows.Forms.Label();
            this.SMTPPortLabel = new System.Windows.Forms.Label();
            this.imapAdress = new System.Windows.Forms.TextBox();
            this.pop3Port = new System.Windows.Forms.TextBox();
            this.pop3Adress = new System.Windows.Forms.TextBox();
            this.smtpPort = new System.Windows.Forms.TextBox();
            this.smtpAdress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imap = new System.Windows.Forms.RadioButton();
            this.pop3 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.RestoreLinkLabel = new System.Windows.Forms.LinkLabel();
            this.connectionOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionOptions
            // 
            this.connectionOptions.Controls.Add(this.IMAPPortLabel);
            this.connectionOptions.Controls.Add(this.imapPort);
            this.connectionOptions.Controls.Add(this.POP3PortLabel);
            this.connectionOptions.Controls.Add(this.SMTPPortLabel);
            this.connectionOptions.Controls.Add(this.imapAdress);
            this.connectionOptions.Controls.Add(this.pop3Port);
            this.connectionOptions.Controls.Add(this.pop3Adress);
            this.connectionOptions.Controls.Add(this.smtpPort);
            this.connectionOptions.Controls.Add(this.smtpAdress);
            this.connectionOptions.Controls.Add(this.label3);
            this.connectionOptions.Controls.Add(this.label2);
            this.connectionOptions.Controls.Add(this.label1);
            this.connectionOptions.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectionOptions.Location = new System.Drawing.Point(12, 12);
            this.connectionOptions.Name = "connectionOptions";
            this.connectionOptions.Size = new System.Drawing.Size(303, 214);
            this.connectionOptions.TabIndex = 2;
            this.connectionOptions.TabStop = false;
            this.connectionOptions.Text = "Параметры подключения";
            // 
            // IMAPPortLabel
            // 
            this.IMAPPortLabel.AutoSize = true;
            this.IMAPPortLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IMAPPortLabel.Location = new System.Drawing.Point(0, 174);
            this.IMAPPortLabel.Name = "IMAPPortLabel";
            this.IMAPPortLabel.Size = new System.Drawing.Size(87, 21);
            this.IMAPPortLabel.TabIndex = 53;
            this.IMAPPortLabel.Text = "Port IMAP";
            // 
            // imapPort
            // 
            this.imapPort.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imapPort.Location = new System.Drawing.Point(96, 175);
            this.imapPort.Name = "imapPort";
            this.imapPort.Size = new System.Drawing.Size(192, 23);
            this.imapPort.TabIndex = 52;
            this.imapPort.TextChanged += new System.EventHandler(this.imapPort_TextChanged);
            this.imapPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.imapPort_KeyPress);
            // 
            // POP3PortLabel
            // 
            this.POP3PortLabel.AutoSize = true;
            this.POP3PortLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.POP3PortLabel.Location = new System.Drawing.Point(1, 116);
            this.POP3PortLabel.Name = "POP3PortLabel";
            this.POP3PortLabel.Size = new System.Drawing.Size(86, 21);
            this.POP3PortLabel.TabIndex = 51;
            this.POP3PortLabel.Text = "Port POP3";
            // 
            // SMTPPortLabel
            // 
            this.SMTPPortLabel.AutoSize = true;
            this.SMTPPortLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SMTPPortLabel.Location = new System.Drawing.Point(2, 58);
            this.SMTPPortLabel.Name = "SMTPPortLabel";
            this.SMTPPortLabel.Size = new System.Drawing.Size(85, 21);
            this.SMTPPortLabel.TabIndex = 50;
            this.SMTPPortLabel.Text = "Port SMTP";
            // 
            // imapAdress
            // 
            this.imapAdress.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imapAdress.Location = new System.Drawing.Point(96, 146);
            this.imapAdress.Name = "imapAdress";
            this.imapAdress.Size = new System.Drawing.Size(192, 23);
            this.imapAdress.TabIndex = 49;
            this.imapAdress.TextChanged += new System.EventHandler(this.imapAdress_TextChanged);
            // 
            // pop3Port
            // 
            this.pop3Port.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pop3Port.Location = new System.Drawing.Point(96, 117);
            this.pop3Port.Name = "pop3Port";
            this.pop3Port.Size = new System.Drawing.Size(192, 23);
            this.pop3Port.TabIndex = 48;
            this.pop3Port.TextChanged += new System.EventHandler(this.pop3Port_TextChanged);
            this.pop3Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pop3Port_KeyPress);
            // 
            // pop3Adress
            // 
            this.pop3Adress.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pop3Adress.Location = new System.Drawing.Point(96, 88);
            this.pop3Adress.Name = "pop3Adress";
            this.pop3Adress.Size = new System.Drawing.Size(192, 23);
            this.pop3Adress.TabIndex = 47;
            this.pop3Adress.TextChanged += new System.EventHandler(this.pop3Adress_TextChanged);
            // 
            // smtpPort
            // 
            this.smtpPort.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smtpPort.Location = new System.Drawing.Point(96, 59);
            this.smtpPort.Name = "smtpPort";
            this.smtpPort.Size = new System.Drawing.Size(192, 23);
            this.smtpPort.TabIndex = 46;
            this.smtpPort.TextChanged += new System.EventHandler(this.smtpPort_TextChanged);
            this.smtpPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.smtpPort_KeyPress);
            // 
            // smtpAdress
            // 
            this.smtpAdress.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smtpAdress.Location = new System.Drawing.Point(96, 30);
            this.smtpAdress.Name = "smtpAdress";
            this.smtpAdress.Size = new System.Drawing.Size(192, 23);
            this.smtpAdress.TabIndex = 45;
            this.smtpAdress.TextChanged += new System.EventHandler(this.smtpAdress_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(35, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 44;
            this.label3.Text = "IMAP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(36, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 43;
            this.label2.Text = "POP3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 42;
            this.label1.Text = "SMTP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imap);
            this.groupBox2.Controls.Add(this.pop3);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 83);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Тип приёма почты";
            // 
            // imap
            // 
            this.imap.AutoSize = true;
            this.imap.Location = new System.Drawing.Point(21, 53);
            this.imap.Name = "imap";
            this.imap.Size = new System.Drawing.Size(67, 24);
            this.imap.TabIndex = 4;
            this.imap.TabStop = true;
            this.imap.Text = "IMAP";
            this.imap.UseVisualStyleBackColor = true;
            // 
            // pop3
            // 
            this.pop3.AutoSize = true;
            this.pop3.Location = new System.Drawing.Point(21, 25);
            this.pop3.Name = "pop3";
            this.pop3.Size = new System.Drawing.Size(66, 24);
            this.pop3.TabIndex = 3;
            this.pop3.TabStop = true;
            this.pop3.Text = "POP3";
            this.pop3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(63, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RestoreLinkLabel
            // 
            this.RestoreLinkLabel.AutoSize = true;
            this.RestoreLinkLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RestoreLinkLabel.Location = new System.Drawing.Point(91, 377);
            this.RestoreLinkLabel.Name = "RestoreLinkLabel";
            this.RestoreLinkLabel.Size = new System.Drawing.Size(225, 17);
            this.RestoreLinkLabel.TabIndex = 5;
            this.RestoreLinkLabel.TabStop = true;
            this.RestoreLinkLabel.Text = "Восстановить начальные настройки";
            this.RestoreLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 403);
            this.Controls.Add(this.RestoreLinkLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.connectionOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(344, 442);
            this.MinimumSize = new System.Drawing.Size(344, 442);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.connectionOptions.ResumeLayout(false);
            this.connectionOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox connectionOptions;
        private System.Windows.Forms.Label IMAPPortLabel;
        public System.Windows.Forms.TextBox imapPort;
        private System.Windows.Forms.Label POP3PortLabel;
        private System.Windows.Forms.Label SMTPPortLabel;
        public System.Windows.Forms.TextBox imapAdress;
        public System.Windows.Forms.TextBox pop3Port;
        public System.Windows.Forms.TextBox pop3Adress;
        public System.Windows.Forms.TextBox smtpPort;
        public System.Windows.Forms.TextBox smtpAdress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton imap;
        private System.Windows.Forms.RadioButton pop3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel RestoreLinkLabel;
    }
}