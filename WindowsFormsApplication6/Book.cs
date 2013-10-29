using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  public class Book
  {
  	//Member-Variablen Deklaration
    private string author;       			//Autor des Buch
    private string titel;        			//Titel
    private string subjectArea;  			//Fachrichtung
    private List<Exemplar> exemplare;	//Liste aller Exemplare

    public string Author
    {
        get { return this.author; }
        set { this.author = value; }
    }
    public string Titel
    {
        get { return this.titel; }
        set { this.titel = value; }
    }
    public string SubjectArea
    {
        get { return this.subjectArea; }
        set { this.subjectArea = value; }
    }
		public List<Exemplar> Exemplare
    {
        get { return this.exemplare; }
        set { this.exemplare= value; }
    }
  }
}
