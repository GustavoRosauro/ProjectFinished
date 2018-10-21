using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluDataList.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ {get;set;}
        public string DataCadastro { get; set; }
        public string Telefone { get; set; }
        public string RG { get; set; }
        public string DataNascimento { get; set; }
    }   
}