using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brProg.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
    }
}