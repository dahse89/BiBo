using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BiBo.Persons;

namespace BiBo.Data
{
  [XmlRoot("Database"), Serializable]
  public class Database
  {
    [XmlElement("Customer")]
    public Customer customer { get; set; }
  }
}
