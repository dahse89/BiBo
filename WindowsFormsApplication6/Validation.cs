using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;  

namespace BiBo
{
  class Validation
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
      return true; // @ todo
    }

  }
}
