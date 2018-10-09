using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class pl_d_contas
    {
        [Key]
        public int idpl_d_contas { get; set; }
        [Display(Name ="Plano de contas")]
        public string planoContas { get; set; }
    }
}