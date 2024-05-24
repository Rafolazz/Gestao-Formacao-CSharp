using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFormacao.Models
{
    public class User
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string palavrapasse { get; set; }
        public int permissao { get; set; }
        public int ativo { get; set; }
        public int funcionario { get; set; }
    }
}