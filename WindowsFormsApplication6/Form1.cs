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
using BiBo.SQL;


namespace BiBo
{
    public partial class Form1 : Form
    {
        private String loginAsUserName; //name of current logged user
        private String   userStatusText; //status of current logged user

        private Tabs activTab = Tabs.CUSTOMER;

        //@todo remove this, it is only needed of testing
        private Random r = new Random();

        //SQLLite Adapters
        private CustomerSQL sqlCustomer;
        private BookSQL sqlBook;

        private Library lib;

        //constructor with getting SQLLite Adapters
       /* public Form1(CustomerDAO CustSQL, BookDAO BookSQL)
        {
            this.SqlCustomer = CustSQL;
            this.SqlBook = BookSQL;
            __construct();
        }*/

        //default constructor
        public Form1()
        {
        	this.sqlCustomer = SqlConnector<Customer>.GetCustomerSqlInstance();
            this.sqlBook = SqlConnector<Book>.GetBookSqlInstance();
            __construct();

        }


        //summary constructor
        private void __construct()
        {
          this.lib = new Library(this);
          lib.getGuiApi().init();
        }
    }     
}
 
