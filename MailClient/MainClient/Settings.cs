using System;
using System.Drawing;
using System.Windows.Forms;
using MainClient.Properties;

namespace MainClient
{
    public partial class SettingsForm : Form
    {
        string typeSettingForm;
        public SettingsForm(string type)
        {
            InitializeComponent();
            typeSettingForm = type;
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
        private void smtpAdress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(smtpAdress.Text))
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = SystemColors.ControlText;
        }
        private void pop3Adress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pop3Adress.Text))
                label2.ForeColor = Color.Red;
            else
                label2.ForeColor = SystemColors.ControlText;
        }
        private void imapAdress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(imapAdress.Text))
                label3.ForeColor = Color.Red;
            else
                label3.ForeColor = SystemColors.ControlText;
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Settings.Default["IMAPAdress"] = imapAdress.Text = "imap.yandex.ru";
            Settings.Default["POP3Adress"] = pop3Adress.Text = "pop.yandex.ru";
            Settings.Default["SMTPAdress"] = smtpAdress.Text = "smtp.yandex.ru";
            Settings.Default["IMAPPort"] = 993;
            Settings.Default["POP3Port"] = 995;
            Settings.Default["SMTPPort"] = 465;
            Settings.Default["POP3Checked"] = pop3.Checked = true;
            Settings.Default["IMAPChecked"] = imap.Checked = false;
            Settings.Default.Save();
            imapPort.Text = Settings.Default["IMAPPort"].ToString();
            pop3Port.Text = Settings.Default["POP3Port"].ToString();
            smtpPort.Text = Settings.Default["SMTPPort"].ToString();
            pop3.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if(control is GroupBox)
                {
                    foreach(Control control1 in control.Controls)
                    {
                        if (control1 is TextBox)
                        {
                            TextBox textbox = control1 as TextBox;
                            if (string.IsNullOrWhiteSpace(textbox.Text))
                            {
                                MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }
            if (typeSettingForm == "Add")
            {
                WorkWithDatabase workWithDatabase = new WorkWithDatabase();
                workWithDatabase.AddMailServer(imapAdress.Text, pop3Adress.Text, smtpAdress.Text, Convert.ToInt32(imapPort.Text), Convert.ToInt32(pop3Port.Text), Convert.ToInt32(smtpPort.Text));
            }
            Settings.Default["IMAPAdress"] = imapAdress.Text;
            Settings.Default["POP3Adress"] = pop3Adress.Text;
            Settings.Default["SMTPAdress"] = smtpAdress.Text;
            Settings.Default["IMAPPort"] = Convert.ToInt32(imapPort.Text);
            Settings.Default["POP3Port"] = Convert.ToInt32(pop3Port.Text);
            Settings.Default["SMTPPort"] = Convert.ToInt32(smtpPort.Text);
            Settings.Default["POP3Checked"] = pop3.Checked;
            Settings.Default["IMAPChecked"] = imap.Checked;
            Settings.Default.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            switch (typeSettingForm)
            {
                case "Add":
                    NameServerPanel.Visible = true;
                    break;
                case "Edit":
                    NameServerPanel.Visible = false;
                    imapAdress.Text = Settings.Default["IMAPAdress"].ToString();
                    pop3Adress.Text = Settings.Default["POP3Adress"].ToString();
                    smtpAdress.Text = Settings.Default["SMTPAdress"].ToString();
                    imapPort.Text = Settings.Default["IMAPPort"].ToString();
                    pop3Port.Text = Settings.Default["POP3Port"].ToString();
                    smtpPort.Text = Settings.Default["SMTPPort"].ToString();
                    pop3.Checked = Convert.ToBoolean(Settings.Default["POP3Checked"]);
                    imap.Checked = Convert.ToBoolean(Settings.Default["IMAPChecked"]);
                    break;
            }
        }
    }
}