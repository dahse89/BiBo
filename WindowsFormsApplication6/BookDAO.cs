using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;

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
    public BookSQL bookSql = SqlConnector<Book>.GetBookSqlInstance();

    public BookDAO(Form1 form)
    {
      this.form = form;
    }

  }
}
