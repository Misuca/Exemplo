﻿using System;
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
    public class FornecedoresController : Controller
    {
        private Gestão_de_Frota_de_AutomoveisEntities db = new Gestão_de_Frota_de_AutomoveisEntities();

        // GET: Fornecedores
        public ActionResult Index(string pesquisa = "")
        {
            var fornecedores = db.Fornecedores.Where((fornecedor) => fornecedor.Localidade.Contains(pesquisa) || fornecedor.NomeFornecedor.Contains(pesquisa) 
            || fornecedor.NIPC.Contains(pesquisa) || fornecedor.Morada.Contains(pesquisa) || fornecedor.CodigoPostal.Contains(pesquisa) 
            || fornecedor.Telefone.Contains(pesquisa) || fornecedor.Email.Contains(pesquisa));
            return View(fornecedores.ToList());
        }

        // GET: Fornecedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            if (fornecedores == null)
            {
                return HttpNotFound();
            }
            return View(fornecedores);
        }

        // GET: Fornecedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Fornecedor,NomeFornecedor,NIPC,Morada,CodigoPostal,Localidade,Telefone,Email")] Fornecedores fornecedores)
        {
            if (ModelState.IsValid)
            {
                db.Fornecedores.Add(fornecedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedores);
        }

        // GET: Fornecedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            if (fornecedores == null)
            {
                return HttpNotFound();
            }
            return View(fornecedores);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Fornecedor,NomeFornecedor,NIPC,Morada,CodigoPostal,Localidade,Telefone,Email")] Fornecedores fornecedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedores);
        }

        // GET: Fornecedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            if (fornecedores == null)
            {
                return HttpNotFound();
            }
            return View(fornecedores);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedores fornecedores = db.Fornecedores.Find(id);
            db.Fornecedores.Remove(fornecedores);
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
