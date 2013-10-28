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
            get { return this.firstName; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public DateTime BirthDate
        {
            get { return this.birthDate; }
        }

        public string Street
        {
            get { return this.street; }
            set { this.street = value; }
        }
        public int StreetNumber
        {
            get { return this.streetNumber; }
            set { this.streetNumber = value; }
        }
        public string AdditionalRoad
        {
            get { return this.additionalRoad; }
            set { this.additionalRoad = value; }
        }
        public int ZipCode
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
        public int ChargeAccountNumber
        {
            get { return this.chargeAccountNumber; }
            set { this.chargeAccountNumber = value; }
        }
        public float ChargeAccount
        {
            get { return this.chargeAccount; }
            set { this.chargeAccount = value; }
        }
        public int BiboID
        {
            get { return this.biboID; }
            set { this.biboID = value; }
        }
        public int CardID
        {
            get { return this.cardID; }
            set { this.cardID = value; }
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

				//Methoden
        public DataSet getDataSet()
        {
          return new DataSet();
        }
    }
}
