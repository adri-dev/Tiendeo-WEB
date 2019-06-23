using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DatabaseModels;

namespace TiendeoWEB.DAO
{
    /// <summary>
    /// DAO Layer of Ciudad
    /// </summary>
    public interface ICiudadDAO
    {
        #region Methods
        /// <summary>
        /// Gets a Ciudad
        /// </summary>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns a Ciudad</returns>
        IQueryable<Ciudad> GetCiudad(int idCiudad);
        /// <summary>
        /// Gets All Ciudades
        /// </summary>
        /// <returns>Returns All Ciudades</returns>
        IQueryable<Ciudad> GetAllCiudades();
        #endregion
    }
}
