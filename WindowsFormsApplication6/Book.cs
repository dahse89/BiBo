using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  public class Book
  {
  	//Member-Variablen Deklaration
    private ulong bookId;
    private string author;       			//Autor des Buch
    private string titel;        			//Titel
    private string subjectArea;  			//Fachrichtung
    private List<Exemplar> exemplare;	//Liste aller Exemplare

    public ulong BookId
    {
        get { return this.bookId; }
    }
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
		
	//Konstruktor
	public Book(ulong bookId, string author, string titel, string subjectArea)
	{
        this.bookId = bookId;
		this.author = author;
		this.titel = titel;
		this.subjectArea = subjectArea;
		exemplare = new List<Exemplar>();
	}

    //Methoden

     public bool AddExemplar(Exemplar newExemplar)
     {
         if (exemplare.Contains(newExemplar))
         		 return false;
         
         newExemplar.ExemplarId = System.Convert.ToUInt64(exemplare.Count+1);
         exemplare.Add(newExemplar);
         return true;
         
     }

     public bool DeleteExemplar(Exemplar oldExemplar)
     {
         if(exemplare.Contains(oldExemplar)){
             exemplare.Remove(oldExemplar);
             return true;
         }
         return false;
     }
     
     public ulong GetLastExemplarId() 
     {
     	ulong lastId = 0;
     	foreach(Exemplar e in exemplare)
     	{
     		if(e.ExemplarId > lastId)
     			lastId = e.ExemplarId;
     	}
     	return lastId; // wenn lastId == 0, dann ist liste leer
     }
     
     public string CreateSignatur()
     {
     	string authorPrefix = this.Author[0].ToString();
     	string subjectAreaPrefix = this.SubjectArea.Substring(0,3);
     	return "[" +authorPrefix + subjectAreaPrefix + "]";
     }
     
	public override string ToString()
	{
		return this.Author + " " + this.Titel + " " + this. subjectArea;
	}
  }
}
