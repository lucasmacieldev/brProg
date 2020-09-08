using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brProg.Models
{
    public class ClienteListViewModel
    {
        public string NomeCliente { get; set; }
        public string Cpf { get; set; }
        public bool? AchouResultado { get; set; }
        public List<Cliente> Clientes{ get; set; }
    }
}