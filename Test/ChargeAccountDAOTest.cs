using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using BiBo;
using BiBo.SQL;
using BiBo.Persons;

namespace Test
{
  [TestClass()]
  class ChargeAccountDAOTest
  {
    [TestMethod()]
    public void GetAllChargeAccountsTest()
    {
      int capacity = 1;
      GUIApi api = new GUIApi(true);
      Library lib = new Library(api);
      ChargeAccountSQL chargeAccountSql = SqlConnector<ChargeAccount>.GetChargeAccountSqlInstance();

      ulong cusID = 1;
      string firstName = "Vorname1";
      string lastName = "Nachname1";
      DateTime birthDate = DateTime.Parse("01.04.1999");
      Customer cus1 = new Customer(cusID, firstName, lastName, birthDate);

      cusID = 2;
      firstName = "Vorname2";
      lastName = "Nachname2";
      birthDate = DateTime.Parse("01.05.1999");
      Customer cus2 = new Customer(cusID, firstName, lastName, birthDate);

      DateTime changedAt = DateTime.Today;
      decimal currentValue = 500;
      decimal changeValue = 50;
      Charge ch = new Charge(changedAt, currentValue, changeValue);

      Assert.IsTrue(ch.ChangeAt == changedAt);
      Assert.IsTrue(ch.CurrentValue == currentValue);
      Assert.IsTrue(ch.ChangeValues == changeValue);

      List<Charge> chargelist1 = new List<Charge>(capacity);
      chargelist1.Add(ch);

      Assert.AreEqual(chargelist1.Capacity, ch);

      ChargeAccount chAcc1 = new ChargeAccount(cus1);
      ChargeAccount chAcc2 = new ChargeAccount(cus2);

      chAcc1.Charges = chargelist1;
      chAcc2.Charges = chargelist1;

      List<ChargeAccount> list = new List<ChargeAccount>(capacity);
      lib.ChargeAccountList = list;

      Assert.IsTrue(chargelist1 == null);

      if (lib.ChargeAccountList == null)
      {
        lib.ChargeAccountList = chargeAccountSql.GetAllEntrys();
      }

      list.Add(chAcc1);
      Assert.AreEqual(list, chAcc1);
      list.Add(chAcc2);

      lib.ChargeAccountList = list;
      Assert.AreEqual(lib.ChargeAccountList, list);
    }
  }
}
