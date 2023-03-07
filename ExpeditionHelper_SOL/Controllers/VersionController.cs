using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpeditionHelper_SOL.Models;
using PagedList;

namespace ExpeditionHelper_SOL.Controllers
{
    public class VersionController : BaseController
    {
        // Initialisation Base de données
        private ExpeditionHelper_SOLEntities db = new ExpeditionHelper_SOLEntities();

        // Index Version
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            var VersionLinq = from version in db.TB_VERSION
                      select version;

            //Gestion du numéro de page
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //Gestion de la recherche par nom
            if (!String.IsNullOrEmpty(searchString))
            {
                VersionLinq = VersionLinq.Where(version => version.Nom.Contains(searchString));
            }

            VersionLinq = VersionLinq.OrderBy(version => version.Nom);

            //Gestion des pages
            int pageSize = 25;
            int pageNumber = (page ?? 1);

            return View(VersionLinq.ToPagedList(pageNumber, pageSize));
        }

        // Liste Ajout Version
        public ActionResult Create()
        {
            return View();
        }

        // Ajout Version
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Auteur,Description,Date_Prod,prod")] TB_VERSION tB_VERSION)
        {
            if (ModelState.IsValid)
            {
                if (tB_VERSION.prod == "1")
                {
                    foreach (var item in db.TB_VERSION.ToList())
                    {
                        item.prod = "0";

                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                db.TB_VERSION.Add(tB_VERSION);

                // Création des logs
                TB_LOG tB_LOG = new TB_LOG();
                tB_LOG.Login = Session["login"].ToString();
                tB_LOG.Date = DateTime.Now.ToString();
                tB_LOG.Action = "Création d'une nouvelle version : '" + tB_VERSION.Nom + "'";
                tB_LOG.Texte = "Nom de la version : '" + tB_VERSION.Nom + "'/Separation/Description : '" + tB_VERSION.Description + "'";
                db.TB_LOG.Add(tB_LOG);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_VERSION);
        }

        // Liste Edition Version
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_VERSION tB_VERSION = db.TB_VERSION.Find(id);

            var VersionLinq = from version in db.TB_VERSION
                          where version.Id == id
                          select version;

            ViewBag.VersionLinq = VersionLinq;

            if (tB_VERSION == null)
            {
                return HttpNotFound();
            }
            return View(tB_VERSION);
        }

        // Edition Version
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Auteur,Description,Date_Prod,prod")] TB_VERSION tB_VERSION)
        {

            if (ModelState.IsValid)
            {
                db.Entry(tB_VERSION).State = EntityState.Modified;
                db.SaveChanges();
            }


            if (tB_VERSION.prod == "1")
            {
                var VersionLinq = from version in db.TB_VERSION
                                  where version.Id != tB_VERSION.Id
                                  select version;

                foreach (var item in VersionLinq)
                {
                    item.prod = "0";
                    if (ModelState.IsValid)
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                }
            }

            // Création des logs
            TB_LOG tB_LOG = new TB_LOG();
            tB_LOG.Login = Session["login"].ToString();
            tB_LOG.Date = DateTime.Now.ToString();
            tB_LOG.Action = "Modification d'une version : '" + tB_VERSION.Nom + "'";
            tB_LOG.Texte = "Nouveau nom de la version : '" + tB_VERSION.Nom + "'/Separation/Nouvelle description : '" + tB_VERSION.Description + "'";
            db.TB_LOG.Add(tB_LOG);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Liste Suppression Version
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_VERSION tB_VERSION = db.TB_VERSION.Find(id);

            var VersionLinq = from version in db.TB_VERSION
                              where version.Id == id
                              select version;

            ViewBag.VersionLinq = VersionLinq;
            if (tB_VERSION == null)
            {
                return HttpNotFound();
            }
            return View(tB_VERSION);
        }

        // Liste Suppression Version
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_VERSION tB_VERSION = db.TB_VERSION.Find(id);
            db.TB_VERSION.Remove(tB_VERSION);

            // Création des logs
            TB_LOG tB_LOG = new TB_LOG();
            tB_LOG.Login = Session["login"].ToString();
            tB_LOG.Date = DateTime.Now.ToString();
            tB_LOG.Action = "Suppression d'une version : '" + tB_VERSION.Nom + "'";
            tB_LOG.Texte = "Nom de la version : '" + tB_VERSION.Nom + "'/Separation/Description : '" + tB_VERSION.Description + "'";
            db.TB_LOG.Add(tB_LOG);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Récupération derniere version pour le menu
        [ChildActionOnly]
        [ValidateInput(false)]
        [AllowAnonymous]
        public ActionResult GetLastVersion()
        {
            int flag = 0;
            var VersionLinq = from version1 in db.TB_VERSION
                              where version1.prod == "1"
                              select version1;

            //foreach (var item in VersionLinq)
            //{
            //    flag = 1;
            //    ViewBag.Num_Version = item.Nom;
            //}

            if (flag == 0)
            {
                ViewBag.Num_Version = "0.0";
            }

            return PartialView("_LastVersion");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
