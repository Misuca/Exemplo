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
    public class ManutençaoController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        // GET: Manutençao
        public ActionResult Index()
        {
            var manutençao = db.Manutençao.Include(m => m.Viatura);
            return View(manutençao.ToList());
        }

        // GET: Manutençao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutençao manutençao = db.Manutençao.Find(id);
            if (manutençao == null)
            {
                return HttpNotFound();
            }
            return View(manutençao);
        }

        // GET: Manutençao/Create
        public ActionResult Create()
        {
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula");
            return View();
        }

        // POST: Manutençao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Viatura,DataManutençao,Matricula,Reparaçao,Fatura,Preço")] Manutençao manutençao)
        {
            if (ModelState.IsValid)
            {
                db.Manutençao.Add(manutençao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", manutençao.Id_Viatura);

            return View(manutençao);
        }

        // GET: Manutençao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutençao manutençao = db.Manutençao.Find(id);
            if (manutençao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", manutençao.Id_Viatura);

            return View(manutençao);
        }

        // POST: Manutençao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Viatura,DataManutençao,Matricula,Reparaçao,Fatura,Preço")] Manutençao manutençao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manutençao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", manutençao.Id_Viatura);

            return View(manutençao);
        }

        // GET: Manutençao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutençao manutençao = db.Manutençao.Find(id);
            if (manutençao == null)
            {
                return HttpNotFound();
            }
            return View(manutençao);
        }

        // POST: Manutençao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manutençao manutençao = db.Manutençao.Find(id);
            db.Manutençao.Remove(manutençao);
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
