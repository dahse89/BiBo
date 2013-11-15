using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo.DAO
{
  public class TestDAO
  {
    private Form1 GUI;

    public TestDAO(Form1 gui)
    {
      this.GUI = gui;
    }
   
    public void changeLoggedUserName(String name)
    {
      //db
      //obj
      this.GUI.SetLoggedUserName(name);
    }

  }
}
