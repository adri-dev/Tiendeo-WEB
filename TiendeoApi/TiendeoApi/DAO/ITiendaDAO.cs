using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;
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
        IQueryable<TiendaApiModel> GetAllTiendas();
        /// <summary>
        /// Gets all Tiendas With Locals
        /// </summary>
        /// <returns>Returns All Tiendas With Locals</returns>
        IQueryable<TiendaLocalApiModel> GetAllTiendasWithLocal();
        #endregion
    }
}
