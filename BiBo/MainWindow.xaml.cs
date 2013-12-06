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
using System.Configuration;
using BiBo.Persons;
using System.IO;
using System.Data;
using System.Collections;
using System.Windows.Controls.Primitives;
using BiBo.Exception;
using BiBo.DAO;
using BiBo.SQL;
using System.Diagnostics;
using System.Resources;

namespace BiBo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Library lib;
        Tabs CurrentEmployeeAreaTab = Tabs.CUSTOMER;

        public MainWindow()
        {
            Debug.WriteLine("Applicaion Beginn");
            AppSettingsReader config = new AppSettingsReader();
            bool migrateDB = (bool)config.GetValue("MigrateDB", typeof(bool));
            bool ImportDummyData = (bool)config.GetValue("ImportDummyData", typeof(bool));
            InitDbSQL x = new InitDbSQL();
            if (migrateDB == true) { x.createAllTables(); }
            if (ImportDummyData == true){x.createDummyData();x.createRandomBooks();}
            
            BiBo.Updater.BiboUpdater updater = new BiBo.Updater.BiboUpdater();
            string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //updater.checkForNewVersion();
            Debug.WriteLine("Update Finish");
            InitializeComponent();
            Debug.WriteLine("InitializeComponent Finish");
            //TODO: An dieser Stelle bricht die Compalierte Exe immer ab, wenn man sie von der Webseite bezieht
            initMainWindow();
            Debug.WriteLine("initMainWindow Finish");
            
        }

        public MainWindow(GUIApi api)
        {
          InitializeComponent();
          initElements();
          lib = new Library(api);
          foreach (Customer cust in lib.CustomerList)
          {
            this.lib.getGuiApi().AddCustomer(cust);
          }
        }

        public void initMainWindow()
        {
            initElements();
            lib = new Library();
            foreach (Customer cust in lib.CustomerList)
            {
                this.lib.getGuiApi().AddCustomer(cust);
            }

            

            foreach (Book book in lib.BookList)
            {                
                this.lib.getGuiApi().Add_c_Book(book);
            }
        }

        private void initElements()
        {
            initCoutriesComboBox();
            initCustomerTable();
            init_c_BookTable();
        }

        private void initCoutriesComboBox()
        {
            //init Employee_UserAdd_Country
            ComboBox comBox = this.FindName("Employee_UserAdd_Country") as ComboBox;
            //create line string to catch lines from file

            // Read the file and display it line by line.
            string resource_data = Properties.Resources.countries;
            string [] words = resource_data.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string lines in words){
                comBox.Items.Add(lines);
            }

            comBox.SelectedIndex = 0;
        }

        private DataTable getCustomerDataTable()
        {
            DataTable New = new DataTable("Customers");         
            New.Columns.Add("ID",typeof(ulong));
            New.Columns.Add("Vorname");
            New.Columns.Add("Nachname");
            New.Columns.Add("Strasse");
            New.Columns.Add("Nummer");
            New.Columns.Add("PLZ");
            New.Columns.Add("Stadt");
            New.Columns.Add("Land");
            return New;
        }


        private DataTable getBookDataTable()
        {
            DataTable New = new DataTable("Books");
            New.Columns.Add("ID",typeof(ulong));
            New.Columns.Add("Author");  
            New.Columns.Add("Title");
                  
            return New;
        }

        private void initCustomerTable()
        {
            DataTable CustomerTable = getCustomerDataTable();
            (FindName("CustomerTable") as DataGrid).DataContext = CustomerTable;
        }

        private void init_c_BookTable()
        {
            DataTable BookTable = getBookDataTable();
            (FindName("cBookTable") as DataGrid).DataContext = BookTable;
            
        }

        private void resetEmployeeArea()
        {
            (FindName("CustomerPanel") as Grid).Visibility = Visibility.Visible;
            (FindName("BookPanel") as Grid).Visibility = Visibility.Hidden;
        }

        private void MouseUp_BooksImage(object sender, MouseButtonEventArgs e)
        {
          HandleTabs_EmployeeArea(Tabs.BOOK);
        }

        private void MouseUp_AccountImage(object sender, MouseButtonEventArgs e)
        {          
          HandleTabs_EmployeeArea(Tabs.CUSTOMER);
        }

        private void MouseUp_BorrowImage(object sender, MouseButtonEventArgs e)
        {          
          HandleTabs_EmployeeArea(Tabs.BORROW);
        }

      
      
        private void HandleTabs_EmployeeArea(Tabs show)
        {
          if (show == CurrentEmployeeAreaTab) return;
  
          //hide all
          (FindName("CustomerPanel") as Grid).Visibility = Visibility.Hidden;
          (FindName("BookPanel") as Grid).Visibility = Visibility.Hidden;
          (FindName("BorrowPanel") as Grid).Visibility = Visibility.Hidden;  

          //show
          switch (show)
          {
            case Tabs.CUSTOMER:
              (FindName("CustomerPanel") as Grid).Visibility = Visibility.Visible;
              CurrentEmployeeAreaTab = Tabs.CUSTOMER;
              break;
            case Tabs.BOOK:
              (FindName("BookPanel") as Grid).Visibility = Visibility.Visible;
              CurrentEmployeeAreaTab = Tabs.BOOK;
              break;
            case Tabs.BORROW:
              (FindName("BorrowPanel") as Grid).Visibility = Visibility.Visible;              
              CurrentEmployeeAreaTab = Tabs.BORROW;
              break;
          }
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
            ToggleAddEditButton("hinzufügen");
            showUnderToolBar(true);
        }

        private void ToolBarDelte_MouseUp(object sender, MouseButtonEventArgs e)
        {         
            DataGrid table = FindName("CustomerTable") as DataGrid;
            if (table.SelectedItems.Count < 1) return;

            ulong id;

            List<Customer> customers = new List<Customer>();
            foreach(DataRowView row in table.SelectedItems){
              id = (ulong)row["ID"];
              customers.Add(lib.getCustomerDAO().GetCustomerById(id));
            }

            foreach (Customer c in customers)
            {
              lib.getCustomerDAO().DeleteCustomer(c);
            }
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

            ulong id = (ulong) row["ID"];

            Customer customer = lib.getCustomerDAO().GetCustomerById(id);

            (FindName("Employee_UserAdd_Firstname") as TextBox).Text = customer.FirstName;
            (FindName("Employee_UserAdd_Lastname") as TextBox).Text = customer.LastName;
            (FindName("Employee_UserAdd_Street") as TextBox).Text = customer.Street;
            (FindName("Employee_UserAdd_StreetNumber") as TextBox).Text = customer.StreetNumber;
            (FindName("Employee_UserAdd_Phone") as TextBox).Text = customer.MobileNumber;
            (FindName("Employee_UserAdd_Birthday") as DatePicker).SelectedDate = customer.BirthDate;
            (FindName("Employee_UserAdd_Town") as TextBox).Text = customer.Town;
            (FindName("Employee_UserAdd_Country") as ComboBox).SelectedValue = customer.Country;
            ToggleAddEditButton("bearbeiten");

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


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String IdString = (FindName("LoginName") as TextBox).Text;
            ulong id = 0;

            String pass = (FindName("LoginPass") as PasswordBox).Password;
            Customer potentialLogin;

            if (Validation.isNumeric(IdString))
            {
                id = (ulong)Convert.ToInt64(IdString);
                try
                {
                    potentialLogin = lib.getCustomerDAO().GetCustomerById(id);
                }
                catch (CustomerNotFoundException cnfe) {
                    MessageBox.Show(cnfe.Message);
                    return;
                }

                if (lib.getCustomerDAO().checkPass(potentialLogin,pass))
                {
                    //login
                    login(potentialLogin); 
                    return;
                }
                MessageBox.Show("Ungültiges Password");
                return;
            }
            MessageBox.Show("Die ID muss eine Zahl sein");
        }

        private void login(Customer x)
        {
            switch (x.Right)
            {
                case Rights.ADMINISTRATOR:
                    admin_login(x);
                    break;
                case Rights.EMPLOYEE:
                    employee_login(x);
                    break;
                case Rights.CUSTOMER:
                    customer_login(x);
                    break;
            }
        }

        private void admin_login(Customer admin)
        {
            employee_login(admin);
        }

        private void employee_login(Customer employee)
        {
            resetEmployeeArea();
            (FindName("EmployeeArea") as Grid).Visibility = Visibility.Visible;
            (FindName("Login") as Grid).Visibility = Visibility.Collapsed;
            lib.getGuiApi().setLoggedInUser(employee);
            lib.LoggedUser = employee;
        }

        private void customer_login(Customer customer)
        {
            (FindName("CustomerArea") as Grid).Visibility = Visibility.Visible;
            (FindName("Login") as Grid).Visibility = Visibility.Collapsed;
            lib.getGuiApi().setLoggedInUser(customer);
            lib.LoggedUser = customer;
            
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

        private void ToolBarShowAllBook_c_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (FindName("cToolBarSearch") as TextBox).Text = "";
            DataGrid table = FindName("cBookTable") as DataGrid;

            table.DataContext = getBookDataTable();

            foreach (Book book in lib.BookList)
            {
                this.lib.getGuiApi().Add_c_Book(book);
            }
        }

        private void Employee_Logout_MouseUp(object sender, MouseButtonEventArgs e) {
            (FindName("EmployeeArea") as Grid).Visibility = Visibility.Collapsed;
            (FindName("Login") as Grid).Visibility = Visibility.Visible;
            (FindName("LoginName") as TextBox).Text = "";
            (FindName("LoginPass") as PasswordBox).Password = "";
        }

        private void Customer_Logout_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (FindName("CustomerArea") as Grid).Visibility = Visibility.Collapsed;
            (FindName("Login") as Grid).Visibility = Visibility.Visible;
            (FindName("LoginName") as TextBox).Text = "";
            (FindName("LoginPass") as PasswordBox).Password = "";
        }

        

        private void LoginInfo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Bitte wenden Sie sich an einen unserer Mitarbeiter. Dieser kann Ihnen über Ihren Zugang informieren");
        }

        private void ToolBarSearch_c_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Boolean useTitle = (bool) (FindName("cCboxTitle") as CheckBox).IsChecked;
            Boolean useAuthor = (bool)(FindName("cCboxAuthor") as CheckBox).IsChecked;
           

            String searchFor = (FindName("cToolBarSearch") as TextBox).Text;

            DataGrid table = FindName("cBookTable") as DataGrid;

            table.DataContext = getBookDataTable();

            foreach (Book book in lib.BookList)
            {
                this.lib.getGuiApi().Add_c_Book(book);
            }

            DataTable dt = table.DataContext as DataTable;
            DataTable newDt = getBookDataTable();

            ulong id;
            Book tmp;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                id = (ulong)Convert.ToInt64(dt.Rows[i]["ID"] as String);
                tmp = lib.getBookDAO().GetBookById(id);

                if (useTitle && useAuthor)
                {
                    if ((tmp.Author + "" + tmp.Titel).ToUpper().Contains(searchFor.ToUpper()))
                    {
                        newDt.Rows.Add(
                            tmp.BookId,
                            tmp.Author,
                            tmp.Titel
                        );
                    }
                }
                else if (useTitle)
                {
                    if ((tmp.Titel).ToUpper().Contains(searchFor.ToUpper()))
                    {
                        newDt.Rows.Add(
                            tmp.BookId,
                            tmp.Author,
                            tmp.Titel
                        );
                    }
                }
                else if(useAuthor)
                {
                    if ((tmp.Author).ToUpper().Contains(searchFor.ToUpper()))
                    {
                        newDt.Rows.Add(
                            tmp.BookId,
                            tmp.Author,
                            tmp.Titel
                        );
                    }
                }
               

            }
            table.DataContext = newDt;
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

        private void ToggleAddEditButton(String value)
        {
          Button x = FindName("CustomerAddEditButton") as Button;
          Button reset = FindName("CustomerAddEditResetButton") as Button;
          if (value != "")
          {
            x.Content = value;
            if (value == "hinzufügen")
            {
              reset.Visibility = Visibility.Visible;
            }
            else
            {
              reset.Visibility = Visibility.Collapsed;
            }
            return;
          }
          
          if (x.Content.ToString().CompareTo("hinzufügen") == 0)
          {
            x.Content = "bearbeiten";
          }
          else
          {
            x.Content = "hinzufügen";
          }
         
        }

        private void MainCustomerTable_DoubleClick(object sender, MouseButtonEventArgs e)
        {
          DataGrid table = sender as DataGrid;
          DataRowView row;
          try
          {
            row = (DataRowView)table.SelectedItems[0];
          }
          catch (ArgumentOutOfRangeException aoore)
          {
            return;
          }

          ulong id = (ulong) row["ID"];
          Customer customer = lib.getCustomerDAO().GetCustomerById(id);
          clearAddCustomer();
          (FindName("Employee_UserAdd_Firstname") as TextBox).Text = customer.FirstName;
          (FindName("Employee_UserAdd_Lastname") as TextBox).Text = customer.LastName;
          (FindName("Employee_UserAdd_Street") as TextBox).Text = customer.Street;
          (FindName("Employee_UserAdd_StreetNumber") as TextBox).Text = customer.StreetNumber;
          (FindName("Employee_UserAdd_Phone") as TextBox).Text = customer.MobileNumber;
          (FindName("Employee_UserAdd_Birthday") as DatePicker).SelectedDate = customer.BirthDate;
          (FindName("Employee_UserAdd_Town") as TextBox).Text = customer.Town;
          (FindName("Employee_UserAdd_Country") as ComboBox).SelectedValue = customer.Country;
          ToggleAddEditButton("bearbeiten");
          showUnderToolBar(true);
        }

        private void LoginName_KeyDown(object sender, KeyEventArgs e)
        {
          if (e.Key == Key.Enter)
          {
            Login_Click(new Object(), new RoutedEventArgs());
          }
        }
       
    }

   
}
