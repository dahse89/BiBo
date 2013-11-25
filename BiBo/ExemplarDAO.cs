using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.SQL;

namespace BiBo.DAO
{
  public class ExemplarDAO
  {
    MainWindow GUI;
    public ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();

    public ExemplarDAO(MainWindow GUI)
    {
      this.GUI = GUI;
    }
  }
}
