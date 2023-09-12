using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Serveri_MVC.DAL;
using Serveri_MVC.Models;

namespace Serveri_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            mssql sql = new mssql();
            log newLog = new log();
            newLog.accessTime = DateTime.Now;
            newLog.IP = Request.UserHostAddress + ", " + Request.UserAgent + ", " + Request.UserHostName + ", " +
                        Request.UserLanguages + ", " + Request.LogonUserIdentity;
            newLog.user = "GET LOGIN";
            newLog.password = "GET LOGIN";
            sql.log.Add(newLog);
            sql.SaveChanges();

            var user = Session["user"] as User;
            if (user != null)
                    return RedirectToAction("Pregled", "ServerDodajNovi");
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            mssql sql = new mssql();
            User usr = sql.User.Where(x => x.UserName == name).Where(x => x.Password == password).FirstOrDefault();                  

            if (usr==null)
            {
                log newLog = new log();
                newLog.accessTime = DateTime.Now;
                newLog.user = name;
                newLog.password = password;
                newLog.IP = Request.UserHostAddress + ", " + Request.UserAgent + ", " + Request.UserHostName + ", " +
                            Request.UserLanguages + ", " + Request.LogonUserIdentity;
                sql.log.Add(newLog);
                sql.SaveChanges();

                return RedirectToAction("Login", "Login");
            }
            if (usr.UserName==name && usr.Password==password)
            {
                log newLog = new log();
                newLog.accessTime = DateTime.Now;
                newLog.user = name.Substring(0, 2);
                newLog.password = "***";
                newLog.IP = Request.UserHostAddress + ", " + Request.UserAgent + ", " + Request.UserHostName + ", " +
                            Request.UserLanguages + ", " + Request.LogonUserIdentity;
                sql.log.Add(newLog);
                sql.SaveChanges();

                Session["user"] = new User() {Login = name, UserName = usr.Login};
                return RedirectToAction("Pregled", "ServerDodajNovi");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            //ili Session["user"]=null;
            return RedirectToAction("Login");
        }

        public ActionResult index()
        {
            return View("index");
        }
    }
}