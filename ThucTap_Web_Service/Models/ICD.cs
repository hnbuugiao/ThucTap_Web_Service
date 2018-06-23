using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThucTap_Web_Service.Models
{
    public class ICD
    {
        public string maicd { get; set; }
        public string tenviet { get; set; }

        public ICD() { }
        public ICD(string maicd, string tenviet)
        {
            this.maicd = maicd;
            this.tenviet = tenviet;
            
        }
    }
}