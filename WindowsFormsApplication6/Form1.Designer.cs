using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;


//Shortcut to shut all nodes in visual studio is Ctrl + M + O
//Shortcut to open all nodes in visual studio is Ctrl + M + L

namespace BiBo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        
        #region init Panels
        private Panel customerImage                 = new Panel();
        private Panel panel1                        = new Panel();
        private Panel CustomerMainPanel             = new Panel();
        private Panel BooksMainPanel                = new Panel();
        private Panel BorrowMainPanel               = new Panel();
        private Panel booksImage                    = new Panel();
        private Panel borrowImage                   = new Panel();
        #endregion
        #region init GroupBox
        private GroupBox UserAddPanel               = new GroupBox();
        private GroupBox groupBoxAddBook            = new GroupBox();
        private GroupBox userDetails                = new GroupBox();
        private GroupBox userStatistic              = new GroupBox();
        private GroupBox UserTablePanel             = new GroupBox();
        private GroupBox groupBoxSearch             = new GroupBox();
        private GroupBox groupBoxSelectedRows       = new GroupBox();
        private GroupBox ageChartPanel              = new GroupBox();
        private GroupBox groupBoxBookTable          = new GroupBox();
        #endregion
        #region init Button
        private Button buttonUserAdd                = new Button();
        private Button buttonDeleteSelectedRows     = new Button();
        private Button close                        = new Button();
        private Button addBooksActionButton         = new Button();
        #endregion
        #region init ComboBox
        private ComboBox comboBoxUserCountries      = new ComboBox();
        #endregion
        #region init Label
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
        #endregion
        #region init TextBox
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
        
        #endregion
        #region init Chart
        private Chart chartUserAge                   = new Chart();
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

                #region LoginAs Label
                this.LoginAs.AutoSize = true;
                this.LoginAs.BackColor = System.Drawing.SystemColors.Window;
                this.LoginAs.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.LoginAs.ForeColor = System.Drawing.Color.Black;
                this.LoginAs.Location = new System.Drawing.Point(21, 32);
                this.LoginAs.Name = "LoginAs";
                this.LoginAs.Size = new System.Drawing.Size(95, 13);
                this.LoginAs.TabIndex = 0;
                this.LoginAs.Text = "eingeloggt als: ";
                #endregion
                    #region userName
                    this.userName.AutoSize = true;
                    this.userName.BackColor = System.Drawing.SystemColors.Window;
                    this.userName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.userName.ForeColor = System.Drawing.Color.Black;
                    this.userName.Location = new System.Drawing.Point(106, 32);
                    this.userName.Margin = new Padding(0);
                    this.userName.Name = "userName";
                    this.userName.Size = new System.Drawing.Size(11, 13);
                    this.userName.TabIndex = 0;
                    this.userName.Text = " ";
                    #endregion

                #region UserStatus Label
                this.UserStatus.AutoSize = true;
                this.UserStatus.BackColor = System.Drawing.SystemColors.Window;
                this.UserStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.UserStatus.ForeColor = System.Drawing.Color.Black;
                this.UserStatus.Location = new System.Drawing.Point(21, 51);
                this.UserStatus.Name = "UserStatus";
                this.UserStatus.Size = new System.Drawing.Size(52, 13);
                this.UserStatus.TabIndex = 1;
                this.UserStatus.Text = "Status: ";
                #endregion
                    #region userStat
                    this.userStat.AutoSize = true;
                    this.userStat.BackColor = System.Drawing.SystemColors.Window;
                    this.userStat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.userStat.ForeColor = System.Drawing.Color.Black;
                    this.userStat.Location = new System.Drawing.Point(64, 51);
                    this.userStat.Name = "userStat";
                    this.userStat.Size = new System.Drawing.Size(11, 13);
                    this.userStat.TabIndex = 1;
                    this.userStat.Text = " ";
                    #endregion

                #region customer user image
                this.customerImage.BackgroundImage = global::BiBo.Properties.Resources.customer;
                this.customerImage.Location = new System.Drawing.Point(221, 19);
                this.customerImage.Name = "panel2";
                this.customerImage.Size = new System.Drawing.Size(64, 64);
                this.customerImage.TabIndex = 2;
                this.customerImage.Click += new System.EventHandler(this.customerImage_Click);
                #endregion
                #region books image
                this.booksImage.BackgroundImage = global::BiBo.Properties.Resources.booksicon;
                this.booksImage.Location = new System.Drawing.Point(286, 18);
                this.booksImage.Name = "panel3";
                this.booksImage.Size = new System.Drawing.Size(64, 64);
                this.booksImage.TabIndex = 2;
                this.booksImage.Click += new System.EventHandler(this.booksImage_Click);
                #endregion
                #region borrow image
                this.borrowImage.BackgroundImage = global::BiBo.Properties.Resources.borrow2;
                this.borrowImage.Location = new System.Drawing.Point(350, 19);
                this.borrowImage.Name = "borrowBookImage";
                this.borrowImage.Size = new System.Drawing.Size(64, 64);
                this.borrowImage.TabIndex = 2;
                this.borrowImage.Click += new System.EventHandler(this.borrowImage_Click);
                #endregion
                #region currently panel1 not used
                this.panel1.BackgroundImage = global::BiBo.Properties.Resources.icon2;
                this.panel1.Location = new System.Drawing.Point(352, 18);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(64, 64);
                this.panel1.TabIndex = 2;
                #endregion

                //Main Panel
                #region CutomerMainPanel
                    #region CutomerMainPanel Values
                    this.CustomerMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    this.CustomerMainPanel.Location = new System.Drawing.Point(220, 77);
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
                        this.UserAddPanel.Text = "Kunde hinzufügen";
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

                        #region ageChartPanel
                        this.ageChartPanel.Location = new System.Drawing.Point(15, 15);
                        this.ageChartPanel.Text = "Altersverteilung";
                        this.ageChartPanel.Size = new Size(this.userStatistic.Width / 2, this.userStatistic.Height - 30);

                        #region chartUserAge
                        ChartArea chartArea1 = new ChartArea();
                        Legend legend1 = new Legend();
                        Series series1 = new Series();
                        chartArea1.Name = "ChartArea1";
                        this.chartUserAge.ChartAreas.Add(chartArea1);
                        legend1.Name = "Legend1";
                        this.chartUserAge.Legends.Add(legend1);
                        this.chartUserAge.Location = new System.Drawing.Point(0, 0);
                        this.chartUserAge.Name = "chartUserAge";
                        series1.ChartArea = "ChartArea1";
                        series1.Legend = "Legend1";
                        series1.Name = "Series1";
                        this.chartUserAge.Series.Add(series1);
                        this.chartUserAge.Width = ageChartPanel.Width;
                        this.chartUserAge.Height = ageChartPanel.Height;
                        this.chartUserAge.TabIndex = 1;
                        this.chartUserAge.Text = "chart1";


                        chartUserAge.Series[0].Points.Clear();
                        chartUserAge.Series[0].ChartType = SeriesChartType.Doughnut;
                        chartUserAge.BackColor = Color.Transparent;


                        chartUserAge.ChartAreas[0].BackColor = Color.Transparent;
                        chartUserAge.Legends.RemoveAt(0);
                        #endregion
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
                                    this.addBooksActionButton.Size = new Size(95,25);
                                    this.addBooksActionButton.Text = "Buch hinzufügen";
                                    this.addBooksActionButton.Click += new System.EventHandler(addBooksActionButton_Click);
                                #endregion
                    #endregion
                    #region groupBoxBookTable
                        this.groupBoxBookTable.Text = "Bücher Tabelle";
                        this.groupBoxBookTable.Location = new Point(10, this.groupBoxAddBook.Location.Y + this.groupBoxAddBook.Height + 10);
                        this.groupBoxBookTable.Size = new Size(this.BooksMainPanel.Width / 3 - 20, this.BooksMainPanel.Height * 3 / 4 );
                        #region booksTableDataSet
                            this.booksTableDataSet.Location = new Point(10,20);
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
                #region booksMainPanel
                    //this.BorrowMainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    this.BorrowMainPanel.BackColor = System.Drawing.Color.Red;
                    this.BorrowMainPanel.Location = this.CustomerMainPanel.Location;
                    this.BorrowMainPanel.Size = this.CustomerMainPanel.Size;
                    this.BorrowMainPanel.Visible = false;
                #endregion

                        #region groupBoxSearch
                            this.groupBoxSearch.Location = new System.Drawing.Point(13, CustomerMainPanel.Location.Y + UserTablePanel.Location.Y);
                            this.groupBoxSearch.Name = "groupBoxSearch";
                            this.groupBoxSearch.Size = new System.Drawing.Size(212, 56);
                            this.groupBoxSearch.TabIndex = 1;
                            this.groupBoxSearch.TabStop = false;
                            this.groupBoxSearch.Text = "Suche";

                            #region textBoxSearch
                                this.textBoxSearch.Location = new System.Drawing.Point(6, 19);
                                this.textBoxSearch.Name = "textBoxSearch";
                                this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
                                this.textBoxSearch.TabIndex = 0;
                                this.textBoxSearch.KeyUp += new KeyEventHandler(this.textBoxSearch_KeyUp);
                            #endregion
                        #endregion
                #region  groupBoxSelectedRows
                    this.groupBoxSelectedRows.Location = new System.Drawing.Point(13, groupBoxSearch.Location.Y + groupBoxSearch.Height + 5);
                    this.groupBoxSelectedRows.Name = "groupBoxSelectedRows";
                    this.groupBoxSelectedRows.Size = new System.Drawing.Size(groupBoxSearch.Width, 120);
                    this.groupBoxSelectedRows.TabIndex = 4;
                    this.groupBoxSelectedRows.TabStop = false;
                    this.groupBoxSelectedRows.Text = "Markierte";

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

                #region close Button
                this.close.Text = "x";
                this.close.Location = new Point(w - 50, 30);
                this.close.Size = new Size(30, 30);
                this.close.Click += new System.EventHandler(close_Click);
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
            #endregion
            #region Adds to userDetails panel
            this.userDetails.Controls.Add(this.labelUserDetailsAdress);
            this.userDetails.Controls.Add(this.labelUserDetailsName);
            this.userDetails.Controls.Add(this.labelUserDetails);
            #endregion
            #region Adds to userStatistic panel
            this.userStatistic.Controls.Add(this.ageChartPanel);
            #endregion
            #region Adds to ageChartPanel
            this.ageChartPanel.Controls.Add(this.chartUserAge);
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
            #region Add to From 1 (main window)
            this.Controls.Add(this.groupBoxSelectedRows);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.CustomerMainPanel);
            this.Controls.Add(this.BooksMainPanel);
            this.Controls.Add(this.BorrowMainPanel);
            this.Controls.Add(this.userStat);
            this.Controls.Add(this.UserStatus);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.LoginAs);
            //this.Controls.Add(this.panel1);
            this.Controls.Add(this.booksImage);
            this.Controls.Add(this.customerImage);
            this.Controls.Add(this.borrowImage);
            this.Controls.Add(this.close);
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
        }

        
      
    }
}

