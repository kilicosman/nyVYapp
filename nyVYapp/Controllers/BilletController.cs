using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nyVYapp.Models;


namespace nyVYapp.Controllers
{
    public class BilletController : Controller
    {
        // GET: Billet
        public ActionResult Index()
        {
            var db = new DB();
            List<Billet> alleBestillinger = db.listAlleBestillinger();
            return View(alleBestillinger);
        }
        public ActionResult Bestilling()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Bestilling(Billet innBillet)
        {
            var db = new DB();
            if (db.settInnBestilling(innBillet))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        /*For å gjøre endringer på billetter. ikke klar ennå.
        public ActionResult Endre(int Bid)
         {
            var db = new DB();
            Bestilling enBestilling = db.hentBestilling(Bid);
            return View;
         }
    }

    [HttpPost]

        public ActionResult Endre(Billet enBestilling)
         {

            var db = new DB();
            bool OK = db.endreBestilling(enBestilling);
          if (OK)
          {
             return RedirectToAction ("Index");
          }
             return View();
         }
         */

    /*feil håndtering
        public ActionResult Slett(int Bid)
        {
            var db = new DB();
            if (!db.slettBestilling(Bid))
            {
              
            }
            return RedirectToAction("Index");
        }

    }*/
    }