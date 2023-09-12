using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Serveri_MVC.Models;

namespace Serveri_MVC.DAL
{
    public class mssql : DbContext
    {
        public mssql() : base("con") { }

        public DbSet<serveriPonuda> serveriPonuda { get; set; }
        public DbSet<mrezaPonuda> mrezaPonuda { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<log> log { get; set; }
    }
}