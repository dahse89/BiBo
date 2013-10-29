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
          SQLiteCommand creater = new SQLiteCommand(this.con);
          creater.CommandText = String.Format("CREATE TABLE IF NOT EXISTS Customer ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL);");
          creater.ExecuteNonQuery();
          return true;
      }
  }
}
