using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;
using BiBo.Persons;

namespace BiBo.DAO
{
  public class ChargeAccountDAO
  {
    Library lib;

    public ChargeAccountSQL chargeAccountSql = SqlConnector<ChargeAccount>.GetChargeAccountSqlInstance();
    public ChargeSQL chargeSql = SqlConnector<Charge>.GetChargeSqlInstance();

    public ChargeAccountDAO()
    {
    }
    
    public ChargeAccountDAO(Library lib)
    {
      this.lib = lib;
    }

    public List<ChargeAccount> GetAllChargeAccounts()
    {
      if (lib.ChargeAccountList == null)
      {
        return lib.ChargeAccountList = chargeAccountSql.GetAllEntrys();
      }
      else
        return lib.ChargeAccountList;
    }

    public List<Charge> GetChargeAccountToCustomer(Customer customer)
    {
      return customer.ChargeAccount.Charges;
    }

    public void AddCharge(Customer customer, DateTime date, decimal changeValue)
    {
      //create the Charge with the last value
      if (customer.ChargeAccount.Charges.Count == 0)
      {
        //create charge
        Charge charge = new Charge(date, changeValue, changeValue);
        charge.ChargeAccountId = customer.ChargeAccount.Id;

        //on db-layer
        charge.TransactionId = chargeSql.AddEntryReturnId(charge);

        //on object layer
        customer.ChargeAccount.Charges.Add(charge);

      }
      else
      {
        //create the charge
        Charge lastCharge = customer.ChargeAccount.Charges.Last();
        decimal value = lastCharge.CurrentValue + changeValue;
        Charge charge = new Charge(date, value, changeValue);
        charge.ChargeAccountId = customer.ChargeAccount.Id;

        //on db-layer
        chargeSql.AddEntryReturnId(charge);

        //on object-layer
        customer.ChargeAccount.Charges.Add(charge);
      }
    }
  }
}
