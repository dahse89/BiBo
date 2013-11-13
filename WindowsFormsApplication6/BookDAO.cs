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
      //insert in db
      //in objects
      form.AddBook(dummy);//insert with real ID
    }

    public void DeleteBooksByIdList()
    {
        //removes all selected rows and return list of deleted customer ids
        List<ulong> IdList = form.DeleteBooksByIdList();
        //delete in Object 
        //delete in DB

    }

  }
}
