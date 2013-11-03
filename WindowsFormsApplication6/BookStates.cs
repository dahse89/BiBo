using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBo
{
    public enum BookStates
    {
        ONLY_VISIBLE, DAMAGED, MISSING, OK
    }
    public static class Converter
    {
        public static BookStates ToBookState(string stateString)
        {
            switch (stateString)
            {
                case "only_visible": return BookStates.ONLY_VISIBLE;
            }
            throw new Exception("Falschen Status angegeben");
        }
    }
}
