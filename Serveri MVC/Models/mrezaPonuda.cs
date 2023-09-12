using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serveri_MVC.Models
{
    public class mrezaPonuda
    {
        public int Id { get; set; }
        public string NazivMrezneKonponente { get; set; }
        public string specifikacija { get; set; }
        public string cijena { get; set; }
        public string OLXLink { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}