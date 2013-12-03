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
    //public ChargeAccountSQL chargeAccountSql = SqlConnector<ChargeAccount>.GetChargeAccountSqlInstance();

    public ChargeAccountDAO(GUIApi gui)
    {
      this.gui = gui;
    }

    public List<Charge> GetChargeAccountList(Customer customer)
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
