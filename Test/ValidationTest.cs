using BiBo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass()]
    public class ValidationTest
    {
        [TestMethod()]
        public void NameTest()
        {
            string name = "";           // Test Namen einfügen
            bool expected = false; 
            bool actual;
            actual = Validation.Name(name);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StreetTest()
        {
            string str = "";            // Straßennamen einfügen
            bool expected = false; 
            bool actual;
            actual = Validation.Street(str);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TelNumberTest()
        {
            string telnr = "";          // Telefonnummer eingeben
            bool expected = false; 
            bool actual;
            actual = Validation.TelNumber(telnr);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void isAlphabeticTest()
        {
            string alpha = "";          // Prüfen ob es alphabetisch ist
            bool expected = false;
            bool actual;
            actual = Validation.isAlphabetic(alpha);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void isEmptyTest()
        {
            string empty = "";  // Prüfen Leer oder NULL
            bool expected = true;
            bool actual;
            actual = Validation.isEmpty(empty);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void isNumericTest()
        {
            string num = "";          // Prüfen ob es numerisch ist
            bool expected = false; 
            bool actual;
            actual = Validation.isNumeric(num);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void zipCodeTest()
        {
            string zip ="";         // Prüfen ob meine PLZ gültig ist
            bool expected = false;
            bool actual;
            actual = Validation.zipCode(zip);
            Assert.AreEqual(expected, actual);
        }
    }
}
