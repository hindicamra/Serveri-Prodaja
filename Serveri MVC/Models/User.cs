using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serveri_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}