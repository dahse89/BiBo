﻿using System;
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

    private Customer loggedUser;

    //Lists of the important objects
    private List<Customer> customerList;
    private List<Book> bookList;
    private List<Exemplar> exemplarList;
    private List<ChargeAccount> chargeAccountList;

    //GUI Adapter
    private GUIApi gui;

    //DAO's
    private CustomerDAO customerDAO;
    private BookDAO bookDAO;

    private bool isEmployeeGUILoaded = false;
  
    

	//Konstruktor
	public Library()
	{
      this.gui = new GUIApi();
      this.customerDAO = new CustomerDAO(gui, this);
      this.bookDAO = new BookDAO(gui, this);   

      //init Customer list
      customerDAO.GetAllCustomer();

      //init Book list
      bookDAO.getAllBooks();
    }

    public Library(GUIApi api)
    {
      this.gui = api;
      this.customerDAO = new CustomerDAO(gui, this);
      this.bookDAO = new BookDAO(gui, this);

      //init Customer list
      customerDAO.GetAllCustomer();

      //init Book list
      bookDAO.getAllBooks();
    }


    //Property Deklaration
    public Customer LoggedUser
    {
        get { return loggedUser; }
        set { loggedUser = value; }
    }


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

    public List<Exemplar> ExemplarList
    {
      get { return exemplarList; }
      set { exemplarList = value; }
    }

    public List<ChargeAccount> ChargeAccountList
    {
      get { return chargeAccountList; }
      set { chargeAccountList = value; }
    }

    //Methods
    public CustomerDAO getCustomerDAO()
    {
      return customerDAO;
    }

    public BookDAO getBookDAO()
    {
      return this.bookDAO;
    }

    public GUIApi getGuiApi()
    {
      return this.gui;
    }



  }
}
