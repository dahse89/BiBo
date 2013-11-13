using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;

namespace BiBo.DAO
{
  public class ChargeAccountDAO
  {
    Form1 form;
    //public ChargeAccountSQL chargeAccountSql = SqlConnector<ChargeAccount>.GetChargeAccountSqlInstance();

    public ChargeAccountDAO(Form1 form)
    {
      this.form = form;
    }
  }
}
