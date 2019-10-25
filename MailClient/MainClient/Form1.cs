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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(mailTextBox.Text) & !string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                /*Check*/
            }
            else
            {
                MessageBox.Show("Не все поля заполены!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
