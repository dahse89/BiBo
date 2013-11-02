﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using BiBo.Persons;
using BiBo.DAO;

namespace BiBo
{
    public partial class Form1 : Form
    {
        //content
        private String   LoginAsUserName;
        private String   UserStatusText;
        private DateTime userAddBirthDayDefault = new DateTime(1980,1,1);

        private String  countriesSource = "../../countries.txt";

        private Random r = new Random();

        private CustomerDAO SqlCustomer;


        public Form1(CustomerDAO CustCon)
        {
            this.SqlCustomer = CustCon;
            __construct();
        }


        public Form1()
        {
            __construct();
        }

        private void __construct(){
            InitializeComponent();
            makeResponsivOnce(this);

            //init content
            this.LoginAsUserName = "Philipp Dahse";
            this.UserStatusText = "Admin";

            //render view
            initCourtries();
            publishContent();
           // randomPushUser();
        }

        private void initCourtries()
        {

          List<String> countrieNames = new List<String>();

          //create line string to catch lines from file
          string line;

          // Read the file and display it line by line.
          StreamReader file = new System.IO.StreamReader(this.countriesSource);
          while ((line = file.ReadLine()) != null)
          {
            //add to country dataTable
            countrieNames.Add(line);
          }
          file.Close();

          comboBoxUserCountries.DataSource = countrieNames;
        }

        private void publishContent()
        {
            //login as label
            userName.Text += this.LoginAsUserName;

            //User Status Label
            userStat.Text += this.UserStatusText;

            //userAddBirthDay Default;
            dateTimePickerAddUser.Value = userAddBirthDayDefault;
            DataTable ds = new DataTable("UserTable");

            userTableDataSet.RowHeadersVisible = false;
            userTableDataSet.AllowUserToAddRows = false;

            userTableDataSet.ColumnCount = 7;
            userTableDataSet.Columns[0].Name = "ID";
            userTableDataSet.Columns[1].Name = "Vorname";
            userTableDataSet.Columns[2].Name = "Nachname";
            userTableDataSet.Columns[3].Name = "Alter";
            userTableDataSet.Columns[4].Name = "Status";
            userTableDataSet.Columns[5].Name = "ausgeliehende Bücher";
            userTableDataSet.Columns[6].Name = "Adresse";
            
            userTableDataSet.Columns.Insert(0, new DataGridViewCheckBoxColumn());

            //insert customers from db
            foreach (Customer customer in SqlCustomer.GetAllEntrys())
            {
	        	addToUserTable(customer);
	        }

           
        }


        private void addToUserTable(Customer cust)
        {
            TimeSpan age = DateTime.Now - cust.BirthDate;

            String adress = cust.Street + " " +
                            cust.StreetNumber +"\n " + 
                            cust.AdditionalRoad + "\n " + 
                            cust.ZipCode + " " + 
                            cust.Town + "\n " + 
                            cust.Country;

            userTableDataSet.Rows.Add(
                    false,
                    cust.CustomerID.ToString(),
                    cust.FirstName,
                    cust.LastName,
                    ((int)Math.Floor((DateTime.Now - cust.BirthDate).TotalDays / 365.25D)).ToString(),
                    "test",
                    "0",
                    adress
             );

            setUserTableReadOnly();
        }

