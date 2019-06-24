using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;

namespace TiendeoApi.AppService
{
    /// <summary>
    /// Service Layer of Servicio
    /// </summary>
    public interface IServicioService
    {
        #region Methods
        /// <summary>
        /// Gets all Servicios from a Ciudad
        /// </summary>
        /// <param name="idCiudad">ID Ciudad</param>
        /// <returns>Returns all Servicios From a Ciudad</returns>
        IQueryable<ServicioApiModel> GetAllCiudadServicios(int idCiudad);
        #endregion
    }
}
