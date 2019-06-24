using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;
using TiendeoApi.DAO;

namespace TiendeoApi.AppService
{
    /// <summary>
    /// Implementation of <see cref="IServicioService"/>
    /// </summary>
    public class ServicioService : IServicioService
    {
        #region Fields
        private IServicioDAO _ServicioDAO;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="ServicioService"/>
        /// </summary>
        /// <param name="tiendaDAO">Tienda DAO</param>
        public ServicioService(IServicioDAO tiendaDAO)
        {
            this._ServicioDAO = tiendaDAO;
        }
        #endregion

        #region Methods
        IQueryable<ServicioApiModel> IServicioService.GetAllCiudadServicios(int idCiudad)
        {
            return this._ServicioDAO.GetAllCiudadServicios(idCiudad);
        }
        #endregion
    }
}
