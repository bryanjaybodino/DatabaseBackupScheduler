using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseBackup
{
    class CMD
    {

        public async void open_folder(string DatabaseName)
        {
            await Task.Run(() =>
            {
                App_Data.ParentNode parentNode = new App_Data.ParentNode();
                string backup_location = parentNode.data(App_Data.ParentNode.node.BackupLocation);
                ProcessStartInfo processStart = new ProcessStartInfo(@"C:\Windows\system32\cmd.exe");
                processStart.WindowStyle = ProcessWindowStyle.Hidden;
                string destination = backup_location + "\\" + Main.Selected_Database + "\\";
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }
                processStart.Arguments = string.Format("/C start " + destination);
                Process.Start(processStart);
            });
        }
        public async void command(string DatabaseName, bool showmessage)
        {
            await Task.Run(async () =>
            {
                App_Data.ParentNode parentNode = new App_Data.ParentNode();
                App_Data.MySQLNode mySQLNode = new App_Data.MySQLNode();
                string backup_location = parentNode.data(App_Data.ParentNode.node.BackupLocation);
                string mysql_location = mySQLNode.data(App_Data.MySQLNode.node.Location);
                string user = mySQLNode.data(App_Data.MySQLNode.node.User);
                string password = mySQLNode.data(App_Data.MySQLNode.node.Password);
                bool Overtwrite_Backup = (parentNode.data(App_Data.ParentNode.node.OverwriteBackup).ToUpper() == "TRUE") ? true : false;


                if (!Directory.Exists(backup_location))
                {
                    Directory.CreateDirectory(backup_location);
                }
                string destination = backup_location + "\\" + DatabaseName + "\\";
                if (!Directory.Exists(destination))
                {
                    Directory.CreateDirectory(destination);
                }
                string save_file = destination + "\\" + DatabaseName + ".sql";
                if (Overtwrite_Backup == false)
                {
                    save_file = destination + "\\" + DatabaseName + "_" + DateTime.Now.ToString("yyyy_MMM_dd") + ".sql";
                }

                ProcessStartInfo processStart = new ProcessStartInfo(@"C:\Windows\system32\cmd.exe");
                processStart.WindowStyle = ProcessWindowStyle.Hidden;
                //processStart.Verb = "runas"; 
                processStart.Arguments = @"/K cd " + mysql_location + " & ";
                processStart.Arguments += "mysqldump --user=" + user + " --password=" + password + " " + DatabaseName + ">" + save_file;
                Process.Start(processStart);

                if (showmessage == true)
                {
                    bool loop = true;
                    while (loop)
                    {
                        if (File.Exists(save_file) == true)
                        {
                            await Task.Delay(1000);//Wait the file has been save with value
                            FileInfo fileInfo = new FileInfo(save_file);
                            if (fileInfo.Length <= 0)
                            {
                                MessageBox.Show("Backup failed all possible reasons\n1. Wrong Mysql Folder Location\n2. Wrong Username or Password\n3. Database Name is deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (fileInfo.Length > 0)
                            {
                                MessageBox.Show("Database has been backup successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            loop = false;
                        }
                    }
                }
            });

        }
    }
}
