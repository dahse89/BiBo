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
    Form1 form;
    private Library lib;
    public BookSQL bookSql = SqlConnector<Book>.GetBookSqlInstance();


    public BookDAO(Form1 form, Library lib)
    {
      this.form = form;
      this.lib = lib;
    }

    public List<Book> getAllBooks(){
      if (lib.BookList == null)
        return lib.BookList = bookSql.GetAllEntrys();

      else
        return lib.BookList;
    }

    public void AddBook(Book dummy)
    {
      //insert in db and dummy get the right id
      dummy.BookId = bookSql.AddEntryReturnId(dummy);

      //in objects
      lib.BookList.Add(dummy);

      //refresh GUI-View
      form.AddBook(dummy);
    }

    public void DeleteBooksByIdList()
    {
        //removes all selected rows and return list of deleted customer ids
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
        bookSql.DeleteEntryByIdList(idList);
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

    public bool AddExemplar(Exemplar newExemplar)
    {
      return true;
    }

    public bool DeleteExemplar(Exemplar oldExemplar)
    {
      return false;
    }

    public ulong GetLastExemplarId()
    {
      return 0;
    }

  }
}
