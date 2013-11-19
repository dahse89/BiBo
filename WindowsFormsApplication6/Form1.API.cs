using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.Persons;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace BiBo
{
  partial class Form1
  {
    public void SetLoggedUserName(String name)
    {
      this.userName.Text = name;
    }

    public void init()
    {
      //get current screen size
      int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
      int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

      //load GUI elements, calculated by screen size (responsive)
      //@see: Form1.Designer
      InitializeComponent(width, height);

      //init content

      //@todo this should come form login and SQLLite
      this.loginAsUserName = "Philipp Dahse";
      this.userStatusText = "Admin";

      //fill GUI elemens with content
      publishContent();

      this.lib.getTestDAO().changeLoggedUserName("Lol");

      //@todo remove at the end is only for testing
      // randomPushUser();
    }

    //fill GUI elements with content
    private void publishContent()
    {
      //set name of current logged user
      userName.Text += this.loginAsUserName;

      //set statis of current logged user
      userStat.Text += this.userStatusText;

      //fill content on customer tab
      //@see Form1.Customer
      this.publishCustomerContent();
      //fill content on books tab
      //@see Form1.Books
      this.publishBookContent();
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
      setUserTableReadOnly();
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
        setBooksTableReadOnly();

    }

    //clear book add form
    private void clearBookAddForm()
    {
        this.textBoxBookAddauthor.Text = "";
        this.textBoxBookAddsubjectArea.Text = "";
        this.textBoxBookAddTitel.Text = "";
    }

    //set all cells in datagridview readonly. except the checkbox cells
    private void setBooksTableReadOnly()
    {
        //run through all rows
        for (int i = 0; i < this.booksTableDataSet.Rows.Count; i++)
        {
            //run through all cells of row
            for (int j = 0; j < this.booksTableDataSet.Rows[i].Cells.Count; j++)
            {
                if (j != 0) // if not is checkbox cell
                {
                    //set cell readonly
                    this.booksTableDataSet.Rows[i].Cells[j].ReadOnly = true;
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

        this.loggedInAs_Name.Text = "Name: " + logginUser.FirstName + " " + logginUser.LastName;
        this.loggedInAs_Adress.Text = "Adresse: " + logginUser.getFullAdress();
    }

    private void EmployeeLogin(Customer logginUser)
    {
        MessageBox.Show("logged in as employee");
    }

    private void AdminLogin(Customer logginUser)
    {
        MessageBox.Show("logged in as admin");
    }

  }
}
