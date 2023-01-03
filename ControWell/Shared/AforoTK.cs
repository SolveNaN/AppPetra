using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControWell.Shared
{
    public class AforoTK
    {
        public int Id { get; set; }
        public Tanque? Tanque { get; set; }
        public int TanqueId { get; set; }
        public int Nivel { get; set; }
        public int Volunen { get; set; }
        public int TempBase { get; set; }
        public string Material { get; set; } = string.Empty;
    }
}
