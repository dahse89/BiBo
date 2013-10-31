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
          //SQLCon con = new SQLCon(); 
          /*Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new Form1());
*/
          
          SqlConnector<Book> conBook = SqlConnector<Book>.GetBookSqlInstance();
          SqlConnector<Customer> conCustomer = SqlConnector<Customer>.GetCustomerSqlInstance();
          
          Customer c = new Customer(123, "Marcus", "Münzberg", DateTime.Now);
          Book b = new Book("Gronwoski", "SCJP6", "Programming");
          
          conCustomer.CreateTable();
          conBook.CreateTable();
    
          conCustomer.AddEntry(c);
          conBook.AddEntry(b);

          List<Customer> customerList = conCustomer.GetAllEntrys();
          List<Book> bookList = conBook.GetAllEntrys();
          
          foreach(Customer customer in customerList )
          {
	        	Console.WriteLine(customer);
          }
          foreach(Book book in bookList )
          {
	        	Console.WriteLine(book);
	      }
          
        }
    }
}
