using System;
using System.Collections.Generic;

namespace TiendeoApi.Models
{
    public partial class TipoServicio
    {
        public TipoServicio()
        {
            Servicio = new HashSet<Servicio>();
        }

        public int IdTipoServicio { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
