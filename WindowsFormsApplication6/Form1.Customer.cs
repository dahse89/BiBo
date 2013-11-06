using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using BiBo.Persons;
using System.Windows.Forms;
using System.Drawing;

namespace BiBo
{
    partial class Form1
    {

        //default value of DatePicker for user add birthday
        private DateTime userAddBirthDayDefault = new DateTime(1980, 1, 1);

        //Source file of Countries
        //@todo this could be stored in SQLLite Table
        private String countriesSource = "../../countries.txt";

        //adds a Customer to user´datagridview
        private void addToUserTable(Customer cust)
        {
            //calcualte age by birtday
            TimeSpan age = DateTime.Now - cust.BirthDate;

            //whole adress to string
            String adress = cust.getFullAdress();

            //add new row with customer informations
            //@todo add status and number of borrowed books
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
        }


        //set all cells in datagridview readonly. except the checkbox cells
        private void setUserTableReadOnly()
        {
            //run through all rows
            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
                //run through all cells of row
                for (int j = 0; j < userTableDataSet.Rows[i].Cells.Count; j++)
                {
                    if (j != 0) // if not is checkbox cell
                    {
                        //set cell readonly
                        userTableDataSet.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }

        //fill age chart with values
        private void initAgeChart()
        {
            //init age tmp and counter vars
            int age;
            int count_less18 = 0;
            int count_less25 = 0;
            int count_less35 = 0;
            int count_less50 = 0;
            int count_less60 = 0;
            int count_gt60 = 0;

            //run through all rows
            foreach (DataGridViewRow row in userTableDataSet.Rows)
            {
                //get age
                age = Convert.ToInt32(row.Cells[4].Value.ToString());

                //increase the right counter
                if (age < 18){count_less18++;}
                else if (age < 25){count_less25++;}
                else if (age < 35){count_less35++;}
                else if (age < 50){count_less50++;}
                else if (age < 60){count_less60++;}
                else{count_gt60++;}
            }

            //create dictionary for values names and values
            Dictionary<string, int> tags = new Dictionary<string, int>() { 
                { "< 18", count_less18 },
                { "< 25", count_less25 },
                { "< 35", count_less35 },
                { "< 50", count_less50 },
                { "< 60", count_less60 },
                { ">= 60", count_gt60 }
            };


            //init age chart by dictionary
            foreach (string tagname in tags.Keys)
            {
                chartUserAge.Series[0].Points.AddXY(tagname, tags[tagname]);
            }

        }

        //push a random user to SQLLite Table
        //@todo remove at the end, only for testing
        private void randomPushUser()
        {

            String[] fnames = { "Klaus", "Peter", "Anton", "Susan", "Ingo", "Carlos", "Olga", "Emiel", "Philipp" };
            String[] names = { "Dahse", "Münzberg", "Korepin", "Dambeck", "Quittenbaum", "Müller", "Mayer", "Schulze" };

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

        //summery of save and show new customer
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
            //create a dummy with id zero
            //@notice: we can bypass this by having a setter of customer id
            Customer dummy = new Customer(
              0,
              UserFName,
              UserName,
              Birthday
           );

            //init dummy
            dummy.Street = Street;
            dummy.StreetNumber = Convert.ToInt32(StreetNumber);
            dummy.AdditionalRoad = StreetExtention;
            dummy.ZipCode = Convert.ToInt32(zipCode);
            dummy.Town = City;
            dummy.Country = Country;

            //add dummy to SQLLite Table and get customer id back
            ulong id = this.SqlCustomer.AddEntryReturnId(dummy);

            //create final customer with right id
            Customer finalCustomer = new Customer(
                id,
                UserFName,
                UserName,
                Birthday
             );

            //init final customer
            finalCustomer.Street = Street;
            finalCustomer.StreetNumber = Convert.ToInt32(StreetNumber);
            finalCustomer.AdditionalRoad = StreetExtention;
            finalCustomer.ZipCode = Convert.ToInt32(zipCode);
            finalCustomer.Town = City;
            finalCustomer.Country = Country;

            //add final customer to datagridview
            addToUserTable(finalCustomer);

            //set read only again
            setUserTableReadOnly();
        }

        //set background of all textboxes for user add to white
        //is is like a clear for validation errors
        private void whilteUserAddInputs()
        {
            textBoxUserFirstname.BackColor = Color.White;
            textBoxUserLastname.BackColor = Color.White;
            textBoxUserStreet.BackColor = Color.White;
            textBoxUserHomeNumber.BackColor = Color.White;
            textBoxUserCity.BackColor = Color.White;
            textBoxUserPLZ.BackColor = Color.White;
        }

        //set all textboxes for user add empty
        private void clearUserAddFrom()
        {
            textBoxUserFirstname.Text = "";
            textBoxUserLastname.Text = "";
            textBoxUserStreet.Text = "";
            textBoxUserHomeNumber.Text = "";
            textBoxUserAdressExtention.Text = "";
            //set default as empty
            dateTimePickerAddUser.Value = userAddBirthDayDefault;
            textBoxUserPLZ.Text = "";
            textBoxUserCity.Text = "";
        }


        //get customer details and show in details panel
        private void displayCustomerDetails(Customer customer)
        {
            labelUserDetailsName.Text = "Name: " + customer.FirstName + " " + customer.LastName;
            labelUserDetailsAdress.Text = "Adresse: " + customer.getFullAdress();
        }

        //fill GUI in customer tab with content
        private void publishCustomerContent()
        {
             //userAddBirthDay Default;
            dateTimePickerAddUser.Value = userAddBirthDayDefault;

            //set number of culoms
            userTableDataSet.ColumnCount = 7;

            //set colum names
            userTableDataSet.Columns[0].Name = "ID";
            userTableDataSet.Columns[1].Name = "Vorname";
            userTableDataSet.Columns[2].Name = "Nachname";
            userTableDataSet.Columns[3].Name = "Alter";
            userTableDataSet.Columns[4].Name = "Status";
            userTableDataSet.Columns[5].Name = "ausgeliehende Bücher";
            userTableDataSet.Columns[6].Name = "Adresse";

            //insert a special colum for checkboxes
            userTableDataSet.Columns.Insert(0, new DataGridViewCheckBoxColumn());

            //insert customers from SQLLite table
            foreach (Customer customer in SqlCustomer.GetAllEntrys())
            {
                //add user to datagrid view
                addToUserTable(customer);
            }

            //set customer table to read only
            setUserTableReadOnly();

            //insert all countries to comboBox
            initCourtries();

            //calculate and insert values to age chart
            initAgeChart();
        }

        //read country names source and insert to comboBox
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

        /*
         * interaction events functions
         */



        //search in data grid view and hide dismatched rows
        private void searchUserTable(String str){

            Customer tmp;
            ulong id;
            string sid;

            //run througth rows
            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
                //get customer id as string
                sid = userTableDataSet.Rows[i].Cells[1].Value.ToString();

                //convert id string to ulong
                id = (ulong)Convert.ToInt64(sid);

                //get customer form SQLLite table
                tmp = SqlCustomer.GetEntryById(id);

                //check if search input is in toString value of customer
                if (!tmp.ToString().ToUpper().Contains(str.ToUpper()))
                {
                    //hide row
                    userTableDataSet.Rows[i].Visible = false;
                }
                else
                {
                    //show row
                    userTableDataSet.Rows[i].Visible = true;
                }
            }

        }

        //event by clicking cell this selects all cells in rows
        private void userTableDataSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //make all cells selected, so that it looks like the row is selected
            for (int i = 0; i < userTableDataSet.Rows[e.RowIndex].Cells.Count; i++) //IndexOutOfBoundException wenn man in der Tabelle auf de koopf klickt zum sortieren --> Marcus
            {
                userTableDataSet.Rows[e.RowIndex].Cells[i].Selected = true;
            }

            //get  current user id and pass to show details method
            ulong custId = (ulong)Convert.ToInt64(userTableDataSet.Rows[e.RowIndex].Cells[1].Value.ToString());
            Customer currCustomer = SqlCustomer.GetEntryById(custId);
            displayCustomerDetails(currCustomer);
        }

