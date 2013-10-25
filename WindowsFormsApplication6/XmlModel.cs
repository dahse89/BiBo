using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace BiBo
{
  class XmlModel
  {
    public XmlModel()
    {
      if (File.Exists("Customers.xml"))
      {
        XmlTextReader customersReader = new XmlTextReader("Customers.xml");
      }
      else
      {
        XmlDocument customersXml = new XmlDocument();
        XmlNode xmlRoot;
        xmlRoot = customersXml.CreateElement("Customershere");
        customersXml.AppendChild(xmlRoot);
        customersXml.Save("Customers.xml");
      }
    }
  }
}
