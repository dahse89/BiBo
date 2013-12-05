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
    private int cardID;                             //Ausweis
    private string cardValidUntil;                  //Gültigkeitdatum des Ausweises 

    public Card()
    {
    }

    public Card(int cardID, string cardValidUntil)
    {
      this.cardID = cardID;
      this.cardValidUntil = cardValidUntil;
    }

    public int CardID
    {
      get { return this.cardID; }
      set { this.cardID = value; }
    }

    public string CardValidUntil
    {
      get { return this.cardValidUntil; }
      set { this.cardValidUntil = value; }
    }
  }
}
