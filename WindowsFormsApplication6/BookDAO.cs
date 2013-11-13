using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;
using BiBo.Persons;

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
      return bookSql.GetAllEntrys();
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
        foreach (Book book in lib.BookList)
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

  }
}
