using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.SQL;

namespace BiBo.DAO
{
  public class ExemplarDAO
  {
    GUIApi gui;
    Library lib;

    public ExemplarSQL exemplarSql = SqlConnector<Exemplar>.GetExemplarSqlInstance();

    public ExemplarDAO(GUIApi gui, Library lib)
    {
      this.lib = lib;
      this.gui = gui;
    }

    public List<Exemplar> GetAllExemplars()
    {
      if (lib.ExemplarList == null)
      {
        return lib.ExemplarList = exemplarSql.GetAllEntrys();
      }
      else
        return lib.ExemplarList;
    }
  }
}
