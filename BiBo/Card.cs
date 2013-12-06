using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.Persons;

namespace BiBo
{
  public class Card
  {
    private Customer customer;                        //dazugehöriger Benutzer
    private ulong cardID;                             //Ausweis
    private DateTime cardValidUntil;                  //Gültigkeitdatum des Ausweises 

    public Card()
    {
    }

    public Card(Customer customer)
    {
      this.customer = customer;
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
