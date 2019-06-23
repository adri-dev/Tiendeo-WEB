using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoWEB.Models
{
    /// <summary>
    /// Model Tiendas in a Ciudad
    /// </summary>
    public class TiendasCiudadViewModel
    {
        #region Constructors
        /// <summary>
        /// Creates a new intance of <see cref="TiendasCiudadViewModel"/>
        /// </summary>
        public TiendasCiudadViewModel()
        {
            this.Tiendas = new List<LocalTiendaNegocioViewModel>();
        }
        #endregion

        #region Properties
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public List<LocalTiendaNegocioViewModel> Tiendas { get; set; }
        public int NumeroTotalTiendas { get; set; }
        #endregion
    }
}
