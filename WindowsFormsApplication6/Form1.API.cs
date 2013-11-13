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
      this.SetFontsToBlack();
      this.SetTablesFixed();
    }
  }
}
