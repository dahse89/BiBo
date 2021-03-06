﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.Persons;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace BiBo
{
  partial class Form1
  {
    public void SetLoggedUserName(String name)
    {
      this.userName.Text = name;//hj
    }

    public void init()
    {
      //get current screen size
      int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
      int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

      //load GUI elements, calculated by screen size (responsive)
      //@see: Form1.Designer
      InitializeComponent(width, height);
    }

    //fill GUI elements with content
    private bool publishContent(Customer logginUser)
    {
      //set name of current logged user
      userName.Text = logginUser.FirstName + " " + logginUser.LastName;
      switch(logginUser.Right){
          case Rights.ADMINISTRATOR:
              userStat.Text = "Admin";
              break;
          case Rights.EMPLOYEE:
              userStat.Text = "Mitarbeiter";
              break;
          case Rights.CUSTOMER:
              userStat.Text = "Kunde";
              break;
      }
      

      //fill content on customer tab
      //@see Form1.Customer
      this.publishCustomerContent();
      //fill content on books tab
      //@see Form1.Books
      this.publishBookContent();

      return true;
    }


    private void switchTabTo(Tabs tab)
    {
      switch (tab)
      {
        case Tabs.CUSTOMER:
          //show customer Main Panel hide others
          this.CustomerMainPanel.Visible = true;
          this.BooksMainPanel.Visible = false;
          this.BorrowMainPanel.Visible = false;

          this.activTab = Tabs.CUSTOMER;
          break;
        case Tabs.BOOK:
          //show books Main Panel hide others
          this.CustomerMainPanel.Visible = false;
          this.BorrowMainPanel.Visible = false;
          this.BooksMainPanel.Visible = true;

          this.activTab = Tabs.BOOK;
          break;
        case Tabs.BORROW:
          //show borrow panel hide otheres
          this.CustomerMainPanel.Visible = false;
          this.BooksMainPanel.Visible = false;
          this.BorrowMainPanel.Visible = true;
          break;
            
      }
    }

    public void AddBook(Book book)
    {
      this.booksTableDataSet.Rows.Add(
          false,
          book.BookId,
          book.Author,
          book.Titel,
          book.SubjectArea
       );
    }

    //adds a Customer to user´datagridview
    public void AddCustomer(Customer cust)
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

      //set read only again
      List<int> exceptions = new List<int>();
      exceptions.Add(0); //checkbox colum
      setDataGridViewReadOnly(userTableDataSet, exceptions);   
    }

    public List<ulong> DeleteCustomersByIdList()
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

      return potentialDeletedIds;
    }

    public List<ulong> DeleteBooksByIdList()
    {
      //init a list for collecting id that should be deleted
      List<ulong> potentialDeletedIds = new List<ulong>();

      //placeholder of id
      ulong id;

      //run  through all rows
      for (int i = 0; i < booksTableDataSet.Rows.Count; i++)
      {
        //get DataGridViewCheckBoxCell Object from checkbox colum
        DataGridViewCheckBoxCell chkchecking = booksTableDataSet.Rows[i].Cells[0] as DataGridViewCheckBoxCell;

        //get value of checkbox
        if ((bool)chkchecking.Value == true) //if checkbox id checked
        {
          //get customer id from row and add to list of ids
          id = (ulong)Convert.ToInt64(booksTableDataSet.Rows[i].Cells[1].Value.ToString());
          potentialDeletedIds.Add(id);
        }
      }

      //remove book from table
      foreach (ulong x in potentialDeletedIds)
      {
        foreach (DataGridViewRow row in booksTableDataSet.Rows)
        {
          if (x == (ulong)Convert.ToInt64(row.Cells[1].Value.ToString()))
          {
            booksTableDataSet.Rows.RemoveAt(row.Index);
            break;
          }
        }
      }

      return potentialDeletedIds;
    }


    //fill age chart with values
    private void initAgeChart()
    {
        //colors
        Color[] colors = new Color[] { 
            ColorTranslator.FromHtml("#4140A8"),            
            ColorTranslator.FromHtml("#8483A8"),
            ColorTranslator.FromHtml("#C0BFF5"),
            ColorTranslator.FromHtml("#A8A8A8"),
            ColorTranslator.FromHtml("#605DF5"),
            ColorTranslator.FromHtml("#cccccc")
            //ColorTranslator.FromHtml("#575757")
            
        };
        //init age tmp and counter vars
        int age = 0;
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
            try
            {
                age = Convert.ToInt32(row.Cells[4].Value.ToString());
            }
            catch (FormatException err) { }

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

        foreach (Series series in chartUserAge.Series)
        {
            foreach (DataPoint point in series.Points)
            {
                point.Color = colors[series.Points.IndexOf(point)];
            }
        }
    }

    private void initRegDateChart()
    {

        //Random reg dates
        List<fakeCustomer> customers = new List<fakeCustomer>();
        for (int i = 0; i < 100; i++)
        {
            customers.Add(new fakeCustomer(new DateTime(r.Next(2012,2014), r.Next(1, 12), r.Next(1, 28))));

            if (r.Next(2) == 1)
            {
                customers[i].DeletedAt = customers[i].CreatedAt.Add(TimeSpan.FromDays(r.Next(1,14)));
            }
        }

        customers.Sort( (cust1,cust2) => cust1.CreatedAt.CompareTo(cust2.CreatedAt) );

        DateTime oldesRegDate = customers[0].CreatedAt;
        DateTime latesRegDate = customers[customers.Count - 1].CreatedAt;

        DateTime startDate = new DateTime(oldesRegDate.Year, oldesRegDate.Month, 1);
        DateTime endDate = new DateTime(latesRegDate.Year, latesRegDate.Month, 1);

        int count = 0;

        for (DateTime it = startDate; it < endDate;it = it.AddMonths(1))
        {
            count += (
                from 
                    cust in customers 
                where 
                    cust.CreatedAt.Year  == it.Year && 
                    cust.CreatedAt.Month == it.Month 
                select 
                    cust
             ).Count() - (
                 from
                        cust in customers
                 where
                     cust.DeletedAt != null &&
                     cust.DeletedAt.Year == it.Year &&
                     cust.DeletedAt.Month == it.Month
                 select
                     cust
             ).Count();

            chartRegDate.Series[0].Points.AddXY(it.Day + "." + it.Month + "." + it.Year, count);   
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
        List<int> exceptions = new List<int>();
        exceptions.Add(0); //checkbox colum
        setDataGridViewReadOnly(userTableDataSet, exceptions);   

        //insert all countries to comboBox
        initCourtries();

        //calculate and insert values to age chart
        initAgeChart();
        initRegDateChart();
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


    //search in data grid view and hide dismatched rows
    private void searchUserTable(String str)
    {

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
            tmp = lib.getCustomerDAO().GetCustomerById(id);

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

    //fill GUI with content
    private void publishBookContent()
    {
        //create data table for datagridview

        //set number of culoms
        this.booksTableDataSet.ColumnCount = 4;

        //set colum names
        this.booksTableDataSet.Columns[0].Name = "ID";
        this.booksTableDataSet.Columns[1].Name = "Author";
        this.booksTableDataSet.Columns[2].Name = "Title";
        this.booksTableDataSet.Columns[3].Name = "Genre";

        //insert a special colum for checkboxes
        this.booksTableDataSet.Columns.Insert(0, new DataGridViewCheckBoxColumn());

        foreach (Book book in lib.getBookDAO().getAllBooks())
        {
            lib.getGuiApi().AddBook(book);
        }

        //make table readonly
        List<int> exceptions = new List<int>();
        exceptions.Add(0); //checkbox colum
        setDataGridViewReadOnly(this.booksTableDataSet, exceptions);  

    }


    //clear book add form
    private void clearBookAddForm()
    {
        this.textBoxBookAddauthor.Text = "";
        this.textBoxBookAddsubjectArea.Text = "";
        this.textBoxBookAddTitel.Text = "";
    }



    private void setDataGridViewReadOnly(DataGridView dgv)
    {
        setDataGridViewReadOnly(dgv, new List<int>());
    }

    private void setDataGridViewReadOnly(DataGridView dgv, List<int> excludedColums)
    {
        //run through all rows
        for (int i = 0; i < dgv.Rows.Count; i++)
        {
            //run through all cells of row
            for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
            {
                if (excludedColums.IndexOf(j) == -1) // exclude exceptions
                {
                    //set cell readonly
                    dgv.Rows[i].Cells[j].ReadOnly = true;
                }
            }
        }
    }


    private void searchBookTable(String str)
    {

        Book tmp;
        ulong id;
        string sid;

        //run througth rows
        for (int i = 0; i < booksTableDataSet.Rows.Count; i++)
        {
            //get customer id as string
            sid = booksTableDataSet.Rows[i].Cells[1].Value.ToString();

            //convert id string to ulong
            id = (ulong)Convert.ToInt64(sid);

            //get customer form SQLLite table
            tmp = lib.getBookDAO().GetBookById(id);

            //check if search input is in toString value of customer
            if (!tmp.ToString().ToUpper().Contains(str.ToUpper()))
            {
                //hide row
                booksTableDataSet.Rows[i].Visible = false;
            }
            else
            {
                //show row
                booksTableDataSet.Rows[i].Visible = true;
            }
        }
    }

    private void UserLogin(Customer logginUser){
        this.SuperPanelLogin.Visible = false;
        this.SuperPanelCustomer.Visible = true;

        publishCustomerSearchLogin(logginUser);
    }

    private void EmployeeLogin(Customer logginUser)
    {
        this.SuperPanelLogin.Visible = false;
        this.SuperPanelEmployee.Visible = true;

        //init content
        //fill GUI elemens with content
        if (!lib.IsEmployeeGUILoaded)
        {
            lib.IsEmployeeGUILoaded = publishContent(logginUser); ;
        }
    }

    private void AdminLogin(Customer logginUser)
    {
        this.SuperPanelLogin.Visible = false;
        this.SuperPanelEmployee.Visible = true;

        //init content
        //fill GUI elemens with content
        if (!lib.IsEmployeeGUILoaded)
        {
            lib.IsEmployeeGUILoaded = publishContent(logginUser); ;
        } 
    }

    private void publishCustomerSearchLogin(Customer logginUser)
    {

        this.loggedInAs_Name.Text = "Name: " + logginUser.FirstName + " " + logginUser.LastName;
        this.loggedInAs_Adress.Text = "Adresse: " + logginUser.getFullAdress();

        this.customerSearchBook.ColumnCount = 4;

        //set colum names
        this.customerSearchBook.Columns[0].Name = "ID";
        this.customerSearchBook.Columns[1].Name = "Author";
        this.customerSearchBook.Columns[2].Name = "Title";
        this.customerSearchBook.Columns[3].Name = "Genre";

        foreach (Book book in lib.getBookDAO().getAllBooks())
        {
            lib.getGuiApi().AddBookCustomerSearch(book);
        }

        //make table readonly
        setDataGridViewReadOnly(customerSearchBook);  
    }

      public void AddBookCustomerSearch(Book book){
          customerSearchBook.Rows.Add(
          book.BookId,
          book.Author,
          book.Titel,
          book.SubjectArea
       );
      }


  }

  class fakeCustomer
  {
      private DateTime createdAt;
      private DateTime deletedAt;

      public fakeCustomer(DateTime cd){
          this.CreatedAt = cd;
      }

      public DateTime CreatedAt{
          get { return createdAt; }
          set { createdAt = value; }
      }

      public DateTime DeletedAt
      {
          get { return deletedAt; }
          set { deletedAt = value; }
      }

  }
}
