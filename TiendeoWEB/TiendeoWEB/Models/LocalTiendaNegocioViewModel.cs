using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoWEB.Models
{
    /// <summary>
    /// Models a Local-Tienda-Negocio
    /// </summary>
    public class LocalTiendaNegocioViewModel
    {
        #region Properties
        public int IdTienda { get; set; }
        public string TiendaNombre { get; set; }
        public int TiendaRate { get; set; }
        public int IdLocal { get; set; }
        public string Direccion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int IdCiudad { get; set; }
        public int IdNegocio { get; set; }
        public string Marker { get; set; }
        public string NegocioNombre { get; set; }
        #endregion
    }
}
