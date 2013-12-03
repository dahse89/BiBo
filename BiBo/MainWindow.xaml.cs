using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BiBo.Persons;
using System.IO;
using System.Data;
using System.Collections;
using System.Windows.Controls.Primitives;

namespace BiBo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Library lib;
        private String CountriesSource = "../../countries.txt";

        public MainWindow()
        {
          SQL.InitDbSQL x = new SQL.InitDbSQL();
          x.createAllTables();


            InitializeComponent();
            initMainWindow();
        }

        public void initMainWindow()
        {
            initElements();
            lib = new Library();
            foreach (Customer cust in lib.CustomerList)
            {
                this.lib.getGuiApi().AddCustomer(cust);
            }
        }

        private void initElements()
        {
            initCoutriesComboBox();
            initCustomerTable();
        }

        private void initCoutriesComboBox()
        {
            //init Employee_UserAdd_Country
            ComboBox comBox = this.FindName("Employee_UserAdd_Country") as ComboBox;

            //create line string to catch lines from file
            string line;

            // Read the file and display it line by line.
            StreamReader file = new System.IO.StreamReader(this.CountriesSource);
            
            while ((line = file.ReadLine()) != null)
            {
                //add to country dataTable
                comBox.Items.Add(line);
            }
            file.Close();

            comBox.SelectedIndex = 0;
        }

        private DataTable getCustomerDataTable()
        {
            DataTable New = new DataTable("Customers");
            New.Columns.Add("ID");
            New.Columns.Add("Vorname");
            New.Columns.Add("Nachname");
            New.Columns.Add("Strasse");
            New.Columns.Add("Nummer");
            New.Columns.Add("PLZ");
            New.Columns.Add("Stadt");
            New.Columns.Add("Land");
            return New;
        }

        private void initCustomerTable()
        {
            DataTable CustomerTable = getCustomerDataTable();
            (FindName("CustomerTable") as DataGrid).DataContext = CustomerTable;
        }

        private void MouseUp_BooksImage(object sender, MouseButtonEventArgs e)
        {
            (FindName("CustomerPanel") as Grid).Visibility = Visibility.Hidden;
            (FindName("BookPanel") as Grid).Visibility = Visibility.Visible;
        }

        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
           
            String Firstname    = (FindName("Employee_UserAdd_Firstname")    as TextBox).Text;
            String Lastname     = (FindName("Employee_UserAdd_Lastname")     as TextBox).Text;
            String Street       = (FindName("Employee_UserAdd_Street")       as TextBox).Text;
            String StreetNumber = (FindName("Employee_UserAdd_StreetNumber") as TextBox).Text;
            String zipCode = (FindName("Employee_UserAdd_ZipCode") as TextBox).Text;
            
            String Phone        = (FindName("Employee_UserAdd_Phone")        as TextBox).Text;
            var bday            = (FindName("Employee_UserAdd_Birthday")     as DatePicker).SelectedDate;

            DateTime Birthday   = bday is DateTime ? (DateTime)bday : new DateTime(0,0,0);

            String Town         = (FindName("Employee_UserAdd_Town")         as TextBox).Text;
            String Country      = (FindName("Employee_UserAdd_Country")      as ComboBox).SelectedValue as String;

            

            Customer dummy = new Customer(0,Firstname,Lastname,Birthday);

            dummy.Street = Street;
            dummy.StreetNumber = StreetNumber;
            dummy.MobileNumber = Phone;
            dummy.ZipCode = zipCode;
            dummy.Town = Town;
            dummy.Country = Country;
           

            lib.getCustomerDAO().AddCustomer(dummy);
            clearAddCustomer();
           
        }

        private void ToolBarUserAdd_Click(object sender, MouseButtonEventArgs e)
        {
            clearAddCustomer();
            showUnderToolBar(true);
        }

        private void ToolBarDelte_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid table = FindName("CustomerTable") as DataGrid;
            DataRowView row;
            try
            {
                row = (DataRowView)table.SelectedItems[0];
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                return;
            }

            ulong id = (ulong)Convert.ToInt64(row["ID"] as String);

            Customer customer = lib.getCustomerDAO().GetCustomerById(id);

            (table.DataContext as DataTable).Rows[table.SelectedIndex].Delete();

        }

        private void showUnderToolBar(bool s)
        {
            if (s)
            {
                Grid grid = FindName("CustomerPanel") as Grid;
                grid.RowDefinitions[0].Height = new GridLength(150);

                Grid CustomerAddGrid = FindName("CustomerAddGrid") as Grid;
                CustomerAddGrid.Visibility = Visibility.Visible;
            }
            else
            {
                Grid grid = FindName("CustomerPanel") as Grid;
                grid.RowDefinitions[0].Height = new GridLength(30);

                Grid CustomerAddGrid = FindName("CustomerAddGrid") as Grid;
                CustomerAddGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            showUnderToolBar(false);
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            showUnderToolBar(true);

            DataGrid table = FindName("CustomerTable") as DataGrid;
            DataRowView row;
            try
            {
                row = (DataRowView)table.SelectedItems[0];
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                return;
            }

            ulong id = (ulong) Convert.ToInt64( row["ID"] as String );

            Customer customer = lib.getCustomerDAO().GetCustomerById(id);

            (FindName("Employee_UserAdd_Firstname") as TextBox).Text = customer.FirstName;
            (FindName("Employee_UserAdd_Lastname") as TextBox).Text = customer.LastName;
            (FindName("Employee_UserAdd_Street") as TextBox).Text = customer.Street;
            (FindName("Employee_UserAdd_StreetNumber") as TextBox).Text = customer.StreetNumber;
            (FindName("Employee_UserAdd_Phone") as TextBox).Text = customer.MobileNumber;
            (FindName("Employee_UserAdd_Birthday") as DatePicker).SelectedDate = customer.BirthDate;
            (FindName("Employee_UserAdd_Town") as TextBox).Text = customer.Town;
            (FindName("Employee_UserAdd_Country") as ComboBox).SelectedValue = customer.Country;

        }

        private void clearAddCustomer()
        {
            (FindName("Employee_UserAdd_Firstname") as TextBox).Text = "";
            (FindName("Employee_UserAdd_Lastname") as TextBox).Text = "";
            (FindName("Employee_UserAdd_Street") as TextBox).Text = "";
            (FindName("Employee_UserAdd_StreetNumber") as TextBox).Text = "";
            (FindName("Employee_UserAdd_Phone") as TextBox).Text = "";
            (FindName("Employee_UserAdd_Birthday") as DatePicker).SelectedDate = DateTime.Now;
            (FindName("Employee_UserAdd_Town") as TextBox).Text = "";
            (FindName("Employee_UserAdd_Country") as ComboBox).SelectedValue = "Deutschland";
        }

        private void ClearUserAdd_Click(object sender, RoutedEventArgs e)
        {
            clearAddCustomer();
        }
        


        private void ToolBarShowAll_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (FindName("ToolBarSearch") as TextBox).Text = "";
            DataGrid table = FindName("CustomerTable") as DataGrid;

            table.DataContext = getCustomerDataTable();

            foreach (Customer cust in lib.CustomerList)
            {
                this.lib.getGuiApi().AddCustomer(cust);
            }            
        }

        private void ToolBarSearch_MouseUp(object sender, MouseButtonEventArgs e)
        {
            String searchFor = (FindName("ToolBarSearch") as TextBox).Text;

            

            DataGrid table = FindName("CustomerTable") as DataGrid;

            table.DataContext = getCustomerDataTable();

            foreach (Customer cust in lib.CustomerList)
            {
                this.lib.getGuiApi().AddCustomer(cust);
            }

            DataTable dt = table.DataContext as DataTable;
            DataTable newDt = getCustomerDataTable();

            ulong id;
            Customer tmp;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                id = (ulong)Convert.ToInt64(dt.Rows[i]["ID"] as String);
                tmp = lib.getCustomerDAO().GetCustomerById(id);
                if (tmp.ToString().ToUpper().Contains(searchFor.ToUpper()))
                {
                    newDt.Rows.Add(
                        tmp.CustomerID.ToString(),
                        tmp.FirstName,
                        tmp.LastName,
                        tmp.Street,
                        tmp.StreetNumber,
                        tmp.ZipCode,
                        tmp.Town,
                        tmp.Country
                    );
                }

            }
            table.DataContext = newDt;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          //resize to full
        }

     
       
    }

   
}
