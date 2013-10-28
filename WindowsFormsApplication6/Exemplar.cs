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
    private string state; 				// anderer Status als bei Kunde ( ausgeliehen / verf�gbar) 
    [XmlAttribute("Signatur")]
    private string signatur; 			// mehere Exemplare / alphanumerisch 
    [XmlAttribute("Access")]
    private string access; 
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
    public string State
    {
            get { return this.state; }
            set { this.state = value; }
    }
    public string Signatur
    {
            get { return this.signatur; }
            set { this.signatur = value; }
    }
    public string Access
    {
            get { return this.access; }
            set { this.access = value; }
    }
    public string Borrower
    {
            get { return this.borrower; }
            set { this.borrower = value; }
    }
    
    
  }
}
