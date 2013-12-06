using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

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
                                        deletedAt DATEIME,
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
                                        TransactionID Integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                        ChargeAccountID INTEGER NOT NULL,
                                        change DECIMAL,
                                        newValue DECIMAL,
                                        changedAt DATETIME
                                    );";

      SQLiteCommand command5 = new SQLiteCommand(chargeTransactionSQL, con);
      command5.ExecuteNonQuery();

      string cardSQL = @"CREATE TABLE IF NOT EXISTS Card (
                                        ID Integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                                        cardValidUntil DATETIME NOT NULL
                                    );";

      SQLiteCommand command6 = new SQLiteCommand(cardSQL, con);
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
        DateTime valid = new DateTime();
        valid = DateTime.Now.AddYears(1);
        //customer.Card = new Card(valid);

        dao.SetPassword(customer, "1234");

        SQL.CustomerSQL customerSQL = new SQL.CustomerSQL();
        customerSQL.AddEntry(customer);
      }
      return true;
    }

    public void createRandomBooks()
    {
      ExemplarSQL exemplarSql = new ExemplarSQL();
      BookSQL bookSql = new BookSQL();

      String Source = "http://www.lovelybooks.de/buecher/romane/Schr%C3%A4ge-Buchtitel-582954334/";
      WebClient client = new WebClient();
      client.Encoding = Encoding.UTF8;
      string downloadString = client.DownloadString(Source);



      Regex regex = new Regex(@">([^<]+)</span></a></h3");
      var listTitle = (from Match m in regex.Matches(downloadString) select m).ToList();


      regex = new Regex(@"von\s<a[^>]+>([^<]+)<");
      var listAuthor = (from Match m in regex.Matches(downloadString) select m).ToList();

      Random r = new Random();
      int k;
      Book book;

      for (int i = 0; i < listTitle.Count; i++)
      {
        k = r.Next(1, 5);
        book = new Book(0, listAuthor[i].Groups[1].Value, listTitle[i].Groups[1].Value, "Roman");
        for (int j = 0; j < k; j++)
        {
          Exemplar ex = new Exemplar(book);
          ulong id = exemplarSql.AddEntryReturnId(ex);
          ex.ExemplarId = id;
          book.Exemplare.Add(ex);
        }

        book.BookId = bookSql.AddEntryReturnId(book);
      }

      MessageBox.Show("Book add done");

    }
  }
}
