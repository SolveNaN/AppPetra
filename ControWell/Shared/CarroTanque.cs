using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class CarroTanque
    {
        public int Id { get;set; }
        public string TipoVehiculo { get; set; } = string.Empty;
        public string Capacidad { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
