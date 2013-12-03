using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiBo.Persons;
using BiBo;
using System;

namespace Test
{
    [TestClass()]
    public class CustomerTest
    {
        [TestMethod()]
        public void GetHashCodeEqualsTest()
        {
            ulong cusID = 1;
            string firstName = "Vorname";
            string lastName = "Nachname";
            DateTime birthDate = DateTime.Parse("01.04.1999");

            Customer cus = new Customer(cusID, firstName, lastName, birthDate);

            Assert.IsTrue(cus.CustomerID == cusID);
            Assert.IsTrue(cus.FirstName == firstName);
            Assert.IsTrue(cus.LastName == lastName);
            Assert.IsTrue(cus.BirthDate == birthDate);

            string hashString = firstName + lastName + birthDate;
            hashString.GetHashCode();

            Assert.AreEqual(cus.GetHashCode(), hashString.GetHashCode());

        }
        [TestMethod()]
        public void getFullAdressTest()
        {
            ulong cusID = 1;
            string firstName = "Vorname";
            string lastName = "Nachname";
            DateTime birthDate = DateTime.Parse("01.04.1999");

            Customer cus = new Customer(cusID, firstName, lastName, birthDate);

            Assert.IsTrue(cus.CustomerID == cusID);
            Assert.IsTrue(cus.FirstName == firstName);
            Assert.IsTrue(cus.LastName == lastName);
            Assert.IsTrue(cus.BirthDate == birthDate);

            string street = "Straße 342";
            string streetNumber = "1a";
            string additionalRoad = "";
            string zipCode = "13589";
            string town = "Berlin";
            string country = "Deutschland";

            cus.Street = street;
            cus.StreetNumber = streetNumber;
            cus.AdditionalRoad = additionalRoad;
            cus.ZipCode = zipCode;
            cus.Town = town;
            cus.Country = country;

            Assert.IsTrue(cus.Street == street);
            Assert.IsTrue(cus.StreetNumber == streetNumber);
            Assert.IsTrue(cus.AdditionalRoad == additionalRoad);
            Assert.IsTrue(cus.ZipCode == zipCode);
            Assert.IsTrue(cus.Town == town);
            Assert.IsTrue(cus.Country == country);

            string adress = street + " " + streetNumber + "\n" +
                (additionalRoad == "" ? "" : (additionalRoad + "\n")) +
                zipCode + " " + town + "\n" + country;

            Assert.AreEqual(cus.getFullAdress(), adress);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            ulong cusID = 1;
            string firstName = "Vorname";
            string lastName = "Nachname";
            DateTime birthDate = DateTime.Parse("01.04.1999");

            Customer cus = new Customer(cusID, firstName, lastName, birthDate);

            Assert.IsTrue(cus.CustomerID == cusID);
            Assert.IsTrue(cus.FirstName == firstName);
            Assert.IsTrue(cus.LastName == lastName);
            Assert.IsTrue(cus.BirthDate == birthDate);

            string street = "Straße 342";
            string streetNumber = "1a";
            string town = "Berlin";

            string sString = cusID + " " + firstName + " " + lastName + " " + birthDate + " " + street + " " + streetNumber + " " + town;

            Assert.AreEqual(cus.ToString(), sString);
        }
    }
}
