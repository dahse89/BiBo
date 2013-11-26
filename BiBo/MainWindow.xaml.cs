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

namespace BiBo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindow lib;
        private String CountriesSource = "../../countries.txt";

        public MainWindow()
        {
            //this.lib = new Library(this);
            InitializeComponent();
            initObjects();
            initElements();
        }

        private void initObjects(){
            //lib = 0;
        }

        private void initElements()
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
            
            

        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
           
            String Firstname    = (FindName("Employee_UserAdd_Firstname")    as TextBox).Text;
            String Lastname     = (FindName("Employee_UserAdd_Lastname")     as TextBox).Text;
            String Street       = (FindName("Employee_UserAdd_Street")       as TextBox).Text;
            String StreetNumber = (FindName("Employee_UserAdd_StreetNumber") as TextBox).Text;
            String Phone        = (FindName("Employee_UserAdd_Phone")        as TextBox).Text;
            var bday            = (FindName("Employee_UserAdd_Birthday")     as DatePicker).SelectedDate;

            DateTime Birthday   = bday is DateTime ? (DateTime)bday : new DateTime(0,0,0);

            String Town         = (FindName("Employee_UserAdd_Town")         as TextBox).Text;
            String Country      = (FindName("Employee_UserAdd_Country")      as ComboBox).SelectedValue as String;

            Birthday = Birthday == null ? new DateTime(0, 0, 0) : Birthday;

            Customer dummy = new Customer(0,Firstname,Lastname,Birthday);

            MessageBox.Show(
                Firstname + "\n" +
                Lastname + "\n" +
                Street + " " +
                StreetNumber + "\n" +
                Phone + "\n" +
                Birthday + "\n" +
                Town + "\n" +
                Country
            );
           
        }

       
    }

   
}
