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

        public void setLoggedInUser(Customer customer)
        {
            (load("MainUserName") as Label).Content = customer.FirstName + " " + customer.LastName;
            Label UserRights = load("MainUserRights") as Label;
            switch(customer.Right){
                case Rights.CUSTOMER:
                    UserRights.Content = "Kunde";
                    break;
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
                customer.CustomerID.ToString(),
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

       

        private object load(String Name)
        {
            return GUI.FindName(Name);
        }
    }
}
