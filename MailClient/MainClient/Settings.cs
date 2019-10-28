using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainClient
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        #region LogicsOfSettingsForm
        private void smtpPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void pop3Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void imapPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void smtpPort_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(smtpPort.Text))
                SMTPPortLabel.ForeColor = Color.Red;
            else
                SMTPPortLabel.ForeColor = SystemColors.ControlText;
        }
        private void pop3Port_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pop3Port.Text))
                POP3PortLabel.ForeColor = Color.Red;
            else
                POP3PortLabel.ForeColor = SystemColors.ControlText;
        }
        private void imapPort_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(imapPort.Text))
                IMAPPortLabel.ForeColor = Color.Red;
            else
                IMAPPortLabel.ForeColor = SystemColors.ControlText;
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            smtpAdress.Text = "smtp.yandex.ru";
            pop3Adress.Text = "pop.yandex.ru";
            imapAdress.Text = "imap.yandex.ru";
            smtpPort.Text = "465";
            pop3Port.Text = "995";
            imapPort.Text = "993";
            pop3.Checked = true;
        }
    }
}