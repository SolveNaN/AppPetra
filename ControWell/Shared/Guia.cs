using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class Guia
    {
        public int Id { get;set; }
        public string NumeroGuia { get; set; } = string.Empty;
        public string Lote { get; set; } = string.Empty;
        public int Estado { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}


