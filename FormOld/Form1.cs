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
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace BiBo
{
    public partial class Form1 : Form
    {
        private String loginAsUserName; //name of current logged user
        private String   userStatusText; //status of current logged user

        private Tabs activTab = Tabs.CUSTOMER;

        //default value of DatePicker for user add birthday
        private DateTime userAddBirthDayDefault = new DateTime(1980, 1, 1);

        //Source file of Countries
        //@todo this could be stored in SQLLite Table
        private String countriesSource = "../../countries.txt";

        //@todo remove this, it is only needed of testing
        private Random r = new Random();

        private Customer selectedUser;

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
            //createRandomBooks();return;
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

        private void createRandomBooks()
        {
            BookSQL db = new BookSQL();

            String Source = "http://www.lovelybooks.de/buecher/romane/Schr%C3%A4ge-Buchtitel-582954334/";
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string downloadString = client.DownloadString(Source);

	
            
            Regex regex = new Regex(@">([^<]+)</span></a></h3");
            var listTitle = (from Match m in regex.Matches(downloadString) select m).ToList();


            regex = new Regex(@"von\s<a[^>]+>([^<]+)<");
            var listAuthor = (from Match m in regex.Matches(downloadString) select m).ToList();


            for (int i = 0; i < listTitle.Count; i++)
            {
               
                    db.AddEntryReturnId(new Book(0, listAuthor[i].Groups[1].Value, listTitle[i].Groups[1].Value, "Roman"));
               
             
            }

            
            
        }
    }     
}
 
