using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseBackup
{
    class App_Data
    {
        public static string DefaultPath = @"C:\DatabaseBackup";
        public static string XMLPath = DefaultPath + @"\data.xml";
        public static void CreatePath()
        {
            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
                createXML();
            }
            else
            {
                createXML();
            }
        }
        static void createXML()
        {
            if (!File.Exists(XMLPath))
            {
                string data =
                    "<Settings>\n" +
                        " <MySQL>\n" +
                            "  <User></User>\n" +
                            "  <Password></Password>\n" +
                            "  <Location></Location>\n" +
                        "  </MySQL>\n" +
                        " <BackupLocation></BackupLocation>\n" +
                        " <BackupSchedule></BackupSchedule>\n" +
                        " <OverwriteBackup>True</OverwriteBackup>\n" +
                    "</Settings>\n";
                File.AppendAllText(XMLPath, data);
            }
        }

        public class ParentNode
        {
            public enum node
            {
                BackupLocation,
                BackupSchedule,
                OverwriteBackup
            }
            public void update(string BackupLocation,string BackupSchedule,string OverwriteBackup)
            {
                string value = "";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(XMLPath);
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Settings");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    XmlNodeList _BackupLocation = xmlNodeList.Item(i).SelectNodes("BackupLocation");
                    _BackupLocation[i].InnerText = BackupLocation;

                    XmlNodeList _BackupSchedule = xmlNodeList.Item(i).SelectNodes("BackupSchedule");
                    _BackupSchedule[i].InnerText = BackupSchedule;

                    XmlNodeList _OverwriteBackup = xmlNodeList.Item(i).SelectNodes("OverwriteBackup");
                    _OverwriteBackup[i].InnerText = OverwriteBackup;

                }
                xmlDocument.Save(XMLPath);
            }


            public string data(node node)
            {
                string value = "";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(XMLPath);
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Settings");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    XmlNodeList User = xmlNodeList.Item(i).SelectNodes(node.ToString());
                    value = User.Item(i).InnerText;
                }
                return value;
            }
        }

        public class MySQLNode
        {
            public enum node
            {
                User,
                Password,
                Location
            }

            public void update(string User, string Password, string Location)
            {
                string value = "";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(XMLPath);
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Settings/MySQL");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    XmlNodeList _User = xmlNodeList.Item(i).SelectNodes("User");
                    _User[i].InnerText = User;

                    XmlNodeList _Password = xmlNodeList.Item(i).SelectNodes("Password");
                    _Password[i].InnerText = Password;

                    XmlNodeList _Location = xmlNodeList.Item(i).SelectNodes("Location");
                    _Location[i].InnerText = Location;

                }
                xmlDocument.Save(XMLPath);
            }
            public string data(node node)
            {
                string value = "";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(XMLPath);

                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Settings/MySQL");
                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    XmlNodeList User = xmlNodeList.Item(i).SelectNodes(node.ToString());
                    value = User.Item(i).InnerText;
                }
                return value;
            }

        }
    }
}
