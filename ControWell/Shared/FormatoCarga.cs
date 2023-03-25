using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class FormatoCarga
    {
        public int Id { get;set; }
        public DateTime FechaCargue { get; set; }
        public DateTime HoraEntrada { get; set; }
        public string HoraSalida { get; set; } = string.Empty;
        public string OrigenDespacho { get; set; } = string.Empty;
        public string ProductoCargado { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string NombreConductor { get; set; } = string.Empty;
        public string OrdenDeCargue { get; set; } = string.Empty;
        public string PlacaCarro { get; set; } = string.Empty;
        public string PlacaTanque { get; set; } = string.Empty;
        public string DestinoRecibo { get; set; } = string.Empty;
        public string EmpresasTransportadoras { get; set; } = string.Empty;
        public string SellosInstalados { get; set; } = string.Empty;
        public string VolumenBrutoObservadoGOV { get; set; } = string.Empty;
        public string BSW { get; set; } = string.Empty;
        public string Temp { get; set; } = string.Empty;
        public string API { get; set; } = string.Empty;
        public string FactorTemp { get; set; } = string.Empty;
        public string VolumenNeto { get; set; } = string.Empty;
        public string GuiaDeTransporteGTU { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
