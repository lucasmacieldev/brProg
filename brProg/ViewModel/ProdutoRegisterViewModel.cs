using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brProg.Models
{
    public class ProdutoRegisterViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o Nome Produto!", AllowEmptyStrings = false)]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage = "Informe o CPF!", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public float Cpf { get; set; }

        [Required(ErrorMessage = "Informe o Email!", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Telefone!", AllowEmptyStrings = false)]
        public string Telefone { get; set; }


    }
}