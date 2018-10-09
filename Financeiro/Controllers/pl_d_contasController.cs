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
    public class pl_d_contasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: pl_d_contas
        public async Task<ActionResult> Index()
        {
            return View(await db.pl_d_contas.ToListAsync());
        }

        // GET: pl_d_contas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pl_d_contas pl_d_contas = await db.pl_d_contas.FindAsync(id);
            if (pl_d_contas == null)
            {
                return HttpNotFound();
            }
            return View(pl_d_contas);
        }

        // GET: pl_d_contas/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: pl_d_contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idpl_d_contas,planoContas")] pl_d_contas pl_d_contas)
        {
            if (ModelState.IsValid)
            {
                db.pl_d_contas.Add(pl_d_contas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return PartialView(pl_d_contas);
        }

        // GET: pl_d_contas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pl_d_contas pl_d_contas = await db.pl_d_contas.FindAsync(id);
            if (pl_d_contas == null)
            {
                return HttpNotFound();
            }
            return PartialView(pl_d_contas);
        }

        // POST: pl_d_contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idpl_d_contas,planoContas")] pl_d_contas pl_d_contas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pl_d_contas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(pl_d_contas);
        }

        // GET: pl_d_contas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pl_d_contas pl_d_contas = await db.pl_d_contas.FindAsync(id);
            if (pl_d_contas == null)
            {
                return HttpNotFound();
            }
            return PartialView(pl_d_contas);
        }

        // POST: pl_d_contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            pl_d_contas pl_d_contas = await db.pl_d_contas.FindAsync(id);
            db.pl_d_contas.Remove(pl_d_contas);
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
