using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DatabaseBackup.App_Data;

namespace DatabaseBackup
{
    public class App_XMLCaller
    {

        App_Data.MailerNode mailerNode = new App_Data.MailerNode();
        App_Data.ParentNode parentNode = new App_Data.ParentNode();
        App_Data.MySQLNode mySQLNode = new App_Data.MySQLNode();


        //MYSQL NODE
        public string GetPortOrDefault()
        {
            return string.IsNullOrWhiteSpace(mySQLNode.data(App_Data.MySQLNode.node.Port)) ? "3306" : mySQLNode.data(App_Data.MySQLNode.node.Port);
        }
        public string GetHostNameOrDefault()
        {
            return string.IsNullOrWhiteSpace(mySQLNode.data(App_Data.MySQLNode.node.Hostname)) ? "localhost" : mySQLNode.data(App_Data.MySQLNode.node.Hostname);
        }
        public string GetUsernameOrDefault()
        {
            return string.IsNullOrWhiteSpace(mySQLNode.data(App_Data.MySQLNode.node.User)) ? "root" : mySQLNode.data(App_Data.MySQLNode.node.User);
        }
        public string GetPasswordOrDefault()
        {
            return string.IsNullOrWhiteSpace(mySQLNode.data(App_Data.MySQLNode.node.Password)) ? "" : mySQLNode.data(App_Data.MySQLNode.node.Password);
        }


        //DATA NODES
        public string GetBackupLocationOrDefault()
        {
            return string.IsNullOrWhiteSpace(parentNode.data(App_Data.ParentNode.node.BackupLocation)) ? "C:\\Backup_Files" : parentNode.data(App_Data.ParentNode.node.BackupLocation);
        }
        public string GetBackupScheduleOrDefault()
        {
            return string.IsNullOrWhiteSpace(parentNode.data(App_Data.ParentNode.node.BackupSchedule)) ? "12 AM" : parentNode.data(App_Data.ParentNode.node.BackupSchedule);
        }
        public bool GetOverwriteBackupOrDefault()
        {
            return (parentNode.data(App_Data.ParentNode.node.OverwriteBackup).ToUpper() == "FALSE") ? false : true;
        }

        //MAILER NODES
        public string GetEmailOrDefault()
        {
            return string.IsNullOrWhiteSpace(mailerNode.data(App_Data.MailerNode.node.Email)) ? "" : mailerNode.data(App_Data.MailerNode.node.Email);
        }
        public string GetEmailPasswordOrDefault()
        {
            return string.IsNullOrWhiteSpace(mailerNode.data(App_Data.MailerNode.node.Password).Replace(" ","")) ? "" : mailerNode.data(App_Data.MailerNode.node.Password).Replace(" ", "");
        }
        public string GetEmailSubjectOrDefault()
        {
            return string.IsNullOrWhiteSpace(mailerNode.data(App_Data.MailerNode.node.Subject)) ? "" : mailerNode.data(App_Data.MailerNode.node.Subject);
        }
        public string GetEmailCCOrDefault()
        {
            return string.IsNullOrWhiteSpace(mailerNode.data(App_Data.MailerNode.node.CC)) ? "" : mailerNode.data(App_Data.MailerNode.node.CC);
        }
    }
}
