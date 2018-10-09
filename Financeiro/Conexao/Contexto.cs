using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Financeiro.Conexao
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Contexto")
        {

        }
        //public DbSet<TpCliente> TpCliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));
        }

        public System.Data.Entity.DbSet<Financeiro.Models.bancos> bancos { get; set; }

        public System.Data.Entity.DbSet<Financeiro.Models.bancos_contas> bancos_contas { get; set; }

        public System.Data.Entity.DbSet<Financeiro.Models.tp_conta> tp_conta { get; set; }

        public System.Data.Entity.DbSet<Financeiro.Models.lancamentos> lancamentos { get; set; }

        public System.Data.Entity.DbSet<Financeiro.Models.pl_d_contas> pl_d_contas { get; set; }

        public System.Data.Entity.DbSet<Financeiro.Models.tipo_pl_contas> tipo_pl_contas { get; set; }
    }
}