using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo.Persons
{
  public class Admin : Employee
  {
    
    //Konstruktor für Administrator
    public Admin(int customerID, string firstName, string lastName, DateTime birthDate)
      : base(customerID, firstName, lastName, birthDate)
    {
        Right = Rights.ADMINISTRATOR;
    }

    //Erstelle neuen Mitarbeiter
    public Employee createEmployee(int customerID, string firstName, string lastName, DateTime birthDate)
    {
      return new Employee(customerID, firstName, lastName, birthDate);
    }

    //Erstelle neuen Administrator
    public Admin createAdmin(int customerID, string firstName, string lastName, DateTime birthDate)
    {
      return new Admin(customerID, firstName, lastName, birthDate);
    }

    //Oeffnungszeiten der Bibliothek aendern
    public void changeOpeningTime(Library library, string openingTime)
    {
      library.OpeningTime = openingTime;
    }

    //Gebuehren aendern
    public void changeFee(Library library, double fee)
    {
      library.Fee = fee;
    }
  }
}
