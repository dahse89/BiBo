using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Deployment.Application;
using System.Xml;

namespace BiBo.Updater
{
    class BiboUpdater
    {
        string url = "";
        XmlTextReader reader;
        Version newVersion = null;  

        public Version AssemblyVersion
        {
            get
            {
                try
                {
                    return ApplicationDeployment.CurrentDeployment.CurrentVersion;
                }
                catch
                {
                    return new Version("1.3.3.7");
                }
            }
        }

        public void checkForNewVersion()
        {
            try
            {
                string xmlURL = "http://bibo.vicodambeck.de/app_version.xml";
                reader = new XmlTextReader(xmlURL);
                reader.MoveToContent();
                string elementName = "";
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "versionInfo"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) &&
                                (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "version":
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        url = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            if (curVersion < newVersion)
            {
                System.Diagnostics.Process.Start(url);
            } 
        }
        public override string ToString()
        {
            return ""+this.AssemblyVersion;
        }
    }
}
