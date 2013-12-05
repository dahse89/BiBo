using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Deployment.Application;

namespace BiBo.Updater
{
    class BiboUpdater
    {
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

        public override string ToString()
        {
            return ""+this.AssemblyVersion;
        }
    }
}
