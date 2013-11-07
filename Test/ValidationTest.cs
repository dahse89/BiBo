using BiBo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass()]
    public class ValidationTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get{ return testContextInstance; }
            set{ testContextInstance = value; }
        }

        [TestMethod()]
        public void ValidationConstructorTest()
        {
            Validation target = new Validation();
            Assert.Inconclusive("Validation Constructor Test");
        }


        [TestMethod()]
        public void NameTest()
        {
            string name = "";           // Test Namen einfügen
            bool expected = false; 
            bool actual;
            actual = Validation.Name(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen ob der Name validiert werden kann");
        }

        [TestMethod()]
        public void StreetTest()
        {
            string str = "";            // Straßennamen einfügen
            bool expected = false; 
            bool actual;
            actual = Validation.Street(str);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen ob die Strasse validiert werden kann");
        }

        [TestMethod()]
        public void TelNumberTest()
        {
            string telnr = "";          // Telefonnummer eingeben
            bool expected = false; 
            bool actual;
            actual = Validation.TelNumber(telnr);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen ob die Telefonummer validiert werden kann");
        }

        [TestMethod()]
        public void isAlphabeticTest()
        {
            string alpha = "";          // Prüfen ob es alphabetisch ist
            bool expected = false;
            bool actual;
            actual = Validation.isAlphabetic(alpha);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen ob meine Übergabe alphabetisch ist");
        }

        [TestMethod()]
        public void isEmptyTest()
        {
            string empty = "";  // Prüfen Leer oder NULL
            bool expected = false;
            bool actual;
            actual = Validation.isEmpty(empty);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen ob meine Übergabe Leer oder NULL ist");
        }

        [TestMethod()]
        public void isNumericTest()
        {
            string num = "";          // Prüfen ob es numerisch ist
            bool expected = false; 
            bool actual;
            actual = Validation.isNumeric(num);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen ob meine Übergabe numerisch ist");
        }

        [TestMethod()]
        public void zipCodeTest()
        {
            string zip ="";         // Prüfen ob meine PLZ gültig ist
            bool expected = false;
            bool actual;
            actual = Validation.zipCode(zip);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen ob meine PLZ gültig ist");
        }
    }
}
