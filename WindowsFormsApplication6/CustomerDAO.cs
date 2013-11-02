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


namespace BiBo.DAO
{
	/// <summary>
	/// Description of CustomerSql.
	/// </summary>
	public class CustomerDAO : SqlConnector<Customer>
	{
		public CustomerDAO()
		{
			string customerSQL = @"CREATE TABLE IF NOT EXISTS
                                    Customer (
                                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                        firstName VARCHAR(100) NOT NULL,
                                        lastName VARCHAR(100) NOT NULL,
                                        birthDate DATETIME,
                                        street VARCHAR(100),
                                        streetNumber VARCHAR(10),
                                        additionalRoad VARCHAR(100), 
                                        zipCode INTEGER(5), 
                                        town VARCHAR(100), 
                                        country VARCHAR(100), 
                                        chargeAccount INTEGER(100)
                                    );";

          	SQLiteCommand command = new SQLiteCommand(customerSQL, con);
          	command.ExecuteNonQuery();
		}
		
		public override bool CreateTable()
		{
		  
          return true;
		}
		
		public override bool AddEntry(Customer customer)
		{
              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = @"INSERT INTO
                                            Customer (
                                                id,
                                                firstName, 
                                                lastName, 
                                                birthDate,
                                                street,
                                                streetNumber,
                                                additionalRoad,
                                                zipCode,
                                                town,
                                                country
                                            ) 
                                            VALUES (
                                                NULL,
                                                '" + customer.FirstName + @"',
                                                '" + customer.LastName  + @"',
                                                '" + customer.BirthDate.ToShortDateString() + @"',
                                                '" + customer.Street + @"',
                                                '" + customer.StreetNumber + @"',
                                                '" + customer.AdditionalRoad + @"',
                                                '" + customer.ZipCode + @"',
                                                '" + customer.Town + @"',
                                                '" + customer.Country + @"'
                                             );";
              command.ExecuteNonQuery();

            return true;
		}

        public ulong AddEntryReturnId(Customer customer)
        {
            AddEntry(customer);//da hier ja eh ne unique id erzeugt wird kann ich die ja auch gleich nutzen <Philipp>

            SQLiteCommand command = new SQLiteCommand(con);
            command.CommandText = "select last_insert_rowid()";
            Int64 LastRowID64 = (Int64)command.ExecuteScalar();
            return (ulong) LastRowID64;
        }
		
		public override bool DeleteEntry(Customer customer)
		{
			if (customer.FirstName != "")
            {
              SQLiteCommand command = new SQLiteCommand(con);
              command.CommandText = "DELETE FROM Customer WHERE firstName='" + customer.FirstName + "';";
              command.ExecuteNonQuery();
            }
            return true;
		}
		
		public override List<Customer> GetAllEntrys()
		{
		List<Customer> customerList = new List<Customer>();

          SQLiteCommand command = new SQLiteCommand(con);
          command.CommandText = "SELECT * FROM Customer";
          SQLiteDataReader reader = command.ExecuteReader();

          Customer tmp;

          if (reader.HasRows)
          {
              while (reader.Read())
              {
                  int intId = reader.GetInt32(reader.GetOrdinal("id"));
                  ulong id = System.Convert.ToUInt64(intId);
                  string firstName = reader.GetString(reader.GetOrdinal("firstName"));
                  string lastName = reader.GetString(reader.GetOrdinal("lastName"));
                  DateTime birthDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("birthDate")));

                  tmp = new Customer(id, firstName, lastName, birthDate);
                  
                  string street = reader.GetString(reader.GetOrdinal("street"));
                  tmp.Street = street;
                  tmp.StreetNumber = Convert.ToInt32(reader.GetString(reader.GetOrdinal("streetNumber")));
                  tmp.AdditionalRoad = reader.GetString(reader.GetOrdinal("additionalRoad"));
                  tmp.ZipCode = reader.GetInt32(reader.GetOrdinal("zipCode"));
                  tmp.Town = reader.GetString(reader.GetOrdinal("town"));
                  tmp.Country = reader.GetString(reader.GetOrdinal("country"));

                  customerList.Add(tmp);
              }
          }

          return customerList;
		}
	
		
	}
}
