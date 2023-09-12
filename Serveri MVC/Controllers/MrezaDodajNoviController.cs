using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serveri_MVC.DAL;
using Serveri_MVC.Models;

namespace Serveri_MVC.Controllers
{
    public class MrezaDodajNoviController : Controller
    {
        // GET: MrezaDodajNovi
        public ActionResult Index()
        {
            if (Session["user"]==null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        public ActionResult Snimi(string TextNazivKomponente, string TextSpecifikacija, string TextCijena, string TextOLXLink)
        {
            mssql sql = new mssql();
            mrezaPonuda m = new mrezaPonuda();
            m.NazivMrezneKonponente = TextNazivKomponente;
            m.specifikacija = TextSpecifikacija;
            m.cijena = TextCijena;
            m.OLXLink = TextOLXLink;

            sql.mrezaPonuda.Add(m);
            sql.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Pregled()
        {
            mssql sql = new mssql();
            List<mrezaPonuda> m = sql.mrezaPonuda.ToList();
            ViewData["mp"] = m;
            return View("Pregled");
        }

        public ActionResult Delete(int id)
        {
            mssql sql = new mssql();
            sql.mrezaPonuda.Remove(sql.mrezaPonuda.Single(x => x.Id == id));
            sql.SaveChanges();
            return RedirectToAction("Pregled");
        }

        public ActionResult Edit(int id)
        {
            mssql sql = new mssql();
            mrezaPonuda mp = sql.mrezaPonuda.Single(x => x.Id == id);
            ViewData["mp"] = mp;
            return View("Edit");
        }

        public ActionResult EditSave(int id, string TextNazivMrezneKomponente, string TextSpecifikacija, string TextCijena, string TextOLXLink)
        {
            mssql sql = new mssql();
            mrezaPonuda mp = sql.mrezaPonuda.Single(x => x.Id == id);
            mp.NazivMrezneKonponente = TextNazivMrezneKomponente;
            mp.specifikacija = TextSpecifikacija;
            mp.cijena = TextCijena;
            mp.OLXLink = TextOLXLink;
            sql.SaveChanges();

            return RedirectToAction("Pregled");
        }
    }
}