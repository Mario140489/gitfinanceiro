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
        static string filtro;
        // GET: bancos_contas
        public ActionResult Index(string ativo, string inativo)
        {
            if (ativo is null && inativo is null)
            {
                ViewBag.ativo = "checked";
            }
            if (ativo == "on" && inativo == "on")
            {
                filtro = null;
                ViewBag.ativo = "checked";
                ViewBag.inativo = "checked";
            }
            if (ativo != null && inativo is null)
            {
                filtro = "A";
                ViewBag.ativo = "checked";
            }
            if (ativo == "on" && inativo == "checked")
            {
                filtro = "A";
                ViewBag.ativo = "checked";
            }
            if (ativo is null && inativo != null)
            {
                filtro = "I";
                ViewBag.inativo = "checked";
            }
            if (ativo == "checked" && inativo == "on")
            {
                filtro = "I";
                ViewBag.inativo = "checked";
            }
            if (ativo == "checked" && inativo == "checked")
            {
                filtro = null;
                ViewBag.inativo = "checked";
                ViewBag.ativo = "checked";
            }
            // var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado== "N").OrderBy(b => b.bancos_contas_id);
            //var bc = bancos_contas.ToPagedList(pag ?? 1, 10);
            return View();
        }
        public PartialViewResult Listar(int? pagina, string Buscar, string ativo, string inativo)
        {
            if (ativo is null && inativo is null)
            {
                ViewBag.ativo = "checked";
            }
            if (ativo == "on" && inativo == "on")
            {
                filtro = null;
                ViewBag.ativo = "checked";
                ViewBag.inativo = "checked";
            }
            if (ativo != null && inativo is null)
            {
                filtro = "A";
                ViewBag.ativo = "checked";
            }
            if (ativo == "on" && inativo == "checked")
            {
                filtro = "A";
                ViewBag.ativo = "checked";
            }
            if (ativo is null && inativo != null)
            {
                filtro = "I";
                ViewBag.inativo = "checked";
            }
            if (ativo =="checked" && inativo == "on")
            {
                filtro = "I";
                ViewBag.inativo = "checked";
            }
            if (ativo == "checked" && inativo == "checked")
            {
                filtro = null;
                ViewBag.inativo = "checked";
                ViewBag.ativo = "checked";
            }

            int paginatamanho = 10;
            int paginaNumero = (pagina ?? 1);
            if(Buscar is null && pagina is null)
            {
                var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.status == "A").OrderBy(b => b.bancos_contas_id);
                return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
            }
            else
            {
                if (Buscar is null && pagina >= 1)
                { 
                
                    if(Buscar != null )
                    {
                        buscando = Buscar;
                    }
                    if(buscando == Buscar)
                    {
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.status == filtro).OrderBy(b => b.bancos_contas_id);
                        return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                    }
                    if (ativo == "checked" && inativo == "checked")
                    {
                        if(Buscar =="" )
                        {
                            var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" ).OrderBy(b => b.bancos_contas_id);
                            return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                        }
                        if(Buscar is null )
                        {
                            var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" ).OrderBy(b => b.bancos_contas_id);
                            ViewBag.inativo = "checked";
                            ViewBag.ativo = "checked";
                            return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                        }
                        else
                        {
                            paginaNumero = 1;
                            var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.descricao.Contains(buscando)).OrderBy(b => b.bancos_contas_id);
                            return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                        }
                        
                    }
                    else
                    {
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.descricao.Contains(buscando) && b.status == filtro).OrderBy(b => b.bancos_contas_id);
                        return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                    }
                }
                else
                { if(filtro == "")
                    {
                        buscando = Buscar;
                        paginaNumero = 1;
                        var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.descricao.Contains(buscando)).OrderBy(b => b.bancos_contas_id);
                        return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                    }
                    else
                    {
                        if (ativo == "on" && inativo == "on")
                        {
                            if(pagina >1 && buscando =="")
                            {
                                buscando = Buscar;
                                var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" ).OrderBy(b => b.bancos_contas_id);
                                return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                            }
                            else
                            {
                                buscando = Buscar;
                                paginaNumero = 1;
                                var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.descricao.Contains(buscando)).OrderBy(b => b.bancos_contas_id);
                                return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                            }
                          
                        }
                        else
                        {
                            buscando = Buscar;
                            paginaNumero = 1;
                            var bancos_contas = db.bancos_contas.Include(b => b.bancos).Include(b => b.tp_conta).Where(b => b.apagado == "N" && b.descricao.Contains(Buscar) && b.status == filtro).OrderBy(b => b.bancos_contas_id);
                            return PartialView("_Listar", bancos_contas.ToPagedList(paginaNumero, paginatamanho));
                        }
                    }
                   

                }
              
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
            return View();
        }

        // POST: bancos_contas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "bancos_contas_id,descricao,bancos_id,idtp_conta,conta,agencia,saldo,nib,swift,iban,obs,apagado,dtcadastro,cad_usuario_id,dtalteracao,alt_usuario_id,apag_usuario_id,status")] bancos_contas bancos_contas)
        {

            bancos_contas.status = "A";
            bancos_contas.apagado = "N";
            if (ModelState.IsValid)
            {
                db.bancos_contas.Add(bancos_contas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
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
            if(bancos_contas.status == "I")
            {
                ViewBag.inativo = "checked";
            }
            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
            return View(bancos_contas);
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

                db.Entry(bancos_contas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.bancos_id = new SelectList(db.bancos, "bancos_id", "descricao", bancos_contas.bancos_id);
            ViewBag.idtp_conta = new SelectList(db.tp_conta, "idtp_conta", "descricao", bancos_contas.idtp_conta);
            return View(bancos_contas);
        }

        // GET: bancos_contas/Delete/5
        public async Task<ActionResult> Delete(int? id, int? pagina, string Buscar, string ativo, string inativo)
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
            bancos_contas.apagado = "S";
            db.Entry(bancos_contas).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return PartialView();
         
        }

        // POST: bancos_contas/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bancos_contas bancos_contas = await db.bancos_contas.FindAsync(id);
            db.bancos_contas.Remove(bancos_contas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }*/

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
