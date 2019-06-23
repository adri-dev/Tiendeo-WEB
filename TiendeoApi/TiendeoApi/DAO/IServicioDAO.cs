using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.Models;

namespace TiendeoApi.DAO
{
    /// <summary>
    /// DAO Layer of Service
    /// </summary>
    public interface IServicioDAO
    {
        #region Methods
        /// <summary>
        /// Gets all Servicios from a Ciudad
        /// </summary>
        /// <param name="idCiudad">ID Ciudad</param>
        /// <returns>Returns all Servicios From a Ciudad</returns>
        IQueryable<Servicio> GetAllCiudadServicios(int idCiudad);
        #endregion
    }
}
