using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.Models;

namespace TiendeoApi.DAO
{
    /// <summary>
    /// Implementation of <see cref="IServicioDAO"/>
    /// </summary>
    public class ServicioDAO : IServicioDAO
    {

        #region Fields
        private masterContext _Context;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new intance of <see cref="ServicioDAO"/>
        /// </summary>
        public ServicioDAO()
        {
            this._Context = new masterContext();
        }
        #endregion

        #region Methods
        public IQueryable<Servicio> GetAllCiudadServicios(int idCiudad)
        {
            return this._Context.Servicio.Include(servicio => servicio.IdLocalNavigation).Where(servicio => servicio.IdLocalNavigation.IdCiudad == idCiudad).AsQueryable();
        }
        #endregion
    }
}
