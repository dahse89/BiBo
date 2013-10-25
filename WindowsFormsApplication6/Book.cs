using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BiBo
{
  public class Book
  {
    [XmlAttribute("Author")]
    private string author;       //Autor des Buch
    [XmlAttribute("Titel")]
    private string titel;        //Titel
    [XmlAttribute("SubjectArea")]
    private string subjectArea;  //Fachrichtung

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string Titel
    {
        get { return titel; }
        set { titel = value; }
    }

    public string SubjectArea
    {
        get { return subjectArea; }
        set { subjectArea = value; }
    }

  }
}
