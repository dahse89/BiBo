using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BiBo.Persons
{
    public class Customer
    {
        //Member-Variablen Deklaration
        [XmlAttribute("CustomerID")]
        private double customerID;                  //Kunden-ID

        [XmlAttribute("FirstName")]
        private string firstName;                //Vorname
        [XmlAttribute("LastName")]
        private string lastName;                 //Nachname
        [XmlAttribute("BirthDate")]
        private DateTime birthDate;              //Geburtstag

        [XmlAttribute("Street")]
        private string street;                   //Strasse
        [XmlAttribute("StreetNumber")]
        private int streetNumber;                //Hausnummer
        [XmlAttribute("AdditionalRoad")]
        private string additionalRoad;           //Strassenzusatz
        [XmlAttribute("ZipCode")]
        private int zipCode;                     //PLZ
        [XmlAttribute("Town")]
        private string town;                     //Stadt
        [XmlAttribute("Country")]
        private string country;                  //Land

        [XmlAttribute("Rights")]
        private Rights right = Rights.CUSTOMER;  //Rechte
        [XmlAttribute("ChargeAccountNumber")]
        private int chargeAccountNumber;         //GebuehrenkontoNr
        [XmlAttribute("ChargeAccount")]
        private float chargeAccount;             //Gebuehrenkonto
        [XmlAttribute("BiboID")]
        private int biboID;                      //Bibliotheks-ID
        [XmlAttribute("CardID")]
        private int cardID;                      //Ausweis-ID
        [XmlAttribute("CardValidUntil")]
        private string cardValidUntil;           //Gültigkeitdatum des Auswieses
        [XmlAttribute("UserState")]
        private UserStates userState;            //Benutzer- Status
        [XmlAttribute("MobileNumber")]
        private string mobileNumber;             //Handy-Nummer
        [XmlAttribute("Email")]
        private string eMailAddress;             //Email-Adresse


        //Konstruktor
        public Customer(double customerID, string firstName, string lastName, DateTime birthDate)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }
        public Customer() { }

        //Property Deklaration
        public double CustomerID
        {
            get { return this.customerID; }
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
        public float ChargeAccount
        {
            get { return chargeAccount; }
            set { chargeAccount = value; }
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
        public string MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }
        public string EMailAddress
        {
            get { return eMailAddress; }
            set { eMailAddress = value; }
        }



        public DataSet getDataSet()
        {
          return new DataSet();
        }
    }
}
