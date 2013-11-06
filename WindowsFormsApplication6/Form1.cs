using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using BiBo.Persons;
using BiBo.DAO;


namespace BiBo
{
    public partial class Form1 : Form
    {
        private String LoginAsUserName; //name of current logged user
        private String   UserStatusText; //status of current logged user

        private Tabs activTab = Tabs.CUSTOMER;

        //@todo remove this, it is only needed of testing
        private Random r = new Random();

        //SQLLite Adapters
        private CustomerDAO SqlCustomer;
        private BookDAO SqlBook;

        //constructor with getting SQLLite Adapters
        public Form1(CustomerDAO CustSQL, BookDAO BookSQL)
        {
            this.SqlCustomer = CustSQL;
            this.SqlBook = BookSQL;
            __construct();
        }

        //default constructor
        public Form1()
        {
            __construct();
        }

        //summary constructor
        private void __construct(){
            //get current screen size
            int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            //load GUI elements, calculated by screen size (responsive)
            //@see: Form1.Designer
            InitializeComponent(width,height);

            //init content

            //@todo this should come form login and SQLLite
            this.LoginAsUserName = "Philipp Dahse";
            this.UserStatusText = "Admin";

            //fill GUI elemens with content
            publishContent();

            //@todo remove at the end is only for testing
            // randomPushUser();
        }

    
        //fill GUI elements with content
        private void publishContent()
        {
            //set name of current logged user
            userName.Text += this.LoginAsUserName;

            //set statis of current logged user
            userStat.Text += this.UserStatusText;

            //fill content on customer tab
            //@see Form1.Customer
            this.publishCustomerContent();
            //fill content on books tab
            //@see Form1.Books
            this.publishBookContent();
        }


        /*
         * Click Event functions
         */

        //click in main tabs in customer
        private void customerImage_Click(object sender, EventArgs e)
        {
            //show customer Main Panel hide others
            this.CustomerMainPanel.Visible = true;
            this.BooksMainPanel.Visible = false;

            this.activTab = Tabs.CUSTOMER;
        }

        private void booksImage_Click(object sender, EventArgs e)
        {
            //show books Main Panel hide others
            this.CustomerMainPanel.Visible = false;
            this.BooksMainPanel.Visible = true;

            this.activTab = Tabs.BOOK;
        }

        //close application
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //delete
        //delete customer which are selected in datagrid view
        private void buttonDeleteSelectedRows_Click(object sender, EventArgs e)
        {
            switch(this.activTab)
            {
                case Tabs.CUSTOMER: deleteSelectedCustomers(); break;
                case Tabs.BOOK: deleteSelectedBooks(); break;
            }
        }

        //search
        private void textBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {

            //@todo if main tab on user
            TextBox self = (TextBox)sender;

            switch(this.activTab)
            {
                case Tabs.CUSTOMER: searchUserTable(self.Text); break;
                case Tabs.BOOK: searchBookTable(self.Text); break;
            }

        }
    } 
    
}
 
