using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serveri_MVC.DAL;

namespace Serveri_MVC.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
            mssql sql = new mssql();
            ViewData["logs"] = sql.log.OrderByDescending(x => x.Id).Take(100).ToList();
            return View();
        }
    }
}