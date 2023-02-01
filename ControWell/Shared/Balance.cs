using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class Balance
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public Tanque? Tanque { get; set; }
        public int TanqueId { get; set; }
        public Pozo? Pozo { get; set; }
        public int PozoId { get; set; }
        public decimal Nivel { get; set; }
        public decimal Tov { get; set;}
        public decimal Interfase { get; set;}
        public decimal Fw { get; set; }
        public decimal Gov { get; set; }
        public decimal Api { get; set; }
        public decimal TemFluido { get; set; }
        public decimal TemAmbiente { get; set; }
        public decimal Ctsh { get; set; }
        public decimal Cti { get; set; }
        public decimal Gvs { get; set; }
        public decimal Syw { get; set; }
        public decimal Csw { get; set; }
        public decimal Nsv { get; set; }
        public decimal Agua { get; set; }
        public TipoMovimiento? Movimiento { get; set; }
        public int MovimientoId { get; set; }


    }
}
