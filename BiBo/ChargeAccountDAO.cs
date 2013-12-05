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
    GUIApi gui;
    Library lib;
    public ChargeAccountSQL chargeAccountSql = SqlConnector<ChargeAccount>.GetChargeAccountSqlInstance();

    public ChargeAccountDAO(GUIApi gui, Library lib)
    {
      this.lib = lib;
      this.gui = gui;
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
      Charge charge = customer.ChargeAccount.Charges.Last();
      decimal value = charge.CurrentValue + changeValue;
      customer.ChargeAccount.Charges.Add(new Charge(date, value, changeValue));
    }
  }
}
