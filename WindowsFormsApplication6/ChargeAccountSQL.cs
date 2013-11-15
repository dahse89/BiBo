using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SqlTypes;

namespace BiBo.SQL
{
  public class ChargeAccountSQL : SqlConnector<ChargeAccountSQL>
    {
      public override bool AddEntry(ChargeAccountSQL obj)
      {
        throw new NotImplementedException();
      }

      public override ulong AddEntryReturnId(ChargeAccountSQL obj)
      {
        throw new NotImplementedException();
      }

      public override bool DeleteEntry(ChargeAccountSQL obj)
      {
        throw new NotImplementedException();
      }

      public override bool DeleteEntryByIdList(List<ulong> l)
      {
        throw new NotImplementedException();
      }

      public override ChargeAccountSQL GetEntryById(ulong id)
      {
        throw new NotImplementedException();
      }

      public override List<ChargeAccountSQL> GetAllEntrys()
      {
        throw new NotImplementedException();
      }

      protected override ChargeAccountSQL InitEntryByReader(SQLiteDataReader reader)
      {
        throw new NotImplementedException();
      }
    }
}
