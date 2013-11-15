using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiBo.Exception
{
  class CustomerNotFoundException : System.Exception
  {
    public CustomerNotFoundException(string message)
      : base(message)
    {

    }
  }
}
