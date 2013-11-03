using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  public class Library
  {
  	//Member-Variablen Deklaration
    private double fee;           //Gebuehren
    private string openingTime;  //Oeffnungszeiten

		//Konstruktor
		public Library(double fee, string openingTime)
		{
			this.fee = fee;
			this.openingTime = openingTime;
		}
		public Library(double fee)
		{
			this.fee = fee;
		}
		public Library(string openingTime)
		{
			this.openingTime = openingTime;
		}

		//Property Deklaration
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
