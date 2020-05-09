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
    public class ViaturasController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        // GET: Viaturas
        public ActionResult Index()
        {
            var viatura = db.Viatura.Include(v => v.Contrato).Include(v => v.Kilometros).Include(v => v.Manutençao);
            return View(viatura.ToList());
        }

        // GET: Viaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viatura viatura = db.Viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // GET: Viaturas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Contrato = new SelectList(db.Contrato, "Id_Contrato", "NomeFornecedor");
            ViewBag.Id_Viatura = new SelectList(db.Kilometros, "Id_Viatura", "Matricula");
            ViewBag.Id_Viatura = new SelectList(db.Manutençao, "Id_Viatura", "Matricula");
            return View();
        }

        // POST: Viaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Contrato,Id_Viatura,Matricula,Marca,Modelo,NºProcedimento,PedidoCompra,Combustivel,PreçoTotal")] Viatura viatura)
        {
            if (ModelState.IsValid)
            {
                db.Viatura.Add(viatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Contrato = new SelectList(db.Contrato, "Id_Contrato", "NomeFornecedor", viatura.Id_Contrato);
            ViewBag.Id_Viatura = new SelectList(db.Kilometros, "Id_Viatura", "Matricula", viatura.Id_Viatura);
            ViewBag.Id_Viatura = new SelectList(db.Manutençao, "Id_Viatura", "Matricula", viatura.Id_Viatura);
            return View(viatura);
        }

        // GET: Viaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viatura viatura = db.Viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Contrato = new SelectList(db.Contrato, "Id_Contrato", "NomeFornecedor", viatura.Id_Contrato);
            ViewBag.Id_Viatura = new SelectList(db.Kilometros, "Id_Viatura", "Matricula", viatura.Id_Viatura);
            ViewBag.Id_Viatura = new SelectList(db.Manutençao, "Id_Viatura", "Matricula", viatura.Id_Viatura);
            return View(viatura);
        }

        // POST: Viaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Contrato,Id_Viatura,Matricula,Marca,Modelo,NºProcedimento,PedidoCompra,Combustivel,PreçoTotal")] Viatura viatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Contrato = new SelectList(db.Contrato, "Id_Contrato", "NomeFornecedor", viatura.Id_Contrato);
            ViewBag.Id_Viatura = new SelectList(db.Kilometros, "Id_Viatura", "Matricula", viatura.Id_Viatura);
            ViewBag.Id_Viatura = new SelectList(db.Manutençao, "Id_Viatura", "Matricula", viatura.Id_Viatura);
            return View(viatura);
        }

        // GET: Viaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viatura viatura = db.Viatura.Find(id);
            if (viatura == null)
            {
                return HttpNotFound();
            }
            return View(viatura);
        }

        // POST: Viaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viatura viatura = db.Viatura.Find(id);
            db.Viatura.Remove(viatura);
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
