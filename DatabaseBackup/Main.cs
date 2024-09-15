using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseBackup.App_Data;


namespace DatabaseBackup
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }
        App_Databases backup = new App_Databases();
        App_Data.MailerNode mailerNode = new App_Data.MailerNode();
        App_Data.ParentNode parentNode = new App_Data.ParentNode();
        App_Data.MySQLNode mySQLNode = new App_Data.MySQLNode();
        App_XMLCaller xml = new App_XMLCaller();
        App_CMD cmd = new App_CMD();




        private void Main_Load(object sender, EventArgs e)
        {
            App_Data.CreatePath();
            App_Databases.CreatePath();

            textBox_backup_location.Text = xml.GetBackupLocationOrDefault();
            textBox_mysql_hostname.Text = xml.GetHostNameOrDefault();
            textBox_mysql_username.Text = xml.GetUsernameOrDefault();
            textBox_mysql_password.Text = xml.GetPasswordOrDefault();
            comboBox_backup_schedule.Text = xml.GetBackupScheduleOrDefault();
            textBox_mysql_port.Text = xml.GetPortOrDefault();
            checkBox_overwrite_backup_filename.Checked = xml.GetOverwriteBackupOrDefault();
            backup.bind(dataGridView1);
            dataGridView1.ClearSelection();
        }
        private void button_choose_path(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_backup_location.Text = folderBrowserDialog.SelectedPath;
            }
        }
        private void button_save_settings_Click(object sender, EventArgs e)
        {
            try
            {
                string user = textBox_mysql_username.Text;
                string password = textBox_mysql_password.Text;
                string hostname = textBox_mysql_hostname.Text;
                string port = textBox_mysql_port.Text;

                if (backup.mysql_login_success(user, password, hostname, port))
                {
                    parentNode.update(textBox_backup_location.Text, comboBox_backup_schedule.Text, checkBox_overwrite_backup_filename.Checked.ToString());
                    mySQLNode.update(textBox_mysql_username.Text, textBox_mysql_password.Text, textBox_mysql_hostname.Text, textBox_mysql_port.Text);
                    MessageBox.Show("Settings has been saved successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            label_ampm.Text = DateTime.Now.ToString("tt");
            label_time.Text = DateTime.Now.ToString("hh:mm:ss");
            if (
                DateTime.Now.ToString("hh tt").ToUpper() == xml.GetBackupScheduleOrDefault() &&
                DateTime.Now.ToString("mm").ToUpper() == "01" &&
                DateTime.Now.ToString("ss").ToUpper() == "01")
            {
          
                DataTable table = (DataTable)dataGridView1.DataSource;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    try
                    {
                        string databasename = table.Rows[i]["DatabaseName"].ToString();
                        string backupLocation = xml.GetBackupLocationOrDefault();
                        string fullpath = backupLocation + "\\" + databasename;
                        if (Directory.Exists(fullpath))
                        {
                          
                            cmd.command(databasename, false);
                            await Task.Delay(5000);

                            List<string> attachments = new List<string>();
                            attachments.Add(fullpath + "\\" + databasename + ".sql");
                            App_Mailer mailer = new App_Mailer();
                            await mailer.Send(xml.GetEmailOrDefault(), $"Your Database Backup {databasename}", attachments, true);
                        }
                    }
                    catch { }
                }
            }
        }



        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                backup.CellContent(sender, e);
            }
        }
        private void Action_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            backup.ItemClicked(sender, e);
            backup.bind(dataGridView1);
        }
        public static string Selected_Database = "";
        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Columns[1].ReadOnly = true;   //PARA HINDI MAKAPAG EDIT SA GRIDVIEW
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].ReadOnly = false;//INSERT ONLY LANG
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].ContextMenuStrip = null;
                    dataGridView1.Rows[i].ContextMenuStrip = null;
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
                {
                    dataGridView1.Rows[e.RowIndex].ContextMenuStrip = Action;
                    dataGridView1.Rows[e.RowIndex].ContextMenuStrip = Action;
                }
                Selected_Database = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }
        private void button_how_Click(object sender, EventArgs e)
        {
            string msg = "" +
                "1. How to create?\n" +
                "Double left click the cell [database name] of the table and type your database name then press enter.\n\n" +

                "2. How to delete?\n" +
                "Left click the row and right click and choose delete.\n\n" +

                "3. How to backup?\n" +
                "Set your backup time schedule and click the save setting button.\n\n" +

                "4. Manual backup?\n" +
                "Left click the row and backup button.\n\n" +

                "5. How to find backup files?\n" +
                "Left click the row and right click and choose path";

            MessageBox.Show(msg, "How to use", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_backup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Main.Selected_Database))
            {
                App_CMD cmd = new App_CMD();
                backup.create_backup_directory();
                cmd.command(Main.Selected_Database, true);
            }
            else
            {
                MessageBox.Show("Please select database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        EmailSettings emailSettings = new EmailSettings();
        private void button_email_settings_Click(object sender, EventArgs e)
        {
            if (!emailSettings.Visible)
            {
                emailSettings.Owner = this;
                emailSettings.Open();
            }
            else
            {
                emailSettings.BringToFront(); // Bring the form to the front if it is already visible
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            emailSettings.Close();
        }

        private void textBox_mysql_port_TextChanged(object sender, EventArgs e)
        {
            string text = textBox_mysql_port.Text;
            string newText = string.Empty;

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    newText += c;
                }
            }

            // Update the TextBox content if it has changed
            if (textBox_mysql_port.Text != newText)
            {
                textBox_mysql_port.Text = newText;
                textBox_mysql_port.SelectionStart = textBox_mysql_port.Text.Length; // Move cursor to the end
            }
        }
    }
}
