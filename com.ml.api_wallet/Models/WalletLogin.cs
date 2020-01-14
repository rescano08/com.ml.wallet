using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.ml.api_wallet.Models
{
    public class WalletLogin
    {
        public string email { get; set; }
        public string password { get; set; }
        public string device { get; set; }
        public string platform { get; set; }
        public string version { get; set; }
    }
}