using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  class Library
  {
    private double fee;           //Gebuehren
    private string openingTime;  //Oeffnungszeiten

    public double Fee
    {
      get { return fee; }
      set { fee = value; }
    }
    public string OpeningTime
    {
      get { return openingTime; }
      set { openingTime = value; }
    }


  }
}
