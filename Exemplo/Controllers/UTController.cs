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
    public class UTController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        // GET: UT
        public ActionResult Index()
        {
            var utilizaçao_Temporaria = db.Utilizaçao_Temporaria.Include(u => u.Utilizador);
            return View(utilizaçao_Temporaria.ToList());
        }

        // GET: UT/Details/5
        public ActionResult Details(int? idUtilizador, int? idViatura)
        {
            if (idUtilizador == null || idViatura == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizaçao_Temporaria utilizaçao_Temporaria = db.Utilizaçao_Temporaria.Find(idUtilizador, idViatura);
            if (utilizaçao_Temporaria == null)
            {
                return HttpNotFound();
            }
            return View(utilizaçao_Temporaria);
        }

        // GET: UT/Create
        public ActionResult Create()
        {
            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome");
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula");
            return View();
        }

        // POST: UT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Utilizador,Id_Viatura,Matricula,DataInicio,DataFim,HoraInicio,HoraFim")] Utilizaçao_Temporaria utilizaçao_Temporaria)
        {
            if (ModelState.IsValid)
            {
                db.Utilizaçao_Temporaria.Add(utilizaçao_Temporaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome", utilizaçao_Temporaria.Id_Utilizador);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula" , utilizaçao_Temporaria.Matricula);
            return View(utilizaçao_Temporaria);
        }

        // GET: UT/Edit/5
        public ActionResult Edit(int? idUtilizador , int? idViatura)
        {
            if (idUtilizador == null || idViatura == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizaçao_Temporaria utilizaçao_Temporaria = db.Utilizaçao_Temporaria.Find(idUtilizador,idViatura);
            if (utilizaçao_Temporaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome", utilizaçao_Temporaria.Id_Utilizador);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", utilizaçao_Temporaria.Matricula);
            return View(utilizaçao_Temporaria);
        }

        // POST: UT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Utilizador,Id_Viatura,Matricula,DataInicio,DataFim,HoraInicio,HoraFim")] Utilizaçao_Temporaria utilizaçao_Temporaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilizaçao_Temporaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Utilizador = new SelectList(db.Utilizador, "Id_Utilizador", "Nome", utilizaçao_Temporaria.Id_Utilizador);
            ViewBag.Matricula = new SelectList(db.Viatura, "Matricula", "Matricula", utilizaçao_Temporaria.Matricula);
            return View(utilizaçao_Temporaria);
        }

        // GET: UT/Delete/5
        public ActionResult Delete(int? idUtilizador , int? idViatura)
        {
            if (idUtilizador == null || idViatura == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizaçao_Temporaria utilizaçao_Temporaria = db.Utilizaçao_Temporaria.Find(idUtilizador , idViatura);
            if (utilizaçao_Temporaria == null)
            {
                return HttpNotFound();
            }
            return View(utilizaçao_Temporaria);
        }

        // POST: UT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? idUtilizador , int? idViatura)
        {
            Utilizaçao_Temporaria utilizaçao_Temporaria = db.Utilizaçao_Temporaria.Find(idUtilizador , idViatura);
            db.Utilizaçao_Temporaria.Remove(utilizaçao_Temporaria);
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
