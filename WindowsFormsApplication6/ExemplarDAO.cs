using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.SQL;

namespace BiBo.DAO
{
  class ExemplarDAO
  {
    Form1 form;
    public ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();

    public ExemplarDAO(Form1 form)
    {
      this.form = form;
    }
  }
}
