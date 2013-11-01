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
        
          SqlConnector<Customer> conCustomer = SqlConnector<Customer>.GetCustomerSqlInstance();
          Customer c = new Customer(123, "Marcus", "Münzberg", DateTime(1989,07,16));
          conCustomer.DeleteEntry(c);
          conCustomer.AddEntry(c);
          
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());

          
        }
    }
}
