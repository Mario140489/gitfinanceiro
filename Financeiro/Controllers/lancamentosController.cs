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
    public class lancamentosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: lancamentos
        public async Task<ActionResult> Index()
        {
            return View(await db.lancamentos.ToListAsync());
        }

        // GET: lancamentos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lancamentos lancamentos = await db.lancamentos.FindAsync(id);
            if (lancamentos == null)
            {
                return HttpNotFound();
            }
            return View(lancamentos);
        }

        // GET: lancamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lancamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idlancamentos,numero,doc,descricao,debito,cedito,saldo,ok,ac,divs,his,au,dt_vencimento,dt_entarda,dt_emissao,obs,dt_cadastro,dt_alteracao,id_conta")] lancamentos lancamentos)
        {
            if (ModelState.IsValid)
            {
                db.lancamentos.Add(lancamentos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lancamentos);
        }

        // GET: lancamentos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lancamentos lancamentos = await db.lancamentos.FindAsync(id);
            if (lancamentos == null)
            {
                return HttpNotFound();
            }
            return View(lancamentos);
        }

        // POST: lancamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idlancamentos,numero,doc,descricao,debito,cedito,saldo,ok,ac,divs,his,au,dt_vencimento,dt_entarda,dt_emissao,obs,dt_cadastro,dt_alteracao,id_conta")] lancamentos lancamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lancamentos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lancamentos);
        }

        // GET: lancamentos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lancamentos lancamentos = await db.lancamentos.FindAsync(id);
            if (lancamentos == null)
            {
                return HttpNotFound();
            }
            return View(lancamentos);
        }

        // POST: lancamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            lancamentos lancamentos = await db.lancamentos.FindAsync(id);
            db.lancamentos.Remove(lancamentos);
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
