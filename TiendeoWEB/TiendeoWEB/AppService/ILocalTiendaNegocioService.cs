using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.Models;

namespace TiendeoWEB.AppService
{
    /// <summary>
    /// Service Layer of LocalTiendaNegocio
    /// </summary>
    public interface ILocalTiendaNegocioService
    {
        #region Methods
        /// <summary>
        /// Gets All Tiendas of Ciudad
        /// </summary>
        /// <param name="top">top Number</param>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns All Tiendas of Ciudad</returns>
        TiendasCiudadViewModel GetCiudadTiendas(int? top,int idCiudad);
        #endregion
    }
}
