using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlTypes;
using BiBo.Persons;

namespace BiBo.SQL
{
  public class ChargeSQL : SqlConnector<Charge>
  {
    public override bool AddEntry(Charge obj)
    {
      try
      {
        SQLiteCommand command = new SQLiteCommand(con);
        if (command != null)
        {
          command.CommandText = @"INSERT INTO ChargeTransactions (
                                      ChargeAccountID,
                                      change,
                                      newValue,
                                      changedAt
                                  )   
                                  VALUES (
                                      '1',
                                      '" + obj.ChangeValues +@"',  
                                      '" + obj.CurrentValue + obj.ChangeValues + @"',
                                      '" + DateTime.Now + @"'
                                  );";

          command.ExecuteNonQuery();
        }
        return true;
      }
      catch (System.Exception)
      {
        return false;
      }
    }
    public override bool UpdateEntry(Charge customer)
    {
      throw new NotImplementedException();
    }

    public override ulong AddEntryReturnId(Charge obj)
    {
      AddEntry(obj);

      SQLiteCommand command = new SQLiteCommand(con);
      command.CommandText = "select last_insert_rowid()";
      UInt64 lastRowID64 = Convert.ToUInt64(command.ExecuteScalar());
      // UInt64 lastRowID64 = (UInt64)command.ExecuteScalar(); // Fehler	System.InvalidCastException: Die angegebene Umwandlung ist ungültig.	
      return (ulong)lastRowID64;
    }

    public override bool DeleteEntryByIdList(List<ulong> l)
    {
      throw new NotImplementedException();
    }

    public override List<Charge> GetAllEntrys()
    {
      throw new NotImplementedException();
    }

    protected override Charge InitEntryByReader(SQLiteDataReader reader)
    {
      throw new NotImplementedException();
    }
  }
}
