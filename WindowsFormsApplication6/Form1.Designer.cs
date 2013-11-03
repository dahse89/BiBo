namespace BiBo
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.UserStatus = new System.Windows.Forms.Label();
            this.LoginAs = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.UserAddPanel = new System.Windows.Forms.GroupBox();
            this.buttonUserAdd = new System.Windows.Forms.Button();
            this.comboBoxUserCountries = new System.Windows.Forms.ComboBox();
            this.labelUserCoutry = new System.Windows.Forms.Label();
            this.textBoxUserCity = new System.Windows.Forms.TextBox();
            this.labelUserCity = new System.Windows.Forms.Label();
            this.textBoxUserPLZ = new System.Windows.Forms.TextBox();
            this.labelPLZ = new System.Windows.Forms.Label();
            this.textBoxUserAdressExtention = new System.Windows.Forms.TextBox();
            this.labelUserStreetExtention = new System.Windows.Forms.Label();
            this.textBoxUserHomeNumber = new System.Windows.Forms.TextBox();
            this.textBoxUserStreet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerAddUser = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUserFirstname = new System.Windows.Forms.TextBox();
            this.textBoxUserLastname = new System.Windows.Forms.TextBox();
            this.userDetails = new System.Windows.Forms.GroupBox();
            this.labelUserDetailsAdress = new System.Windows.Forms.Label();
            this.labelUserDetailsName = new System.Windows.Forms.Label();
            this.labelUserDetails = new System.Windows.Forms.Label();
            this.userStatistic = new System.Windows.Forms.GroupBox();
            this.UserTablePanel = new System.Windows.Forms.GroupBox();
            this.userTableDataSet = new System.Windows.Forms.DataGridView();
            this.userName = new System.Windows.Forms.Label();
            this.userStat = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBoxSelectedRows = new System.Windows.Forms.GroupBox();
            this.buttonDeleteSelectedRows = new System.Windows.Forms.Button();
            this.chartUserAge = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MainPanel.SuspendLayout();
            this.UserAddPanel.SuspendLayout();
            this.userDetails.SuspendLayout();
            this.userStatistic.SuspendLayout();
            this.UserTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userTableDataSet)).BeginInit();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxSelectedRows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUserAge)).BeginInit();
            this.SuspendLayout();
            // 
            // UserStatus
            // 
            this.UserStatus.AutoSize = true;
            this.UserStatus.BackColor = System.Drawing.SystemColors.Window;
            this.UserStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserStatus.ForeColor = System.Drawing.Color.Black;
            this.UserStatus.Location = new System.Drawing.Point(21, 51);
            this.UserStatus.Name = "UserStatus";
            this.UserStatus.Size = new System.Drawing.Size(52, 13);
            this.UserStatus.TabIndex = 1;
            this.UserStatus.Text = "Status: ";
            // 
            // LoginAs
            // 
            this.LoginAs.AutoSize = true;
            this.LoginAs.BackColor = System.Drawing.SystemColors.Window;
            this.LoginAs.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginAs.ForeColor = System.Drawing.Color.Black;
            this.LoginAs.Location = new System.Drawing.Point(21, 32);
            this.LoginAs.Name = "LoginAs";
            this.LoginAs.Size = new System.Drawing.Size(95, 13);
            this.LoginAs.TabIndex = 0;
            this.LoginAs.Text = "eingeloggt als: ";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::BiBo.Properties.Resources.icon2;
            this.panel3.Location = new System.Drawing.Point(286, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(60, 53);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::BiBo.Properties.Resources.user2;
            this.panel2.Location = new System.Drawing.Point(221, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 65);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BiBo.Properties.Resources.icon2;
            this.panel1.Location = new System.Drawing.Point(352, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 53);
            this.panel1.TabIndex = 2;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MainPanel.Controls.Add(this.UserAddPanel);
            this.MainPanel.Controls.Add(this.userDetails);
            this.MainPanel.Controls.Add(this.userStatistic);
            this.MainPanel.Controls.Add(this.UserTablePanel);
            this.MainPanel.Location = new System.Drawing.Point(220, 77);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(815, 483);
            this.MainPanel.TabIndex = 3;
            // 
            // UserAddPanel
            // 
            this.UserAddPanel.Controls.Add(this.buttonUserAdd);
            this.UserAddPanel.Controls.Add(this.comboBoxUserCountries);
            this.UserAddPanel.Controls.Add(this.labelUserCoutry);
            this.UserAddPanel.Controls.Add(this.textBoxUserCity);
            this.UserAddPanel.Controls.Add(this.labelUserCity);
            this.UserAddPanel.Controls.Add(this.textBoxUserPLZ);
            this.UserAddPanel.Controls.Add(this.labelPLZ);
            this.UserAddPanel.Controls.Add(this.textBoxUserAdressExtention);
            this.UserAddPanel.Controls.Add(this.labelUserStreetExtention);
            this.UserAddPanel.Controls.Add(this.textBoxUserHomeNumber);
            this.UserAddPanel.Controls.Add(this.textBoxUserStreet);
            this.UserAddPanel.Controls.Add(this.label4);
            this.UserAddPanel.Controls.Add(this.dateTimePickerAddUser);
            this.UserAddPanel.Controls.Add(this.label2);
            this.UserAddPanel.Controls.Add(this.label3);
            this.UserAddPanel.Controls.Add(this.label1);
            this.UserAddPanel.Controls.Add(this.textBoxUserFirstname);
            this.UserAddPanel.Controls.Add(this.textBoxUserLastname);
            this.UserAddPanel.ForeColor = System.Drawing.Color.Black;
            this.UserAddPanel.Location = new System.Drawing.Point(12, 13);
            this.UserAddPanel.Name = "UserAddPanel";
            this.UserAddPanel.Size = new System.Drawing.Size(579, 282);
            this.UserAddPanel.TabIndex = 0;
            this.UserAddPanel.TabStop = false;
            this.UserAddPanel.Text = "Kunde hinzufügen";
            // 
            // buttonUserAdd
            // 
            this.buttonUserAdd.Location = new System.Drawing.Point(14, 240);
            this.buttonUserAdd.Name = "buttonUserAdd";
            this.buttonUserAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonUserAdd.TabIndex = 15;
            this.buttonUserAdd.Text = "hinzufügen";
            this.buttonUserAdd.UseVisualStyleBackColor = true;
            this.buttonUserAdd.Click += new System.EventHandler(this.buttonUserAdd_Click);
            // 
            // comboBoxUserCountries
            // 
            this.comboBoxUserCountries.FormattingEnabled = true;
            this.comboBoxUserCountries.Location = new System.Drawing.Point(77, 207);
            this.comboBoxUserCountries.Name = "comboBoxUserCountries";
            this.comboBoxUserCountries.Size = new System.Drawing.Size(200, 21);
            this.comboBoxUserCountries.TabIndex = 14;
            // 
            // labelUserCoutry
            // 
            this.labelUserCoutry.AutoSize = true;
            this.labelUserCoutry.Location = new System.Drawing.Point(12, 207);
            this.labelUserCoutry.Name = "labelUserCoutry";
            this.labelUserCoutry.Size = new System.Drawing.Size(34, 13);
            this.labelUserCoutry.TabIndex = 13;
            this.labelUserCoutry.Text = "Land:";
            // 
            // textBoxUserCity
            // 
            this.textBoxUserCity.Location = new System.Drawing.Point(187, 171);
            this.textBoxUserCity.Name = "textBoxUserCity";
            this.textBoxUserCity.Size = new System.Drawing.Size(90, 20);
            this.textBoxUserCity.TabIndex = 12;
            // 
            // labelUserCity
            // 
            this.labelUserCity.AutoSize = true;
            this.labelUserCity.Location = new System.Drawing.Point(146, 178);
            this.labelUserCity.Name = "labelUserCity";
            this.labelUserCity.Size = new System.Drawing.Size(35, 13);
            this.labelUserCity.TabIndex = 11;
            this.labelUserCity.Text = "Stadt:";
            // 
            // textBoxUserPLZ
            // 
            this.textBoxUserPLZ.Location = new System.Drawing.Point(77, 172);
            this.textBoxUserPLZ.Name = "textBoxUserPLZ";
            this.textBoxUserPLZ.Size = new System.Drawing.Size(58, 20);
            this.textBoxUserPLZ.TabIndex = 10;
            // 
            // labelPLZ
            // 
            this.labelPLZ.AutoSize = true;
            this.labelPLZ.Location = new System.Drawing.Point(12, 175);
            this.labelPLZ.Name = "labelPLZ";
            this.labelPLZ.Size = new System.Drawing.Size(30, 13);
            this.labelPLZ.TabIndex = 9;
            this.labelPLZ.Text = "PLZ:";
            // 
            // textBoxUserAdressExtention
            // 
            this.textBoxUserAdressExtention.Location = new System.Drawing.Point(77, 145);
            this.textBoxUserAdressExtention.Name = "textBoxUserAdressExtention";
            this.textBoxUserAdressExtention.Size = new System.Drawing.Size(200, 20);
            this.textBoxUserAdressExtention.TabIndex = 8;
            // 
            // labelUserStreetExtention
            // 
            this.labelUserStreetExtention.AutoSize = true;
            this.labelUserStreetExtention.Location = new System.Drawing.Point(12, 145);
            this.labelUserStreetExtention.Name = "labelUserStreetExtention";
            this.labelUserStreetExtention.Size = new System.Drawing.Size(42, 13);
            this.labelUserStreetExtention.TabIndex = 7;
            this.labelUserStreetExtention.Text = "Zusatz:";
            // 
            // textBoxUserHomeNumber
            // 
            this.textBoxUserHomeNumber.Location = new System.Drawing.Point(248, 115);
            this.textBoxUserHomeNumber.Name = "textBoxUserHomeNumber";
            this.textBoxUserHomeNumber.Size = new System.Drawing.Size(29, 20);
            this.textBoxUserHomeNumber.TabIndex = 6;
            // 
            // textBoxUserStreet
            // 
            this.textBoxUserStreet.Location = new System.Drawing.Point(77, 115);
            this.textBoxUserStreet.Name = "textBoxUserStreet";
            this.textBoxUserStreet.Size = new System.Drawing.Size(164, 20);
            this.textBoxUserStreet.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Strasse: ";
            // 
            // dateTimePickerAddUser
            // 
            this.dateTimePickerAddUser.Location = new System.Drawing.Point(77, 84);
            this.dateTimePickerAddUser.Name = "dateTimePickerAddUser";
            this.dateTimePickerAddUser.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerAddUser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Geburtstag: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Vorname:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nachname:";
            // 
            // textBoxUserFirstname
            // 
            this.textBoxUserFirstname.Location = new System.Drawing.Point(77, 28);
            this.textBoxUserFirstname.Name = "textBoxUserFirstname";
            this.textBoxUserFirstname.Size = new System.Drawing.Size(200, 20);
            this.textBoxUserFirstname.TabIndex = 0;
            // 
            // textBoxUserLastname
            // 
            this.textBoxUserLastname.Location = new System.Drawing.Point(77, 55);
            this.textBoxUserLastname.Name = "textBoxUserLastname";
            this.textBoxUserLastname.Size = new System.Drawing.Size(200, 20);
            this.textBoxUserLastname.TabIndex = 0;
            // 
            // userDetails
            // 
            this.userDetails.Controls.Add(this.labelUserDetailsAdress);
            this.userDetails.Controls.Add(this.labelUserDetailsName);
            this.userDetails.Controls.Add(this.labelUserDetails);
            this.userDetails.ForeColor = System.Drawing.Color.Black;
            this.userDetails.Location = new System.Drawing.Point(603, 173);
            this.userDetails.Name = "userDetails";
            this.userDetails.Size = new System.Drawing.Size(200, 100);
            this.userDetails.TabIndex = 3;
            this.userDetails.TabStop = false;
            this.userDetails.Text = "Kunden Details";
            // 
            // labelUserDetailsAdress
            // 
            this.labelUserDetailsAdress.AutoSize = true;
            this.labelUserDetailsAdress.Location = new System.Drawing.Point(10, 37);
            this.labelUserDetailsAdress.Name = "labelUserDetailsAdress";
            this.labelUserDetailsAdress.Size = new System.Drawing.Size(51, 13);
            this.labelUserDetailsAdress.TabIndex = 2;
            this.labelUserDetailsAdress.Text = "Adresse: ";
            // 
            // labelUserDetailsName
            // 
            this.labelUserDetailsName.AutoSize = true;
            this.labelUserDetailsName.Location = new System.Drawing.Point(10, 19);
            this.labelUserDetailsName.Name = "labelUserDetailsName";
            this.labelUserDetailsName.Size = new System.Drawing.Size(41, 13);
            this.labelUserDetailsName.TabIndex = 1;
            this.labelUserDetailsName.Text = "Name: ";
            // 
            // labelUserDetails
            // 
            this.labelUserDetails.AutoSize = true;
            this.labelUserDetails.Location = new System.Drawing.Point(9, 31);
            this.labelUserDetails.Name = "labelUserDetails";
            this.labelUserDetails.Size = new System.Drawing.Size(0, 13);
            this.labelUserDetails.TabIndex = 0;
            // 
            // userStatistic
            // 
            this.userStatistic.Controls.Add(this.chartUserAge);
            this.userStatistic.ForeColor = System.Drawing.Color.Black;
            this.userStatistic.Location = new System.Drawing.Point(598, 13);
            this.userStatistic.Name = "userStatistic";
            this.userStatistic.Size = new System.Drawing.Size(200, 100);
            this.userStatistic.TabIndex = 2;
            this.userStatistic.TabStop = false;
            this.userStatistic.Text = "Statistic";
            // 
            // UserTablePanel
            // 
            this.UserTablePanel.Controls.Add(this.userTableDataSet);
            this.UserTablePanel.ForeColor = System.Drawing.Color.Black;
            this.UserTablePanel.Location = new System.Drawing.Point(12, 301);
            this.UserTablePanel.Name = "UserTablePanel";
            this.UserTablePanel.Size = new System.Drawing.Size(562, 166);
            this.UserTablePanel.TabIndex = 1;
            this.UserTablePanel.TabStop = false;
            this.UserTablePanel.Text = "Kunden";
            // 
            // userTableDataSet
            // 
            this.userTableDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userTableDataSet.Location = new System.Drawing.Point(6, 19);
            this.userTableDataSet.Name = "userTableDataSet";
            this.userTableDataSet.Size = new System.Drawing.Size(443, 150);
            this.userTableDataSet.TabIndex = 0;
            this.userTableDataSet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userTableDataSet_CellClick);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.BackColor = System.Drawing.SystemColors.Window;
            this.userName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.Black;
            this.userName.Location = new System.Drawing.Point(106, 32);
            this.userName.Margin = new System.Windows.Forms.Padding(0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(11, 13);
            this.userName.TabIndex = 0;
            this.userName.Text = " ";
            // 
            // userStat
            // 
            this.userStat.AutoSize = true;
            this.userStat.BackColor = System.Drawing.SystemColors.Window;
            this.userStat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStat.ForeColor = System.Drawing.Color.Black;
            this.userStat.Location = new System.Drawing.Point(64, 51);
            this.userStat.Name = "userStat";
            this.userStat.Size = new System.Drawing.Size(11, 13);
            this.userStat.TabIndex = 1;
            this.userStat.Text = " ";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.textBoxSearch);
            this.groupBoxSearch.Location = new System.Drawing.Point(2, 378);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(212, 56);
            this.groupBoxSearch.TabIndex = 1;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Suche";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(6, 19);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            // 
            // groupBoxSelectedRows
            // 
            this.groupBoxSelectedRows.Controls.Add(this.buttonDeleteSelectedRows);
            this.groupBoxSelectedRows.Location = new System.Drawing.Point(8, 440);
            this.groupBoxSelectedRows.Name = "groupBoxSelectedRows";
            this.groupBoxSelectedRows.Size = new System.Drawing.Size(206, 120);
            this.groupBoxSelectedRows.TabIndex = 4;
            this.groupBoxSelectedRows.TabStop = false;
            this.groupBoxSelectedRows.Text = "Markierte";
            // 
            // buttonDeleteSelectedRows
            // 
            this.buttonDeleteSelectedRows.Location = new System.Drawing.Point(6, 19);
            this.buttonDeleteSelectedRows.Name = "buttonDeleteSelectedRows";
            this.buttonDeleteSelectedRows.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteSelectedRows.TabIndex = 0;
            this.buttonDeleteSelectedRows.Text = "löschen";
            this.buttonDeleteSelectedRows.UseVisualStyleBackColor = true;
            this.buttonDeleteSelectedRows.Click += new System.EventHandler(this.buttonDeleteSelectedRows_Click);
            // 
            // chartUserAge
            // 
            chartArea1.Name = "ChartArea1";
            this.chartUserAge.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartUserAge.Legends.Add(legend1);
            this.chartUserAge.Location = new System.Drawing.Point(17, 19);
            this.chartUserAge.Name = "chartUserAge";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartUserAge.Series.Add(series1);
            this.chartUserAge.Size = new System.Drawing.Size(300, 107);
            this.chartUserAge.TabIndex = 1;
            this.chartUserAge.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 572);
            this.Controls.Add(this.groupBoxSelectedRows);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.userStat);
            this.Controls.Add(this.UserStatus);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.LoginAs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MainPanel.ResumeLayout(false);
            this.UserAddPanel.ResumeLayout(false);
            this.UserAddPanel.PerformLayout();
            this.userDetails.ResumeLayout(false);
            this.userDetails.PerformLayout();
            this.userStatistic.ResumeLayout(false);
            this.UserTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userTableDataSet)).EndInit();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxSelectedRows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartUserAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LoginAs;
        private System.Windows.Forms.Label UserStatus;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label userStat;
        private System.Windows.Forms.GroupBox UserAddPanel;
        private System.Windows.Forms.GroupBox UserTablePanel;
        private System.Windows.Forms.GroupBox userDetails;
        private System.Windows.Forms.GroupBox userStatistic;
        private System.Windows.Forms.DataGridView userTableDataSet;
        private System.Windows.Forms.DateTimePicker dateTimePickerAddUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUserFirstname;
        private System.Windows.Forms.TextBox textBoxUserLastname;
        private System.Windows.Forms.TextBox textBoxUserHomeNumber;
        private System.Windows.Forms.TextBox textBoxUserStreet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelUserStreetExtention;
        private System.Windows.Forms.TextBox textBoxUserAdressExtention;
        private System.Windows.Forms.TextBox textBoxUserPLZ;
        private System.Windows.Forms.Label labelPLZ;
        private System.Windows.Forms.TextBox textBoxUserCity;
        private System.Windows.Forms.Label labelUserCity;
        private System.Windows.Forms.ComboBox comboBoxUserCountries;
        private System.Windows.Forms.Label labelUserCoutry;
        private System.Windows.Forms.Button buttonUserAdd;
        private System.Windows.Forms.Label labelUserDetails;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.GroupBox groupBoxSelectedRows;
        private System.Windows.Forms.Button buttonDeleteSelectedRows;
        private System.Windows.Forms.Label labelUserDetailsName;
        private System.Windows.Forms.Label labelUserDetailsAdress;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUserAge;

    }
}

