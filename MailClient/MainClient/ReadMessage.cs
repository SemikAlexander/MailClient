using System;
using MimeKit;
using System.Windows.Forms;

namespace MainClient
{
    public partial class ReadMessage : Form
    {
        public MimeMessage MimeMessage;
        public ReadMessage()
        {
            InitializeComponent();
        }

        private void AlginLeft_Click(object sender, EventArgs e)
        {
            TextLetter.TextAlign = HorizontalAlignment.Left;
        }

        private void AlginCenter_Click(object sender, EventArgs e)
        {
            TextLetter.TextAlign = HorizontalAlignment.Center;
        }

        private void AlginRight_Click(object sender, EventArgs e)
        {
            TextLetter.TextAlign = HorizontalAlignment.Right;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            TextLetter.Font = new System.Drawing.Font("Century Gothic", (float)UserFontSize.Value);
        }
    }
}
