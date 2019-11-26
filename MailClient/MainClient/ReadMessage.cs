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
    }
}