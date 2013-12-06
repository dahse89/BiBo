using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.Persons;

namespace BiBo
{
  public class Card
  {
    private Customer customer;                      //dazugehöriger Benutzer
    private ulong cardID;                             //Ausweis
    private DateTime cardValidUntil;                  //Gültigkeitdatum des Ausweises 

    public Card()
    {
    }

    public Card(ulong cardID, DateTime cardValidUntil)
    {
      this.cardID = cardID;
      this.cardValidUntil = cardValidUntil;
    }

    public Card(DateTime cardValidUntil)
    {
      this.cardValidUntil = cardValidUntil;
    }

    public ulong CardID
    {
      get { return this.cardID; }
      set { this.cardID = value; }
    }

    public DateTime CardValidUntil
    {
      get { return this.cardValidUntil; }
      set { this.cardValidUntil = value; }
    }
  }
}
