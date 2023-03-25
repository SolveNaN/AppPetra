using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class Sello
    {
        public int Id { get;set; }
        public string IndiceSello { get; set; } = string.Empty;
        public string NumeroSello { get; set; } = string.Empty;
        public string Lote { get; set; } = string.Empty;
        public int Estado { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
