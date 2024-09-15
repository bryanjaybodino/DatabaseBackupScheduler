
namespace DatabaseBackup
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_time = new System.Windows.Forms.Label();
            this.label_ampm = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Action = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Path = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_mysql_port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_mysql_hostname = new System.Windows.Forms.TextBox();
            this.checkBox_overwrite_backup_filename = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_backup_schedule = new System.Windows.Forms.ComboBox();
            this.button_save_settings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_mysql_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_mysql_username = new System.Windows.Forms.TextBox();
            this.button_choose_backup_location = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button_email_settings = new System.Windows.Forms.Button();
            this.button_backup = new System.Windows.Forms.Button();
            this.button_how = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_backup_location = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Action.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(884, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(38, 440);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 440);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(922, 62);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label_time);
            this.panel4.Controls.Add(this.label_ampm);
            this.panel4.Location = new System.Drawing.Point(1419, 11);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(234, 40);
            this.panel4.TabIndex = 21;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_time.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_time.ForeColor = System.Drawing.Color.White;
            this.label_time.Location = new System.Drawing.Point(178, 0);
            this.label_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(28, 38);
            this.label_time.TabIndex = 19;
            this.label_time.Text = "-";
            // 
            // label_ampm
            // 
            this.label_ampm.AutoSize = true;
            this.label_ampm.BackColor = System.Drawing.Color.White;
            this.label_ampm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_ampm.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_ampm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_ampm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ampm.Location = new System.Drawing.Point(206, 0);
            this.label_ampm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ampm.Name = "label_ampm";
            this.label_ampm.Size = new System.Drawing.Size(28, 38);
            this.label_ampm.TabIndex = 20;
            this.label_ampm.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(411, 39);
            this.label4.TabIndex = 12;
            this.label4.Text = "MySql Database Backup";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Action
            // 
            this.Action.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Path,
            this.Delete,
            this.Backup});
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(147, 76);
            this.Action.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Action_ItemClicked);
            // 
            // Path
            // 
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(146, 24);
            this.Path.Text = "Open Path";
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(146, 24);
            this.Delete.Text = "Delete";
            // 
            // Backup
            // 
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(146, 24);
            this.Backup.Text = "Backup";
            this.Backup.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.textBox_mysql_port);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.textBox_mysql_hostname);
            this.panel5.Controls.Add(this.checkBox_overwrite_backup_filename);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.comboBox_backup_schedule);
            this.panel5.Controls.Add(this.button_save_settings);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.textBox_mysql_password);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.textBox_mysql_username);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(40, 62);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(294, 440);
            this.panel5.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "MySQL Port Number";
            // 
            // textBox_mysql_port
            // 
            this.textBox_mysql_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_mysql_port.Location = new System.Drawing.Point(16, 101);
            this.textBox_mysql_port.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_mysql_port.Name = "textBox_mysql_port";
            this.textBox_mysql_port.Size = new System.Drawing.Size(244, 27);
            this.textBox_mysql_port.TabIndex = 2;
            this.textBox_mysql_port.TextChanged += new System.EventHandler(this.textBox_mysql_port_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "MySQL Hostname";
            // 
            // textBox_mysql_hostname
            // 
            this.textBox_mysql_hostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_mysql_hostname.Location = new System.Drawing.Point(16, 48);
            this.textBox_mysql_hostname.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_mysql_hostname.Name = "textBox_mysql_hostname";
            this.textBox_mysql_hostname.Size = new System.Drawing.Size(244, 27);
            this.textBox_mysql_hostname.TabIndex = 1;
            // 
            // checkBox_overwrite_backup_filename
            // 
            this.checkBox_overwrite_backup_filename.AutoSize = true;
            this.checkBox_overwrite_backup_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_overwrite_backup_filename.Location = new System.Drawing.Point(16, 292);
            this.checkBox_overwrite_backup_filename.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_overwrite_backup_filename.Name = "checkBox_overwrite_backup_filename";
            this.checkBox_overwrite_backup_filename.Size = new System.Drawing.Size(237, 24);
            this.checkBox_overwrite_backup_filename.TabIndex = 6;
            this.checkBox_overwrite_backup_filename.Text = "Overwrite Backup Filename";
            this.checkBox_overwrite_backup_filename.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 232);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Backup Schedule";
            // 
            // comboBox_backup_schedule
            // 
            this.comboBox_backup_schedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_backup_schedule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_backup_schedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_backup_schedule.FormattingEnabled = true;
            this.comboBox_backup_schedule.Items.AddRange(new object[] {
            "01 AM",
            "01 PM",
            "02 AM",
            "02 PM",
            "03 AM",
            "03 PM",
            "04 AM",
            "04 PM",
            "05 AM",
            "05 PM",
            "06 AM",
            "06 PM",
            "07 AM",
            "07 PM",
            "08 AM",
            "08 PM",
            "09 AM",
            "09 PM",
            "10 AM",
            "10 PM",
            "11 AM",
            "11 PM",
            "12 AM",
            "12 PM"});
            this.comboBox_backup_schedule.Location = new System.Drawing.Point(16, 254);
            this.comboBox_backup_schedule.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_backup_schedule.Name = "comboBox_backup_schedule";
            this.comboBox_backup_schedule.Size = new System.Drawing.Size(244, 28);
            this.comboBox_backup_schedule.TabIndex = 5;
            // 
            // button_save_settings
            // 
            this.button_save_settings.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_save_settings.FlatAppearance.BorderSize = 0;
            this.button_save_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save_settings.ForeColor = System.Drawing.Color.White;
            this.button_save_settings.Location = new System.Drawing.Point(16, 356);
            this.button_save_settings.Margin = new System.Windows.Forms.Padding(4);
            this.button_save_settings.Name = "button_save_settings";
            this.button_save_settings.Size = new System.Drawing.Size(246, 51);
            this.button_save_settings.TabIndex = 7;
            this.button_save_settings.Text = "SAVE SETTINGS";
            this.button_save_settings.UseVisualStyleBackColor = false;
            this.button_save_settings.Click += new System.EventHandler(this.button_save_settings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "MySQL Password";
            // 
            // textBox_mysql_password
            // 
            this.textBox_mysql_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_mysql_password.Location = new System.Drawing.Point(16, 204);
            this.textBox_mysql_password.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_mysql_password.Name = "textBox_mysql_password";
            this.textBox_mysql_password.Size = new System.Drawing.Size(244, 27);
            this.textBox_mysql_password.TabIndex = 4;
            this.textBox_mysql_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "MySQL Username";
            // 
            // textBox_mysql_username
            // 
            this.textBox_mysql_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_mysql_username.Location = new System.Drawing.Point(16, 153);
            this.textBox_mysql_username.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_mysql_username.Name = "textBox_mysql_username";
            this.textBox_mysql_username.Size = new System.Drawing.Size(244, 27);
            this.textBox_mysql_username.TabIndex = 3;
            this.textBox_mysql_username.UseSystemPasswordChar = true;
            // 
            // button_choose_backup_location
            // 
            this.button_choose_backup_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_choose_backup_location.Location = new System.Drawing.Point(4, 41);
            this.button_choose_backup_location.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button_choose_backup_location.Name = "button_choose_backup_location";
            this.button_choose_backup_location.Size = new System.Drawing.Size(101, 75);
            this.button_choose_backup_location.TabIndex = 8;
            this.button_choose_backup_location.Text = "PATH";
            this.button_choose_backup_location.UseVisualStyleBackColor = true;
            this.button_choose_backup_location.Click += new System.EventHandler(this.button_choose_path);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button_email_settings);
            this.panel6.Controls.Add(this.button_backup);
            this.panel6.Controls.Add(this.button_how);
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Controls.Add(this.textBox_backup_location);
            this.panel6.Controls.Add(this.button_choose_backup_location);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(334, 62);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(550, 440);
            this.panel6.TabIndex = 21;
            // 
            // button_email_settings
            // 
            this.button_email_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_email_settings.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_email_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_email_settings.FlatAppearance.BorderSize = 0;
            this.button_email_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_email_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_email_settings.ForeColor = System.Drawing.Color.White;
            this.button_email_settings.Location = new System.Drawing.Point(261, 80);
            this.button_email_settings.Margin = new System.Windows.Forms.Padding(2);
            this.button_email_settings.Name = "button_email_settings";
            this.button_email_settings.Size = new System.Drawing.Size(138, 34);
            this.button_email_settings.TabIndex = 10;
            this.button_email_settings.Text = "Email Settings";
            this.button_email_settings.UseVisualStyleBackColor = false;
            this.button_email_settings.Click += new System.EventHandler(this.button_email_settings_Click);
            // 
            // button_backup
            // 
            this.button_backup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_backup.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_backup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_backup.FlatAppearance.BorderSize = 0;
            this.button_backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_backup.ForeColor = System.Drawing.Color.White;
            this.button_backup.Location = new System.Drawing.Point(412, 80);
            this.button_backup.Margin = new System.Windows.Forms.Padding(2);
            this.button_backup.Name = "button_backup";
            this.button_backup.Size = new System.Drawing.Size(138, 34);
            this.button_backup.TabIndex = 11;
            this.button_backup.Text = "Backup";
            this.button_backup.UseVisualStyleBackColor = false;
            this.button_backup.Click += new System.EventHandler(this.button_backup_Click);
            // 
            // button_how
            // 
            this.button_how.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_how.BackColor = System.Drawing.Color.DodgerBlue;
            this.button_how.FlatAppearance.BorderSize = 0;
            this.button_how.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_how.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_how.ForeColor = System.Drawing.Color.White;
            this.button_how.Location = new System.Drawing.Point(109, 80);
            this.button_how.Margin = new System.Windows.Forms.Padding(2);
            this.button_how.Name = "button_how";
            this.button_how.Size = new System.Drawing.Size(138, 34);
            this.button_how.TabIndex = 9;
            this.button_how.Text = "How to use";
            this.button_how.UseVisualStyleBackColor = false;
            this.button_how.Click += new System.EventHandler(this.button_how_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DatabaseName});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 140);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(550, 300);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.Width = 125;
            // 
            // DatabaseName
            // 
            this.DatabaseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DatabaseName.DataPropertyName = "DatabaseName";
            this.DatabaseName.HeaderText = "Database Name";
            this.DatabaseName.MinimumWidth = 6;
            this.DatabaseName.Name = "DatabaseName";
            this.DatabaseName.ReadOnly = true;
            this.DatabaseName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // textBox_backup_location
            // 
            this.textBox_backup_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_backup_location.Location = new System.Drawing.Point(109, 41);
            this.textBox_backup_location.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_backup_location.Name = "textBox_backup_location";
            this.textBox_backup_location.ReadOnly = true;
            this.textBox_backup_location.Size = new System.Drawing.Size(441, 27);
            this.textBox_backup_location.TabIndex = 20;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 502);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(922, 26);
            this.panel7.TabIndex = 25;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(922, 528);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1139, 638);
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Action.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_ampm;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.ContextMenuStrip Action;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem Backup;
        private System.Windows.Forms.ToolStripMenuItem Path;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox checkBox_overwrite_backup_filename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_backup_schedule;
        private System.Windows.Forms.Button button_save_settings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_mysql_password;
        private System.Windows.Forms.TextBox textBox_mysql_username;
        private System.Windows.Forms.Button button_choose_backup_location;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button_how;
        private System.Windows.Forms.TextBox textBox_backup_location;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseName;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button_backup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_email_settings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_mysql_hostname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_mysql_port;
    }
}