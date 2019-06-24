using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;

namespace TiendeoApi.AppService
{
    /// <summary>
    /// Service Layer of Tienda
    /// </summary>
    public interface ITiendaService 
    {
        #region Methods
        /// <summary>
        /// Gets all Tiendas
        /// </summary>
        /// <returns>Returns All Tiendas</returns>
        IQueryable<TiendaApiModel> GetAllTiendas();
        /// <summary>
        /// Get the Top Closests Tienda
        /// </summary>
        /// <param name="top">Top number</param>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <returns>Retruns the Top Closests Tienda</returns>
        List<TiendaLocalApiModel> GetClosestsTiendas(int top, decimal latitude, decimal longitude);
        #endregion
    }
}
