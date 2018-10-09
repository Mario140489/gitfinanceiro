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
    public class tipo_pl_contasController : Controller
    {
        private Contexto db = new Contexto();
        static int idplcontas;
        // GET: tipo_pl_contas
        public async Task<ActionResult> Index(int id)
        {
            idplcontas = id;
            var tpplcpontas = db.tipo_pl_contas.Where( x => x.pl_d_contas_idpl_d_contas == id);
            return PartialView(await tpplcpontas.ToListAsync());
        }

        // GET: tipo_pl_contas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pl_contas tipo_pl_contas = await db.tipo_pl_contas.FindAsync(id);
            if (tipo_pl_contas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_pl_contas);
        }

        // GET: tipo_pl_contas/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: tipo_pl_contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idtipo_pl_contas,descricao")] tipo_pl_contas tipo_pl_contas)
        {
            tipo_pl_contas.pl_d_contas_idpl_d_contas = idplcontas;
            if (ModelState.IsValid)
            {
                db.tipo_pl_contas.Add(tipo_pl_contas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index","pl_d_contas");
            }

            return PartialView(tipo_pl_contas);
        }

        // GET: tipo_pl_contas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pl_contas tipo_pl_contas = await db.tipo_pl_contas.FindAsync(id);
            if (tipo_pl_contas == null)
            {
                return HttpNotFound();
            }
            return PartialView(tipo_pl_contas);
        }

        // POST: tipo_pl_contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idtipo_pl_contas,pl_d_contas_idpl_d_contas,descricao")] tipo_pl_contas tipo_pl_contas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_pl_contas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(tipo_pl_contas);
        }

        // GET: tipo_pl_contas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipo_pl_contas tipo_pl_contas = await db.tipo_pl_contas.FindAsync(id);
            if (tipo_pl_contas == null)
            {
                return HttpNotFound();
            }
            return PartialView(tipo_pl_contas);
        }

        // POST: tipo_pl_contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tipo_pl_contas tipo_pl_contas = await db.tipo_pl_contas.FindAsync(id);
            db.tipo_pl_contas.Remove(tipo_pl_contas);
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
