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
		
	public class BookSQL : SqlConnector<Book>
	{
		public BookSQL()
		{
            string bookSQL = @"CREATE TABLE IF NOT EXISTS Book (
                                       ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,  
                                       author VARCHAR(100) NOT NULL, 
                                       titel VARCHAR(100) NOT NULL, 
                                       subjectArea VARCHAR(100) NOT NULL
                                    );";

            SQLiteCommand command = new SQLiteCommand(bookSQL, con);
            command.ExecuteNonQuery();
		}
		
		public override bool AddEntry(Book book)
        {
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

            return (command.ExecuteNonQuery() == 1);
        }

        public override ulong AddEntryReturnId(Book book)
        {
            AddEntry(book);
            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "SELECT last_insert_rowid()";
            Int64 lastRowID64 = Convert.ToInt64(command.ExecuteScalar());
            return (ulong)lastRowID64;
        }

		public override bool DeleteEntry(Book book)
        {
          if (book.Author != "")
          {
              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = "DELETE FROM Book WHERE author='" + book.Author + "';";
              return (command.ExecuteNonQuery() == 1);
          }
          return false;
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

        public override Book GetEntryById(ulong id)
        {
            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "SELECT * FROM Book WHERE id = '" + id + "'";
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return InitEntryByReader(reader);
            }

            else
                throw new Exception("Eintrag nicht vorhanden");
         
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

        //Get all Exemplars from an Book and save it in the object --> Wopat wollte ja, dass die Aktionen auf Objektebene ablaufen
        public void FillExemplarListOfBook(Book book)
        {
            ExemplarSQL exDAO = SqlConnector<Exemplar>.GetExemplarSqlInstance();
        	  List<Exemplar> exemplars = new List<Exemplar>();
        	  SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "SELECT * FROM Exemplar WHERE bookId = " + book.BookId;
            SQLiteDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows)
          	{
            	while (reader.Read()){
                Exemplar ex = exDAO.GetInitEntryByReader(reader);
		            book.Exemplare.Add(ex);
            	}
            }
            
        }
        
        //realy usefull ?
        public int GetNumberOfExemplars(Book book)
        {
            return book.Exemplare.Count;
        }

        //return the number of available exemplars of a book
        //List of Exemplars in an object of Book must be filled --> method FillExemplarListOfBook must run before
        public int GetNumberOfAvailableExemplars(Book book)
        {
            int numberOfAvailableExemplars = 0;
            foreach (Exemplar exemplar in book.Exemplare)
            {
                if (exemplar.LoanPeriod != null)
                    numberOfAvailableExemplars++;
            }
            return numberOfAvailableExemplars;
        }

        //return the earliest available date of an exemplar
        public DateTime GetDateOfEarliestAvailable(Book book)
        {
            DateTime earliest = new DateTime(9999,12,30);
            
            foreach (Exemplar exemplar in book.Exemplare)
            {
                if (exemplar.LoanPeriod.CompareTo(earliest) < 0)
                    earliest = exemplar.LoanPeriod;
            }
            return earliest;
        }

        public bool BorrowExemplar(DateTime dateBookWillBeBack, String signatur)
        {
            return true;
        }

        public void DeleteAllExemplars(Book book)
        {
            ExemplarSQL exDAO = SqlConnector<Exemplar>.GetExemplarSqlInstance();
            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "DELETE FROM Exemplar WHERE id = '" + book.BookId + "';";
            command.ExecuteNonQuery();
            book.Exemplare.Clear();
            
        }

        public void AddExemplar(Exemplar x, Book book)
        {
            ExemplarSQL exDAO = SqlConnector<Exemplar>.GetExemplarSqlInstance();

            //first add the exemplar into the db
            exDAO.AddEntry(x);

            //and then add the exemplar into the list in the specific book
            book.Exemplare.Add(x);

        }

        public void RemoveExemplar(ulong exemplarId, Book book) // <-- Alle exemplare haben die selbe Signatur, dadurch ist dies der Falsche Parameter ... evtl. eher die ExemplarID als Kriterium wählen
        {
            ExemplarSQL exDAO = SqlConnector<Exemplar>.GetExemplarSqlInstance();

            //first remove the exemplar(specified by the exemplarId)
            Exemplar ex = new Exemplar();
            ex.ExemplarId = exemplarId;
            book.Exemplare.Remove(ex);

            //and then delete from the db, specified by the exemplarId
            exDAO.DeleteEntry(ex);
        }

    }
}
