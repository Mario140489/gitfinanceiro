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
using X.PagedList;
using PagedList;

namespace Financeiro.Controllers
{
    
    public class bancos_contasController : Controller
    { 
    
        private Contexto db = new Contexto();
        static string buscando;
     
        // GET: bancos_contas
        public ActionResult Index(string Buscar, string ativo, string inativo, string op)
        {
     
           
            if (Request.IsAjaxRequest())
            {
             
                if (Buscar is "")
                {
                    buscando = Buscar;
                    if (ativo == "on" && inativo is null)
                    {
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.status == "A").OrderBy(b => b.bancos_contas_id);
                        var bc = bancos_contas;
                        return PartialView("_Listar", bc.ToList());
                    }
                    if(ativo is null && inativo == "on")
                    {
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.status == "I").OrderBy(b => b.bancos_contas_id);
                        
                        return PartialView("_Listar", bancos_contas.ToList());
                    }
                    if(ativo == "on" && inativo == "on")
                    {
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N").OrderBy(b => b.bancos_contas_id);
                        
                        return PartialView("_Listar", bancos_contas.ToList());
                    }
                    else
                    {
                        ViewBag.message = "Verifique sua pesquisa";
                        return PartialView("_Listar");
                    }
                }
                else
                {
                    buscando = Buscar;
                    if (ativo == "on" && inativo is null)
                    {
                      
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.status == "A" && b.descricao.Contains(buscando)).OrderBy(b => b.bancos_contas_id);
                       
                        return PartialView("_Listar",bancos_contas.ToList());
                    }
                    if (ativo is null && inativo == "on")
                    {
                        
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.status == "I" && b.descricao.Contains(buscando)).OrderBy(b => b.bancos_contas_id);
                 
                        return PartialView("_Listar", bancos_contas.ToList());
                    }
                    if (ativo == "on" && inativo == "on")
                    {
                
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.descricao.Contains(buscando)).OrderBy(b => b.bancos_contas_id);
                       
                        return PartialView("_Listar", bancos_contas.ToList());
                    }
                    else
                    {
                        ViewBag.message = "Verifique sua pesquisa";
                        return PartialView("_Listar");
                    }
                   
                }

            }
            else
            {
                var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.status == "A").OrderBy(b => b.bancos_contas_id);
                return View(bancos_contas.ToList());
            }

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
            ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao");
            return PartialView();
        }

        // POST: bancos_contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "bancos_contas_id,descricao,bancos_id,idtp_conta,conta,agencia,nib,swift,iban,obs,apagado,dtcadastro,cad_usuario_id,dtalteracao,alt_usuario_id,apag_usuario_id,status")] bancos_contas bancos_contas)
        {

            bancos_contas.status = "A";
            bancos_contas.apagado = "N";
            if (ModelState.IsValid)
            {
                bancos_contas.dtcadastro = DateTime.Now;
                db.bancos_contas.Add(bancos_contas);
                await db.SaveChangesAsync();
                ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
                ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
                bancos_contas.descricao = null;
                bancos_contas.agencia = null;
                bancos_contas.conta = null;
                bancos_contas.swift = null;
                bancos_contas.nib = null;
                bancos_contas.iban = null;
                bancos_contas.obs = null;
                return PartialView();
            }

            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
            ViewBag.erro = "erro";
            return PartialView(bancos_contas);
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
            if(bancos_contas.status == "I")
            {
                ViewBag.inativo = "checked";
            }
            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
            return PartialView(bancos_contas);
        }

        // POST: bancos_contas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "bancos_contas_id,descricao,bancos_id,idtp_conta,conta,agencia,saldo,nib,swift,iban,obs,apagado,dtcadastro,cad_usuario_id,dtalteracao,alt_usuario_id,apag_usuario_id,status")] bancos_contas bancos_contas,string inativo)
        {
            if (inativo != "on")
            {
                bancos_contas.status = "A";
                ViewBag.inativo = "";
            }
            if (inativo == "on")
            {
                bancos_contas.status = "I";
                ViewBag.inativo = "checked";
            }
            bancos_contas.apagado = "N";
            if (ModelState.IsValid)
            {
                bancos_contas.dtalteracao = DateTime.Now;
                ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
                ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
                db.Entry(bancos_contas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return PartialView();
            }
            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
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
            return PartialView(bancos_contas);
         
        }

        // POST: bancos_contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bancos_contas bancos_contas = await db.bancos_contas.FindAsync(id);
            bancos_contas.apagado = "S";
            db.Entry(bancos_contas).State = EntityState.Modified;
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
