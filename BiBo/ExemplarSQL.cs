﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using BiBo.Persons;

using BiBo.SQL;
using System.Data;

namespace BiBo.SQL
{
    public class ExemplarSQL : SqlConnector<Exemplar>
    {
        //Member-Variablen Deklaration
        private DateTime loanPeriod;     //Ausleifrist 
        private BookStates state;		    //Status des Buches (only_visible, damaged, missing)
        private string signatur; 	    //signatur des buches
        private Access accesser; 	    //Zugang zum Exemplar (magazin, freihandausleihe)
        private Customer borrower;	    //Ausleiher
        private ulong exemplarId;     //Exemplar-Nummer
        private ulong bookId;         //dazugehörige Buch-ID

        public override bool AddEntry(Exemplar exemplar)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(con);
                if (command != null)
                {
                    command.CommandText = @"INSERT INTO Exemplar (
                                      id,
                                      bookId,
                                      loanPeriod,
                                      state,
                                      signatur,
                                      access
                                  )   
                                  VALUES (
                                      NULL,  
                                      '" + exemplar.BookId.ToString() + @"',
                                      '" + exemplar.LoanPeriod.ToShortDateString() + @"',
                                      '" + exemplar.State.ToString() + @"',
                                      '" + exemplar.Signatur + @"',
                                      '" + exemplar.Accesser.ToString() + @"'
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

        public override ulong AddEntryReturnId(Exemplar exemplar)
        {
            AddEntry(exemplar);

            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            

            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "select last_insert_rowid()";
            UInt64 lastRowID64 = Convert.ToUInt64(command.ExecuteScalar());
            // UInt64 lastRowID64 = (UInt64)command.ExecuteScalar(); // Fehler	System.InvalidCastException: Die angegebene Umwandlung ist ungültig.	
            return (ulong)lastRowID64;
        }

      //TODO: add countBorrow to db
        public override bool UpdateEntry(Exemplar obj)
        {
          SQLiteCommand command = new SQLiteCommand(con);
          command.CommandText = ("UPDATE Exemplar SET bookId = '" + obj.BookId.ToString() + "', loanPeriod = '" + obj.LoanPeriod.ToShortDateString() + "', state = '" + obj.State.ToString() + "', signatur = '" + obj.Signatur + "', access = '" + obj.Accesser.ToString() + "', customerId = '" + obj.Borrower.CustomerID + "' WHERE ID = '" + obj.ExemplarId + "'");
          command.ExecuteNonQuery();

          return true;
        }

        public override bool DeleteEntryByIdList(List<ulong> l)
        {
            foreach (ulong x in l)
            {
                SQLiteCommand command = new SQLiteCommand(con);
                command.CommandText = "DELETE FROM Exemplar WHERE id = '" + x + "';";
                command.ExecuteNonQuery();

            }
            return true;
        }

        public override List<Exemplar> GetAllEntrys()
        {
            List<Exemplar> exemplarList = new List<Exemplar>();

            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "SELECT * FROM Exemplar";
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    exemplarList.Add(InitEntryByReader(reader));
                }
            }

            return exemplarList;
        }

        public List<Exemplar> GetAllEntrysByBook(Book book)
        {
          List<Exemplar> exemplarList = new List<Exemplar>();
          SQLiteCommand command = new SQLiteCommand(con);
          command.CommandText = "SELECT * FROM Exemplar WHERE bookId = '" + book.BookId + "'";

          SQLiteDataReader reader = command.ExecuteReader();
          if (reader.HasRows)
          {
            while (reader.Read())
            {
              exemplarList.Add(InitEntryByReader(reader));
            }
          }
          return exemplarList;
        }

        public List<Exemplar> GetAllEntrysByCustomer(Customer customer)
        {
          List<Exemplar> exemplarList = new List<Exemplar>();
          SQLiteCommand command = new SQLiteCommand(con);
          command.CommandText = "SELECT * FROM Exemplar WHERE customerId = '" + customer.CustomerID + "'";
          
          SQLiteDataReader reader = command.ExecuteReader();
          if (reader.HasRows)
          {
            while (reader.Read())
            {
              exemplarList.Add(InitEntryByReader(reader));
            }
          }
          return exemplarList;
        }
        protected override Exemplar InitEntryByReader(System.Data.SQLite.SQLiteDataReader reader)
        {
            Exemplar exemplar = new Exemplar();
            
            ulong id = System.Convert.ToUInt64(reader.GetInt32(reader.GetOrdinal("id")));

            string loanPeriodAsString = reader.GetString(reader.GetOrdinal("loanPeriod"));
            DateTime loanPeriod = new DateTime();
            if(loanPeriodAsString != null || loanPeriodAsString != "")
                loanPeriod = DateTime.Parse(loanPeriodAsString);

            string stateString = reader.GetString(reader.GetOrdinal("state"));
            BookStates state = (BookStates) Enum.Parse(typeof(BookStates), stateString, true);
            string accessString = reader.GetString(reader.GetOrdinal("access"));
            Access access = (Access)Enum.Parse(typeof(Access), accessString, true);
            string signatur = reader.GetString(reader.GetOrdinal("signatur"));
            //ulong customerId = System.Convert.ToUInt64(reader.GetInt32(reader.GetOrdinal("customerID"))); <--- TODO: nicht sinnvoll, da nicht zwinend vorhanden
            ulong bookId = System.Convert.ToUInt64(reader.GetInt32(reader.GetOrdinal("bookID")));
            
            exemplar.ExemplarId = id;
            exemplar.LoanPeriod = loanPeriod;
            exemplar.State = state;
            exemplar.Accesser = access; 
            exemplar.Signatur = signatur;
            exemplar.BookId = bookId;

            return exemplar;
        }

        //to make it possile to call the method outside
        public Exemplar GetInitEntryByReader(SQLiteDataReader reader)
        {
            return InitEntryByReader(reader);
        }
    }   
}