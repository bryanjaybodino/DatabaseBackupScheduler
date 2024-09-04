﻿using System;
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
using static System.Net.WebRequestMethods;

namespace DatabaseBackup
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }
        BackupList backupList = new BackupList();
        App_Data.ParentNode parentNode = new App_Data.ParentNode();
        App_Data.MySQLNode mySQLNode = new App_Data.MySQLNode();
        App_Data.MailerNode mailerNode = new App_Data.MailerNode();
        private void Main_Load(object sender, EventArgs e)
        {
            App_Data.CreatePath();
            BackupList.CreatePath();

            textBox_backup_location.Text = parentNode.data(App_Data.ParentNode.node.BackupLocation);
            textBox_mysql_folder_location.Text = mySQLNode.data(App_Data.MySQLNode.node.Location);
            textBox_mysql_username.Text = mySQLNode.data(App_Data.MySQLNode.node.User);
            textBox_mysql_password.Text = mySQLNode.data(App_Data.MySQLNode.node.Password);
            comboBox_backup_schedule.Text = parentNode.data(App_Data.ParentNode.node.BackupSchedule);

            textBox_email_account.Text = mailerNode.data(App_Data.MailerNode.node.Email);
            textBox_email_password.Text = mailerNode.data(App_Data.MailerNode.node.Password);



            bool Overtwrite_Backup = (parentNode.data(App_Data.ParentNode.node.OverwriteBackup).ToUpper() == "TRUE") ? true : false;
            checkBox_overwrite_backup_filename.Checked = Overtwrite_Backup;
            backupList.bind(dataGridView1);
            dataGridView1.ClearSelection();
        }
        private void button_choose_path(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (button.Name == "button_choose_backup_location")
                {
                    textBox_backup_location.Text = folderBrowserDialog.SelectedPath;
                }
                else if (button.Name == "button_choose_mysql_location")
                {
                    textBox_mysql_folder_location.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
        private void button_save_settings_Click(object sender, EventArgs e)
        {
            parentNode.update(textBox_backup_location.Text, comboBox_backup_schedule.Text, checkBox_overwrite_backup_filename.Checked.ToString());
            mySQLNode.update(textBox_mysql_username.Text, textBox_mysql_password.Text, textBox_mysql_folder_location.Text);
            mailerNode.update(textBox_email_account.Text, textBox_email_password.Text);
            MessageBox.Show("Settings has been saved successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            label_ampm.Text = DateTime.Now.ToString("tt");
            label_time.Text = DateTime.Now.ToString("hh:mm:ss");
            if (
                //DateTime.Now.ToString("hh tt").ToUpper() == parentNode.data(App_Data.ParentNode.node.BackupSchedule) &&
                //DateTime.Now.ToString("mm").ToUpper() == "01" &&
                DateTime.Now.ToString("ss").ToUpper() == "01")
            {
                CMD cmd = new CMD();
                DataTable table = (DataTable)dataGridView1.DataSource;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    try
                    {
                        string databasename = table.Rows[i]["DatabaseName"].ToString();
                        string backupLocation = parentNode.data(App_Data.ParentNode.node.BackupLocation);
                        string fullpath = backupLocation + "\\" + databasename;
                        if (Directory.Exists(fullpath))
                        {
                            cmd.command(databasename, false);
                            await Task.Delay(5000);

                            List<string> attachments = new List<string>();
                            attachments.Add(fullpath + "\\" + databasename + ".sql");
                            Mailer mailer = new Mailer();
                            await mailer.Send(mailerNode.data(App_Data.MailerNode.node.Email), "", databasename, "Your Database Backup", attachments, true);
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
                backupList.CellContent(sender, e);
            }
        }
        private void Action_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            backupList.ItemClicked(sender, e);
            backupList.bind(dataGridView1);
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

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control && e.Shift)
            {

            }
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
                "Left click the row and right click and choose backup.\n" +

                "5. How to find backup files?\n" +
                "Left click the row and right click and choose path";

            MessageBox.Show(msg, "How to use", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
