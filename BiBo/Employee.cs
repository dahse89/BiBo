using System;
using BiBo.Persons;

namespace BiBo.Persons
{
  public class Employee : Customer    
  {
      //Member-Variablen Deklaration
      
      //Konstruktor für Mitarbeiter
      public Employee(ulong customerID, string firstName, string lastName, DateTime birthDate)
          : base(customerID, firstName, lastName, birthDate)
      {
          Right = Rights.EMPLOYEE;
      }
      
      //Erstelle Kunden

      public Customer createCustomer(ulong customerID, string firstName, string lastName, DateTime birthDate) 
      {
          return new Customer(customerID, firstName, lastName, birthDate);
      }
      
      //Aendere Adresse des Kunden
      public void changeAddress(Customer customer, string street, string streetNumber, string additionalRoad, string zipCode, string town, string country) 
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
