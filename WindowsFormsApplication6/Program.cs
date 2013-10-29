using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BiBo.Persons;
using BiBo.Properties;

namespace BiBo
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
          SQLCon con = new SQLCon(); 
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());

          Customer c = new Customer(123, "Marcus", "Münzberg", DateTime.Now);
          con.createDatabase();
          con.addCustomer(c);
        }
    }
}
