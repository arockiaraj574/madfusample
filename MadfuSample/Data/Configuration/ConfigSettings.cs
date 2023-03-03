using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
   public class ConfigSettings
    {

        public AWSDefault AWS { get; set; }
        public string Environment { get; set; }
        public string ImageURLPrefix { get; set; }

        public bool IsProduction { get { return this.Environment.Equals("Production"); } }
        public bool IsStaging { get { return this.Environment.Equals("Staging"); } }
        public bool IsDevelopment { get { return this.Environment.Equals("Development"); } }
        public bool IsTest { get { return this.Environment.Equals("Test"); } }
    }
}