        //click on user add
        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            //get values into local vars
            String UserFName = textBoxUserFirstname.Text;
            String UserName = textBoxUserLastname.Text;

            String Street = textBoxUserStreet.Text;
            String StreetNumber = textBoxUserHomeNumber.Text;
            String StreetExtention = textBoxUserAdressExtention.Text;

            DateTime Birthday = dateTimePickerAddUser.Value;

            String zipCode = textBoxUserPLZ.Text;

            String City = textBoxUserCity.Text;
            String Country = comboBoxUserCountries.SelectedValue + "";

            //set all textboxes background to white
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

            //here the user is valid and will be pushed to SQLLite Table and datagridview
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

            //make textboxes for add user empty
            clearUserAddFrom();
        }


        //delete customer which are selected in datagrid view
        private void buttonDeleteSelectedRows_Click(object sender, EventArgs e)
        {
            //init a list for collecting id that should be deleted
            List<ulong> potentialDeletedIds = new List<ulong>();

            //placeholder of id
            ulong id;

            //run  through all rows
            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
                //get DataGridViewCheckBoxCell Object from checkbox colum
                DataGridViewCheckBoxCell chkchecking = userTableDataSet.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

                //get value of checkbox
                if ((bool)chkchecking.Value == true) //if checkbox id checked
                {
                    //get customer id from row and add to list of ids
                    id = (ulong)Convert.ToInt64(userTableDataSet.Rows[i].Cells[1].Value.ToString());
                    potentialDeletedIds.Add(id);
                }
            }

            //delete all customers whose id is in the list
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
