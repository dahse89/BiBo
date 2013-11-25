using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace BiBo
{
  public class Validation
  {
    public static bool isEmpty(string s) // Leer oder Null
    {
      return String.IsNullOrEmpty(s.Trim());
    }
    public static bool isNumeric(string s) // Zahlen
    {
      return Regex.IsMatch(s, "^[0-9]+$");
    }
    public static bool isAlphabetic(string s) // Alphabetisch
    {
      return Regex.IsMatch(s, "^[A-Za-zäÄöÖüÜß\\s]+$");
    }
    public static bool Name(string s)
    {
      return (!isEmpty(s) && isAlphabetic(s));
    }
    public static bool Street(string s)
    {
        // Straße-Hausnummer-Kombinationen nach folgenden Regeln für gültig: 
        // Straße muss mit einem dt. Buchstaben beginnen, vor der Hausnummer muss (mind.) 
        // ein Whitespace stehen, der Nummer dürfen andere Zeichen folgen ("1/2", "c" etc.).
      return Regex.IsMatch(s, "^(([a-zA-ZäöüÄÖÜ]\\D*)\\s+\\d+?\\s*.*)$");
    }
    public static bool zipCode(string s)
    {
      return Regex.IsMatch(s, "[0-9]{5}|[0-9]{5}-[0-9]{4}|([A-Z]{1}[0-9]{1}){3}");  // DE, USA, CA
    }
    public static bool TelNumber(string s)
    {
      return Regex.IsMatch(s, "^((\\+\\d{1,3}(-| )?\\(?\\d\\)?(-| )?\\d{1,5})|(\\(?\\d{2,6}\\)?))(-| )?(\\d{3,4})(-| )?(\\d{4})(( x| ext)\\d{1,5}){0,1}$");
    }
    public static bool MobileNumber(string s)
    {
      return Regex.IsMatch(s, "(015[1|2|7|9])\\d{7,9}|(016[0|2|3])\\d{7,9}|(017[0-9])\\d{7,9}");   // alle deutschen Handynummern
    }
    public static bool OpeningTime(string s)
    {
        return Regex.IsMatch(s, "(([0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])");
    }

    public static bool validateCustomerAddPanel(/*Control x*/)
    {
        /*
      TextBox firstName = (TextBox)x.Controls.Find("textBoxUserFirstname", true)[0];
      if (!Validation.Name(firstName.Text))
      {
        firstName.BackColor = Color.Red;
        return false;
      }

      TextBox lastName = (TextBox)x.Controls.Find("textBoxUserLastname", true)[0];
      if (!Validation.Name(lastName.Text))
      {
          lastName.BackColor = Color.Red;
          return false;
      }

      TextBox UserStreet = (TextBox)x.Controls.Find("textBoxUserStreet", true)[0];
      if (!Validation.Name(lastName.Text))
      {
          UserStreet.BackColor = Color.Red;
          return false;
      }

      TextBox HomeNumber = (TextBox)x.Controls.Find("textBoxUserHomeNumber", true)[0];
      if (!Validation.Name(lastName.Text))
      {
          HomeNumber.BackColor = Color.Red;
          return false;
      }

      TextBox UserCity = (TextBox)x.Controls.Find("textBoxUserCity", true)[0];
      if (!Validation.Name(lastName.Text))
      {
          UserCity.BackColor = Color.Red;
          return false;
      }

      TextBox UserPLZ = (TextBox)x.Controls.Find("textBoxUserPLZ", true)[0];
      if (!Validation.Name(lastName.Text))
      {
          UserPLZ.BackColor = Color.Red;
          return false;
      }
         */        

      return true;
        
    }

  }
}