using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo.Exception
{
    [Serializable()] 
    class BookNotFoundException : System.Exception
    {
        public BookNotFoundException(string message): base(message)
        {
        
        }
    }
}
