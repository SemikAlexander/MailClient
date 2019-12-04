using System;
using MimeKit;
using System.Windows.Forms;
using System.IO;

namespace MainClient
{
    public partial class ReadMessage : Form
    {
        public MimeMessage MimeMessage;
        public ReadMessage()
        {
            InitializeComponent();
        }

        private void FileAttachment_Click(object sender, EventArgs e)
        {
            foreach (MimeEntity attachment in MimeMessage.Attachments)
            {
                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string saveFile = $"{Path.GetDirectoryName(saveFileDialog.FileName)}\\{fileName}";
                    using (var stream = File.Create(saveFile))
                    {
                        if (attachment is MessagePart)
                        {
                            var rfc822 = (MessagePart)attachment;
                            rfc822.Message.WriteTo(stream);
                        }
                        else
                        {
                            var part = (MimePart)attachment;
                            part.Content.DecodeTo(stream);
                        }
                    }
                }
                
            }
        }
    }
}