﻿using System.Linq;
using TiendeoApi.ApiModels;

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
        IQueryable<ServicioApiModel> GetAllCiudadServicios(int idCiudad);
        #endregion
    }
}
