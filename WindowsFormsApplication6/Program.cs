using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BiBo.Persons;
using BiBo.Properties;
using BiBo.DAO;

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
        
          CustomerDAO conCustomer = SqlConnector<Customer>.GetCustomerSqlInstance();
          //Customer c = new Customer(1234, "Philipp", "Dahse", new DateTime(1989,12,4));
          //conCustomer.DeleteEntry(c);
          //conCustomer.AddEntry(c);
          
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1(conCustomer));

          
        }
    }
}
