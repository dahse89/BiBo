using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BiBo
{
  public class Book
  {
  	//Member-Variablen Deklaration
    [XmlAttribute("Author")]
    private string author;       			//Autor des Buch
    [XmlAttribute("Titel")]
    private string titel;        			//Titel
    [XmlAttribute("SubjectArea")]
    private string subjectArea;  			//Fachrichtung
    [XmlAttribute("Exemplare")]
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
		public string Exemplare
    {
        get { return this.exemplare; }
        set { this.exemplare= value; }
    }
  }
}
