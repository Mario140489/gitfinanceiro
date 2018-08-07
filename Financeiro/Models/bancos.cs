using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class bancos
    {
        [Key]
        public int bancos_id { get; set; }
        [Display(Name ="Banco")]
        [Required(ErrorMessage ="campo obrigatorio, não pode ser nulo")]
        public string descricao { get; set; }
        public string apagado { get; set; }
    }
}