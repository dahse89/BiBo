using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Threading.Tasks;

namespace BiBo.Persons
{
    public class Customer
    {
        //Member-Variablen Deklaration
        private ulong customerID;                       //Kunden-ID

        private string firstName;                       //Vorname
        private string lastName;                        //Nachname
        private DateTime birthDate;                     //Geburtstag

        private string street;                          //Strasse
        private string streetNumber;                    //
        private string additionalRoad;                  //
        private string zipCode;                         //PLZ 
        private string town;                            //
        private string country;                         //Land

        private Rights right = Rights.CUSTOMER;         //Rechte
        private ChargeAccount chargeAccount;            //Gebuehrenkonto
        private int biboID;                             //Bibliotheks-ID
        private Card card;                              //Ausweis
        private UserStates userState;                   //Benutzer- 
        private string mobileNumber;                    //Handy-
        private string eMailAddress;                    //Email-Adresse

        private string password;                        //Passwort des Nutzers

        private DateTime createdAt;                        //Kunde erstellt am
        private DateTime lastUpdate;                        //Kunde geändert am
        private DateTime deletedAt;                        //Kunde ausgetreten am  

        private List<Exemplar> exemplarList;            // Liste aller vom Customer ausgeliehen Buechern


        //Konstruktor
        public Customer(ulong customerID, string firstName, string lastName, DateTime birthDate)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.password = "";
            this.ExemplarList = new List<Exemplar>();
        }
        public Customer() 
        {
          this.password = "";
          this.ExemplarList = new List<Exemplar>();
        }

        //Property Deklaration
        public ulong CustomerID
        {
            get { return this.customerID; }
            set { this.customerID = value; }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public DateTime BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }

        public string Street
        {
            get { return this.street; }
            set { this.street = value; }
        }
        public string StreetNumber
        {
            get { return this.streetNumber; }
            set { this.streetNumber = value; }
        }
        public string AdditionalRoad
        {
            get { return this.additionalRoad; }
            set { this.additionalRoad = value; }
        }
        public string ZipCode
        {
            get { return this.zipCode; }
            set { this.zipCode = value; }
        }
        public string Town
        {
            get { return this.town; }
            set { this.town = value; }
        }
        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }
        public Rights Right
        {
            get { return this.right; }
            set { this.right = value; }
        }
        public ChargeAccount ChargeAccount
        {
          get { return this.chargeAccount; }
          set { this.chargeAccount = value; }
        }
        public int BiboID
        {
            get { return this.biboID; }
            set { this.biboID = value; }
        }
        public UserStates UserState
        {
            get { return this.userState; }
            set { this.userState = value; }
        }
        public string MobileNumber
        {
            get { return this.mobileNumber; }
            set { this.mobileNumber = value; }
        }
        public string EMailAddress
        {
            get { return this.eMailAddress; }
            set { this.eMailAddress = value; }
        }
        public List<Exemplar> ExemplarList
        {
          get { return this.exemplarList; }
          set { this.exemplarList = value; }
        }
        public string Password
        {
          get { return this.password; }
          set { this.password = value; }
        }
        public Card Card
        {
          get { return this.card; }
          set { this.card = value; }
        }
        public DateTime CreatedAt
        {
          get { return this.createdAt; }
          set { this.createdAt = value; }
        }
        public DateTime LastUpdate
        {
          get { return this.lastUpdate; }
          set { this.lastUpdate = value; }
        }
        public DateTime DeletedAt
        {
          get { return this.deletedAt; }
          set { this.deletedAt = value; }
        }

        public String getFullAdress()
        {
            return  this.Street + " " + this.StreetNumber + "\n" +
                    (this.AdditionalRoad == "" ? "" : (this.AdditionalRoad + "\n")) +
                    this.ZipCode + " " +
                    this.Town + "\n" +
                    this.Country;
        }

		//Methoden
        public DataSet getDataSet()
        {
          return new DataSet();
        }
        
        public override string ToString()
		{
			return CustomerID + " " + FirstName + " " + LastName + " " + BirthDate + " " + Street + " " + Town;
		}

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            string hashString = this.firstName + this.lastName + this.birthDate + this.street + this.streetNumber + this.town;
            return hashString.GetHashCode();
        }
    }
}
