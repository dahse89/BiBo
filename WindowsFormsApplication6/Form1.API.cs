using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
  }
}
