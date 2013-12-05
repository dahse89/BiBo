using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

using BiBo.SQL;
using BiBo.Persons;
using BiBo.Exception;
using System.Windows;

namespace BiBo.DAO
{
  public class CustomerDAO
  {
    private GUIApi gui;
    private Library lib;
    private CustomerSQL customerSql = SqlConnector<Customer>.GetCustomerSqlInstance();
    private ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();
    private ChargeAccountDAO chargeAccountSql;
    private BookDAO bookDAO;
    private ExemplarDAO exemplarDAO;

    public CustomerDAO(GUIApi gui, Library lib)
    {
      this.gui = gui;
      this.lib = lib;
      this.bookDAO = new BookDAO(gui, lib);
      this.chargeAccountSql = new ChargeAccountDAO(gui, lib);
      this.exemplarDAO = new ExemplarDAO(gui, lib);
    }

    public CustomerDAO()
    {
    }

    public List<Customer> GetAllCustomer()
    {
        if (lib.CustomerList == null)
        {
          //initialize the Lists when start the application
          //List<Customer> customerList = customerSql.GetAllEntrys();
          //List<ChargeAccount> chargeAccountList = chargeAccountSql.GetAllEntrys();
          List<Exemplar> exemplarList = exemplarSql.GetAllEntrys();
          //List<ChargeAccount> chargeAccountList = chargeAccountSql.GetAllChargeAccounts();

          lib.CustomerList = customerSql.GetAllEntrys();            
        }
        return lib.CustomerList;
    }

    public void AddCustomer(Customer customer)
    {
      //add user to DB and dummy get the right id
        customer.CustomerID = customerSql.AddEntryReturnId(customer);
      
      //add user in Objects
        lib.CustomerList.Add(customer);

      //refresh GUI-View
        gui.AddCustomer(customer);
    }

    public void DeleteCustomer(Customer customer)
    {
      decimal currentValue = customer.ChargeAccount.Charges.Last().CurrentValue;
      if (currentValue == 0 && customer.ExemplarList.Count == 0)
      {
        List<ulong> list = new List<ulong>();
        list.Add(customer.CustomerID);

        //on object-layer
        lib.CustomerList.Remove(customer);

        //on db-layer
        customerSql.DeleteEntryByIdList(list); //<--- TODO possibility to delete a single customer ?

        //on view-layer
        //gui.DeleteCustomer();   <--- TODO possibilitý to delete customer in the view
      }
    }

    //TODO: is not possible to delete single Customer?
    public void DeleteCustomersByIdList()
    {
       //removes all selected rows and return list of deleted customer ids
       /*List<ulong> idList = gui.DeleteCustomer();

        //delete in Object <----- must be go better !!! SCHAU DA NOCHMAL NACH MARCUS !!!!!
        List<Customer> copyOfCustomerList = lib.CustomerList.ToList(); //<----- ist nötig, sonst InvalidOperationException, weil die Liste, die durchlaufen wird, geändert wird
        foreach (Customer customer in copyOfCustomerList)  
        {
          foreach (ulong id in idList)
          {
            if (id == customer.CustomerID)
              lib.CustomerList.Remove(customer);
          }
        }

        //delete in DB
        customerSql.DeleteEntryByIdList(idList);*/
    }

    //method to edit a customer
    public void UpdateCustomer(Customer customer)
    {
      //on object-layer
      foreach (Customer customerInList in lib.CustomerList)
      {
        if (customerInList.CustomerID == customer.CustomerID)
        {
          lib.CustomerList.Remove(customerInList);
          lib.CustomerList.Add(customer);
        }
      }

      //on db layer
      customerSql.UpdateEntry(customer);

      //on view
      gui.UpdateCustomer(customer);
    }

    public Customer GetCustomerById(ulong id)
    {

        /*
        @Marcus: hier nur mal ein Beispiel mit LINQ, nur falls du lust hast das zu benutzen
        try
        {
            return (from Customer c in lib.CustomerList where c.CustomerID == id select c).ToList()[0];
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            throw new CustomerNotFoundException("Benutzer mit gegebener ID nicht vorhanden");
        }
        */
       
      foreach (Customer customer in lib.CustomerList)
      {
        if (customer.CustomerID == id)
          return customer;
      }
      throw new CustomerNotFoundException("Benutzer mit gegebener ID nicht vorhanden");
       
    }

    public void SetPassword(Customer cust, string password)
    {

        cust.Password = getMD5(password);
    }

    public bool checkPass(Customer customer, String pass){
        return getMD5(pass) == customer.Password;
    }

    //musste das mal splitten
    private String getMD5(String from)
    {
        MD5 md5 = MD5.Create();
        byte[] output = md5.ComputeHash(Encoding.UTF8.GetBytes(from));
        StringBuilder builder = new StringBuilder();

        foreach (byte by in output)
        {
            builder.Append(by.ToString("x2"));
        }

        return builder.ToString();
    }

    public bool BorrowExemplar(DateTime dateBookWillBeBack, Book book, Customer customer)
    {
      //get the first exemplar who is available
      Exemplar borrowExemplar = bookDAO.GetFirstAvailableExemplar(book);
      //on object-layer
      //if exemplar not null, borrow it
      if (borrowExemplar != null)
      {
        borrowExemplar.LoanPeriod = dateBookWillBeBack;
        customer.ExemplarList.Add(borrowExemplar);
      }
      else
      {
        return false;
      }
      //on db-layer update the customer
      customerSql.UpdateEntry(customer);

      //on db-layer update the exemplar
      exemplarSql.UpdateEntry(borrowExemplar);
      return true;
    }

    public List<Exemplar> GetBorrowedBooks(Customer customer)
    {
      return customer.ExemplarList;
    }
  }
}
