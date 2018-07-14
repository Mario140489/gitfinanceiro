using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class bancos_contas
    {
        [Key]
        public int bancos_contas_id { get; set; }  
        [Display(Name ="Descrição")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use apenas caracteres alfabéticos.")]
        [StringLength(100,MinimumLength =10,ErrorMessage = "Descrição deve conter mínimo de 10 e máximo 100 caracteres!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Conta")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Descrição deve conter mínimo de 1 e máximo 20 caracteres!")]
        public string conta { get; set; }       
        [Display(Name = "Agencia")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Descrição deve conter mínimo de 1 e máximo 20 caracteres!")]
        public string agencia { get; set; }
        [Display(Name = "Saldo")]
        public decimal saldo { get; set; }
        [Display(Name = "NIB")]
        public string nib { get; set; }
        [Display(Name = "Swift")]
        public string swift { get; set; }
        [Display(Name = "IBAN")]
        public string iban { get; set; }
        [Display(Name = "Obs")]
        public string obs { get; set; }
        public string apagado { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? dtcadastro { get; set; }
        public int cad_usuario_id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? dtalteracao { get; set; }
        public int? alt_usuario_id { get; set; }
        public int? apag_usuario_id { get; set; }
        public string status { get; set; }
        public int bancos_id { get; set; }
        public virtual bancos bancos { get; set; }
        public int idtp_conta { get; set; }
        public virtual tp_conta tp_conta { get; set; }
    }
}