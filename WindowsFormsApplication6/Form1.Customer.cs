using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using BiBo.Persons;
using System.Windows.Forms;
using System.Drawing;

using BiBo.DAO;

namespace BiBo
{
    partial class Form1
    {

        //default value of DatePicker for user add birthday
        private DateTime userAddBirthDayDefault = new DateTime(1980, 1, 1);

        //Source file of Countries
        //@todo this could be stored in SQLLite Table
        private String countriesSource = "../../countries.txt";




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
            if (age < 18) { count_less18++; }
            else if (age < 25) { count_less25++; }
            else if (age < 35) { count_less35++; }
            else if (age < 50) { count_less50++; }
            else if (age < 60) { count_less60++; }
            else { count_gt60++; }
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
            foreach (Customer customer in lib.getCustomerDAO().GetAllCustomer())
            {
                //add user to datagrid view
                lib.getGuiApi().AddCustomer(customer);
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

            CustomerDAO dao = new CustomerDAO(this, lib);

            //run througth rows
            for (int i = 0; i < userTableDataSet.Rows.Count; i++)
            {
                //get customer id as string
                sid = userTableDataSet.Rows[i].Cells[1].Value.ToString();

                //convert id string to ulong
                id = (ulong)Convert.ToInt64(sid);

                //get customer form SQLLite table
                tmp = dao.GetCustomerById(id);

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
          CustomerDAO dao = new CustomerDAO(this, lib);

            //make all cells selected, so that it looks like the row is selected
            for (int i = 0; i < userTableDataSet.Rows[e.RowIndex].Cells.Count; i++) //IndexOutOfBoundException wenn man in der Tabelle auf de koopf klickt zum sortieren --> Marcus
            {
                userTableDataSet.Rows[e.RowIndex].Cells[i].Selected = true;
            }

            //get  current user id and pass to show details method
            ulong custId = (ulong)Convert.ToInt64(userTableDataSet.Rows[e.RowIndex].Cells[1].Value.ToString());
            Customer currCustomer = dao.GetCustomerById(custId);
            displayCustomerDetails(currCustomer);
        }
    }
}
