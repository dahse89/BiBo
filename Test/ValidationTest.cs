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
      Assert.IsTrue(Validation.Street("Königsstrasse 15"));

      //test if validation of street strings failed
      Assert.IsFalse(Validation.Street("Königsstra$$e"));
      Assert.IsFalse(Validation.Street("Königsstrasse"));
    }

    [TestMethod()]
    public void TelNumberTest()
    {
      //test if validation of telephonnumbers is ok
      Assert.IsTrue(Validation.TelNumber("+1-234-567-8901"));
      Assert.IsTrue(Validation.TelNumber("+46-234 5678901"));

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
      Assert.IsTrue(Validation.zipCode("03242"));
      Assert.IsTrue(Validation.zipCode("12394"));

      Assert.IsTrue(Validation.zipCode("K7P3K6"));

      Assert.IsTrue(Validation.zipCode("123456789"));
      Assert.IsTrue(Validation.zipCode("12345-6789"));


      //test if validation of zipCode string failed
      Assert.IsFalse(Validation.zipCode("3520"));

      Assert.IsTrue(Validation.zipCode("W7P3K6"));

      Assert.IsTrue(Validation.zipCode("12345-0000"));
      Assert.IsTrue(Validation.zipCode("00000-0000"));

    }
  }
}