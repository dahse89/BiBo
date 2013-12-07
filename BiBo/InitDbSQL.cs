using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

using BiBo.Persons;
using BiBo.DAO;

namespace BiBo.SQL
{
  class InitDbSQL
  {
    protected static SQLiteConnection con;

    Library lib;

    private ChargeAccountSQL chargeAccountSql = SqlConnector<ChargeAccount>.GetChargeAccountSqlInstance();
    private CardSQL cardSql = SqlConnector<Card>.GetCardSqlInstance();
    private BookSQL bookSql = SqlConnector<Book>.GetBookSqlInstance();
    private CustomerSQL customerSql = SqlConnector<Customer>.GetCustomerSqlInstance();
    private ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();

    private CustomerDAO customerDAO = new CustomerDAO();
    private BookDAO bookDAO = new BookDAO();

    public InitDbSQL() { }
    public InitDbSQL(Library lib)
    {
      this.lib = lib;
    }

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
                                        chargeAccountId INTEGER(100)
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
                                       state VARCHAR(100),
                                       signatur VARCHAR(100), 
                                       access VARCHAR(100),
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
      command6.ExecuteNonQuery();
      
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
      CustomerDAO dao = new CustomerDAO();
      List<Book> bookList = bookDAO.getAllBooksForNonLib();

      String[] fnames = {"Klaus","Peter","Anton","Susan","Ingo","Carlos","Olga","Emiel","Philipp"};
      String[] names = {"Dahse","Münzberg","Korepin","Dambeck","Quittenbaum","Müller","Mayer","Schulze"};

      for (int i = 0; i < 5; i++)
      {
        Customer customer = new Customer();
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
        customer.CustomerID = Convert.ToUInt64(i + 1);

        //add an empty ChargeAccount
        ChargeAccount chargeAccount = new ChargeAccount(customer);
        ulong chargeAccountId = chargeAccountSql.AddEntryReturnId(chargeAccount);
        chargeAccount.Id = chargeAccountId;
        customer.ChargeAccount = chargeAccount;

        //add the customer card
        Card card = new Card(customer);
        ulong cardId = cardSql.AddEntryReturnId(card);
        card.CardID = cardId;
        DateTime valid = new DateTime();
        valid = DateTime.Now.AddYears(1);
        card.CardValidUntil = valid;
        customer.Card = card;

        //add exemplar to customer
        for (int j = 0; j < r.Next(1, 6); j++)
        {
          DateTime date = new DateTime();
          date = DateTime.Now.AddDays(r.Next(20,30));
          Book book = bookList.ElementAt(r.Next(1,20));
          //customerDAO.BorrowExemplar(date, book, customer);
          Exemplar ex = null;
          foreach (Exemplar exemplar in book.Exemplare)
          {
            if (exemplar.Accesser == Access.FREEHAND_LENDING && exemplar.State != BookStates.MISSING && exemplar.State != BookStates.ONLY_VISIBLE)
            {
              ex = exemplar;
              break;
            }
          }
          if (ex != null)
          {
            ex.LoanPeriod = date;
            ex.Borrower = customer;
            ex.CountBorrow = ex.CountBorrow + 1;
            //customer.ExemplarList.Add(ex);
          }
          
          //on db-layer update the customer
          //customerSql.UpdateEntry(customer);

          //on db-layer update the exemplar
          exemplarSql.UpdateEntry(ex);
        }

        //add a charge to customer
        DateTime current = new DateTime();
        current = DateTime.Now.AddDays(r.Next(1,5));
        Charge charge = new Charge(current, 5, 5);
        customer.ChargeAccount.Charges.Add(charge);

        dao.SetPassword(customer, "1234");

        CustomerSQL customerSQL = new CustomerSQL();
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

      for (int i = 0; i < listTitle.Count; i++) //TODO: there are only 100 exemplars but not for every book
      {
        k = r.Next(1, 5);
        book = new Book(0, listAuthor[i].Groups[1].Value, listTitle[i].Groups[1].Value, "Roman");
        book.BookId = bookSql.AddEntryReturnId(book);
        for (int j = 0; j < k; j++)
        {
          Exemplar ex = new Exemplar(book);
          ex.ExemplarId = exemplarSql.AddEntryReturnId(ex); 
          book.Exemplare.Add(ex);
        }

        
      }

      MessageBox.Show("Book add done");

    }

  }
}
