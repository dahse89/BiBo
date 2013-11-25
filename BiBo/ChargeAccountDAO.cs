using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;

namespace BiBo.DAO
{
  public class ChargeAccountDAO
  {
    MainWindow GUI;
    //public ChargeAccountSQL chargeAccountSql = SqlConnector<ChargeAccount>.GetChargeAccountSqlInstance();

    public ChargeAccountDAO(MainWindow GUI)
    {
      this.GUI = GUI;
    }
  }
}
