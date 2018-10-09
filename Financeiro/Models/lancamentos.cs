using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class lancamentos
    {
        [Key]
        public int idlancamentos { get; set; }
        public int numero { get; set; }
        public int doc { get; set; }
        public string descricao { get; set; }
        public decimal debito { get; set; }
        public decimal cedito { get; set; }
        public decimal saldo { get; set; }
        public bool ok { get; set; }
        public bool ac { get; set; }
        public bool divs { get; set; }
        public bool his { get; set; }
        public bool au { get; set; }
        public DateTime dt_vencimento { get; set; }
        public DateTime dt_entarda { get; set; }
        public DateTime dt_emissao { get; set; }
        public string obs { get; set; }
        public DateTime dt_cadastro { get; set; }
        public DateTime dt_alteracao { get; set; }
        public int id_conta { get; set; }


    }
}