using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BiBo.Persons;
using System.Data;

namespace BiBo
{    
    public class GUIApi
    {
        private MainWindow GUI;
        public GUIApi()
        {
            this.GUI = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;            
        }

        public GUIApi(bool test)
        {
          GUI = new MainWindow(this);
        }

        public void setLoggedInUser(Customer customer)
        {
            //TODO: Hier wird die Version nur bei Customer angezeigt.
            //      Admins und Employees bekommen keine Version angezeigt
            //      Das müsste noch gefixed werden
            BiBo.Updater.BiboUpdater updater = new BiBo.Updater.BiboUpdater();
            string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            (load("CurrentVersion") as Label).Content = "Version: " + currentVersion;

            if (customer.Right == Rights.CUSTOMER)
            {
                (load("CustomerUserName") as Label).Content = customer.FirstName + " " + customer.LastName;
                (load("CustomerCreatedAt") as Label).Content = "seit " + customer.CreatedAt.ToShortDateString();
            }
            else
            {
                (load("MainUserName") as Label).Content = customer.FirstName + " " + customer.LastName;
            }
            Label UserRights = load("MainUserRights") as Label;
            switch(customer.Right){
                case Rights.EMPLOYEE:
                    UserRights.Content = "Mitarbeiter";
                    break;
                case Rights.ADMINISTRATOR:
                    UserRights.Content = "Adminiestrator";
                    break;

            }
        }

        public void AddCustomer(Customer customer)
        {
            DataGrid CustomerTable = load("CustomerTable") as DataGrid;

            //CustomerTable.DataContext
            DataTable test = (CustomerTable.DataContext as DataTable);
            

            test.Rows.Add(
                customer.CustomerID,
                customer.FirstName,
                customer.LastName,
                customer.Street,
                customer.StreetNumber,
                customer.ZipCode,
                customer.Town,
                customer.Country
            );
            CustomerTable.DataContext = test;
           
        }

        public void Add_c_Book(Book book)
        {
            DataGrid BookTable = load("cBookTable") as DataGrid;

            //CustomerTable.DataContext
            DataTable test = (BookTable.DataContext as DataTable);


            test.Rows.Add(
                book.BookId,
                book.Author,
                book.Titel
            );

            
            BookTable.DataContext = test;

        }

        public void DeleteCustomer(Customer customer)
        {
            ulong id = customer.CustomerID;
            DataGrid table = GUI.FindName("CustomerTable") as DataGrid;
            // (table.DataContext as DataTable).Rows[table.SelectedIndex].Delete();
            DataTable dataTable = table.DataContext as DataTable;
            //from Customer c in lib.CustomerList where c.CustomerID == id select c).ToList()[0];
            dataTable = dataTable.AsEnumerable().Where(r => r.Field<string>("ID") != customer.CustomerID.ToString()).CopyToDataTable();
            table.DataContext = dataTable;
        }

       

        private object load(String Name)
        {
            return GUI.FindName(Name);
        }

        public void UpdateCustomer(Customer customer)
        {
          //TODO : implement ^^
        }

        public void AddBook(Book book)
        {
          //TODO : implement ^^
        }
    }
}
