using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.Persons;

namespace BiBo
{
    public class ChargeAccount
    {
      private Customer customer;
      private List<Charge> charges;

      //Konstruktor
      public ChargeAccount(Customer customer) 
      {
          this.customer = customer;
      }

      public Customer Customer
      {
        get { return this.customer; }
        set { this.customer = value; }
      }

      public List<Charge> Charges
      {
        get { return this.charges; }
        set { this.charges = value; }
      }
    }
}
