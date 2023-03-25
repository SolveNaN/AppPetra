using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class OfertaDiaria
    {
        public int Id { get;set; }
        public string EmpresaTransportadora { get; set; } = string.Empty;
        public string Placa { get; set; } = string.Empty;
        public string Tanque { get; set; } = string.Empty;
        public string NombreConductor { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string CodigoRuta { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public string disponible { get; set; } = string.Empty;
        public string FechaCreacion { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
