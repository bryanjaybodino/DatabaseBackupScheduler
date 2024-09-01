using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DatabaseBackup
{
    class BackupList
    {
        public static string XMLPath = App_Data.DefaultPath + @"\database.xml";
        public static void CreatePath()
        {
            if (!Directory.Exists(App_Data.DefaultPath))
            {
                Directory.CreateDirectory(App_Data.DefaultPath);
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
                    "<Schema>\n" +
                    "</Schema>\n";
                File.AppendAllText(XMLPath, data);
            }
        }
        public class Database
        {
            App_Data.MySQLNode mySQLNode = new App_Data.MySQLNode();

            public void delete(string name)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(XMLPath);

                XmlNodeList Schema = xmlDocument.SelectNodes("Schema");

                XmlNodeList XmlNode_Database = xmlDocument.SelectNodes("Schema/Database");

                for (int i = 0; i < XmlNode_Database.Count; i++)
                {
                    string database = XmlNode_Database.Item(i).Attributes["id"].Value;
                    if (name.ToLower() == database.ToLower())
                    {
                        XmlNode node = XmlNode_Database.Item(i);
                        Schema.Item(0).RemoveChild(node);
                        xmlDocument.Save(XMLPath);
                    }

                }


            }



            public void insert(string name)
            {
                BackupList backupList = new BackupList();
                if (backupList.mysql_login_success(name))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(XMLPath);
                    XmlNode Schema = xmlDocument.SelectSingleNode("Schema");
                    XmlNodeList XmlNode_Database = xmlDocument.SelectNodes("Schema/Database");
                    bool isDuplicate = false;
                    for (int i = 0; i < XmlNode_Database.Count; i++)
                    {
                        XmlNode Node_Name = XmlNode_Database.Item(i).SelectSingleNode("Name");
                        string Name = Node_Name.InnerText;
                        if (Name.ToUpper() == name.ToUpper())
                        {
                            isDuplicate = true;
                        }
                    }

                    if (isDuplicate == false)
                    {
                        XmlElement Database = xmlDocument.CreateElement("Database");
                        Database.SetAttribute("id", name.ToLower().Replace(" ", ""));
                        string data = "\n" +
                            "  <ID>" + (XmlNode_Database.Count + 1).ToString() + "</ID>\n" +
                            "  <Name>" + name.ToLower().Replace(" ", "") + "</Name>\n";
                        Database.InnerXml = data;
                        Schema.AppendChild(Database);
                        xmlDocument.Save(XMLPath);
                    }
                    else
                    {
                        MessageBox.Show("Database is already added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        public void bind(DataGridView gridView)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("DatabaseName");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(XMLPath);
            XmlNodeList XmlNode_Database = xmlDocument.SelectNodes("Schema/Database");
            for (int i = 0; i < XmlNode_Database.Count; i++)
            {
                XmlNode Node_ID = XmlNode_Database.Item(i).SelectSingleNode("ID");
                string ID = Node_ID.InnerText;

                XmlNode Node_Name = XmlNode_Database.Item(i).SelectSingleNode("Name");
                string Name = Node_Name.InnerText;

                dataTable.Rows.Add(ID, Name);
            }
            gridView.DataSource = dataTable;
            gridView.Columns[1].ReadOnly = true;   //PARA HINDI MAKAPAG EDIT SA GRIDVIEW
            gridView.Rows[dataTable.Rows.Count].Cells[1].ReadOnly = false;//INSERT ONLY LANG
        }
        public void CellContent(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView table = (sender as DataGridView);
                if (e.RowIndex != -1)
                {
                    Database database = new Database();
                    string Name = table.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (Name.Replace(" ", "") != "")
                    {
                        database.insert(Name);
                    }
                }
                bind(table);
            }
            catch { }
        }

        public void ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CMD cmd = new CMD();
            if (e.ClickedItem.Name == "Delete")
            {
                Database database = new Database();
                database.delete(Main.Selected_Database);
            }
            if (e.ClickedItem.Name == "Backup")
            {
                create_backup_directory();
                cmd.command(Main.Selected_Database,true);
            }
            if (e.ClickedItem.Name == "Path")
            {
                create_backup_directory();
                cmd.open_folder(Main.Selected_Database);
            }
        }

        public bool mysql_login_success(string name)
        {
            App_Data.MySQLNode mySQLNode = new App_Data.MySQLNode();
            bool isSuccess = false;
            string user = mySQLNode.data(App_Data.MySQLNode.node.User);
            string password = mySQLNode.data(App_Data.MySQLNode.node.Password);
            try
            {
                MySqlConnection mySQLCon = new MySqlConnection("server=localhost;user id=" + user + "; password = " + password + ";database=" + name);
                mySQLCon.Open();
                if (mySQLCon.State == ConnectionState.Open)
                {
                    isSuccess = true;
                }
                mySQLCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isSuccess;

        }
        public void create_backup_directory() // If ever na binura na yung backup directory tapos nag backup parin ng database dapat ma create ulit yung mga folders
        {
            App_Data.ParentNode parentNode = new App_Data.ParentNode();
            string backup_location = parentNode.data(App_Data.ParentNode.node.BackupLocation);
            string[] folders = backup_location.Split('\\');
            string check_folder = folders[0];//This is Local Disk
            for (int i = 1; i < folders.Length; i++)
            {
                string folder = folders[i];
                check_folder += folder;

                if (!Directory.Exists(check_folder))
                {
                    Directory.CreateDirectory(check_folder);
                }
            }
        }
    }
}
