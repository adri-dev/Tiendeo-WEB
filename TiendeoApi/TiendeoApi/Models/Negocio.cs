using System;
using System.Collections.Generic;

namespace TiendeoApi.Models
{
    public partial class Negocio
    {
        public Negocio()
        {
            Local = new HashSet<Local>();
        }

        public int IdNegocio { get; set; }
        public string Nombre { get; set; }
        public string Marker { get; set; }
        public int Rate { get; set; }

        public virtual ICollection<Local> Local { get; set; }
    }
}
