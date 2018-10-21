using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluDataList.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string UF { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }
}