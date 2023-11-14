using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mR_Utility
{
    // берем из appsettings 
    public class MailJetSettings
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
    }
}
