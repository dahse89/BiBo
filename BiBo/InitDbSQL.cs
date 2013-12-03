using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlTypes;

namespace BiBo.SQL
{
  class InitDbSQL
  {
    protected static SQLiteConnection con;

    public bool createAllTables()
    {
      if (con == null)
      {
        con = new SQLiteConnection("Data Source=Database.dat");
        con.Open();
      }

      string customerSQL = @"CREATE TABLE IF NOT EXISTS
                                    Customer (
                                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                        firstName VARCHAR(100) NOT NULL,
                                        lastName VARCHAR(100) NOT NULL,
                                        birthDate DATETIME,
                                        street VARCHAR(100),
                                        streetNumber VARCHAR(10),
                                        additionalRoad VARCHAR(100), 
                                        zipCode INTEGER(5), 
                                        town VARCHAR(100), 
                                        country VARCHAR(100),
                                        rights VARCHAR(100),
                                        password VARCHAR(100), 
                                        chargeAccount INTEGER(100),
                                    );";

      SQLiteCommand command = new SQLiteCommand(customerSQL, con);
      command.ExecuteNonQuery();

      string chargeAccountSQL = @"CREATE TABLE IF NOT EXISTS
                                    ChargeAccount (
                                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                        customerId INTEGER NOT NULL,
                                        changedAt DATETIME,
                                        currentValue DECIMAL
                                    );";

      SQLiteCommand command2 = new SQLiteCommand(chargeAccountSQL, con);
      command2.ExecuteNonQuery();

      string exemplarSQL = @"CREATE TABLE IF NOT EXISTS Exemplar (
                                       ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                       bookId INTEGER,
                                       loanPeriod DateTime, 
                                       state VARCHAR(100) NOT NULL,
                                       signatur VARCHAR(100) NOT NULL, 
                                       access VARCHAR(100) NOT NULL,
                                       customerId INTEGER
                                    );";

      SQLiteCommand command3 = new SQLiteCommand(exemplarSQL, con);
      command3.ExecuteNonQuery();

      string bookSQL = @"CREATE TABLE IF NOT EXISTS Book (
                                       ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,  
                                       author VARCHAR(100) NOT NULL, 
                                       titel VARCHAR(100) NOT NULL, 
                                       subjectArea VARCHAR(100) NOT NULL
                                    );";

      SQLiteCommand command4 = new SQLiteCommand(bookSQL, con);
      command4.ExecuteNonQuery();

      con.Close();

      if (con.State.ToString() == "Close")
      {
        return true;
      }
      return false;
    }
  }
}
