using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace BiBo
{
  class XmlModel
  {
    // Initialisiert die "Datenbank"
    // Sorgt dafür, dass bei jedem Aufruf auf jeden Fall eine Database.xml Datei vorhanden ist
    public XmlModel()
    {
      if (!File.Exists("Database.xml"))
      {
        XmlDocument customersXml = new XmlDocument();
        XmlNode xmlRoot;
        xmlRoot = customersXml.CreateElement("Database");
        customersXml.AppendChild(xmlRoot);
        customersXml.Save("Database.xml");
      }
      else
      {
        XmlSerializer serializer = new XmlSerializer(typeof(Database));
        FileStream loadStream = new FileStream("Database.xml", FileMode.Open, FileAccess.Read);
        Database loadedObject = (Database)serializer.Deserialize(loadStream);
        loadStream.Close();
      }
    }

    // Wandelt ein Customer Object in XML Code um
    // und speichert diesen in die geöffnete XML Datei
    public bool addCustomer(Customer customer)
    {
      TextWriter WriteFileStream = new StreamWriter("Database.xml");
      XmlSerializer xmlSerializer = new XmlSerializer(customer.GetType());

      xmlSerializer.Serialize(WriteFileStream, customer);
      return true;
    }
  }
}
