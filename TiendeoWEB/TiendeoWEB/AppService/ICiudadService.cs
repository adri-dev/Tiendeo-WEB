using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.Models;

namespace TiendeoWEB.AppService
{
    /// <summary>
    /// Service Layer of Ciudad
    /// </summary>
    public interface ICiudadService
    {
        #region Methods
        /// <summary>
        /// Gets a Ciudad
        /// </summary>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns a Ciudad</returns>
        IQueryable<CiudadViewModel> GetCiudad(int idCiudad);
        /// <summary>
        /// Gets All Ciudades
        /// </summary>
        /// <returns>Returns All Ciudades</returns>
        IQueryable<CiudadViewModel> GetAllCiudades();
        #endregion
    }
}
