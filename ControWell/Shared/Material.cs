using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class Material
    {
        public int Id { get; set; }
        public string TipoMaterial { get; set; }=string.Empty;
        public double CoefLineal { get; set; }
    }
}
