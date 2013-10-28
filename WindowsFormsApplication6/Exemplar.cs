using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  public class Exemplar
  {
  	//Member-Variablen Deklaration
  	[XmlAttribute("LoanPeriod")]
    private DateTime loanPeriod; 	//Ausleifrist 
    [XmlAttribute("State")]
    private BookStates state;			//Status des Buches (only_visible, damaged, missing)
    [XmlAttribute("Signatur")]
    private string signatur; 			//signatur des buches
    [XmlAttribute("Access")]
    private Access accesser; 			//Zugang zum Exemplar (magazin, freihandausleihe)
    [XmlAttribute("Borrower")]
    private Customer borrower;		//Ausleiher
    
    //Konstruktor
    public Exemplar(string signatur)
    {
    	this.signatur = signatur
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
    public string Borrower
    {
            get { return this.borrower; }
            set { this.borrower = value; }
    }
    
    
  }
}
