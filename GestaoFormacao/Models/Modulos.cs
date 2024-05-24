using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFormacao.Models
{
    public class Modulos
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int horas { get; set; }
        public DateTime? data_max { get; set; }
        public int tipo_formacao { get; set; }
        public int tipo_modulo { get; set; }
        public string url { get; set; }
        public int tipo_avaliacao { get; set; }
        public int ativo { get; set; }
    }
}
