using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo
{
  class Employee : Customer    
  {
   public Rights right = Rights.EMPLOYEE;
    
    public Customer createCustomer(int customerID, string firstName, string lastName, DateTime birthDate) 
    {
      Customer newCustomer = new Customer(customerID, firstName, lastName, birthDate);
      return newCustomer;
    }
    
    public void changeAddress(Customer customer, string street, int streetNumber, string additionalRoad, int zipCode, string town, string country) 
    {
      Customer.Street = street;
      Customer.StreetNumber = streetNumber;
      Customer.AdditionalRoad = additionalRoad;
      this.ZipCode = zipCode;
      this.Town = town;
      this.Country = country;
    }
  }
}
