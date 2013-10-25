using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo.Persons
{
  class Employee : Customer    
  {
   public Rights right = Rights.EMPLOYEE;

   //Konstruktor für Mitarbeiter
   public Employee(int customerID, string firstName, string lastName, DateTime birthDate)
     : base(customerID, firstName, lastName, birthDate)
   {
   }

   public Rights Right
   {
     get { return right; }
     set { right = value; }
   }
    
    //Erstelle Kunden
    public Customer createCustomer(int customerID, string firstName, string lastName, DateTime birthDate) 
    {
      return new Customer(customerID, firstName, lastName, birthDate);
    }
    
    //Aendere Adresse des Kunden
    public void changeAddress(Customer customer, string street, int streetNumber, string additionalRoad, int zipCode, string town, string country) 
    {
      customer.Street = street;
      customer.StreetNumber = streetNumber;
      customer.AdditionalRoad = additionalRoad;
      customer.ZipCode = zipCode;
      customer.Town = town;
      customer.Country = country;
    }
  }
}