        private void setUserTableReadOnly()
        {

            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
                for (int j = 0; j < userTableDataSet.Rows[i].Cells.Count; j++)
                {
                    if (j == 0)
                    {
                        /*checkbox*/


                    }
                    else
                    {
                        userTableDataSet.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //makeResponsiv((Form)sender);
        }

        private void makeResponsivOnce(Form window)
        {
            makeResponsiv(window);
        }

        private void makeResponsiv(Form window)
        {

            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
          	int deskWidth = Screen.PrimaryScreen.Bounds.Width;

            window.Width = deskWidth;
            window.Height = deskHeight;

            //get current window size
            int windowHeight = window.Height;
            int windowWidth = window.Width;


            //resize main panel
            MainPanel.Width = windowWidth - 235;
            MainPanel.Height = windowHeight - 115;

            //resize add user panel
            UserAddPanel.Width = MainPanel.Width / 3 - 25;
            int userAddHeight = MainPanel.Height / 3 - 25;
            int userAddMinHeight = 280;
            UserAddPanel.Height = userAddHeight < userAddMinHeight ? userAddMinHeight : userAddHeight;

            //resize user statstic panel
            userStatistic.Location = new System.Drawing.Point(MainPanel.Width / 3 - 4, 13);
            userStatistic.Height = UserAddPanel.Height;
            userStatistic.Width = MainPanel.Width * 2 / 3 - 7;


            //resize user table panel
            UserTablePanel.Location = new System.Drawing.Point(13, UserAddPanel.Height + 15); 
            UserTablePanel.Width = MainPanel.Width * 3 / 4 - 25;
            UserTablePanel.Height = MainPanel.Height - UserAddPanel.Height - 15;    
            
            //resize search panel
            int y = MainPanel.Location.Y + UserTablePanel.Location.Y;
            groupBoxSearch.Location = new System.Drawing.Point(13, y); 

            //resize selected Rows panel
            y = groupBoxSearch.Location.Y + groupBoxSearch.Height + 5;
            groupBoxSelectedRows.Location = new System.Drawing.Point(13, y);
            groupBoxSelectedRows.Width = groupBoxSearch.Width;

            //resize user details panel
            userDetails.Location = new System.Drawing.Point(MainPanel.Width * 3 / 4 - 2, UserAddPanel.Height + 15);
            userDetails.Width = MainPanel.Width / 4 - 10;
            userDetails.Height = MainPanel.Height - UserAddPanel.Height - 15;

            //resize user table 
            userTableDataSet.Width = UserTablePanel.Width - 15;
            userTableDataSet.Height = UserTablePanel.Height - 25;

           
            
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {

          String UserFName = textBoxUserFirstname.Text;
          String UserName = textBoxUserLastname.Text;

          String Street = textBoxUserStreet.Text;
          String StreetNumber = textBoxUserHomeNumber.Text;
          String StreetExtention = textBoxUserAdressExtention.Text;

          DateTime Birthday = dateTimePickerAddUser.Value;

          String zipCode = textBoxUserPLZ.Text;

          String City = textBoxUserCity.Text;
          String Country = comboBoxUserCountries.SelectedValue + "";

          whilteUserAddInputs();


          //@todo validation task should be like this in val call
          //validate UserFName
          if (!Validation.Name(UserFName))
          {
            textBoxUserFirstname.BackColor = Color.Red;
            return;
          }

          //validate UserName
          if (!Validation.Name(UserName))
          {
            textBoxUserLastname.BackColor = Color.Red;
            return;
          }

          //validate Street
          if (!Validation.Street(Street))
          {
            textBoxUserStreet.BackColor = Color.Red;
            return;
          }

          //validate StreetNumber
          if (!Validation.isNumeric(StreetNumber) || Validation.isEmpty(StreetNumber))
          {
            textBoxUserHomeNumber.BackColor = Color.Red;
            return;
          }

          //validate City
          if (!Validation.Name(City))
          {
            textBoxUserCity.BackColor = Color.Red;
            return;
          }

          //validate zipCode
          if (!Validation.isNumeric(zipCode) || Validation.isEmpty(zipCode))
          {
              textBoxUserPLZ.BackColor = Color.Red;
              return;
          }

          pushUserToGUITableAndDB(
                UserFName, 
                UserName,
                Birthday,
                Street,
                StreetNumber,
                StreetExtention,
                zipCode,
                City,
                Country
          );

            clearUserAddFrom();
        }


        private void randomPushUser(){

            String[] fnames = {"Klaus","Peter","Anton","Susan","Ingo","Carlos","Olga","Emiel","Philipp"};
            String[] names = {"Dahse","Münzberg","Korepin","Dambeck","Quittenbaum","Müller","Mayer","Schulze"};

            for (int i = 0; i < 100; i++)
            {
                pushUserToGUITableAndDB(
                    fnames[r.Next(0, fnames.Length - 1)],
                    names[r.Next(0, names.Length - 1)],
                    new DateTime(r.Next(1900, 2000), r.Next(1, 12), r.Next(1, 28)),
                    fnames[r.Next(0, fnames.Length - 1)] + "strasse",
                    r.Next(1, 100).ToString(),
                    "",
                    r.Next(10000, 99999).ToString(),
                     names[r.Next(0, names.Length - 1)] + "stadt",
                     "Deutschland"
                );
            }
        }

        private void pushUserToGUITableAndDB(
                string UserFName, 
                string UserName,
                DateTime Birthday,
                String Street,
                String StreetNumber,
                String StreetExtention,
                String zipCode,
                String City,
                String Country
        )
        {
            Customer dummy = new Customer(
              0,
              UserFName,
              UserName,
              Birthday
           );

            dummy.Street = Street;
            dummy.StreetNumber = Convert.ToInt32(StreetNumber);
            dummy.AdditionalRoad = StreetExtention;
            dummy.ZipCode = Convert.ToInt32(zipCode);
            dummy.Town = City;
            dummy.Country = Country;

            ulong id = this.SqlCustomer.AddEntryReturnId(dummy);

            Customer finalCustomer = new Customer(
                id,
                UserFName,
                UserName,
                Birthday
             );

            finalCustomer.Street = Street;
            finalCustomer.StreetNumber = Convert.ToInt32(StreetNumber);
            finalCustomer.AdditionalRoad = StreetExtention;
            finalCustomer.ZipCode = Convert.ToInt32(zipCode);
            finalCustomer.Town = City;
            finalCustomer.Country = Country;

            addToUserTable(finalCustomer);
        }

        private void whilteUserAddInputs()
        {
            textBoxUserFirstname.BackColor = Color.White;
            textBoxUserLastname.BackColor = Color.White;
            textBoxUserStreet.BackColor = Color.White;
            textBoxUserHomeNumber.BackColor = Color.White;
            textBoxUserCity.BackColor = Color.White;
            textBoxUserPLZ.BackColor = Color.White;
        }

        private void clearUserAddFrom()
        {
            textBoxUserFirstname.Text = "";
            textBoxUserLastname.Text = "";

            textBoxUserStreet.Text = "";
            textBoxUserHomeNumber.Text = "";
            textBoxUserAdressExtention.Text = "";

            dateTimePickerAddUser.Value = userAddBirthDayDefault;

            textBoxUserPLZ.Text = "";

            textBoxUserCity.Text = "";
            
        }

        private void userTableDataSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //make all cells selected, so that it looks like the row is selected
            for (int i = 0; i < userTableDataSet.Rows[e.RowIndex].Cells.Count; i++)
            {
                userTableDataSet.Rows[e.RowIndex].Cells[i].Selected = true;
            }

            //get  current user id and pass to show details method
            ulong custId = (ulong) Convert.ToInt64( userTableDataSet.Rows[e.RowIndex].Cells[1].Value.ToString() );
            Customer currCustomer = SqlCustomer.getCustomerById(custId);
            displayCustomerDetails(currCustomer);
        }

        private void displayCustomerDetails(Customer customer)
        {
            labelUserDetails.Text = customer.ToString();
        }

        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            Customer tmp;
            ulong id;
            string sid;

            //@todo if main tab on user
            TextBox self = (TextBox) sender;

            debug.Text = userTableDataSet.ToString();

            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
                sid = userTableDataSet.Rows[i].Cells[1].Value.ToString();
                id = (ulong)Convert.ToInt64(sid);
                tmp = SqlCustomer.getCustomerById(id);
                if (!tmp.ToString().ToUpper().Contains(self.Text.ToUpper()))
                {
                    userTableDataSet.Rows[i].Visible = false;
                }
                else
                {
                    userTableDataSet.Rows[i].Visible = true;
                }
            }
                
        }

