using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exemplo.Models;

namespace Exemplo.Controllers
{
    public class KilometrosController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        
        public ActionResult Index(string pesquisa = "")
        {
            var kilometros = db.Kilometros.Where((kilometro) => kilometro.Viatura.Matricula.Contains(pesquisa));
            return View(kilometros.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kilometros kilometros = db.Kilometros.Find(id);
            if (kilometros == null)
            {
                return HttpNotFound();
            }
            return View(kilometros);
        }

       
        public ActionResult Create()
        {
            
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Viatura,QuantidadeKm,DataRegisto")] Kilometros kilometros)
        {
            if (ModelState.IsValid)
            {
                db.Kilometros.Add(kilometros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", kilometros.Id_Viatura);
            return View(kilometros);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kilometros kilometros = db.Kilometros.Find(id);
            if (kilometros == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", kilometros.Id_Viatura);
            return View(kilometros);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Kilometros,Id_Viatura,QuantidadeKm,DataRegisto")] Kilometros kilometros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kilometros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", kilometros.Id_Viatura);
            return View(kilometros);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kilometros kilometros = db.Kilometros.Find(id);
            if (kilometros == null)
            {
                return HttpNotFound();
            }
            return View(kilometros);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Kilometros kilometros = db.Kilometros.Find(id);
            db.Kilometros.Remove(kilometros);
            db.SaveChanges();
            return RedirectToAction("Index");
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
