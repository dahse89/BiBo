using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using BiBo.Persons;

namespace BiBo
{
  public class SQLCon
  {
      private SQLiteConnection con;
      // Initialisiert die "Datenbank"
      // Sorgt dafür, dass bei jedem Aufruf auf jeden Fall eine Database.xml Datei vorhanden ist
      public SQLCon()
      {
          this.con = new SQLiteConnection("Data Source=Database.dat");
          con.Open();
      }
      ~SQLCon()
      {
         con.Close();
      }

      public bool createDatabase()
      {
          string customerSQL = "CREATE TABLE IF NOT EXISTS Customer (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, firstName VARCHAR(100) NOT NULL, lastName VARCHAR(100) NOT NULL, birthDate DATETIME NOT NULL, street VARCHAR(100), streetNumber VARCHAR(10), additionalRoad VARCHAR(100), zipCode INTEGER(5), town VARCHAR(100), country VARCHAR(100), chargeAccount INTEGER(100));";
          SQLiteCommand command = new SQLiteCommand(customerSQL, this.con);
          command.ExecuteNonQuery();
          return true;
      }
  }
}
