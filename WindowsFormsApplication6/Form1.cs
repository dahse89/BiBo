using System;
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

namespace BiBo
{
    public partial class Form1 : Form
    {
        //content
        private String   LoginAsUserName;
        private String   UserStatusText;

        private String  countriesSource = "../../countries.txt";

        private Random r = new Random();

        public Form1()
        {
            InitializeComponent();
            makeResponsivOnce(this);

            //init content
            this.LoginAsUserName = "Philipp Dahse";
            this.UserStatusText = "Admin";

            //render view
            initCourtries();
            publishContent();
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

            DataTable ds = new DataTable("UserTable");

            userTableDataSet.RowHeadersVisible = false;

            userTableDataSet.ColumnCount = 6;
            userTableDataSet.Columns[0].Name = "ID";
            userTableDataSet.Columns[1].Name = "Vorname";
            userTableDataSet.Columns[2].Name = "Nachname";
            userTableDataSet.Columns[3].Name = "Alter";
            userTableDataSet.Columns[4].Name = "Status";
            userTableDataSet.Columns[5].Name = "ausgeliehende Bücher";



            //insert some random stuff

            userTableDataSet.Columns.Insert(0, new DataGridViewCheckBoxColumn());


            for (int i = 0; i < 5; i++)
            {

                addToUserTable(getRandomCustomer());
            }


            
        }

        private void addToUserTable(Customer cust)
        {
            TimeSpan age;

            age = DateTime.Now - cust.BirthDate;
        
            userTableDataSet.Rows.Add(
                    false,
                    cust.CustomerID.ToString(),
                    cust.FirstName,
                    cust.LastName,
                    ((int)Math.Floor((DateTime.Now - cust.BirthDate).TotalDays / 365.25D)).ToString(),
                    "test",
                    "0"
             );

            setUserTableReadOnly();
        }

        private Customer getRandomCustomer()
        {
           
            String[] fnames = new String[] {"Philipp","Marcus","Vico","Yevgen","Klaus","Peter","Ignatz","Mario","Hans","Ingolf"};
            String[] lnames = new String[] { "Dahse", "Münzberg", "Dambeck", "Korpin", "Müller", "Meyer", "Schultz", "Mustermann", "Li", "Bauer" };
      
            return new Customer(
                r.Next(10000,1000000),
                fnames[r.Next(0, fnames.Length)],
                lnames[r.Next(0, lnames.Length)],
                new DateTime(r.Next(1920,2005),r.Next(1,12),r.Next(1,28))
            );
        }

        private void setUserTableReadOnly()
        {

            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
                for (int j = 0; j < userTableDataSet.Rows[i].Cells.Count; j++)
                {
                    if (j == 1)
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

            //resize user details panel
            userDetails.Location = new System.Drawing.Point(MainPanel.Width * 3 / 4 - 2, UserAddPanel.Height + 15);
            userDetails.Width = MainPanel.Width / 4 - 10;
            userDetails.Height = MainPanel.Height - UserAddPanel.Height - 15;

            //resize user table 
            userTableDataSet.Width = UserTablePanel.Width - 15;
            userTableDataSet.Height = UserTablePanel.Height - 25;

           
            
        }

        /*
   *         //Member-Variablen Deklaration
          private int customerID;                  //Kunden-ID

          private string firstName;                //Vorname
          private string lastName;                 //Nachname
          private DateTime birthDate;              //Geburtstag

          private string street;                   //Strasse
          private int streetNumber;                //Hausnummer
          private string additionalRoad;           //Strassenzusatz
          private int zipCode;                     //PLZ
          private string town;                     //Stadt
          private string country;                  //Land

          private Rights right = Rights.CUSTOMER; //Rechte
          private int chargeAccountNumber;         //GebuehrenkontoNr
          private int biboID;                      //Bibliotheks-ID
          private int cardID;                      //Ausweis-ID
          private UserStates userState;            //Benutzer- Status

   * 
   */

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


          // @todo remove all error messages
          textBoxUserFirstname.BackColor = Color.White;
          textBoxUserLastname.BackColor = Color.White;
          textBoxUserStreet.BackColor = Color.White;
          textBoxUserHomeNumber.BackColor = Color.White;
          textBoxUserCity.BackColor = Color.White;

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

          

            Customer newCustomer = new Customer(
                23,
                UserFName,
                UserName,
                Birthday
             );

            addToUserTable(newCustomer);



        }
    }
}
 