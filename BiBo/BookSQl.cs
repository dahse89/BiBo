/*
 * Erstellt mit SharpDevelop.
 * Benutzer: m588
 * Datum: 30.10.2013
 * Zeit: 16:55
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml.Linq;

namespace BiBo.SQL
{
	/// <summary>
	/// Description of BookSql.
    /// </summary>

    // Yevgen: Mein Studio wird sämtliche Warnungen hier: 
    // To fix a violation of this rule, call Dispose on the object before all references to it are out of scope.
    // Im großen und ganzen musst du eine Fehleranalyse machen, das z.B. kein Objekt vorhanden ist apfangen

	public class BookSQL : SqlConnector<Book>
	{		
		public override bool AddEntry(Book book)
        {
            try
            {
// Schau dir hier nochmal die Seite hier an: http://msdn.microsoft.com/de-de/library/ms182310.aspx
// SQL-Abfragen auf Sicherheitsrisiken überprüfen
// .... Eine aus Benutzereingaben erstellte SQL-Befehlszeichenfolge ist anfällig für SQL-Injection-Angriffe. 
// Bei einem SQL-Injection-Angriff stellt ein böswilliger Benutzer Eingaben bereit, die das Design der Abfrage 
// so ändern, dass die zugrunde liegende Datenbank beschädigt wird oder der Benutzer unbefugten Zugriff auf die 
// zugrunde liegende Datenbank erhält. 

// Versuch es mal mit der sicheren Methode!
                SQLiteCommand command = new SQLiteCommand(con);
                command.CommandText = @"INSERT INTO Book (
                                      id, 
                                      author, 
                                      titel, 
                                      subjectArea
                                  )   
                                  VALUES (
                                      NULL,  
                                      '" + book.Author 		+ @"',
                                      '" + book.Titel 		+ @"',
                                      '" + book.SubjectArea + @"'
                                  );";

                command.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            } 
        }
       

        public override ulong AddEntryReturnId(Book book)
        {
            AddEntry(book);
            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "SELECT last_insert_rowid()";
            Int64 lastRowID64 = Convert.ToInt64(command.ExecuteScalar());
            return (ulong)lastRowID64;
        }

		public bool DeleteEntry(Book book)
        {
          if (book.Author != "")
          {
              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = "DELETE FROM Book WHERE author='" + book.Author + "';";
              return (command.ExecuteNonQuery() == 1);
          }
          return false;
        }

    public override bool UpdateEntry(Book obj)
    {
      throw new NotImplementedException();
    }
        public override bool DeleteEntryByIdList(List<ulong> l)  //Return wert ist schwachsinnig ... man müsste prüfen ob der Execute funktionierthat und nicht einfach true zurück geben ... dies ist an mehreren Stellen der Fall ..marcus
        {
            foreach (ulong x in l)
            {
                SQLiteCommand command = new SQLiteCommand(con);
                command.CommandText = "DELETE FROM Book WHERE id ='" + x + "';";
                command.ExecuteNonQuery();

            }
            return true;
        }		
		public override List<Book> GetAllEntrys()
        {
          List<Book> bookList = new List<Book>();

          SQLiteCommand command = new SQLiteCommand(con);
          command.CommandText = "SELECT * FROM Book";
          SQLiteDataReader reader = command.ExecuteReader();

          if (reader.HasRows)
          {
              while (reader.Read())
              {
                  bookList.Add(InitEntryByReader(reader));
              }
          }

          return bookList;
        }

        protected override Book InitEntryByReader(SQLiteDataReader reader)
        {
            ulong id = System.Convert.ToUInt64(reader.GetInt32(reader.GetOrdinal("id")));
            string author = reader.GetString(reader.GetOrdinal("author"));
            string titel = reader.GetString(reader.GetOrdinal("titel"));
            string subjectArea = reader.GetString(reader.GetOrdinal("subjectArea"));
            return new Book(id, author, titel, subjectArea);
        }

        //new implemented methods TODO : IMPLEMENT THIS SHIT

        //Get all Exemplars from an Book and save it in the object --> denke nicht notwendig, da wir Änderungen auf der ObjektEbene vollziehen und diese in die DB liefern
        public List<Exemplar> GetExemplarListOfBook(Book book)
        {
            ExemplarSQL exDAO = SqlConnector<Exemplar>.GetExemplarSqlInstance();
        	  List<Exemplar> exemplars = new List<Exemplar>();
        	  SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "SELECT * FROM Exemplar WHERE bookId = " + book.BookId;
            SQLiteDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows)
          	{
            	while (reader.Read())
                {
                  Exemplar ex = exDAO.GetInitEntryByReader(reader);
		          exemplars.Add(ex);
            	}
            }
            return exemplars;
            
        }
      
        public void DeleteAllExemplars(Book book)
        {
            ExemplarSQL exDAO = SqlConnector<Exemplar>.GetExemplarSqlInstance();
            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "DELETE FROM Exemplar WHERE id = '" + book.BookId + "';";
            command.ExecuteNonQuery();
            book.Exemplare.Clear();
            
        }

       

    }
}
