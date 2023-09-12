using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serveri_MVC.DAL;
using Serveri_MVC.Models;

namespace Serveri_MVC.Controllers
{
    public class ServerDodajNoviController : Controller
    {
        // GET: ServerDodajNovi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Snimi(string TextNazivServera, string TextSpecifikacija, string TextCijena, string TextOLXLink, string TextRAM)
        {
            serveriPonuda ns = new serveriPonuda();
            ns.NazivServera = TextNazivServera;
            ns.specifikacija = TextSpecifikacija;
            ns.cijena = Int32.Parse(TextCijena);
            ns.OLXLink = TextOLXLink;
            ns.RAM = Int32.Parse(TextRAM);

            mssql sql = new mssql();

            sql.serveriPonuda.Add(ns);
            sql.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Pregled()
        {
            mssql sql = new mssql();
            List<serveriPonuda> srv = sql.serveriPonuda.ToList();
            ViewData["srv"] = srv;
            return View("Pregled");
        }

        public ActionResult DodajSliku(int id)
        {
            ViewData["id"] = id;
            return View("Dodaj");
        }

        public ActionResult SnimiSliku(int id, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0 && id >0)
            {
                mssql sql = new mssql();
                serveriPonuda srv = sql.serveriPonuda.Single(x => x.Id == id);
                srv.FileName = System.IO.Path.GetFileName(upload.FileName);
                srv.ContentType= upload.ContentType;
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    srv.Content = reader.ReadBytes(upload.ContentLength);
                }
                sql.SaveChanges();
            }
            return RedirectToAction("Pregled");
        }

        public ActionResult Edit(int id)
        {
            mssql sql = new mssql();
            serveriPonuda sp = sql.serveriPonuda.Single(x => x.Id == id);
            ViewData["sp"] = sp;
            return View("Edit");
        }

        public ActionResult EditSave(int id, string TextNazivServera, string TextSpecifikacija, string TextCijena, string TextOLXLink, string TextRAM)
        {
            mssql sql = new mssql();
            serveriPonuda sp = sql.serveriPonuda.Single(x => x.Id == id);
            sp.NazivServera = TextNazivServera;
            sp.specifikacija = TextSpecifikacija;
            sp.cijena = Int32.Parse(TextCijena);
            sp.OLXLink = TextOLXLink;
            sp.RAM = Int32.Parse(TextRAM);
            sql.SaveChanges();

            return RedirectToAction("Pregled");
        }

        public ActionResult Delete(int id)
        {
            mssql sql = new mssql();
            sql.serveriPonuda.Remove(sql.serveriPonuda.Single(x=>x.Id==id));

            sql.SaveChanges();

            return RedirectToAction("Pregled");
        }
    }
}