using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System;
using System.IO;


//Shortcut to shut all nodes in visual studio is Ctrl + M + O
//Shortcut to open all nodes in visual studio is Ctrl + M + L

namespace BiBo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        
        #region init Panels
        private Panel SuperPanelLogin               = new Panel();
        private Panel SuperPanelEmployee            = new Panel();
        private Panel SuperPanelCustomer            = new Panel();
        private Panel customerImage                 = new Panel();
        private Panel imageAccount                  = new Panel();

        private Panel customerSearchBookPanel = new Panel();
        private Panel customerAccountPanel = new Panel();


        private Panel imageSearch = new Panel();
        private Panel panel1                        = new Panel();
        private Panel CustomerMainPanel             = new Panel();
        private Panel BooksMainPanel                = new Panel();
        private Panel BorrowMainPanel               = new Panel();
        private Panel booksImage                    = new Panel();
        private Panel borrowImage                   = new Panel();

        private Panel imageCustomerFound = new Panel();
        private Panel imageCustomerCardValidation = new Panel();
        #endregion
        #region init GroupBox
        private GroupBox groupBoxLogin              = new GroupBox();

        private GroupBox customerSideBarGroupeBox   = new GroupBox();
        private GroupBox customerMainGroupeBox      = new GroupBox();
        private GroupBox customerTabsGroupeBox = new GroupBox();

        private GroupBox employeeSideBarGroupeBox = new GroupBox();
        private GroupBox employeeMainGroupeBox = new GroupBox();
        private GroupBox employeeTabsGroupeBox = new GroupBox();

        private GroupBox customerChargeAccountGroupBox = new GroupBox();
        private GroupBox customerBooksGroupeBox = new GroupBox();


        private GroupBox UserAddPanel               = new GroupBox();
        private GroupBox groupBoxAddBook            = new GroupBox();
        private GroupBox userDetails                = new GroupBox();
        private GroupBox userStatistic              = new GroupBox();
        private GroupBox UserTablePanel             = new GroupBox();
        private GroupBox groupBoxSearch             = new GroupBox();
        private GroupBox groupBoxSelectedRows       = new GroupBox();
        private GroupBox groupBoxBookTable          = new GroupBox();

        private GroupBox borrowCustomer = new GroupBox();
        private GroupBox borrowBooks = new GroupBox();

        #endregion
        #region init Button
        private Button login                        = new Button();
        private Button buttonUserAdd                = new Button();
        private Button buttonDeleteSelectedRows     = new Button();
        private Button close                        = new Button();
        private Button addBooksActionButton         = new Button();
        private Button Logout = new Button();
        private Button EmployeeLogout = new Button();
        private Button EditUser = new Button();
        private Button clearCancel = new Button();
        #endregion
        #region init ComboBox
        private ComboBox comboBoxUserCountries      = new ComboBox();
        #endregion
        #region init Label
        private Label labelUserLoginName            = new Label();
        private Label labelUserLoginPass            = new Label();

        private Label labelCustomerSearch            = new Label();

        private Label loggedInAs_Name               = new Label();
        private Label loggedInAs_Adress             = new Label();


        private Label labelUserCoutry               = new Label();
        private Label labelUserCity                 = new Label();
        private Label labelPLZ                      = new Label();
        private Label labelUserStreetExtention      = new Label();
        private Label label4                        = new Label();
        private Label labelUserDetailsAdress        = new Label();
        private Label labelUserDetailsName          = new Label();
        private Label labelUserDetails              = new Label();
        private Label label2                        = new Label();
        private Label label3                        = new Label();
        private Label label1                        = new Label();
        private Label userName                      = new Label();
        private Label userStat                      = new Label();
        private Label UserStatus                    = new Label();
        private Label LoginAs                       = new Label();
        private Label labelBookAddauthor            = new Label();
        private Label lableBookAddTitel             = new Label();
        private Label labelBookAddsubjectArea       = new Label();
        private Label borrowCustomerIDLabel = new Label();
        private Label borrowCustomerInfoLabel = new Label();
        private Label borrowCustomerCardValidLabel = new Label();


        private Label ChartLabel = new Label();
        #endregion
        #region init TextBox
        private TextBox borrowCustomerIDTextBox = new TextBox(); 
        private TextBox textBoxUserLoginName         = new TextBox();
        private TextBox textBoxUserLoginPass         = new TextBox();
        private TextBox textBoxCustomerSearch        = new TextBox();

        private TextBox textBoxUserCity              = new TextBox();
        private TextBox textBoxUserPLZ               = new TextBox();
        private TextBox textBoxUserAdressExtention   = new TextBox();           
        private TextBox textBoxUserHomeNumber        = new TextBox();
        private TextBox textBoxUserStreet            = new TextBox();
        private TextBox textBoxUserFirstname         = new TextBox();
        private TextBox textBoxUserLastname          = new TextBox();
        private TextBox textBoxSearch                = new TextBox();
        private TextBox textBoxBookAddauthor         = new TextBox();
        private TextBox textBoxBookAddTitel          = new TextBox();
        private TextBox textBoxBookAddsubjectArea    = new TextBox();

        #endregion        
        #region init DateTimePicker
        private DateTimePicker dateTimePickerAddUser = new DateTimePicker();
        #endregion
        #region init DataGridView
        private DataGridView userTableDataSet        = new DataGridView();
        private DataGridView booksTableDataSet       = new DataGridView();
        private DataGridView customerSearchBook      = new DataGridView();
        
        #endregion
        #region init Chart
        private Chart chartUserAge                   = new Chart();
        private Chart chartRegDate                   = new Chart();
        #endregion
        #region init CheckBox
        private CheckBox checkBoxCustomerSearchTitle = new CheckBox();
        private CheckBox checkBoxCustomerSearchAutor = new CheckBox();
        #endregion

 

        

        private void InitializeComponent(int w, int h)
        {

            //get current window size         
            /*force small monitor for testing <dahse89>*
            w = 1366;
            h = 768;
            /**/
            int windowHeight = h;
            int windowWidth = w;

            #region Form1

            #region Form1 Values
            this.ClientSize = new System.Drawing.Size(w, h);
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Name = "Form1";
                this.Text = "Form1";
                this.CustomerMainPanel.ResumeLayout(false);
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
                #endregion

                #region Super Panel Login
                this.SuperPanelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //this.SuperPanelEmployee.BackColor = System.Drawing.Color.Blue;
                this.SuperPanelLogin.Location = new System.Drawing.Point(0, 0);
                this.SuperPanelLogin.Name = "SuperPanelLogin";
                this.SuperPanelLogin.Size = new System.Drawing.Size(windowWidth, windowHeight);
                this.SuperPanelLogin.TabIndex = 3;
                this.SuperPanelLogin.Visible = true;


                #region login Group Box
                this.groupBoxLogin.Text = "Login";
                this.groupBoxLogin.Location = new Point(50, 50);
                this.groupBoxLogin.Size = new Size(200, 120);

                #region login lables
                this.labelUserLoginName.Text = "ID: ";
      
                this.labelUserLoginName.Location = new Point(10, 20);
                this.labelUserLoginPass.Text = "Password";
                this.labelUserLoginPass.Location = new Point(10, 45);
                #endregion

                #region text Box login name
                this.textBoxUserLoginName.Name = "UserLoginName";
                this.textBoxUserLoginName.Text = "103"; //@todo remove
                this.textBoxUserLoginName.Location = new Point(70, 20);
                this.textBoxUserLoginName.Width = 100;
                
                #endregion
                #region text Box login pass
                this.textBoxUserLoginPass.Location = new Point(70, 45);
                this.textBoxUserLoginPass.Name = "UserLoginPass";
                this.textBoxUserLoginPass.PasswordChar = '°';
                this.textBoxUserLoginPass.Width = 100;
                #endregion

                #region login button
                this.login.Location = new Point(70, 75);
                this.login.Text = "einloggen";
                this.login.Click += new System.EventHandler(this.login_Click);
                
                #endregion

                #endregion
                #endregion
                #region super panel customer
                this.SuperPanelCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //this.SuperPanelCustomer.BackColor = System.Drawing.Color.Blue;
                this.SuperPanelCustomer.Location = new System.Drawing.Point(0, 0);
                this.SuperPanelCustomer.Name = "SuperPanelCustomer";
                this.SuperPanelCustomer.Size = new System.Drawing.Size(windowWidth, windowHeight);
                this.SuperPanelCustomer.TabIndex = 3;
                this.SuperPanelCustomer.Visible = false;

                #region customerSideBarGroupeBox
                this.customerSideBarGroupeBox.Location = new Point(10, 10);
                this.customerSideBarGroupeBox.Size = new Size(200, windowHeight - 20);
                

                #region labels
                this.loggedInAs_Name.Name = "LoggedInAsCustomer";
                this.loggedInAs_Name.Location = new Point(10, 10);
                this.loggedInAs_Name.AutoSize = true;

                this.loggedInAs_Adress.Name = "LoggedInAsCustomerAdress";
                this.loggedInAs_Adress.Location = new Point(10, 30);
                this.loggedInAs_Adress.AutoSize = true;
                #endregion
                #region logout button
                    this.Logout.Location = new Point(10, 80);
                    this.Logout.Text = "Abmelden";
                    this.Logout.Click += new System.EventHandler(this.Logout_Click);
                #endregion
                #endregion

                #region customerTabsGroupeBox
                this.customerTabsGroupeBox.Location = new Point(220, 10);
                this.customerTabsGroupeBox.Size = new Size(windowWidth - 230, 80);

                #region seach image
                this.imageSearch.BackgroundImage = global::BiBo.Properties.Resources.Search;
                this.imageSearch.Location = new System.Drawing.Point(20, 10);
                this.imageSearch.Name = "searchImage";
                this.imageSearch.Size = new System.Drawing.Size(64, 64);
                this.imageSearch.TabIndex = 2;
                this.imageSearch.Click += new System.EventHandler(this.imageSearch_Click);
                #endregion

                #region account image
                this.imageAccount.BackgroundImage = global::BiBo.Properties.Resources.account;
                this.imageAccount.Location = new System.Drawing.Point(84, 10);
                this.imageAccount.Name = "accountImage";
                this.imageAccount.Size = new System.Drawing.Size(64, 64);
                this.imageAccount.TabIndex = 2;
                this.imageAccount.Click += new System.EventHandler(this.imageAccount_Click);
                #endregion

                #endregion

                #region customerMainGroupeBox
                this.customerMainGroupeBox.Location = new Point(220, 94);
                this.customerMainGroupeBox.Size = new Size(windowWidth - 230, windowHeight - 104);


                #region customer sreach book panel
                this.customerSearchBookPanel.Location = new Point(0, 0);
                this.customerSearchBookPanel.Size = this.customerMainGroupeBox.Size;

                #region customer search checkboxes
                this.checkBoxCustomerSearchAutor.Location = new Point(250, 20);
                this.checkBoxCustomerSearchAutor.Text = "Autor";
                this.checkBoxCustomerSearchAutor.Checked = true;

                this.checkBoxCustomerSearchTitle.Location = new Point(400, 20);
                this.checkBoxCustomerSearchTitle.Text = "Title";
                this.checkBoxCustomerSearchTitle.Checked = true;
                #endregion

                #region customer search label
                this.labelCustomerSearch.Text = "Suche: ";
                this.labelCustomerSearch.AutoSize = true;
                this.labelCustomerSearch.Location = new Point(50, 20);

           

                #endregion

                #region customer search textbox
                this.textBoxCustomerSearch.Location = new Point(100, 20);
                this.textBoxCustomerSearch.KeyUp += new KeyEventHandler(this.CustomerSearchBook_KeyUp);
                #endregion

                #region data grid view
                this.customerSearchBook.Location = new Point(20, 50);
                this.customerSearchBook.Size = new Size(this.customerSearchBookPanel.Width - 40, this.customerSearchBookPanel.Height - 70);
                this.customerSearchBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //enable contentless left colum
                this.customerSearchBook.RowHeadersVisible = false;
                //enable empty last row
                this.customerSearchBook.AllowUserToAddRows = false;
                
                
                #endregion




                #endregion

                #region customer account panel
                this.customerAccountPanel.Location = this.customerSearchBookPanel.Location;
                this.customerAccountPanel.Size = this.customerSearchBookPanel.Size;
        
                this.customerAccountPanel.Visible = false;

                #region account group box
                this.customerChargeAccountGroupBox.Location = new Point(10, 10);
                this.customerChargeAccountGroupBox.Size = new Size(customerAccountPanel.Width - 20, customerAccountPanel.Height / 2 - 5);
                this.customerChargeAccountGroupBox.Text = "Gebührenkonto";
                #endregion

                #region books group box
                this.customerBooksGroupeBox.Location = new Point(10, customerAccountPanel.Height / 2 + 5);
                this.customerBooksGroupeBox.Size = new Size(customerAccountPanel.Width - 20, customerAccountPanel.Height / 2 - 15);
                this.customerBooksGroupeBox.Text = "ausgeliehende Bücher";
                #endregion

                #endregion


                #endregion

                #endregion
                #region Super Panel Employee
                this.SuperPanelEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //this.SuperPanelEmployee.BackColor = System.Drawing.Color.Blue;
                this.SuperPanelEmployee.Location = new System.Drawing.Point(0, 0);
                this.SuperPanelEmployee.Name = "SuperPanelEmployee";
                this.SuperPanelEmployee.Size = new System.Drawing.Size(windowWidth, windowHeight);
                this.SuperPanelEmployee.TabIndex = 3;
                this.SuperPanelEmployee.Visible = false;

                #region employee tabs
                this.employeeTabsGroupeBox.Location = new Point(220, 10);
                this.employeeTabsGroupeBox.Size = new Size(windowWidth - 230, 80);


                #region customer user image
                this.customerImage.BackgroundImage = global::BiBo.Properties.Resources.account;
                this.customerImage.Location = new System.Drawing.Point(20, 10);
                this.customerImage.Name = "customer image";
                this.customerImage.Size = new System.Drawing.Size(64, 64);
                this.customerImage.TabIndex = 2;
                this.customerImage.Click += new System.EventHandler(this.customerImage_Click);
                #endregion

                #region books image
                this.booksImage.BackgroundImage = global::BiBo.Properties.Resources.books;
                this.booksImage.Location = new System.Drawing.Point(84, 10);
                this.booksImage.Name = "books image";
                this.booksImage.Size = new System.Drawing.Size(64, 64);
                this.booksImage.TabIndex = 2;
                this.booksImage.Click += new System.EventHandler(this.booksImage_Click);
                #endregion

                #region borrow image
                this.borrowImage.BackgroundImage = global::BiBo.Properties.Resources.borrowicon;
                this.borrowImage.Location = new System.Drawing.Point(148, 10);
                this.borrowImage.Name = "borrowBookImage";
                this.borrowImage.Size = new System.Drawing.Size(64, 64);
                this.borrowImage.TabIndex = 2;
                this.borrowImage.Click += new System.EventHandler(this.borrowImage_Click);
                #endregion

                #endregion

                #region employee main
                this.employeeMainGroupeBox.Location = new Point(220, 94);
                this.employeeMainGroupeBox.Size = new Size(windowWidth - 230, windowHeight - 104);

                //Main Panel
                #region CutomerMainPanel
                #region CutomerMainPanel Values
                this.CustomerMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.CustomerMainPanel.Location = new System.Drawing.Point(5, 5);
                this.CustomerMainPanel.Name = "MainPanel";
                this.CustomerMainPanel.Size = new System.Drawing.Size(windowWidth - 235, windowHeight - 115);
                this.CustomerMainPanel.TabIndex = 3;
                #endregion

                #region UserAddPanel
                #region UserAddPanel VAlues
                this.UserAddPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.UserAddPanel.Location = new System.Drawing.Point(12, 13);
                this.UserAddPanel.Name = "UserAddPanel";
                this.UserAddPanel.Size = new System.Drawing.Size(CustomerMainPanel.Width / 3 - 25, CustomerMainPanel.Height / 2 - 25);
                this.UserAddPanel.TabIndex = 0;
                this.UserAddPanel.TabStop = false;
                this.UserAddPanel.Text = "Kunde hinzufügen/ bearbeiten";
                //this.UserAddPanel
                #endregion

                #region labelFirstname
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(11, 32);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(52, 13);
                this.label3.TabIndex = 1;
                this.label3.Text = "Vorname:";
                #endregion
                #region textBoxUserFirstname
                this.textBoxUserFirstname.Location = new System.Drawing.Point(77, 28);
                this.textBoxUserFirstname.Name = "textBoxUserFirstname";
                this.textBoxUserFirstname.Size = new System.Drawing.Size(200, 20);
                this.textBoxUserFirstname.TabIndex = 0;
                #endregion

                #region labelLastname
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(11, 58);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(62, 13);
                this.label1.TabIndex = 1;
                this.label1.Text = "Nachname:";
                #endregion
                #region textBoxUserLastname
                this.textBoxUserLastname.Location = new System.Drawing.Point(77, 55);
                this.textBoxUserLastname.Name = "textBoxUserLastname";
                this.textBoxUserLastname.Size = new System.Drawing.Size(200, 20);
                this.textBoxUserLastname.TabIndex = 0;
                #endregion

                #region  labelBirthday
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(11, 90);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(65, 13);
                this.label2.TabIndex = 1;
                this.label2.Text = "Geburtstag: ";
                #endregion
                #region dateTimePickerAddUser
                this.dateTimePickerAddUser.Location = new System.Drawing.Point(77, 84);
                this.dateTimePickerAddUser.Name = "dateTimePickerAddUser";
                this.dateTimePickerAddUser.Size = new System.Drawing.Size(200, 20);
                this.dateTimePickerAddUser.TabIndex = 2;
                #endregion

                #region labelStreet
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(11, 118);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(48, 13);
                this.label4.TabIndex = 4;
                this.label4.Text = "Strasse: ";
                #endregion
                #region textBoxUserStreet
                this.textBoxUserStreet.Location = new System.Drawing.Point(77, 115);
                this.textBoxUserStreet.Name = "textBoxUserStreet";
                this.textBoxUserStreet.Size = new System.Drawing.Size(164, 20);
                this.textBoxUserStreet.TabIndex = 5;
                #endregion
                #region  textBoxUserHomeNumber
                this.textBoxUserHomeNumber.Location = new System.Drawing.Point(248, 115);
                this.textBoxUserHomeNumber.Name = "textBoxUserHomeNumber";
                this.textBoxUserHomeNumber.Size = new System.Drawing.Size(29, 20);
                this.textBoxUserHomeNumber.TabIndex = 6;
                #endregion

                #region labelUserStreetExtention
                this.labelUserStreetExtention.AutoSize = true;
                this.labelUserStreetExtention.Location = new System.Drawing.Point(12, 145);
                this.labelUserStreetExtention.Name = "labelUserStreetExtention";
                this.labelUserStreetExtention.Size = new System.Drawing.Size(42, 13);
                this.labelUserStreetExtention.TabIndex = 7;
                this.labelUserStreetExtention.Text = "Zusatz:";
                #endregion
                #region textBoxUserAdressExtention
                this.textBoxUserAdressExtention.Location = new System.Drawing.Point(77, 145);
                this.textBoxUserAdressExtention.Name = "textBoxUserAdressExtention";
                this.textBoxUserAdressExtention.Size = new System.Drawing.Size(200, 20);
                this.textBoxUserAdressExtention.TabIndex = 8;
                #endregion

                #region labelPLZ
                this.labelPLZ.AutoSize = true;
                this.labelPLZ.Location = new System.Drawing.Point(12, 175);
                this.labelPLZ.Name = "labelPLZ";
                this.labelPLZ.Size = new System.Drawing.Size(30, 13);
                this.labelPLZ.TabIndex = 9;
                this.labelPLZ.Text = "PLZ:";
                #endregion
                #region textBoxUserPLZ
                this.textBoxUserPLZ.Location = new System.Drawing.Point(77, 172);
                this.textBoxUserPLZ.Name = "textBoxUserPLZ";
                this.textBoxUserPLZ.Size = new System.Drawing.Size(58, 20);
                this.textBoxUserPLZ.TabIndex = 10;
                #endregion

                #region labelUserCity
                this.labelUserCity.AutoSize = true;
                this.labelUserCity.Location = new System.Drawing.Point(146, 178);
                this.labelUserCity.Name = "labelUserCity";
                this.labelUserCity.Size = new System.Drawing.Size(35, 13);
                this.labelUserCity.TabIndex = 11;
                this.labelUserCity.Text = "Stadt:";
                #endregion
                #region textBoxUserCity
                this.textBoxUserCity.Location = new System.Drawing.Point(187, 171);
                this.textBoxUserCity.Name = "textBoxUserCity";
                this.textBoxUserCity.Size = new System.Drawing.Size(90, 20);
                this.textBoxUserCity.TabIndex = 12;
                #endregion

                #region  labelUserCoutry
                this.labelUserCoutry.AutoSize = true;
                this.labelUserCoutry.Location = new System.Drawing.Point(12, 207);
                this.labelUserCoutry.Name = "labelUserCoutry";
                this.labelUserCoutry.Size = new System.Drawing.Size(34, 13);
                this.labelUserCoutry.TabIndex = 13;
                this.labelUserCoutry.Text = "Land:";
                #endregion

                #region comboBoxUserCountries
                this.comboBoxUserCountries.FormattingEnabled = true;
                this.comboBoxUserCountries.Location = new System.Drawing.Point(77, 207);
                this.comboBoxUserCountries.Name = "comboBoxUserCountries";
                this.comboBoxUserCountries.Size = new System.Drawing.Size(200, 21);
                this.comboBoxUserCountries.TabIndex = 14;
                #endregion
                #region buttonUserAdd
                this.buttonUserAdd.Location = new System.Drawing.Point(14, 240);
                this.buttonUserAdd.Name = "buttonUserAdd";
                this.buttonUserAdd.Size = new System.Drawing.Size(75, 23);
                this.buttonUserAdd.TabIndex = 15;
                this.buttonUserAdd.Text = "hinzufügen";
                this.buttonUserAdd.UseVisualStyleBackColor = true;
                this.buttonUserAdd.Click += new System.EventHandler(this.buttonUserAdd_Click);
                #endregion
                #region clear cancle button
                this.clearCancel.Text = "Leeren";
                this.clearCancel.Location = new Point(100, 240);
                this.clearCancel.Click += new EventHandler(this.clearCancel_Click);
                #endregion
                #endregion
                #region userDetails Panel
                #region userDetails Panel Value
                this.userDetails.ForeColor = System.Drawing.Color.Black;
                this.userDetails.Location = new System.Drawing.Point(CustomerMainPanel.Width * 3 / 4 - 2, UserAddPanel.Height + 15);
                this.userDetails.Name = "userDetails";
                this.userDetails.Size = new System.Drawing.Size(CustomerMainPanel.Width / 4 - 10, CustomerMainPanel.Height - UserAddPanel.Height - 15);
                this.userDetails.TabIndex = 3;
                this.userDetails.TabStop = false;
                this.userDetails.Text = "Kunden Details";
                #endregion
                #region labelUserDetailsName
                this.labelUserDetailsName.AutoSize = true;
                this.labelUserDetailsName.Location = new System.Drawing.Point(10, 19);
                this.labelUserDetailsName.Name = "labelUserDetailsName";
                this.labelUserDetailsName.Size = new System.Drawing.Size(41, 13);
                this.labelUserDetailsName.TabIndex = 1;
                this.labelUserDetailsName.Text = "Name: ";
                #endregion
                #region labelUserDetailsAdress
                this.labelUserDetailsAdress.AutoSize = true;
                this.labelUserDetailsAdress.Location = new System.Drawing.Point(10, 37);
                this.labelUserDetailsAdress.Name = "labelUserDetailsAdress";
                this.labelUserDetailsAdress.Size = new System.Drawing.Size(51, 13);
                this.labelUserDetailsAdress.TabIndex = 2;
                this.labelUserDetailsAdress.Text = "Adresse: ";
                #endregion
                #region edit user button
                this.EditUser.Text = "bearbeiten";
                this.EditUser.Location = new Point(10, 100);
                this.EditUser.Click += new EventHandler(this.EditUser_Click);
                #endregion
                #endregion
                #region userStatistic Panel
                #region userStatistic Panel Values
                this.userStatistic.ForeColor = System.Drawing.Color.Black;
                this.userStatistic.Location = new System.Drawing.Point(CustomerMainPanel.Width / 3 - 4, 13);
                this.userStatistic.Name = "userStatistic";
                this.userStatistic.Size = new System.Drawing.Size(CustomerMainPanel.Width * 2 / 3 - 7, UserAddPanel.Height);
                this.userStatistic.TabIndex = 2;
                this.userStatistic.TabStop = false;
                this.userStatistic.Text = "Statistic";
                #endregion



                #region chartUserAge
                ChartArea chartArea1 = new ChartArea();
                Series series1 = new Series();
                chartArea1.Name = "ChartArea1";
                this.chartUserAge.ChartAreas.Add(chartArea1);
                this.chartUserAge.Location = new System.Drawing.Point(0, 0);
                this.chartUserAge.Name = "chartUserAge";
                series1.ChartArea = "ChartArea1";
                series1.Legend = "Legend1";
                series1.Name = "Series1";
                this.chartUserAge.Series.Add(series1);
                this.chartUserAge.Width = this.userStatistic.Width / 2;
                this.chartUserAge.Height = this.userStatistic.Height;
                this.chartUserAge.TabIndex = 1;
                this.chartUserAge.Text = "chart1";


                chartUserAge.Series[0].Points.Clear();
                chartUserAge.Series[0].ChartType = SeriesChartType.Doughnut;
                chartUserAge.BackColor = Color.Transparent;


                chartUserAge.ChartAreas[0].BackColor = Color.Transparent;
                //chartUserAge.Legends.RemoveAt(0);
                #endregion

                #region chart reg date
                ChartArea chartArea2 = new ChartArea();
                Legend legend2 = new Legend();
                Series series2 = new Series();

                chartArea2.Name = "ChartArea2";
                this.chartRegDate.ChartAreas.Add(chartArea2);

                this.chartRegDate.Location = new System.Drawing.Point(this.userStatistic.Width / 2 , 0);
                this.chartRegDate.Name = "chartUserAge";
                series2.ChartArea = "ChartArea2";
                series2.Legend = "Legend2";
                series2.Name = "Series2";
                this.chartRegDate.Series.Add(series2);
                this.chartRegDate.Width = this.userStatistic.Width / 2;
                this.chartRegDate.Height = this.userStatistic.Height;
                this.chartRegDate.TabIndex = 1;
                this.chartRegDate.Text = "chart2";

                this.chartRegDate.ChartAreas[0].AxisX.LineColor = Color.LightGray;
                this.chartRegDate.ChartAreas[0].AxisY.LineColor = Color.LightGray;
                this.chartRegDate.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                this.chartRegDate.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                this.chartRegDate.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
                this.chartRegDate.ChartAreas[0].AxisY.MajorGrid.Interval = 5;

                chartRegDate.Series[0].Points.Clear();
                chartRegDate.Series[0].ChartType = SeriesChartType.Line;
                chartRegDate.BackColor = Color.Transparent;


                chartRegDate.ChartAreas[0].BackColor = Color.Transparent;
                #endregion


                #region ChartLabel
                ChartLabel.Text = "Altersverteilung";
                ChartLabel.Location = new Point(135, 140);
                ChartLabel.Font = new Font("Tahoma", 11.0F);
                ChartLabel.AutoSize = true;
                #endregion
                #endregion
                #region UserTablePanel
                #region UserTablePanel Values
                this.UserTablePanel.ForeColor = System.Drawing.Color.Black;
                this.UserTablePanel.Location = new System.Drawing.Point(13, UserAddPanel.Height + 15);
                this.UserTablePanel.Name = "UserTablePanel";
                this.UserTablePanel.Size = new System.Drawing.Size(CustomerMainPanel.Width * 3 / 4 - 25, CustomerMainPanel.Height - UserAddPanel.Height - 15);
                this.UserTablePanel.TabIndex = 1;
                this.UserTablePanel.TabStop = false;
                this.UserTablePanel.Text = "Kunden";
                #endregion

                #region  userTableDataSet
                this.userTableDataSet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.userTableDataSet.Location = new System.Drawing.Point(6, 19);
                this.userTableDataSet.Name = "userTableDataSet";
                this.userTableDataSet.Size = new System.Drawing.Size(UserTablePanel.Width - 15, UserTablePanel.Height - 25);
                this.userTableDataSet.TabIndex = 0;
                this.userTableDataSet.CellClick += new DataGridViewCellEventHandler(this.userTableDataSet_CellClick);
                //enable contentless left colum
                this.userTableDataSet.RowHeadersVisible = false;
                //enable empty last row
                this.userTableDataSet.AllowUserToAddRows = false;
                this.userTableDataSet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                #endregion
                #endregion

                #endregion
                #region booksMainPanel
                this.BooksMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.BooksMainPanel.Location = this.CustomerMainPanel.Location;
                this.BooksMainPanel.Size = this.CustomerMainPanel.Size;
                this.BooksMainPanel.Visible = false;

                #region groupBoxAddBook
                this.groupBoxAddBook.Text = "Buch hinzufügen";
                this.groupBoxAddBook.Location = new Point(10, 10);
                this.groupBoxAddBook.Size = new Size(this.BooksMainPanel.Width / 3 - 20, this.BooksMainPanel.Height / 4 - 20);
                #region Book Add Labels
                this.labelBookAddauthor.Location = new Point(10, 20);
                this.lableBookAddTitel.Location = new Point(labelBookAddauthor.Location.X, labelBookAddauthor.Location.Y + 30);
                this.labelBookAddsubjectArea.Location = new Point(labelBookAddauthor.Location.X, labelBookAddauthor.Location.Y + 60);


                this.labelBookAddauthor.Text = "Author:";
                this.lableBookAddTitel.Text = "Title";
                this.labelBookAddsubjectArea.Text = "Genre:";
                #endregion
                #region Book Add TextBoxes;
                this.textBoxBookAddauthor.Location = new Point(labelBookAddauthor.Location.X + 50, labelBookAddauthor.Location.Y);
                this.textBoxBookAddTitel.Location = new Point(labelBookAddauthor.Location.X + 50, labelBookAddauthor.Location.Y + 30);
                this.textBoxBookAddsubjectArea.Location = new Point(labelBookAddauthor.Location.X + 50, labelBookAddauthor.Location.Y + 60);

                this.textBoxBookAddauthor.Size = new Size(200, 20);
                this.textBoxBookAddTitel.Size = this.textBoxBookAddauthor.Size;
                this.textBoxBookAddsubjectArea.Size = this.textBoxBookAddauthor.Size;
                #endregion
                #region addBooksActionButton
                this.addBooksActionButton.Location = new Point(10, 110);
                this.addBooksActionButton.Size = new Size(95, 25);
                this.addBooksActionButton.Text = "Buch hinzufügen";
                this.addBooksActionButton.Click += new System.EventHandler(addBooksActionButton_Click);
                #endregion
                #endregion
                #region groupBoxBookTable
                this.groupBoxBookTable.Text = "Bücher Tabelle";
                this.groupBoxBookTable.Location = new Point(10, this.groupBoxAddBook.Location.Y + this.groupBoxAddBook.Height + 10);
                this.groupBoxBookTable.Size = new Size(this.BooksMainPanel.Width / 3 - 20, this.BooksMainPanel.Height * 3 / 4);
                #region booksTableDataSet
                this.booksTableDataSet.Location = new Point(10, 20);
                this.booksTableDataSet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.booksTableDataSet.Name = "booksTableDataSet";
                this.booksTableDataSet.Size = new System.Drawing.Size(this.groupBoxBookTable.Width - 25, this.groupBoxBookTable.Height - 35);
                this.booksTableDataSet.TabIndex = 0;
                this.booksTableDataSet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //enable contentless left colum
                this.booksTableDataSet.RowHeadersVisible = false;
                //enable empty last row
                this.booksTableDataSet.AllowUserToAddRows = false;

                #endregion
                #endregion
                #endregion
                #region BorrowMainPanel
                this.BorrowMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //this.BorrowMainPanel.BackColor = System.Drawing.Color.Red;
                this.BorrowMainPanel.Location = this.CustomerMainPanel.Location;
                this.BorrowMainPanel.Size = this.CustomerMainPanel.Size;
                this.BorrowMainPanel.Visible = false;

                #region GroupBox Customer
                this.borrowCustomer.Location = new Point(10, 10);
                this.borrowCustomer.Text = "Kunde";
                this.borrowCustomer.Size = new Size(this.BorrowMainPanel.Width - 20, this.BorrowMainPanel.Height/3 - 10);


                #region label
                this.borrowCustomerIDLabel.Text = "Kunden ID: ";
                this.borrowCustomerIDLabel.AutoSize = true;
                this.borrowCustomerIDLabel.Location = new Point(20, 45);

                this.borrowCustomerInfoLabel.Text = "";
                this.borrowCustomerInfoLabel.AutoSize = true;
                this.borrowCustomerInfoLabel.Location = new Point(260,45);

                this.borrowCustomerCardValidLabel.Text = "überprüfe Ausweis: ";
                this.borrowCustomerCardValidLabel.AutoSize = true;
                this.borrowCustomerCardValidLabel.Location = new Point(20,95);
                
                #endregion

                #region textbox
                this.borrowCustomerIDTextBox.Location = new Point(85,40);
                this.borrowCustomerIDTextBox.TabIndex = 99;
                this.borrowCustomerIDTextBox.KeyUp += new KeyEventHandler(this.borrowCustomerIDTextBox_KeyUp);
                #endregion

                #region images
                //this.imageCustomerFound.BackgroundImage = global::BiBo.Properties.Resources.user_found;
                this.imageCustomerFound.Size = new Size(48, 48);
                this.imageCustomerFound.Location = new Point(200,20);

                this.imageCustomerCardValidation.Size = new Size(48, 48);
                this.imageCustomerCardValidation.Location = new Point(120,80);
               
                #endregion

                #endregion
                #region GroupBox Books
                this.borrowBooks.Location = new Point(10, this.BorrowMainPanel.Height / 3);
                this.borrowBooks.Text = "Bücher";
                this.borrowBooks.Size = new Size(this.BorrowMainPanel.Width - 20, this.BorrowMainPanel.Height/ 3 - 10);
                #endregion
                #endregion
                #endregion

                #region employee side bar
                this.employeeSideBarGroupeBox.Location = new Point(10, 10);
                this.employeeSideBarGroupeBox.Size = new Size(200, windowHeight - 20);

                #region LoginAs Label
                this.LoginAs.AutoSize = true;
                this.LoginAs.BackColor = System.Drawing.SystemColors.Control;
                this.LoginAs.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.LoginAs.ForeColor = System.Drawing.Color.Black;
                this.LoginAs.Location = new System.Drawing.Point(10, 20);
                this.LoginAs.Name = "LoginAs";
                this.LoginAs.Size = new System.Drawing.Size(95, 13);
                this.LoginAs.TabIndex = 0;
                this.LoginAs.Text = "Angemeldet: ";
                #endregion
                #region userName
                this.userName.AutoSize = true;
                this.userName.BackColor = System.Drawing.SystemColors.Control;
                this.userName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.userName.ForeColor = System.Drawing.Color.Black;
                this.userName.Location = new System.Drawing.Point(90, 20);
                this.userName.Margin = new Padding(0);
                this.userName.Name = "userName";
                this.userName.Size = new System.Drawing.Size(11, 13);
                this.userName.TabIndex = 0;
                this.userName.Text = " ";
                #endregion

                #region logout button
                this.EmployeeLogout.Location = new Point(10, 80);
                this.EmployeeLogout.Text = "Abmelden";
                this.EmployeeLogout.Click += new System.EventHandler(this.EmployeeLogout_Click);
                #endregion

                #region UserStatus Label
                this.UserStatus.AutoSize = true;
                this.UserStatus.BackColor = System.Drawing.SystemColors.Control;
                this.UserStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UserStatus.ForeColor = System.Drawing.Color.Black;
                this.UserStatus.Location = new System.Drawing.Point(10, 50);
                this.UserStatus.Name = "UserStatus";
                this.UserStatus.Size = new System.Drawing.Size(52, 13);
                this.UserStatus.TabIndex = 1;
                this.UserStatus.Text = "Status: ";
                #endregion

                #region userStat
                this.userStat.AutoSize = true;
                this.userStat.BackColor = System.Drawing.SystemColors.Control;
                this.userStat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.userStat.ForeColor = System.Drawing.Color.Black;
                this.userStat.Location = new System.Drawing.Point(90, 50);
                this.userStat.Name = "userStat";
                this.userStat.Size = new System.Drawing.Size(11, 13);
                this.userStat.TabIndex = 1;
                this.userStat.Text = " ";
                #endregion

                #region groupBoxSearch
                int groupBoxSearchY = employeeMainGroupeBox.Location.Y + UserTablePanel.Location.Y - 5;
                 this.groupBoxSearch.Location = new System.Drawing.Point(10, groupBoxSearchY);
                this.groupBoxSearch.Name = "groupBoxSearch";
                this.groupBoxSearch.Size = new System.Drawing.Size(175, 55);
                this.groupBoxSearch.TabIndex = 1;
                this.groupBoxSearch.TabStop = false;
                this.groupBoxSearch.Text = "Suche";

                #region textBoxSearch
                this.textBoxSearch.Location = new System.Drawing.Point(10, 20);
                this.textBoxSearch.Name = "textBoxSearch";
                this.textBoxSearch.Size = new System.Drawing.Size(this.groupBoxSearch.Width - 25, 20);
                this.textBoxSearch.TabIndex = 0;
                this.textBoxSearch.KeyUp += new KeyEventHandler(this.textBoxSearch_KeyUp);
                #endregion
                #endregion

                #region  groupBoxSelectedRows          
                this.groupBoxSelectedRows.Location = new System.Drawing.Point(10, this.groupBoxSearch.Location.Y + this.groupBoxSearch.Height + 10);
                this.groupBoxSelectedRows.Name = "groupBoxSelectedRows";
                this.groupBoxSelectedRows.Size = new System.Drawing.Size(this.groupBoxSearch.Width, 55);
                this.groupBoxSelectedRows.TabIndex = 4;
                this.groupBoxSelectedRows.TabStop = false;
                this.groupBoxSelectedRows.Text = "Markierte";
                this.groupBoxSelectedRows.Visible = true;

                #region buttonDeleteSelectedRows
                this.buttonDeleteSelectedRows.Location = new System.Drawing.Point(6, 19);
                this.buttonDeleteSelectedRows.Name = "buttonDeleteSelectedRows";
                this.buttonDeleteSelectedRows.Size = new System.Drawing.Size(75, 23);
                this.buttonDeleteSelectedRows.TabIndex = 0;
                this.buttonDeleteSelectedRows.Text = "löschen";
                this.buttonDeleteSelectedRows.UseVisualStyleBackColor = true;
                this.buttonDeleteSelectedRows.Click += new System.EventHandler(this.buttonDeleteSelectedRows_Click);
                #endregion
                #endregion

                #endregion


                
                #region currently panel1 not used
                this.panel1.BackgroundImage = global::BiBo.Properties.Resources.icon2;
                this.panel1.Location = new System.Drawing.Point(352, 18);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(64, 64);
                this.panel1.TabIndex = 2;
                #endregion






                #region close Button
                this.close.Text = "x";
                this.close.Location = new Point(w - 50, 30);
                this.close.Size = new Size(30, 30);
                this.close.Click += new System.EventHandler(close_Click);
                #endregion
                #endregion
            #endregion

                #region Layouts
                this.CustomerMainPanel.SuspendLayout();
                    this.BooksMainPanel.SuspendLayout();
                    this.UserAddPanel.SuspendLayout();
                    this.userDetails.SuspendLayout();
                    this.userStatistic.SuspendLayout();
                    this.UserTablePanel.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(this.userTableDataSet)).BeginInit();
                    this.groupBoxSearch.SuspendLayout();
                    this.groupBoxSelectedRows.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(this.chartUserAge)).BeginInit();
                    this.SuspendLayout();
                    #endregion

                    quickFix();

                    /*
             * Controll Adds
             */

            #region groupBoxBookTable
            this.groupBoxBookTable.Controls.Add(this.booksTableDataSet);
            #endregion
            #region Adds to groupBoxAddBook
                    this.groupBoxAddBook.Controls.Add(this.textBoxBookAddauthor);
            this.groupBoxAddBook.Controls.Add(this.textBoxBookAddsubjectArea);
            this.groupBoxAddBook.Controls.Add(this.textBoxBookAddTitel);
            this.groupBoxAddBook.Controls.Add(this.labelBookAddauthor);
            this.groupBoxAddBook.Controls.Add(this.labelBookAddsubjectArea);
            this.groupBoxAddBook.Controls.Add(this.lableBookAddTitel);
            this.groupBoxAddBook.Controls.Add(this.addBooksActionButton);
            #endregion
            #region Adds to BooksMainPanel
            this.BooksMainPanel.Controls.Add(this.groupBoxAddBook);
            this.BooksMainPanel.Controls.Add(this.groupBoxBookTable);
            #endregion
            #region Adds to CustomerMainPanel
            this.CustomerMainPanel.Controls.Add(this.UserAddPanel);
            this.CustomerMainPanel.Controls.Add(this.userDetails);
            this.CustomerMainPanel.Controls.Add(this.userStatistic);
            this.CustomerMainPanel.Controls.Add(this.UserTablePanel);
            #endregion
            #region  Adds to UserAddPanel
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
            this.UserAddPanel.Controls.Add(this.clearCancel);
            #endregion
            #region Adds to userDetails panel
            this.userDetails.Controls.Add(this.labelUserDetailsAdress);
            this.userDetails.Controls.Add(this.labelUserDetailsName);
            this.userDetails.Controls.Add(this.labelUserDetails);
            this.userDetails.Controls.Add(this.EditUser);
            #endregion
            #region Adds to userStatistic panel
            this.chartUserAge.Controls.Add(this.ChartLabel);
            this.userStatistic.Controls.Add(this.chartUserAge);
            this.userStatistic.Controls.Add(this.chartRegDate);

            #endregion
            #region Adds to userTabelPanel
            this.UserTablePanel.Controls.Add(this.userTableDataSet);
            #endregion
            #region Adds to groupBoxSearch
            this.groupBoxSearch.Controls.Add(this.textBoxSearch);
            #endregion
            #region Adds to groupBoxSelectedRows
            this.groupBoxSelectedRows.Controls.Add(this.buttonDeleteSelectedRows);
            #endregion
            #region Add to Super Panel Employee
            #region adds
                 this.employeeTabsGroupeBox.Controls.Add(this.customerImage);
                 this.employeeTabsGroupeBox.Controls.Add(this.booksImage);
                 this.employeeTabsGroupeBox.Controls.Add(this.borrowImage);
            #endregion
            this.SuperPanelEmployee.Controls.Add(this.employeeTabsGroupeBox);
            #region adds
            this.employeeMainGroupeBox.Controls.Add(this.CustomerMainPanel);
            this.employeeMainGroupeBox.Controls.Add(this.BooksMainPanel);
            this.employeeMainGroupeBox.Controls.Add(this.BorrowMainPanel);
            
                       
            #endregion
            this.SuperPanelEmployee.Controls.Add(this.employeeMainGroupeBox);
 
            #region adds
            this.employeeSideBarGroupeBox.Controls.Add(this.userName);
            this.employeeSideBarGroupeBox.Controls.Add(this.LoginAs);

            this.employeeSideBarGroupeBox.Controls.Add(this.EmployeeLogout);

            this.employeeSideBarGroupeBox.Controls.Add(this.UserStatus);
            this.employeeSideBarGroupeBox.Controls.Add(this.userStat);

            this.employeeSideBarGroupeBox.Controls.Add(this.groupBoxSearch);
            this.employeeSideBarGroupeBox.Controls.Add(this.groupBoxSelectedRows);
            
            
            #endregion
            this.SuperPanelEmployee.Controls.Add(this.employeeSideBarGroupeBox);


            /*
            this.SuperPanelEmployee.Controls.Add(this.groupBoxSelectedRows);
            this.SuperPanelEmployee.Controls.Add(this.groupBoxSearch);
            this.SuperPanelEmployee.Controls.Add(this.CustomerMainPanel);
            this.SuperPanelEmployee.Controls.Add(this.BooksMainPanel);
            this.SuperPanelEmployee.Controls.Add(this.BorrowMainPanel);
            this.SuperPanelEmployee.Controls.Add(this.userStat);
            this.SuperPanelEmployee.Controls.Add(this.UserStatus);
            this.SuperPanelEmployee.Controls.Add(this.userName);
            this.SuperPanelEmployee.Controls.Add(this.LoginAs);
            //this.SuperPanelEmployee.Controls.Add(this.panel1);
            this.SuperPanelEmployee.Controls.Add(this.booksImage);
            this.SuperPanelEmployee.Controls.Add();
            this.SuperPanelEmployee.Controls.Add(this.borrowImage);
            this.SuperPanelEmployee.Controls.Add(this.close);
             * */
            #endregion
            #region Add to groupBoxLogin
            this.groupBoxLogin.Controls.Add(this.textBoxUserLoginName);
            this.groupBoxLogin.Controls.Add(this.textBoxUserLoginPass);
            this.groupBoxLogin.Controls.Add(this.labelUserLoginName);
            this.groupBoxLogin.Controls.Add(this.labelUserLoginPass);
            this.groupBoxLogin.Controls.Add(this.login);

            #endregion
            #region add to borrowMainPanel
            this.BorrowMainPanel.Controls.Add(this.borrowCustomer);
            this.BorrowMainPanel.Controls.Add(this.borrowBooks);
            #endregion
            #region add to borrowCustomer groupbox
            this.borrowCustomer.Controls.Add(this.borrowCustomerIDLabel);
            this.borrowCustomer.Controls.Add(this.borrowCustomerIDTextBox);
            this.borrowCustomer.Controls.Add(this.imageCustomerFound);
            this.borrowCustomer.Controls.Add(this.borrowCustomerInfoLabel);
            this.borrowCustomer.Controls.Add(this.borrowCustomerCardValidLabel);
            this.borrowCustomer.Controls.Add(this.imageCustomerCardValidation);
            
            

            #endregion
            #region add to borrowBooks groupbox
            #endregion
            #region Add to SuperPanelLogin
            this.SuperPanelLogin.Controls.Add(this.groupBoxLogin);
            this.SuperPanelLogin.Controls.Add(this.close);
            #endregion

            #region Add to customerSideBarGroupeBox
            this.customerSideBarGroupeBox.Controls.Add(this.loggedInAs_Name);
            this.customerSideBarGroupeBox.Controls.Add(this.loggedInAs_Adress);
            this.customerSideBarGroupeBox.Controls.Add(this.Logout);
            
            #endregion

            #region customerTabsGroupeBox
            this.customerTabsGroupeBox.Controls.Add(this.imageSearch);
            this.customerTabsGroupeBox.Controls.Add(this.imageAccount);
            #endregion

            #region customerMainGroupeBox
            this.customerMainGroupeBox.Controls.Add(this.customerSearchBookPanel);
            this.customerMainGroupeBox.Controls.Add(this.customerAccountPanel);
            
            #endregion

            #region add to customerSearchBookPanel
            this.customerSearchBookPanel.Controls.Add(this.labelCustomerSearch);
            this.customerSearchBookPanel.Controls.Add(this.textBoxCustomerSearch);
            this.customerSearchBookPanel.Controls.Add(this.checkBoxCustomerSearchAutor);
            this.customerSearchBookPanel.Controls.Add(this.checkBoxCustomerSearchTitle);
            this.customerSearchBookPanel.Controls.Add(this.customerSearchBook);
            #endregion
            #region add to customerAccountPanel
            this.customerAccountPanel.Controls.Add(this.customerChargeAccountGroupBox);
            this.customerAccountPanel.Controls.Add(this.customerBooksGroupeBox);

            #endregion
            #region Add to SuperPanelCustomer
            this.SuperPanelCustomer.Controls.Add(this.customerSideBarGroupeBox);
            this.SuperPanelCustomer.Controls.Add(this.customerTabsGroupeBox);
            this.SuperPanelCustomer.Controls.Add(this.customerMainGroupeBox);
            #endregion
            #region Add to From 1 (main window)
            this.Controls.Add(this.SuperPanelEmployee);
            this.Controls.Add(this.SuperPanelLogin);
            this.Controls.Add(this.SuperPanelCustomer);
            #endregion


        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
       
      //quick fixes
        //set font-color default to black for winXP OS
        private void quickFix()
        {
          //set Buttonfont to black
          this.buttonDeleteSelectedRows.ForeColor = Color.Black;
          this.buttonUserAdd.ForeColor = Color.Black;
          this.close.ForeColor = Color.Black;
          this.addBooksActionButton.ForeColor = Color.Black;

          //set labelfont to black
          this.label1.ForeColor = Color.Black;
          this.label2.ForeColor = Color.Black;
          this.label3.ForeColor = Color.Black;
          this.label4.ForeColor = Color.Black;
          this.labelPLZ.ForeColor = Color.Black;
          this.labelUserCity.ForeColor = Color.Black;
          this.labelUserCoutry.ForeColor = Color.Black;
          this.labelUserDetails.ForeColor = Color.Black;
          this.labelUserDetailsAdress.ForeColor = Color.Black;
          this.labelUserDetailsName.ForeColor = Color.Black;
          this.labelUserStreetExtention.ForeColor = Color.Black;
          this.labelBookAddauthor.ForeColor = Color.Black;
          this.labelBookAddsubjectArea.ForeColor = Color.Black;
          this.lableBookAddTitel.ForeColor = Color.Black;

          //set tablecolor to black
          this.booksTableDataSet.ForeColor = Color.Black;
          this.userTableDataSet.ForeColor = Color.Black;

          //set columns and rows fix, so that no one can change the size
          this.userTableDataSet.AllowUserToResizeColumns = false;
          this.userTableDataSet.AllowUserToResizeRows = false;

          this.booksTableDataSet.AllowUserToResizeColumns = false;
          this.booksTableDataSet.AllowUserToResizeRows = false;
          
          //other labels @TODO richtig einordnen
          this.borrowCustomerCardValidLabel.ForeColor = Color.Black;
          this.borrowCustomerIDLabel.ForeColor = Color.Black;
          this.borrowCustomerInfoLabel.ForeColor = Color.Black;
          this.checkBoxCustomerSearchAutor.ForeColor = Color.Black;
          this.checkBoxCustomerSearchTitle.ForeColor = Color.Black;
          this.clearCancel.ForeColor = Color.Black;
          this.close.ForeColor = Color.Black;
          this.customerSearchBook.ForeColor = Color.Black;
          this.labelCustomerSearch.ForeColor = Color.Black;
          this.LoginAs.ForeColor = Color.Black;
          this.loggedInAs_Adress.ForeColor = Color.Black;
          this.loggedInAs_Name.ForeColor = Color.Black;
          this.login.ForeColor = Color.Black;
          this.Logout.ForeColor = Color.Black;
          this.EmployeeLogout.ForeColor = Color.Black;
          this.labelUserLoginName.ForeColor = Color.Black;
          this.labelUserLoginPass.ForeColor = Color.Black;
        }

        
      
    }
}

