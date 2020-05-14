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
    public class UPController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        // GET: UP
        public ActionResult Index()
        {
            var utilizaçao_Permanente = db.Utilizaçao_Permanente.Include(u => u.Utilizador).Include(u => u.Viatura);
            return View(utilizaçao_Permanente.ToList());
        }

        // GET: UP/Details/5
        public ActionResult Details(int? idUtilizador, int? idViatura)
        {
            if (idUtilizador == null || idViatura == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizaçao_Permanente utilizaçao_Permanente = db.Utilizaçao_Permanente.Find(idUtilizador, idViatura);
            if (utilizaçao_Permanente == null)
            {
                return HttpNotFound();
            }
            return View(utilizaçao_Permanente);
        }

        // GET: UP/Create
        public ActionResult Create()
        {
            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome");
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula");
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula");
            return View();
        }

        // POST: UP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Utilizador,Id_Viatura,Matricula,DataInicio,DataFim")] Utilizaçao_Permanente utilizaçao_Permanente)
        {
            if (ModelState.IsValid)
            {
                db.Utilizaçao_Permanente.Add(utilizaçao_Permanente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome", utilizaçao_Permanente.Id_Utilizador);
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", utilizaçao_Permanente.Id_Viatura);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", utilizaçao_Permanente.Matricula);
            return View(utilizaçao_Permanente);
        }

        // GET: UP/Edit/5
        public ActionResult Edit(int? idUtilizador , int? idViatura)
        {
            if (idUtilizador == null || idViatura == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizaçao_Permanente utilizaçao_Permanente = db.Utilizaçao_Permanente.Find(idUtilizador , idViatura);
            if (utilizaçao_Permanente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome", utilizaçao_Permanente.Id_Utilizador);
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", utilizaçao_Permanente.Id_Viatura);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", utilizaçao_Permanente.Matricula);
            return View(utilizaçao_Permanente);
        }

        // POST: UP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Utilizador,Id_Viatura,Matricula,DataInicio,DataFim")] Utilizaçao_Permanente utilizaçao_Permanente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizaçao_Permanente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome", utilizaçao_Permanente.Id_Utilizador);
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", utilizaçao_Permanente.Id_Viatura);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", utilizaçao_Permanente.Matricula);
            return View(utilizaçao_Permanente);
        }

        // GET: UP/Delete/5
        public ActionResult Delete(int? idUtilizador, int?idViatura)
        {
            if (idUtilizador == null || idViatura == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizaçao_Permanente utilizaçao_Permanente = db.Utilizaçao_Permanente.Find(idUtilizador , idViatura);
            if (utilizaçao_Permanente == null)
            {
                return HttpNotFound();
            }
            return View(utilizaçao_Permanente);
        }

        // POST: UP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? idUtilizador , int?idViatura)
        {
            Utilizaçao_Permanente utilizaçao_Permanente = db.Utilizaçao_Permanente.Find(idUtilizador,idViatura);
            db.Utilizaçao_Permanente.Remove(utilizaçao_Permanente);
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
