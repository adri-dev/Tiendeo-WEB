using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.Models;

namespace TiendeoApi.DAO
{
    /// <summary>
    /// DAO Layer of Tienda
    /// </summary>
    public interface ITiendaDAO
    {
        #region Methods
        /// <summary>
        /// Gets all Tiendas
        /// </summary>
        /// <returns>Returns All Tiendas</returns>
        IQueryable<Tienda> GetAllTiendas();
        /// <summary>
        /// Get the Closest Tienda
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns></returns>
        IQueryable<Tienda> GetClosestTienda(decimal latitude, decimal longitude);
        /// <summary>
        /// Gets the top closests tiendas
        /// </summary>
        /// <param name="top">Top number of tiendas</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns></returns>
        IEnumerable<Tienda> GetClosestTiendas(int top, decimal latitude, decimal longitude);
        #endregion
    }
}
