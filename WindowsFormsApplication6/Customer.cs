using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBo.Persons
{
    class Customer
    {
        //Member-Variablen Deklaration
        private int customerID;                  //Kunden-ID

        private string firstName;                //Vorname
        private string lastName;                 //Nachname
        private DateTime birthDate;              //Geburtstag

        private string street;                   //Strasse
        private int streetNumber;                //Hausnummer
        private string additionalRoad;           //Strassenzusatz
        private int zipCode;                     //PLZ
        private string town;                     //Stadt
        private string country;                  //Land
        
        private Rights right = Rights.CUSTOMER; //Rechte
        private int chargeAccountNumber;         //GebuehrenkontoNr
        private int biboID;                      //Bibliotheks-ID
        private int cardID;                      //Ausweis-ID
        private UserStates userState;            //Benutzer- Status

        //Konstruktor
        public Customer(int customerID, string firstName, string lastName, DateTime birthDate)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }

        //Property Deklaration
        public int CustomerID
        {
            get { return customerID; }
        }

        public string FirstName
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return lastName; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public int StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }
        public string AdditionalRoad
        {
            get { return additionalRoad; }
            set { additionalRoad = value; }
        }
        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
        public string Town
        {
            get { return town; }
            set { town = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public Rights Right
        {
            get { return right; }
            set { right = value; }
        }
        public int ChargeAccountNumber
        {
            get { return chargeAccountNumber; }
            set { chargeAccountNumber = value; }
        }
        public int BiboID
        {
            get { return biboID; }
            set { biboID = value; }
        }
        public int CardID
        {
            get { return cardID; }
            set { cardID = value; }
        }
        public UserStates UserState
        {
            get { return userState; }
            set { userState = value; }
        }
    }
}
