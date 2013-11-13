using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.Persons;
using System.Windows.Forms;

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

          this.activTab = Tabs.CUSTOMER;
          break;
        case Tabs.BOOK:
          //show books Main Panel hide others
          this.CustomerMainPanel.Visible = false;
          this.BooksMainPanel.Visible = true;

          this.activTab = Tabs.BOOK;
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

  }
}
