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
    Form1 form;
    Library lib;
    public CustomerSQL customerSql = SqlConnector<Customer>.GetCustomerSqlInstance();

    public CustomerDAO(Form1 form, Library lib)
    {
      this.form = form;
      this.lib = lib;
    }

    public List<Customer> GetAllCustomer()
    {
      return customerSql.GetAllEntrys();
    }

    public void AddCustomer(Customer dummy){
      //add user to DB
      //add user in Objects
      form.AddCustomer(dummy); //real instead of dummy
    }

    public void DeleteCustomersByIdList()
    {
        //removes all selected rows and return list of deleted customer ids
        List<ulong> IdList = form.DeleteCustomersByIdList();
        //delete in Object 
        //delete in DB
    }


  }
}
