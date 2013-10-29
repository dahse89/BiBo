using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiBo.Persons;

namespace BiBo
{
  public class Exemplar
  {
  	//Member-Variablen Deklaration
    private DateTime loanPeriod; 	//Ausleifrist 
    private BookStates state;			//Status des Buches (only_visible, damaged, missing)
    private string signatur; 			//signatur des buches
    private Access accesser; 			//Zugang zum Exemplar (magazin, freihandausleihe)
    private Customer borrower;		//Ausleiher
    private int exemplarID;          //Exemplar-Nummer
    
    //Konstruktor
    public Exemplar(string signatur)
    {
        this.signatur = signatur;
    }
    
    //Property Deklaration
    public DateTime LoanPeriod
    {
            get { return this.loanPeriod; }
            set { this.loanPeriod = value; }
    }
    public BookStates State
    {
            get { return this.state; }
            set { this.state = value; }
    }
    public string Signatur
    {
            get { return this.signatur; }
            set { this.signatur = value; }
    }
    public Access Accesser
    {
            get { return this.accesser; }
            set { this.accesser = value; }
    }
    public Customer Borrower
    {
            get { return this.borrower; }
            set { this.borrower = value; }
    }
    public int ExemplarID
    {
            get { return this.exemplarID; }
            set { this.exemplarID = value; }
    }

    //Methoden

    public override bool Equals(object obj)
    {
        return exemplarID.Equals(obj);
    }
    
    
  }
}
