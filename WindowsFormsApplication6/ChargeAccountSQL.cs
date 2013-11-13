using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlTypes;

namespace BiBo.SQL
{
  public class ChargeAccountSQL : SqlConnector<ChargeAccountSQL>
    {
      public ChargeAccountSQL()
      {
        string customerSQL = @"CREATE TABLE IF NOT EXISTS
                                    ChargeAccount (
                                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                        customerId INTEGER NOT NULL,
                                        changedAt DATETIME,
                                        currentValue DECIMAL
                                    );";

        SQLiteCommand command = new SQLiteCommand(customerSQL, con);
        command.ExecuteNonQuery();
      }
    }
}
