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
            this.Ciudad = new CiudadViewModel();
            this.Tiendas = new List<LocalTiendaNegocioViewModel>();
        }
        #endregion

        #region Properties
        public CiudadViewModel Ciudad { get; set; }
        public List<LocalTiendaNegocioViewModel> Tiendas { get; set; }
        public int NumeroTotalTiendas { get; set; }
        #endregion
    }
}
