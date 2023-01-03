using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class Tanque
    {
        public int Id { get; set; }
        public string NombreTanque { get; set; } = string.Empty;
        public string Capacidad { get; set; } = string.Empty;
        public string TipoFluido { get; set; } = string.Empty;
    }
}
