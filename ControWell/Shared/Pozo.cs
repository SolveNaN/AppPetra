using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class Pozo
    {
        public int Id { get;set; }
        public string NombrePozo { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string Operadora { get; set; } = string.Empty;
        public string Comentario { get; set; } = string.Empty;
    }
}
