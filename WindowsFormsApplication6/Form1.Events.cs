using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        case Tabs.CUSTOMER: deleteSelectedCustomers(); break;
        case Tabs.BOOK: deleteSelectedBooks(); break;
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

  }
}
