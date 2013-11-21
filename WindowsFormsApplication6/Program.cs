using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

using BiBo.Persons;
using BiBo.Properties;
using BiBo.SQL;

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
     

          //CustomerDAO conCustomer = SqlConnector<Customer>.GetCustomerSqlInstance();
          BookSQL conBooks = SqlConnector<Book>.GetBookSqlInstance();
 
          Book book1 = new Book(1, "Gott", "Bibel", "Klassiker");
          //Book book2 = new Book(3, "Tok", "X", "Langweiler");
          //Book book3 = new Book(4, "El James", "Shades of Grey", "Sex Roman");
          //Book book4 = new Book(6, "Sebastian Fitschek", "Der Augensammler", "Psychothriller");
          
         /* conBooks.FillExemplarListOfBook(book1);
          int numberOfExemplars = book1.Exemplare.Count;
          Debug.WriteLine(numberOfExemplars);
          Console.WriteLine(numberOfExemplars);
          */
          
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());
          
        }

    }
}
