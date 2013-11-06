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
          BookDAO conBooks = SqlConnector<Book>.GetBookSqlInstance();
          
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1(conCustomer,conBooks));

          
        }
    }
}
