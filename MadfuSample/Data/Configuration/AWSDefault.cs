using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class AWSDefault
    {
        public SSS S3 { get; set; }
    }

    public class SSS
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Bucket { get; set; }
        public string RootLink { get; set; }
    }
}
