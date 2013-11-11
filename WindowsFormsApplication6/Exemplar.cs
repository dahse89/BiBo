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
    private DateTime    loanPeriod;     //Ausleifrist 
    private BookStates  state;		    //Status des Buches (only_visible, damaged, missing)
    private string      signatur; 	    //signatur des buches
    private Access      accesser; 	    //Zugang zum Exemplar (magazin, freihandausleihe)
    private Customer    borrower;	    //Ausleiher
    private ulong       exemplarId;     //Exemplar-Nummer
    private ulong       bookId;         //dazugehörige Buch-ID
    
    //Konstruktor
    public Exemplar(Book buch)
    {
    	this.signatur = buch.CreateSignatur();
    	this.bookId = buch.BookId;
    	
    	//only for test
    	this.Accesser = Access.FREEHAND_LENDING;
    	this.loanPeriod = new DateTime(2013,12,15);
    	this.state = BookStates.OK;
    	
    }

    public Exemplar()
    { 
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
    public ulong ExemplarId
    {
            get { return this.exemplarId; }
            set { this.exemplarId = value; }
    }

    public ulong BookId
    {
        get { return this.bookId; }
        set { this.bookId = value; }
    }

    //Methoden

    public override bool Equals(object obj)
    {
        return exemplarId.Equals(obj);
    }
    
	public override int GetHashCode()
	{
		return exemplarId.GetHashCode();
	}
    
    
  }
}
