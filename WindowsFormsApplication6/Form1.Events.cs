using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BiBo.Persons;
using System.Drawing;

namespace BiBo
{
  partial class Form1
  {
    //click in main tabs in customer
    private void customerImage_Click(object sender, EventArgs e)
    {
      lib.getGuiApi().switchTabTo(Tabs.CUSTOMER);
    }

    private void booksImage_Click(object sender, EventArgs e)
    {
      lib.getGuiApi().switchTabTo(Tabs.BOOK);
    }

    //close application
    private void close_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    //delete
    //delete customer which are selected in datagrid view
    private void buttonDeleteSelectedRows_Click(object sender, EventArgs e)
    {
      switch (this.activTab)
      {
        case Tabs.CUSTOMER: 
              lib.getCustomerDAO().DeleteCustomersByIdList(); 
           break;
        case Tabs.BOOK: 
              lib.getBookDAO().DeleteBooksByIdList();
           break;
      }
    }

    //search
    private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
    {

      //@todo if main tab on user
      TextBox self = (TextBox)sender;

      switch (this.activTab)
      {
        case Tabs.CUSTOMER: searchUserTable(self.Text); break;
        case Tabs.BOOK: searchBookTable(self.Text); break;
      }

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



      /* //@todo validation task should be like this in val call
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
       }*/

      Button su = (Button)sender;

      if (!Validation.validateCustomerAddPanel(su.Parent))
      {
        return;
      }

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


      lib.getCustomerDAO().AddCustomer(dummy);

       //make textboxes for add user empty
      //clearUserAddFrom();
    }

    //add book to SQLLite Table
    private void addBooksActionButton_Click(object sender, EventArgs e)
    {

      //author
      String author = this.textBoxBookAddauthor.Text;
      String title = this.textBoxBookAddTitel.Text;
      String genre = this.textBoxBookAddsubjectArea.Text;

      //all textboxes to white
      textBoxBookAddauthor.BackColor = Color.White;
      textBoxBookAddTitel.BackColor = Color.White;
      textBoxBookAddsubjectArea.BackColor = Color.White;

      if (Validation.isEmpty(author))
      {
        textBoxBookAddauthor.BackColor = Color.Red;
        return;
      }

      if (Validation.isEmpty(title))
      {
        textBoxBookAddTitel.BackColor = Color.Red;
        return;
      }

      if (Validation.isEmpty(genre))
      {
        textBoxBookAddsubjectArea.BackColor = Color.Red;
        return;
      }

      

     lib.getBookDAO().AddBook(new Book(0, author, title, genre));
      clearBookAddForm();

    }
  }
}
