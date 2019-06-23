using System;
using System.Collections.Generic;

namespace TiendeoApi.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Local = new HashSet<Local>();
        }

        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int Rate { get; set; }

        public virtual ICollection<Local> Local { get; set; }
    }
}
