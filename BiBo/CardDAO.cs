using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BiBo.SQL;
using BiBo.Persons;

namespace BiBo.DAO
{
  class CardDAO
  {
    CardSQL cardSql = SqlConnector<Card>.GetCardSqlInstance();
    CustomerDAO customerDAO = new CustomerDAO();

    public void AddCard(Card card, Customer customer)
    {
      //add Card to Customer
      card.CardID = cardSql.AddEntryReturnId(card);
      
      //add user in Objects
      customerDAO.UpdateCustomer(customer);

    }
  }
}
