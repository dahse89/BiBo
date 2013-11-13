using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;
using BiBo.Persons;

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

    public void AddCustomer(Customer dummy)
    {
      //add user to DB and dummy get the right id
      dummy.CustomerID = customerSql.AddEntryReturnId(dummy);
      
      //add user in Objects
      lib.CustomerList.Add(dummy);

      //refresh GUI-View
      form.AddCustomer(dummy); //real instead of dummy
    }

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


  }
}
