using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseBackup.App_Data;

namespace DatabaseBackup
{
    class App_CMD
    {

        App_XMLCaller xml = new App_XMLCaller();
        void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public async void open_folder(string DatabaseName)
        {
            await Task.Run(() =>
            {
                string backup_location = xml.GetBackupLocationOrDefault();
                ProcessStartInfo processStart = new ProcessStartInfo(@"C:\Windows\system32\cmd.exe");
                processStart.WindowStyle = ProcessWindowStyle.Hidden;
                string destination = backup_location + "\\" + Main.Selected_Database + "\\";
                CreateDirectoryIfNotExists(destination);
                processStart.Arguments = string.Format("/C start " + destination);
                Process.Start(processStart);
            });
        }
        public async void command(string DatabaseName, bool showmessage)
        {
            await Task.Run(async () =>
            {
                string backup_location = xml.GetBackupLocationOrDefault();
                string Hostname = xml.GetHostNameOrDefault();
                string Port = xml.GetPortOrDefault();
                string user = xml.GetUsernameOrDefault();
                string password = xml.GetPasswordOrDefault();
                bool Overtwrite_Backup = xml.GetOverwriteBackupOrDefault();


                CreateDirectoryIfNotExists(backup_location);
                string destination = backup_location + "\\" + DatabaseName + "\\";
                CreateDirectoryIfNotExists(destination);

                string save_file = destination + "\\" + DatabaseName + ".sql";
                if (Overtwrite_Backup == false)
                {
                    save_file = destination + "\\" + DatabaseName + "_" + DateTime.Now.ToString("yyyy_MMM_dd") + ".sql";
                }

                string mysqldumpCommand = $"mysqldump -h {Hostname} -P {Port} --user={user} --password={password} {DatabaseName} > \"{save_file}\"";
                ProcessStartInfo processStart = new ProcessStartInfo(@"C:\Windows\system32\cmd.exe");
                processStart.WindowStyle = ProcessWindowStyle.Hidden;
                //processStart.Verb = "runas"; 
                processStart.Arguments = @"/K cd " + Environment.CurrentDirectory + " & ";
                processStart.Arguments += mysqldumpCommand;
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
