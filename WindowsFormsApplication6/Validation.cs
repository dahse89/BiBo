using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
      return (!isEmpty(s) && (isAlphabetic(s) || isNumeric(s)));
    }
    public static bool zipCode(string s)
    {
      return Regex.IsMatch(s, "\\d{5}");  
      // 5 - stellige Zahlen
    }
    public static bool TelNumber(string s)
    {
      return Regex.IsMatch(s, "^\\(\\d{1,2}(\\s\\d{1,2}){1,2}\\)\\s(\\d{1,2}(\\s\\d{1,2}){1,2})((-(\\d{1,4})){0,1})$");
      // Deutsche Telefonnummer nach DIN 5008: 1996-0 (z. B. (0 34 56) 34 56 67, (03 45) 5 67 67, (0 45) 2 33 45-45)
    }
    public static bool MobileNumber(string s)
    {
      return Regex.IsMatch(s, "(015[1|2|7|9])\\d{7,9}|(016[0|2|3])\\d{7,9}|(017[0-9])\\d{7,9}");
      // alle deutschen Handynummern
    }

    public static bool validateCustomerAddPanel(Control x)
    {
      TextBox firstName = (TextBox) x.Controls.Find("textBoxUserFirstname", true)[0];

      if (!Validation.Name( firstName.Text ))
      {
        firstName.BackColor = Color.Red;
        return false;
      }
      return true;
    }

  }
}
