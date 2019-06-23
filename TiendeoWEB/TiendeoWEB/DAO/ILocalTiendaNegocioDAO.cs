using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DatabaseModels;

namespace TiendeoWEB.DAO
{
    /// <summary>
    /// DAO Layer for LocalTiendaNegocio
    /// </summary>
    public interface ILocalTiendaNegocioDAO
    {
        #region Methods
        /// <summary>
        /// Get the Number of Tiendas in a Ciudad
        /// </summary>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns the Number of Tiendas in a Ciudad</returns>
        int GetNumberOfTiendasInCiudad(int idCiudad);
        /// <summary>
        /// Gets the top Tiendas in a Ciudad
        /// </summary>
        /// <param name="top">top number</param>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns the top Tiendas in a Ciudad</returns>
        IQueryable<VW_LocalTiendaNegocio> GetAllLocalTiendaNeociosOfCiudad(int top, int idCiudad);
        #endregion
    }
}
