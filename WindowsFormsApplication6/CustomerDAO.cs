using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;
using BiBo.Persons;
using BiBo.Exception;

namespace BiBo.DAO
{
  public class CustomerDAO
  {
    private Form1 form;
    private Library lib;
    private CustomerSQL customerSql = SqlConnector<Customer>.GetCustomerSqlInstance();

    public CustomerDAO(Form1 form, Library lib)
    {
      this.form = form;
      this.lib = lib;
    }

    public List<Customer> GetAllCustomer()
    {
      if (lib.CustomerList == null)
        return lib.CustomerList = customerSql.GetAllEntrys();
      else
        return lib.CustomerList;
    }

    public void AddCustomer(Customer customer)
    {
      //add user to DB and dummy get the right id
        customer.CustomerID = customerSql.AddEntryReturnId(customer);
      
      //add user in Objects
        lib.CustomerList.Add(customer);

      //refresh GUI-View
        form.AddCustomer(customer); //real instead of dummy
    }
    //TODO: is not possible to delete single Customer?
    public void DeleteCustomersByIdList()
    {
        //removes all selected rows and return list of deleted customer ids
        List<ulong> idList = form.DeleteCustomersByIdList();

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
        customerSql.DeleteEntryByIdList(idList);
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


  }
}
