using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nyVYapp.Models
{


    public class Billet
    {
        public int Bid { get; set; }  
        public string reiseFra { get; set; }

        public string reiseTil { get; set; }
        public string dato { get; set; }

        public string tid { get; set; }
        public string reisende { get; set; }

        public int antall { get; set; }
        public string navn { get; set; }
        public string epost { get; set; }
        public string telefonnr { get; set; }
    }
}