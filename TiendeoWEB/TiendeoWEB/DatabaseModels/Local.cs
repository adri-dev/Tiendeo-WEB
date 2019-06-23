using System;
using System.Collections.Generic;

namespace TiendeoWEB.DatabaseModels
{
    public partial class Local
    {
        public Local()
        {
            Servicio = new HashSet<Servicio>();
            Tienda = new HashSet<Tienda>();
        }

        public int IdLocal { get; set; }
        public int IdCiudad { get; set; }
        public int IdNegocio { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Direccion { get; set; }

        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual Negocio IdNegocioNavigation { get; set; }
        public virtual ICollection<Servicio> Servicio { get; set; }
        public virtual ICollection<Tienda> Tienda { get; set; }
    }
}
