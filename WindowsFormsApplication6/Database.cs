using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BiBo
{
  [XmlRoot("Database"), Serializable]
  class Database
  {
    [XmlElement("Customer")]
    public Customer customer { get; set; }
  }
}
