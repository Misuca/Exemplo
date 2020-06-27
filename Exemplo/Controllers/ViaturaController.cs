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
    public class ViaturaController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        // GET: Viatura
        public ActionResult Index(string pesquisa = "")
        {
            var viaturas = db.Viatura.Where((viatura) => viatura.Matricula.Contains(pesquisa) || viatura.Marca.Contains(pesquisa) || viatura.Modelo.Contains(pesquisa)
            || viatura.Contrato.NºProcedimento.Contains(pesquisa) || viatura.Contrato.PedidoCompra.Contains(pesquisa) || viatura.Combustivel.Contains(pesquisa));
            return View(viaturas.ToList());
        }

        // GET: Viatura/Details/5
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

        // GET: Viatura/Create
        public ActionResult Create()
        {
           
            ViewBag.NºProcedimento = new SelectList(db.Contrato, "Id_Contrato", "NºProcedimento");
            ViewBag.PedidoCompra = new SelectList(db.Contrato, "Id_Contrato", "PedidoCompra");
            return View();
        }

        // POST: Viatura/Create
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

            
            ViewBag.NºProcedimento = new SelectList(db.Contrato, "Id_Contrato", "NºProcedimento", viatura.Id_Contrato);
            ViewBag.PedidoCompra = new SelectList(db.Contrato, "Id_Contrato", "PedidoCompra", viatura.Id_Contrato);
          
            return View(viatura);
        }

        // GET: Viatura/Edit/5
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
            
            ViewBag.NºProcedimento = new SelectList(db.Contrato, "Id_Contrato", "NºProcedimento", viatura.Id_Contrato);
            ViewBag.PedidoCompra = new SelectList(db.Contrato, "Id_Contrato", "PedidoCompra", viatura.Id_Contrato);
            return View(viatura);
        }

        // POST: Viatura/Edit/5
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
            
            ViewBag.NºProcedimento = new SelectList(db.Contrato, "Id_Contrato", "NºProcedimento", viatura.Id_Contrato);
            ViewBag.PedidoCompra = new SelectList(db.Contrato, "Id_Contrato", "PedidoCompra", viatura.Id_Contrato);
            return View(viatura);
        }

        // GET: Viatura/Delete/5
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

        // POST: Viatura/Delete/5
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
