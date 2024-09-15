using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DatabaseBackup
{
    public partial class EmailSettings : Form
    {
        public EmailSettings()
        {
            InitializeComponent();
        }

        App_Data.MailerNode mailerNode = new App_Data.MailerNode();
        App_XMLCaller xml = new App_XMLCaller();
        public void Open()
        {
            textBox_email_account.Text = xml.GetEmailOrDefault();
            textBox_email_password.Text = xml.GetEmailPasswordOrDefault();
            textBox_email_subject.Text = xml.GetEmailSubjectOrDefault();
            textBox_email_cc.Text = xml.GetEmailCCOrDefault();
            this.Show();
        }
        private void button_get_email_password_Click(object sender, EventArgs e)
        {


            // Specify the URL you want to open
            string url = "https://myaccount.google.com/apppasswords";

            try
            {
                // Open the URL in the default web browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // This is necessary for .NET Core/5+
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Not supporte you can manual type the link\n\n{url}");
            }

        }

        private void button_save_settings_Click(object sender, EventArgs e)
        {
            try
            {
                mailerNode.update(textBox_email_account.Text, textBox_email_password.Text, textBox_email_subject.Text, textBox_email_cc.Text);
                MessageBox.Show("Email has been saved successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private async void button_send_test_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Wait..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            App_Mailer app_Mailer = new App_Mailer();
            mailerNode.update(textBox_email_account.Text, textBox_email_password.Text, textBox_email_subject.Text, textBox_email_cc.Text);
            await app_Mailer.Send(xml.GetEmailOrDefault(), "Database Backup Test Message", null,true,true);
        }
    }
}
