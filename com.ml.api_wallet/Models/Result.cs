using System;

namespace com.ml.api_wallet.Models
{
    public class Result
    {
        public string message { get; set; }
        public Boolean error { get; set; }
        public int total { get; set; }
        public Object data { get; set; }
    }
}