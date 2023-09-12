using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serveri_MVC.Models
{
    public class serveriPonuda
    {
        public int Id { get; set; }
        public string NazivServera { get; set; }
        public Int32 RAM { get; set; }
        public string specifikacija { get; set; }
        public Int32 cijena { get; set; }
        public string OLXLink { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}