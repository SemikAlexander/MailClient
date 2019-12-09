namespace MainClient
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.дляПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.библиотекаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправкаСообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.синхронизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.безопасностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмRSAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оРазработчикеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дляПользователяToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.оРазработчикеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // дляПользователяToolStripMenuItem
            // 
            this.дляПользователяToolStripMenuItem.Name = "дляПользователяToolStripMenuItem";
            this.дляПользователяToolStripMenuItem.Size = new System.Drawing.Size(123, 21);
            this.дляПользователяToolStripMenuItem.Text = "Для пользователя";
            this.дляПользователяToolStripMenuItem.Click += new System.EventHandler(this.дляПользователяToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.библиотекаToolStripMenuItem,
            this.отправкаСообщенияToolStripMenuItem,
            this.синхронизацияToolStripMenuItem,
            this.безопасностьToolStripMenuItem,
            this.базаДанныхToolStripMenuItem});
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(112, 21);
            this.информацияToolStripMenuItem.Text = "Дополнительно";
            // 
            // библиотекаToolStripMenuItem
            // 
            this.библиотекаToolStripMenuItem.Name = "библиотекаToolStripMenuItem";
            this.библиотекаToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.библиотекаToolStripMenuItem.Text = "Библиотека";
            this.библиотекаToolStripMenuItem.Click += new System.EventHandler(this.библиотекаToolStripMenuItem_Click);
            // 
            // отправкаСообщенияToolStripMenuItem
            // 
            this.отправкаСообщенияToolStripMenuItem.Name = "отправкаСообщенияToolStripMenuItem";
            this.отправкаСообщенияToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.отправкаСообщенияToolStripMenuItem.Text = "Отправка сообщения";
            this.отправкаСообщенияToolStripMenuItem.Click += new System.EventHandler(this.отправкаСообщенияToolStripMenuItem_Click);
            // 
            // синхронизацияToolStripMenuItem
            // 
            this.синхронизацияToolStripMenuItem.Name = "синхронизацияToolStripMenuItem";
            this.синхронизацияToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.синхронизацияToolStripMenuItem.Text = "Синхронизация";
            this.синхронизацияToolStripMenuItem.Click += new System.EventHandler(this.синхронизацияToolStripMenuItem_Click);
            // 
            // безопасностьToolStripMenuItem
            // 
            this.безопасностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.алгоритмRSAToolStripMenuItem,
            this.алгоритмToolStripMenuItem});
            this.безопасностьToolStripMenuItem.Name = "безопасностьToolStripMenuItem";
            this.безопасностьToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.безопасностьToolStripMenuItem.Text = "Безопасность";
            // 
            // алгоритмRSAToolStripMenuItem
            // 
            this.алгоритмRSAToolStripMenuItem.Name = "алгоритмRSAToolStripMenuItem";
            this.алгоритмRSAToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.алгоритмRSAToolStripMenuItem.Text = "Алгоритм RSA";
            this.алгоритмRSAToolStripMenuItem.Click += new System.EventHandler(this.алгоритмRSAToolStripMenuItem_Click);
            // 
            // алгоритмToolStripMenuItem
            // 
            this.алгоритмToolStripMenuItem.Name = "алгоритмToolStripMenuItem";
            this.алгоритмToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.алгоритмToolStripMenuItem.Text = "Алгоритм Rijndael";
            this.алгоритмToolStripMenuItem.Click += new System.EventHandler(this.алгоритмToolStripMenuItem_Click);
            // 
            // оРазработчикеToolStripMenuItem
            // 
            this.оРазработчикеToolStripMenuItem.Name = "оРазработчикеToolStripMenuItem";
            this.оРазработчикеToolStripMenuItem.Size = new System.Drawing.Size(118, 21);
            this.оРазработчикеToolStripMenuItem.Text = "О разработчике";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(776, 411);
            this.textBox1.TabIndex = 1;
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            this.базаДанныхToolStripMenuItem.Click += new System.EventHandler(this.базаДанныхToolStripMenuItem_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(816, 488);
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem дляПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem библиотекаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отправкаСообщенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem синхронизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem безопасностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмRSAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оРазработчикеToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
    }
}