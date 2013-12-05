/*
 * Erstellt mit SharpDevelop.
 * Benutzer: m588
 * Datum: 30.10.2013
 * Zeit: 16:22
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Data.SQLite;
using System.Data.SqlTypes;
using BiBo.Persons;
using System.Collections.Generic;


namespace BiBo.SQL
{
	/// <summary>
	/// Description of CustomerSql.
	/// </summary>
	public class CustomerSQL : SqlConnector<Customer>
	{		
		public override bool AddEntry(Customer customer)
		{
              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = @"INSERT INTO
                                            Customer (
                                                id,
                                                cardId,
                                                cardValidUntil,
                                                firstName, 
                                                lastName, 
                                                birthDate,
                                                email,
                                                mobileNumber,
                                                createdAt,
                                                lastUpdate,
                                                street,
                                                streetNumber,
                                                additionalRoad,
                                                zipCode,
                                                town,
                                                country,
                                                rights,
                                                password
                                            ) 
                                            VALUES (
                                                NULL,
                                                '" + customer.Card.CardID + @"',
                                                '" + customer.Card.CardValidUntil + @"',
                                                '" + customer.FirstName + @"',
                                                '" + customer.LastName  + @"',
                                                '" + customer.BirthDate.ToShortDateString() + @"',
                                                '" + customer.EMailAddress + @"',
                                                '" + customer.MobileNumber + @"',
                                                '" + customer.CreatedAt + @"',
                                                '" + customer.LastUpdate + @"',   
                                                '" + customer.Street + @"',
                                                '" + customer.StreetNumber + @"',
                                                '" + customer.AdditionalRoad + @"',
                                                '" + customer.ZipCode + @"',
                                                '" + customer.Town + @"',
                                                '" + customer.Country + @"',
                                                '" + customer.Right.ToString() + @"',
                                                '" + customer.Password + @"'
                                             );";

              command.ExecuteNonQuery();

            return true;
		}

        public override ulong AddEntryReturnId(Customer customer)
        {
            AddEntry(customer);//da hier ja eh ne unique id erzeugt wird kann ich die ja auch gleich nutzen <Philipp>

            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "SELECT last_insert_rowid()";
            Int64 LastRowID64 = (Int64)command.ExecuteScalar();
            return (ulong) LastRowID64;
        }

        public override bool UpdateEntry(Customer customer)
        {
          SQLiteCommand command = new SQLiteCommand(con);
          command.CommandText = @"UPDATE Customer SET
                                    cardValidUntil = '" + customer.Card.CardValidUntil + @"',
                                    email = '" + customer.EMailAddress + @"',
                                    mobileNumber = '" + customer.MobileNumber + @"',
                                    createdAt = '" + customer.CreatedAt + @"',
                                    lastUpdate = '" + customer.LastUpdate + @"',
                                    firstName = '" + customer.FirstName + @"',
                                    lastName = '" + customer.LastName + @"',
                                    street = '" + customer.Street + @"',
                                    streetNumber = '" + customer.StreetNumber + @"',
                                    additionalRoad = '" + customer.AdditionalRoad + @"',
                                    zipCode = '" + customer.ZipCode + @"',
                                    town = '" + customer.Town + @"',
                                    country = '" + customer.Country + @"',
                                    rights = '" + customer.Right.ToString() + @"'
                                    password = '" + customer.Password + @"'
                                  WHERE id = '" + customer.CustomerID + @"');";
          command.ExecuteNonQuery();
          return true;
        }

        public override bool DeleteEntryByIdList(List<ulong> l)
        {
            SQLiteCommand command = new SQLiteCommand(con);
            string listOfIds = "";

            foreach(ulong x in l){
                listOfIds = string.Join(",", x);
            }
            command.CommandText = "DELETE FROM Customer WHERE id IN ('" + listOfIds + "');";
            command.ExecuteNonQuery();
            return true;
        }

		
		    public override List<Customer> GetAllEntrys()
		    {
		    List<Customer> customerList = new List<Customer>();

              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = "SELECT * FROM Customer";
              SQLiteDataReader reader = command.ExecuteReader();

              if (reader.HasRows)
              {
                  while (reader.Read())
                  {
                      customerList.Add(InitEntryByReader(reader));
                  }
              }

              return customerList;
		    }

        protected override Customer InitEntryByReader(SQLiteDataReader reader){
            Customer tmp;

            int intId = reader.GetInt32(reader.GetOrdinal("id"));
            ulong id = System.Convert.ToUInt64(intId);
            string firstName = reader.GetString(reader.GetOrdinal("firstName"));
            string lastName = reader.GetString(reader.GetOrdinal("lastName"));
            DateTime birthDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("birthDate")));

            tmp = new Customer(id, firstName, lastName, birthDate);
            
            tmp.EMailAddress = reader.GetString(reader.GetOrdinal("email"));
            tmp.MobileNumber = reader.GetString(reader.GetOrdinal("mobileNumber"));
                
            string street = reader.GetString(reader.GetOrdinal("street"));
            tmp.Street = street;
            tmp.StreetNumber = reader.GetString(reader.GetOrdinal("streetNumber"));
            tmp.AdditionalRoad = reader.GetString(reader.GetOrdinal("additionalRoad"));
            tmp.ZipCode = reader.GetOrdinal("zipCode").ToString();
            tmp.Town = reader.GetString(reader.GetOrdinal("town"));
            tmp.Country = reader.GetString(reader.GetOrdinal("country"));

            tmp.LastUpdate = DateTime.Parse(reader.GetString(reader.GetOrdinal("lastUpdate")));
            tmp.CreatedAt = DateTime.Parse(reader.GetString(reader.GetOrdinal("createdAt")));

            int cardId = reader.GetInt32(reader.GetOrdinal("cardId"));

            string cardValue = reader.GetString(reader.GetOrdinal("cardValidUntil"));

            tmp.Card = new Card(cardId,cardValue);

            string rightString = reader.GetString(reader.GetOrdinal("rights"));
            Rights right = (Rights)Enum.Parse(typeof(Rights), rightString, true);
            tmp.Right = right;

            tmp.Password = reader.GetString(reader.GetOrdinal("password"));

            return tmp;
        }
		
		bool BorrowBook(ulong bookId)
		{
			return true;
		}
		
		bool NoBooksBorrowed()
		{
			return true;
		}
		
		bool HasOwe()
		{
			return true;
		}
		
		void MergeBlanaceWith(int value)
		{
			
		}
		
		void CreateIDCard()
		{
			
		}
		
		void ExtendIDCard()
		{
			
		}
		
		void OrderBookInAdvance(ulong bookId)
		{
			
		}
		
	
		
	}
}
