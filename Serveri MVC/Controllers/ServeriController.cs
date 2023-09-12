using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serveri_MVC.DAL;
using Serveri_MVC.Models;

namespace Serveri_MVC.Controllers
{
    public class ServeriController : Controller
    {
        // GET: Serveri
        public ActionResult Index(int? RamKolicina, string cena)
        {
            mssql s = new mssql();
            if (RamKolicina == null || RamKolicina == 0)
            {
                if(cena== "Viša=>Niža")
                {
                    List<serveriPonuda> srv = s.serveriPonuda.OrderByDescending(x => x.cijena).ToList();
                    ViewData["srv"] = srv;
                }
                    
                if (cena == "Niža=>Viša")
                {
                    List<serveriPonuda> srv = s.serveriPonuda.OrderBy(x => x.cijena).ToList();
                    ViewData["srv"] = srv;
                }
                if (cena == "" || cena==null)
                {
                    List<serveriPonuda> srv = s.serveriPonuda.ToList();
                    ViewData["srv"] = srv;
                }
            }
            else
            {
                if (cena == "Viša=>Niža")
                {
                    List<serveriPonuda> srv = s.serveriPonuda.Where(x => x.RAM == RamKolicina).OrderByDescending(x => x.cijena).ToList();
                    ViewData["srv"] = srv;
                }

                if (cena == "Niža=>Viša")
                {
                    List<serveriPonuda> srv = s.serveriPonuda.Where(x => x.RAM == RamKolicina).OrderBy(x => x.cijena).ToList();
                    ViewData["srv"] = srv;
                }
                if (cena == "" || cena == null)
                {
                    List<serveriPonuda> srv = s.serveriPonuda.Where(x => x.RAM == RamKolicina).ToList();
                    ViewData["srv"] = srv;
                }
                
            }
                
            

            List<RamVM> srvRam = s.serveriPonuda.Select(x => new RamVM { KolicinaRama = x.RAM}).Distinct().ToList();
            ViewData["srvRam"] = srvRam;

            return View();
        }
        public ActionResult Index2(List<serveriPonuda> srv)
        {
            mssql s = new mssql();

            ViewData["srv"] = srv;

            List<RamVM> srvRam = s.serveriPonuda.Select(x => new RamVM { KolicinaRama = x.RAM }).Distinct().ToList();
            ViewData["srvRam"] = srvRam;

            return View("index");
        }
    }
}