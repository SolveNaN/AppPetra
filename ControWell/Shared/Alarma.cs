using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class Alarma
    {
        public int Id { get; set; }
        public Pozo? Pozo { get; set; }
        public int PozoId { get; set; }
        public VariableProceso? VariableProceso { get; set; }
        public int VariableProcesoId { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
        public int Habilitado { get; set; }
    }
}
