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

namespace BiBo.DAO
{
	/// <summary>
	/// Description of BookSql.
	/// </summary>
		
	public class BookDAO : SqlConnector<Book>
	{
		public BookDAO()
		{
		}
		
		public override bool CreateTable()
		{
		  string bookSQL = "CREATE TABLE IF NOT EXISTS Book (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, author VARCHAR(100) NOT NULL, titel VARCHAR(100) NOT NULL, subjectArea VARCHAR(100) NOT NULL);";
          SQLiteCommand command = new SQLiteCommand(bookSQL, con);
          command.ExecuteNonQuery();
          return true;
		}
		
		public override bool AddEntry(Book book)
        {
          if (book.Author != "")
          {
              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = "INSERT INTO Book (id, author, titel, subjectArea) VALUES (NULL,'" + book.Author + "','" + book.Titel +  "','" + book.SubjectArea + "');";
              command.ExecuteNonQuery();
          }
          return true;
        }
		
		public override bool DeleteEntry(Book book)
        {
          if (book.Author != "")
          {
              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = "DELETE FROM Book WHERE author='" + book.Author + "';";
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
                  int id = reader.GetInt32(reader.GetOrdinal("id"));
                  string author = reader.GetString(reader.GetOrdinal("author"));
                  string titel = reader.GetString(reader.GetOrdinal("titel"));
                  string subjectArea = reader.GetString(reader.GetOrdinal("subjectArea"));
                  bookList.Add(new Book(author, titel, subjectArea));
              }
          }

          return bookList;
        }
	}
}
