﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlTypes;

namespace BiBo.SQL
{
  public class ChargeAccountSQL : SqlConnector<ChargeAccountSQL>
    {
      public override bool AddEntry(ChargeAccount obj)
      {
          try
            {
                SQLiteCommand command = new SQLiteCommand(con);
                if (command != null)
                {
                    command.CommandText = @"INSERT INTO Exemplar (
                                      customerId,
                                      changedAt,
                                      currentValue
                                  )   
                                  VALUES (
                                      NULL,  
                                      '" + obj.Customer.CustomerID + @"',
                                      '" + DateTime.Now + @"',
                                      '0',
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

      public override ulong AddEntryReturnId(ChargeAccount obj)
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

      public override bool UpdateEntry(ChargeAccount obj)
      {
        SQLiteCommand command = new SQLiteCommand(con);
        command.CommandText = @"UPDATE Exemplar SET
                                    customerId = '" + obj.Customer.CustomerID + @"',
                                    changedAt = '" + DateTime.Now + @"',
                                    currentValue = '0',
                                  WHERE ID = '" + obj.id + @"');";
        command.ExecuteNonQuery();
        return true;
      }

      public override List<ChargeAccount> GetAllEntrys()
      {
        throw new NotImplementedException();
      }

      protected override ChargeAccount InitEntryByReader(SQLiteDataReader reader)
      {
        ChargeAccount account;
        return account;
      }
    }
}