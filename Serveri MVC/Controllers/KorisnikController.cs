using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serveri_MVC.DAL;
using Serveri_MVC.Models;

namespace Serveri_MVC.Controllers
{
    public class KorisnikController : Controller
    {
        // GET: Korisnik
        public ActionResult Index()
        {
            mssql sql = new mssql();
            ViewData["usr"] = sql.User.ToList();
            return View();
        }

        public ActionResult Dodaj()
        {
            return View("Dodaj");
        }

        public ActionResult Snimi(string TextImeiPrezime, string TextUsername, string TextPassword)
        {
            mssql sql = new mssql();
            User usr = new User();
            usr.Login = TextImeiPrezime;
            usr.UserName = TextUsername;
            usr.Password = TextPassword;
            sql.User.Add(usr);
            sql.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            mssql sql = new mssql();
            User usr = sql.User.Single(x => x.Id == id);
            sql.User.Remove(usr);
            sql.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}