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
            //test, if only letters ok
            Assert.IsTrue(Validation.Name("Marcus"));

            //test, if numbers give false result
            Assert.IsFalse(Validation.Name("1234567890"));
        }

        [TestMethod()]
        public void StreetTest()
        {
            //test if validation of street strings is ok
            Assert.IsTrue(Validation.Street("Königsstrasse"));
            Assert.IsTrue(Validation.Street("Königsstrasse 15"));   // <--- Sollte eigentlich klappen !!

            //test if validation of street strings failed
            Assert.IsFalse(Validation.Street("Königsstra$$e"));
        }

        [TestMethod()]
        public void TelNumberTest()
        {
            //test if validation of telephonnumbers is ok
            Assert.IsTrue(Validation.TelNumber("01721234567"));     // <--- Sollte eigentlich klappen !!
            Assert.IsTrue(Validation.TelNumber("+49172/1234567"));  // <--- Sollte eigentlich klappen !! 

            //test if validation of telephonnumbers failed
            Assert.IsFalse(Validation.TelNumber("0172coolman"));
        }

        [TestMethod()]
        public void isAlphabeticTest()
        {
            //test if validation of alphabetic strings is ok
            Assert.IsTrue(Validation.isAlphabetic("abcdefghijklmnopqrstuvwxyzäöü"));

            //test if validation of alphabetic strings failed
            Assert.IsFalse(Validation.isAlphabetic("abcdefghijklmnopqrstuvwxyzäöü123"));
        }

        [TestMethod()]
        public void isEmptyTest()
        {
            //test if validation of empty strings is ok
            Assert.IsTrue(Validation.isEmpty(""));

            //test if validation of empty strings failed
            Assert.IsFalse(Validation.isEmpty("a non empty string"));
        }

        [TestMethod()]
        public void isNumericTest()
        {
            //test if validation of numeric string is ok
            Assert.IsTrue(Validation.isNumeric("1234567890"));

            //test if validation of numeric string failed
            Assert.IsFalse(Validation.isNumeric("1234567890abc"));
        }

        [TestMethod()]
        public void zipCodeTest()
        {
            //test if validation of zipCode string is ok
            Assert.IsTrue(Validation.zipCode("15745"));         // <--- Sollte eigentlich klappen !!

            //test if validation of zipCode string failed
            Assert.IsFalse(Validation.zipCode("157454563354"));
        }
    }
}
