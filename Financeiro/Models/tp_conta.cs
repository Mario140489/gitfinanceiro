using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class tp_conta
    {
        [Key]
        public int idtp_conta { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use apenas caracteres alfabéticos.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Descrição deve conter mínimo de 10 e máximo 100 caracteres!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name ="Tipo de conta")]
        public string descricao { get; set; }
        public int fundos { get; set; }
        public int investimento { get; set; }
    }
}