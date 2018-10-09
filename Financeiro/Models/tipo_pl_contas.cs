using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class tipo_pl_contas
    {
        [Key]
        public int idtipo_pl_contas { get; set; }
        public int pl_d_contas_idpl_d_contas { get; set; }
        [Display(Name ="Descrição")]
        public string descricao { get; set; }
    }
}