using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serveri_MVC.Models
{
    public class log
    {
        public int Id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public DateTime accessTime { get; set; }
        public string IP { get; set; }
    }
}