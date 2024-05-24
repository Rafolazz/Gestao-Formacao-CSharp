using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFormacao.Models
{
    public class Funcionario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime data_entrada { get; set; }
        public DateTime data_saida { get; set; }
        public string departamento { get; set; }
        public int ativo { get; set; }
    }
}
