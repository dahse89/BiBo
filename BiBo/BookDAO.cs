using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;
using BiBo.Persons;
using BiBo.Exception;

namespace BiBo.DAO
{
  /// <summary>
  /// BookDAO handle the access to the Type Book.
  /// To save and restore objects in the DB and in the object-layer, you have to use this class.
  /// It also refresh the GUI-View
  /// </summary>
  public class BookDAO
  {
    GUIApi gui;
    private Library lib;
    public BookSQL bookSql = SqlConnector<Book>.GetBookSqlInstance();
    private ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();


    public BookDAO(GUIApi gui, Library lib)
    {
      this.gui = gui;
      this.lib = lib;
    }

    public BookDAO() { }

    public List<Book> getAllBooks()
    {
      if (lib.BookList == null)
      {
        List<Book> bookList = bookSql.GetAllEntrys();
        foreach (Book book in bookList)
        {
          book.Exemplare = exemplarSql.GetAllEntrysByBook(book);
        }
        lib.BookList = bookList;
        return bookList;
      }
      else
        return lib.BookList;
    }

    public List<Book> getAllBooksForNonLib()
    {
      List<Book> bookList = bookSql.GetAllEntrys();
      int i = 0;
      foreach (Book book in bookList)
      {
        book.Exemplare = exemplarSql.GetAllEntrysByBook(book);
        i++;
        if (i == 30) return bookList;
      }
      return bookList;
    }

    //Add only a book without Examples <--- eigentlich nicht sinnvoll oder ?
    public void AddBook(Book dummy)
    {
      //insert in db and dummy get the right id
      dummy.BookId = bookSql.AddEntryReturnId(dummy);

      //in objects
      lib.BookList.Add(dummy);

      //refresh GUI-View
      gui.AddBook(dummy);
    }

    //Add a book with a given number of examples
    public void AddBook(Book book, int countOfExamples)
    {
      
      for (int i = 0; i < countOfExamples; i++)
      {
        Exemplar ex = new Exemplar(book);
        ulong id = exemplarSql.AddEntryReturnId(ex);
        ex.ExemplarId = id;
        book.Exemplare.Add(ex);
      }
      //insert in db and dummy get the right id
      book.BookId = bookSql.AddEntryReturnId(book);

      //in objects
      lib.BookList.Add(book);

      //refresh GUI-View
      gui.AddBook(book);
    }

    public void DeleteBooksByIdList()
    {
        /*removes all selected rows and return list of deleted customer ids
        List<ulong> idList = form.DeleteBooksByIdList();

        //delete in Object <----- must be go better !!! SCHAU DA NOCHMAL NACH MARCUS !!!!!

        List<Book> copyOfBookList = lib.BookList.ToList();//<----- ist nötig, sonst InvalidOperationException, weil die Liste, die durchlaufen wird, geändert wird
        foreach (Book book in copyOfBookList) 
        {
          foreach (ulong id in idList)
          {
            if (id == book.BookId)
              lib.BookList.Remove(book);
          }
        }

        //delete in DB
        bookSql.DeleteEntryByIdList(idList);*/
    }

    public Book GetBookById(ulong id)
    {
      foreach (Book book in lib.BookList)
      {
        if (book.BookId == id)
          return book;
      }
      throw new BookNotFoundException("Buch mit gegebener ID nicht vorhanden");

    }

    //expand loanPeriod of an exemplar 
    public void ExtendLend(Exemplar exemplar, DateTime borrowTill)
    {
      if (exemplar.CountBorrow < 4)
      {
        //on object-layer
        exemplar.LoanPeriod = borrowTill;

        //on db-layer
        exemplarSql.UpdateEntry(exemplar);

        //increment countBorrow
        exemplar.CountBorrow++;
      }
    }

    //new implemented methods TODO : IMPLEMENT THIS SHIT

    //realy usefull ?
    public int GetNumberOfExemplars(Book book)
    {
      return book.Exemplare.Count;
    }

    //return the number of available exemplars of a book
    //List of Exemplars in an object of Book must be filled --> method FillExemplarListOfBook must run before
    //TODO: noch falsche Logik
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
      DateTime earliest = new DateTime(9999, 12, 30);

      foreach (Exemplar exemplar in book.Exemplare)
      {
        if (exemplar.LoanPeriod.CompareTo(earliest) < 0)
          earliest = exemplar.LoanPeriod;
      }
      return earliest;
    }

    public void AddExemplar(Exemplar x, Book book)
    {
      ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();

      //first add the exemplar into the db
      exemplarSql.AddEntry(x);

      //and then add the exemplar into the list in the specific book
      book.Exemplare.Add(x);

    }

    //TODO : Muss noch angepasst werden !!!!!!!!!!!!!!!!!!!!!
    public void RemoveExemplar(ulong exemplarId, Book book)
    {
      ExemplarSQL exDAO = SqlConnector<Exemplar>.GetExemplarSqlInstance();


      //first remove the exemplar(specified by the exemplarId)
      Exemplar ex = new Exemplar();
      ex.ExemplarId = exemplarId;
      book.Exemplare.Remove(ex);

      List<ulong> idList = new List<ulong>();
      idList.Add(ex.ExemplarId);

      //and then delete from the db, specified by the exemplarId
      exDAO.DeleteEntryByIdList(idList);
    }

    public bool BorrowExemplar(DateTime dateBookWillBeBack, String signatur)
    {
      return true;
    }

    //mehod that a customer can bring back a book
    public void BringBookBack(Customer customer ,Exemplar exemplar, BookStates newState)
    {
      //bring exemplar to the default state with new BookState
      exemplar.CountBorrow = 0;
      exemplar.Borrower = null;
      exemplar.LoanPeriod = DateTime.MinValue; // da DateTime nicht auf null gesetzt werden kann, wird hier das ausleihdatum einfach auf den niedrigsten Wert gesetzt
      exemplar.State = newState;
      customer.ExemplarList.Remove(exemplar);

      //update in db
      //<---  muss Vico noch funktion liefern
    }

    //TODO <-- Implement
    public ulong GetLastExemplarId()
    {
      return 0;
    }

    public Exemplar GetFirstAvailableExemplar(Book book)
    {
      foreach (Exemplar exemplar in book.Exemplare)
      {
        if (exemplar.Accesser == Access.FREEHAND_LENDING && exemplar.State != BookStates.MISSING && exemplar.State != BookStates.ONLY_VISIBLE)
          return exemplar;
      }
      return null;
    }
  }
}
