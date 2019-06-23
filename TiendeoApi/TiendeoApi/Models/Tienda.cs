using System;
using System.Collections.Generic;

namespace TiendeoApi.Models
{
    public partial class Tienda
    {
        public int IdTienda { get; set; }
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public int Rate { get; set; }

        public virtual Local IdLocalNavigation { get; set; }
    }
}
