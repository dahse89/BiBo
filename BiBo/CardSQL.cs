using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Xml.Linq;

using BiBo.SQL;

namespace BiBo
{
  public class CardSQL : SqlConnector<Card>
  {
    public override bool AddEntry(Card card)
    {
      try
      {
        SQLiteCommand command = new SQLiteCommand(con);
        if (con.State.ToString().CompareTo("Closed") == 0) con.Open(); //TODO: why is the con closed when i add a customer ?
        command.CommandText = @"INSERT INTO Book (
                                      ID, 
                                      cardValidUntil
                                  )   
                                  VALUES (
                                      NULL,  
                                      '" + card.CardValidUntil + @"'
                                  );";

        command.ExecuteNonQuery();
        return true;
      }
      catch (System.Exception)
      {
        return false;
      } 
    }

    public override ulong AddEntryReturnId(Card card)
    {
      AddEntry(card);
      SQLiteCommand command = new SQLiteCommand(con);
      command.CommandText = "SELECT last_insert_rowid()";
      Int64 lastRowID64 = Convert.ToInt64(command.ExecuteScalar());
      return (ulong)lastRowID64;
    }

    public override bool DeleteEntryByIdList(List<ulong> l)
    {
      throw new NotImplementedException();
    }

    public override bool UpdateEntry(Card obj)
    {
      throw new NotImplementedException();
    }

    public override List<Card> GetAllEntrys()
    {
      List<Card> cardList = new List<Card>();

      SQLiteCommand command = new SQLiteCommand(con);
      command.CommandText = "SELECT * FROM Cards";
      SQLiteDataReader reader = command.ExecuteReader();

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          cardList.Add(InitEntryByReader(reader));
        }
      }

      return cardList;
    }

    protected override Card InitEntryByReader(System.Data.SQLite.SQLiteDataReader reader)
    {
      Card card = new Card();
      card.CardID = System.Convert.ToUInt64(reader.GetInt32(reader.GetOrdinal("id")));
      card.CardValidUntil = DateTime.Parse(reader.GetString(reader.GetOrdinal("cardValidUntil")));
      return card;
    }
  }
}
