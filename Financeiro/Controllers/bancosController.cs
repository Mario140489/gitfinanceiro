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
    public class bancosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: bancos
        public async Task<ActionResult> Index()
        {
            return View(await db.bancos.ToListAsync());
        }

        // GET: bancos/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bancos bancos = await db.bancos.FindAsync(id);
            if (bancos == null)
            {
                return HttpNotFound();
            }
            return PartialView(bancos);
        }

        // GET: bancos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bancos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "bancos_id,descricao")] bancos bancos)
        {
            if (ModelState.IsValid)
            {
                db.bancos.Add(bancos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bancos);
        }

        // GET: bancos/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bancos bancos = await db.bancos.FindAsync(id);
            if (bancos == null)
            {
                return HttpNotFound();
            }
            return View(bancos);
        }

        // POST: bancos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "bancos_id,descricao")] bancos bancos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bancos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bancos);
        }

        // GET: bancos/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bancos bancos = await db.bancos.FindAsync(id);
            if (bancos == null)
            {
                return HttpNotFound();
            }
            return View(bancos);
        }

        // POST: bancos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            bancos bancos = await db.bancos.FindAsync(id);
            db.bancos.Remove(bancos);
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
