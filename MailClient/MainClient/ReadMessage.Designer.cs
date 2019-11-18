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
            this.AlginRight = new System.Windows.Forms.Button();
            this.AlginCenter = new System.Windows.Forms.Button();
            this.AlginLeft = new System.Windows.Forms.Button();
            this.UserFontSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // TextLetter
            // 
            this.TextLetter.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextLetter.Location = new System.Drawing.Point(12, 106);
            this.TextLetter.Multiline = true;
            this.TextLetter.Name = "TextLetter";
            this.TextLetter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextLetter.Size = new System.Drawing.Size(478, 287);
            this.TextLetter.TabIndex = 19;
            // 
            // theme
            // 
            this.theme.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.theme.Location = new System.Drawing.Point(71, 37);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(425, 22);
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
            this.email_client.Size = new System.Drawing.Size(427, 22);
            this.email_client.TabIndex = 15;
            // 
            // AlginRight
            // 
            this.AlginRight.FlatAppearance.BorderSize = 0;
            this.AlginRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlginRight.Image = global::MainClient.Properties.Resources.AlginTextRight;
            this.AlginRight.Location = new System.Drawing.Point(461, 65);
            this.AlginRight.Name = "AlginRight";
            this.AlginRight.Size = new System.Drawing.Size(35, 35);
            this.AlginRight.TabIndex = 20;
            this.AlginRight.UseVisualStyleBackColor = true;
            this.AlginRight.Click += new System.EventHandler(this.AlginRight_Click);
            // 
            // AlginCenter
            // 
            this.AlginCenter.FlatAppearance.BorderSize = 0;
            this.AlginCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlginCenter.Image = global::MainClient.Properties.Resources.AlginTextCenter;
            this.AlginCenter.Location = new System.Drawing.Point(420, 65);
            this.AlginCenter.Name = "AlginCenter";
            this.AlginCenter.Size = new System.Drawing.Size(35, 35);
            this.AlginCenter.TabIndex = 21;
            this.AlginCenter.UseVisualStyleBackColor = true;
            this.AlginCenter.Click += new System.EventHandler(this.AlginCenter_Click);
            // 
            // AlginLeft
            // 
            this.AlginLeft.FlatAppearance.BorderSize = 0;
            this.AlginLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlginLeft.Image = global::MainClient.Properties.Resources.AlginTextLeft;
            this.AlginLeft.Location = new System.Drawing.Point(379, 65);
            this.AlginLeft.Name = "AlginLeft";
            this.AlginLeft.Size = new System.Drawing.Size(35, 35);
            this.AlginLeft.TabIndex = 22;
            this.AlginLeft.UseVisualStyleBackColor = true;
            this.AlginLeft.Click += new System.EventHandler(this.AlginLeft_Click);
            // 
            // UserFontSize
            // 
            this.UserFontSize.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserFontSize.Location = new System.Drawing.Point(131, 72);
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
            this.UserFontSize.TabIndex = 23;
            this.UserFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserFontSize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.UserFontSize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Размер шрифта:";
            // 
            // ReadMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 405);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserFontSize);
            this.Controls.Add(this.AlginLeft);
            this.Controls.Add(this.AlginCenter);
            this.Controls.Add(this.AlginRight);
            this.Controls.Add(this.TextLetter);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email_client);
            this.Name = "ReadMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReadMessage";
            ((System.ComponentModel.ISupportInitialize)(this.UserFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox TextLetter;
        public System.Windows.Forms.TextBox theme;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox email_client;
        private System.Windows.Forms.Button AlginRight;
        private System.Windows.Forms.Button AlginCenter;
        private System.Windows.Forms.Button AlginLeft;
        private System.Windows.Forms.NumericUpDown UserFontSize;
        private System.Windows.Forms.Label label3;
    }
}