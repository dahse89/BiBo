using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BiBo;
using BiBo.Persons;


namespace Test
{
    [TestClass()]
    public class EmployeeTest
    {
        [TestMethod()]
        public void createCustomerTest()
        {
            ulong customerID  = 0;
            string firstName = "Affe";
            string lastName = ""; 
            DateTime birthDate = DateTime.Parse("22.07.2015");
            Customer cus = new Customer(customerID, firstName, lastName, birthDate);

            // Übergabe Test
            Assert.IsTrue(cus.CustomerID == customerID);
            Assert.IsTrue(cus.FirstName == firstName);
            Assert.IsTrue(cus.LastName == lastName);
            Assert.IsTrue(cus.BirthDate == birthDate);
            
            // Falsch Eingaben Test
            Assert.IsFalse(cus.FirstName == "123456");
            Assert.IsFalse(cus.LastName == "$%&&/&)§");
            Assert.IsFalse(cus.BirthDate == DateTime.Today);
        }
        [TestMethod()]
        public void EmployeeKonstruktorTest()
        {
            ulong customerID = 1;
            string firstName = "Affe";
            string lastName = "Bongo";
            DateTime birthDate = DateTime.Parse("22.07.2000");

            Employee em = new Employee(customerID, firstName, lastName, birthDate);

            Assert.IsTrue(em.CustomerID == customerID);
            Assert.IsTrue(em.FirstName == firstName);
            Assert.IsTrue(em.LastName == lastName);
            Assert.IsTrue(em.BirthDate == birthDate);

        }
        [TestMethod()]
        public void changeAddressTest()
        {
            ulong customerID  = 0;
            string firstName = "Affe";
            string lastName = ""; 
            DateTime birthDate = DateTime.Parse("22.07.2015");
            Employee em = new Employee(customerID, firstName, lastName, birthDate);
            Customer cus = new Customer(customerID, firstName, lastName, birthDate);

            string street = "WALKENDCOTTAGE";
            string streetNumber = "12a";
            string country = "Kanada";
            string additionalRoad = "";
            string zipCode = "AB51 7LD";
            string town = "Inverurie";

            em.changeAddress(cus, street, streetNumber, additionalRoad, zipCode, town, country);


            Assert.IsTrue(em.Street == street);
            Assert.IsTrue(em.StreetNumber == streetNumber);
            Assert.IsTrue(em.BirthDate == birthDate);

        }        

    }
}