        private void buttonDeleteSelectedRows_Click(object sender, EventArgs e)
        {
            List<ulong> potentialDeletedIds = new List<ulong>();
            
            ulong id;
            
            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
            
                DataGridViewCheckBoxCell chkchecking = userTableDataSet.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                if ((bool)chkchecking.Value == true)
                {
                    id = (ulong)Convert.ToInt64(userTableDataSet.Rows[i].Cells[1].Value.ToString());
                    potentialDeletedIds.Add(id);                                      
                }
            }
            
            SqlCustomer.DeleteEntryByIdList(potentialDeletedIds);

            /**
             * das hier ist echt lustig =)
             * Auf den ersten Blick sieht es so aus als wären die zwei Scheifen ein bischen
             * Overkill da man für jeden Wert in potentialDeletedIds die complette Tabelle durchläuft.
             * 
             * anfangs hatte ich es so:
             * foreach (DataGridViewRow row in userTableDataSet.Rows)
                {
                    if (x == (ulong)Convert.ToInt64(row.Cells[1].Value.ToString()))
                    {
                        userTableDataSet.Rows.RemoveAt(row.Index);
                    }
                }
             * sieht eigentlich gut aus aber es blieben teilweise werte über
             * z.B.
             * 
             * hab in der tabelle folgende ids; 1,2,3,4,5
             * 
             * ich lösche 1,2,4 
             * es bleiben 2,3,5 stehen ?? -> warum die 2
             * 
             * eigentlich ist es aber ganz logisch:
             * zuerst ist row die erste Zeile der Tabelle sagen wir index 1
             * (id ist das wonach ich lösche)
             * 
             * foreach run 1 >> row -> index 1 -> id 1 | wird gelöscht
             * foreach run 2 >> row -> index 2 -> id 3 | wird nicht gelöscht
             * foreach run 3 >> row -> index 3 -> id 4 | wird gelöscht
             * 
             * id 2 wurde übersprugen ^^
             */
            foreach (ulong x in potentialDeletedIds)
            {
                foreach (DataGridViewRow row in userTableDataSet.Rows)
                {
                    if (x == (ulong)Convert.ToInt64(row.Cells[1].Value.ToString()))
                    {
                        userTableDataSet.Rows.RemoveAt(row.Index);
                        break;
                    }
                }
            }

        }
    }
}
 
