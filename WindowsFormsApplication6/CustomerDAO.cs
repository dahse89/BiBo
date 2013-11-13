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
    public CustomerSQL customerSql = SqlConnector<Customer>.GetCustomerSqlInstance();

    public CustomerDAO(Form1 form)
    {
      this.form = form;
    }
  }
}
