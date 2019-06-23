using System;
using System.Collections.Generic;

namespace TiendeoApi.Models
{
    public partial class Servicio
    {
        public int IdServicio { get; set; }
        public int IdLocal { get; set; }
        public int IdTipoServicio { get; set; }
        public int Nombre { get; set; }
        public int Rate { get; set; }

        public virtual Local IdLocalNavigation { get; set; }
        public virtual TipoServicio IdTipoServicioNavigation { get; set; }
    }
}
