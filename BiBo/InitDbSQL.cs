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
                                        cardId INTEGER NOT NULL,
                                        cardValidUntil VARCHAR(255),
                                        firstName VARCHAR(100) NOT NULL,
                                        lastName VARCHAR(100) NOT NULL,
                                        birthDate DATETIME,
                                        email VARCHAR(100),
                                        mobileNumber VARCHAR(100),
                                        createdAt DATETIME,
                                        lastUpdate DATETIME,
                                        street VARCHAR(100),
                                        streetNumber VARCHAR(10),
                                        additionalRoad VARCHAR(100), 
                                        zipCode INTEGER(5), 
                                        town VARCHAR(100), 
                                        country VARCHAR(100),
                                        rights VARCHAR(100),
                                        password VARCHAR(100), 
                                        chargeAccount INTEGER(100)
                                    );";

      SQLiteCommand command = new SQLiteCommand(customerSQL, con);
      command.ExecuteNonQuery();

      string chargeAccountSQL = @"CREATE TABLE IF NOT EXISTS
                                    ChargeAccount (
                                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                        customerId INTEGER NOT NULL
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

      string chargeTransactionSQL = @"CREATE TABLE IF NOT EXISTS ChargeTransactions (
                                        ChargeAccountID INTEGER NOT NULL PRIMARY KEY,
                                        change DECIMAL,
                                        newValue DECIMAL,
                                        changedAt DATETIME
                                    );";

      SQLiteCommand command5 = new SQLiteCommand(chargeTransactionSQL, con);
      command5.ExecuteNonQuery();
      
      con.Close();

      if (con.State.ToString() == "Closed")
      {
        return true;
      }
      return false;
    }

    public bool createDummyData()
    {
      Random r = new Random();
      BiBo.DAO.CustomerDAO dao = new BiBo.DAO.CustomerDAO();

      String[] fnames = {"Klaus","Peter","Anton","Susan","Ingo","Carlos","Olga","Emiel","Philipp"};
      String[] names = {"Dahse","Münzberg","Korepin","Dambeck","Quittenbaum","Müller","Mayer","Schulze"};

      for (int i = 0; i < 100; i++)
      {
        BiBo.Persons.Customer customer = new BiBo.Persons.Customer();
        if (i == 0)
        {
          customer.Right = Rights.ADMINISTRATOR;
        }
        else if (i == 1)
        {
          customer.Right = Rights.EMPLOYEE;
        }
        else
        {
          customer.Right = Rights.CUSTOMER;
        }
        customer.FirstName = fnames[r.Next(0, fnames.Length - 1)];
        customer.LastName = names[r.Next(0, names.Length - 1)];
        customer.BirthDate = new DateTime(r.Next(1900, 2000), r.Next(1, 12), r.Next(1, 28));
        customer.Country = "Deutschland";
        customer.Town = names[r.Next(0, names.Length - 1)] + "stadt";
        customer.Card = new Card(i, "Bis zur unendlichkeit und noch viel,viel weiter!");

        dao.SetPassword(customer, "1234");

        SQL.CustomerSQL customerSQL = new SQL.CustomerSQL();
        customerSQL.AddEntry(customer);
      }
      return true;
    }
  }
}
