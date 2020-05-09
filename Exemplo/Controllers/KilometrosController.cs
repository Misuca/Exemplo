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

        // GET: Kilometros
        public ActionResult Index()
        {
            var kilometros = db.Kilometros.Include(k => k.Viatura);
            return View(kilometros.ToList());
        }

        // GET: Kilometros/Details/5
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

        // GET: Kilometros/Create
        public ActionResult Create()
        {
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula");
            return View();
        }

        // POST: Kilometros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Viatura,Matricula,DataRegisto,Kilometros1")] Kilometros kilometros)
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

        // GET: Kilometros/Edit/5
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

        // POST: Kilometros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Viatura,Matricula,DataRegisto,Kilometros1")] Kilometros kilometros)
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

        // GET: Kilometros/Delete/5
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

        // POST: Kilometros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
