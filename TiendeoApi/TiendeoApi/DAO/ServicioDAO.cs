using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TiendeoApi.ApiModels;
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
        private IMapper _Mapper;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new intance of <see cref="ServicioDAO"/>
        /// </summary>
        public ServicioDAO()
        {
            this._Context = new masterContext();
            this._Mapper = Mapper.Instance;
        }
        #endregion

        #region Methods
        IQueryable<ServicioApiModel> IServicioDAO.GetAllCiudadServicios(int idCiudad)
        {
            return this._Mapper.ProjectTo<ServicioApiModel>(this._Context.Servicio.Include(servicio => servicio.IdLocalNavigation).Where(servicio => servicio.IdLocalNavigation.IdCiudad == idCiudad).AsQueryable());
        }
        #endregion
    }
}
