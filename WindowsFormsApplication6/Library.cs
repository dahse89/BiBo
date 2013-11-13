using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.SQL;

namespace BiBo
{
  public class Library
  {
  	//Member-Variablen Deklaration
    private double fee;           //Gebuehren
    private string openingTime;  //Oeffnungszeiten

    //GUI Adapter
    private Form1 GUI;

    //DAO's
    private TestDAO testDao;
    

		//Konstruktor
		public Library(Form1 gui)
		{
      this.testDao = new TestDAO(gui);
      this.GUI = gui;
		}

    public TestDAO getTestDAO()
    {
      return this.testDao;
    }

    public Form1 getGUI()
    {
      return this.GUI;
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
