/*
 * Erstellt mit SharpDevelop.
 * Benutzer: m588
 * Datum: 30.10.2013
 * Zeit: 16:01
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

using BiBo;

namespace BiBo.SQL
{
	/// <summary>
	/// Description of SqlConnector.
	/// </summary>
	public abstract class SqlConnector<T>
	{
		protected static SQLiteConnection con;
		private readonly string DATABASE_NAME= "Database.dat" ;
		
		protected SqlConnector()
		{
		  if(con == null){
        
		  	con = new SQLiteConnection("Data Source=" + DATABASE_NAME);
          	con.Open();
            if (new FileInfo("Database.dat").Length == 0)
            {
              BiBo.SQL.InitDbSQL x = new InitDbSQL();
              x.createAllTables();
              x.createDummyData();
            }
		  }
		}
		
		~SqlConnector()
        {
         con.Close();
        }
		
		public static BookSQL GetBookSqlInstance()
		{
			return new BookSQL();
		}
		
		public static CustomerSQL GetCustomerSqlInstance()
		{
			return new CustomerSQL();
		}

    public static ChargeSQL GetChargeSqlInstance()
    {
      return new ChargeSQL();
    }

		public static ExemplarSQL GetExemplarSqlInstance()
		{
			return new ExemplarSQL();
		}

    public static ChargeAccountSQL GetChargeAccountSqlInstance()
    {
      return new ChargeAccountSQL();
    }

    public static CardSQL GetCardSqlInstance()
    {
      return new CardSQL();
    }
		
		public abstract bool AddEntry(T obj);

    public abstract ulong AddEntryReturnId(T obj);

    public abstract bool DeleteEntryByIdList(List<ulong> l);

    public abstract bool UpdateEntry(T obj);

		public abstract List<T> GetAllEntrys();

    protected abstract T InitEntryByReader(SQLiteDataReader reader);
	}
}
