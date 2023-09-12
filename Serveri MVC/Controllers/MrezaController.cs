using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serveri_MVC.DAL;
using Serveri_MVC.Models;

namespace Serveri_MVC.Controllers
{
    public class MrezaController : Controller
    {
        // GET: Mreza
        public ActionResult Index()
        {
            mssql s = new mssql();
            List<mrezaPonuda> mrz = s.mrezaPonuda.ToList();
            ViewData["mrz"] = mrz;
            return View();
        }
    }
}