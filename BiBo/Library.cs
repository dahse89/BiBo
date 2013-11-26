using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;
using BiBo.DAO;
using BiBo.Persons;

namespace BiBo
{
  public class Library
  {
  	//Member-Variablen Deklaration
    private double fee;           //Gebuehren
    private string openingTime;  //Oeffnungszeiten

    //Lists of the important objects
    private List<Customer> customerList;
    private List<Book> bookList;

    //GUI Adapter
    private GUIApi GUI;

    //DAO's
    private TestDAO testDao;
    private CustomerDAO customerDAO;
    private BookDAO bookDAO;

    private bool isEmployeeGUILoaded = false;
  
    

		//Konstruktor
		public Library()
		{
          this.customerDAO = new CustomerDAO(GUI, this);
          this.bookDAO = new BookDAO(GUI, this);
          this.GUI = new GUIApi();

          //init Customer list
          customerDAO.GetAllCustomer();
		}


    //Property Deklaration
    public double Fee
    {
      get { return fee; }
      set { fee = value; }
    }

    public bool IsEmployeeGUILoaded {
        get { return this.isEmployeeGUILoaded; }
        set { this.isEmployeeGUILoaded = value; }
    }

    public string OpeningTime
    {
      get { return openingTime; }
      set { openingTime = value; }
    }

    public List<Customer> CustomerList
    {
      get { return customerList; }
      set { customerList = value; }
    }

    public List<Book> BookList
    {
      get { return bookList; }
      set { bookList = value; }
    }


    //Methods
    public CustomerDAO getCustomerDAO()
    {
      return customerDAO;
    }

    public TestDAO getTestDAO()
    {
      return this.testDao;
    }

    public BookDAO getBookDAO()
    {
      return this.bookDAO;
    }

    public GUIApi getGuiApi()
    {
      return this.GUI;
    }



  }
}
