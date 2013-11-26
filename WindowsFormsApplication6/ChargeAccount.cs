using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo.Persons
{
    public class ChargeAccount
    {
      private Customer customer;
      private DateTime changedAt;
      private List<decimal> changeValues;
      private decimal currentValue;

      //Konstruktor
      public ChargeAccount(Customer customer, DateTime changedAt, List<decimal> changeValues, decimal currentValue) 
      {
          this.customer = customer;
          this.changedAt = changedAt;
          this.changeValues = changeValues;
          this.currentValue = currentValue;
      }

      public Customer Customer
      {
        get { return this.customer; }
        set { this.customer = value; }
      }

      public DateTime ChangeAt
      {
        get { return this.changedAt; }
        set { this.changedAt = value; }
      }

      public List<decimal> ChangeValues
      {
        get { return this.changeValues; }
        set { this.changeValues = value; }
      }

      public decimal CurrentValue
      {
        get { return this.currentValue; }
        set { this.currentValue = value; }
      }
    }
}
