using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiBo.Persons;
using BiBo;
using System;

namespace Test
{
    [TestClass()]
    public class AdminTest
    {
        [TestMethod()]
        public void createEmployeeTest()
        {
            ulong customerID = 2;
            string firstName = "Klaus";
            string lastName = "Pong";
            DateTime birthDate = DateTime.Parse("01.07.1990");
            Employee em = new Employee(customerID, firstName, lastName, birthDate);


            Assert.IsTrue(em.CustomerID == customerID);
            Assert.IsTrue(em.FirstName == firstName);
            Assert.IsTrue(em.LastName == lastName);
            Assert.IsTrue(em.BirthDate == birthDate);
        }

        [TestMethod()]
        public void createAdminTest()
        {
            ulong customerID = 7;
            string firstName = "Admin";
            string lastName = "Boss";
            DateTime birthDate = DateTime.Parse("01.07.1991");
            Employee em = new Employee(customerID, firstName, lastName, birthDate);


            Assert.IsTrue(em.CustomerID == customerID);
            Assert.IsTrue(em.FirstName == firstName);
            Assert.IsTrue(em.LastName == lastName);
            Assert.IsTrue(em.BirthDate == birthDate);
        }

        [TestMethod()]
        public void changeOpeningTimeTest()
        {
            string openingTime = "";
            Library lib = new Library();

            Assert.IsTrue(lib.OpeningTime == openingTime);


        }

        [TestMethod()]
        public void changeFeeTest()
        {
            double fee = 1.00;
            Library lib = new Library();

            Assert.IsTrue(lib.Fee == fee);

        }
    }
}
