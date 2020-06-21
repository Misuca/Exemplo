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
    public class DespesaController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        // GET: Despesa
        public ActionResult Index(string pesquisa = "")
        {
            var despesas = db.Despesa.Where((despesa) => despesa.NomeDespesa.Contains(pesquisa)||despesa.Viatura.Matricula.Contains(pesquisa));
            return View(despesas.ToList());
        }

        // GET: Despesa/Details/5
        public ActionResult Details(int? idViatura , int? idFornecedor)
        {
            if (idViatura == null || idFornecedor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesa.Find(idViatura, idFornecedor);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // GET: Despesa/Create
        public ActionResult Create()
        {
            ViewBag.Id_Fornecedor = new SelectList(db.Fornecedores, "Id_Fornecedor", "NomeFornecedor");
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula");
            return View();
        }

        // POST: Despesa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Viatura,Id_Fornecedor,Matricula,DataDespesa,NºFatura,PedidoCompra,Preço,NomeDespesa")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Despesa.Add(despesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Fornecedor = new SelectList(db.Fornecedores, "Id_Fornecedor", "NomeFornecedor", despesa.Id_Fornecedor);
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", despesa.Id_Viatura);
            return View(despesa);
        }

        // GET: Despesa/Edit/5
        public ActionResult Edit(int? idViatura, int? idFornecedor)
        {
            if (idViatura == null || idFornecedor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesa.Find(idViatura, idFornecedor);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Fornecedor = new SelectList(db.Fornecedores, "Id_Fornecedor", "NomeFornecedor", despesa.Id_Fornecedor);
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", despesa.Id_Viatura);
            return View(despesa);
        }

        // POST: Despesa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Viatura,Id_Fornecedor,Matricula,DataDespesa,NºFatura,PedidoCompra,Preço,NomeDespesa")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Fornecedor = new SelectList(db.Fornecedores, "Id_Fornecedor", "NomeFornecedor", despesa.Id_Fornecedor);
            ViewBag.Id_Viatura = new SelectList(db.Viatura, "Id_Viatura", "Matricula", despesa.Id_Viatura);
            return View(despesa);
        }

        // GET: Despesa/Delete/5
        public ActionResult Delete(int? idViatura , int? idFornecedor)
        {
            if (idViatura == null || idFornecedor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesa.Find(idViatura,idFornecedor);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // POST: Despesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? idViatura, int? idFornecedor)
        {
            Despesa despesa = db.Despesa.Find(idViatura , idFornecedor);
            db.Despesa.Remove(despesa);
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
