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
using PagedList;
using X.PagedList;

namespace Financeiro.Controllers
{
    public class bancosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: bancos
        public  ActionResult Index()
        {
            return View();
        }
           public PartialViewResult Listar(int? pagina, string Buscar)
        {   if(Buscar != null)
            {
                var bancos = db.bancos.Where(b => b.apagado == "N" && b.descricao.Contains(Buscar)).OrderBy(b => b.descricao);
                int paginatamanho = 10;
                int paginaNumero = (pagina ?? 1);
                return PartialView("_Listar", bancos.ToPagedList(paginaNumero, paginatamanho));
            }
        else
            {
                var bancos = db.bancos.Where(b => b.apagado == "N").OrderBy(b => b.descricao);
                int paginatamanho = 10;
                int paginaNumero = (pagina ?? 1);
                return PartialView("_Listar", bancos.ToPagedList(paginaNumero, paginatamanho));
            }
          
           
        }

        // GET: bancos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
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
        public PartialViewResult Create()
        {
            return PartialView();
        }

        // POST: bancos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "bancos_id,descricao")] bancos bancos,string form)
        {
           
            
                if (ModelState.IsValid)
                {
                    bancos.apagado = "N";
                    db.bancos.Add(bancos);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return PartialView(bancos);
            

           
        }

        // GET: bancos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
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

        // POST: bancos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "bancos_id,descricao")] bancos bancos)
        {
            if (ModelState.IsValid)
            {
                bancos.apagado = "N";
                db.Entry(bancos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bancos);
        }

        // GET: bancos/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
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

        // POST: bancos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bancos bancos = await db.bancos.FindAsync(id);
            bancos.apagado = "S";
             db.Entry(bancos).State = EntityState.Modified;
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
