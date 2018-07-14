using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Financeiro.Conexao;
using Financeiro.Models;

namespace Financeiro.Controllers
{
    public class tp_contaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: tp_conta
        public async Task<ActionResult> Index()
        {
            return View(await db.tp_conta.ToListAsync());
        }

        // GET: tp_conta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_conta tp_conta = await db.tp_conta.FindAsync(id);
            if (tp_conta == null)
            {
                return HttpNotFound();
            }
            return View(tp_conta);
        }

        // GET: tp_conta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tp_conta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idtp_conta,descricao,fundos,investimento")] tp_conta tp_conta)
        {
            if (ModelState.IsValid)
            {
                db.tp_conta.Add(tp_conta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tp_conta);
        }

        // GET: tp_conta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_conta tp_conta = await db.tp_conta.FindAsync(id);
            if (tp_conta == null)
            {
                return HttpNotFound();
            }
            return View(tp_conta);
        }

        // POST: tp_conta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idtp_conta,descricao,fundos,investimento")] tp_conta tp_conta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tp_conta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tp_conta);
        }

        // GET: tp_conta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_conta tp_conta = await db.tp_conta.FindAsync(id);
            if (tp_conta == null)
            {
                return HttpNotFound();
            }
            return View(tp_conta);
        }

        // POST: tp_conta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tp_conta tp_conta = await db.tp_conta.FindAsync(id);
            db.tp_conta.Remove(tp_conta);
            await db.SaveChangesAsync();
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
