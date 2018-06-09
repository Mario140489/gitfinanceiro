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
    public class bancos_contasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: bancos_contas
        public async Task<ActionResult> Index()
        {

            var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta);
            var bc = bancos_contas.Where(b => b.apagado == "N");

            return View(await bc.ToListAsync());
        }

        // GET: bancos_contas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bancos_contas bancos_contas = await db.bancos_contas.FindAsync(id);
            if (bancos_contas == null)
            {
                return HttpNotFound();
            }
            return PartialView(bancos_contas);
        }

        // GET: bancos_contas/Create
        public ActionResult Create()
        {
            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao");
            return PartialView();
        }

        // POST: bancos_contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "bancos_contas_id,descricao,bancos_id,conta,agencia,saldo,nib,swift,iban,obs")] bancos_contas bancos_contas)
        {
            if (ModelState.IsValid)
            {
                db.bancos_contas.Add(bancos_contas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            return View(bancos_contas);
        }

        // GET: bancos_contas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bancos_contas bancos_contas = await db.bancos_contas.FindAsync(id);
            if (bancos_contas == null)
            {
                return HttpNotFound();
            }
            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            return View(bancos_contas);
        }

        // POST: bancos_contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "bancos_contas_id,descricao,bancos_id,conta,agencia,saldo,nib,swift,iban,obs")] bancos_contas bancos_contas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bancos_contas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            return View(bancos_contas);
        }

        // GET: bancos_contas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bancos_contas bancos_contas = await db.bancos_contas.FindAsync(id);
            if (bancos_contas == null)
            {
                return HttpNotFound();
            }
            return View(bancos_contas);
        }

        // POST: bancos_contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bancos_contas bancos_contas = await db.bancos_contas.FindAsync(id);
            db.bancos_contas.Remove(bancos_contas);
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
