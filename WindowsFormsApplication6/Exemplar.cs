using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  public class Exemplar : Book
  {
    private DateTime loanPeriod; //Ausleifrist 
    private string state; // anderer Status als bei Kunde ( ausgeliehen / verf�gbar) 
    private string Signatur; // mehere Exemplare / alphanumerisch 
    string access; 
  }
}
