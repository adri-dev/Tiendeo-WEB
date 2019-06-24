using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DAO;
using TiendeoWEB.Models;

namespace TiendeoWEB.AppService
{
    /// <summary>
    /// Implementation of <see cref="ICiudadService"/>
    /// </summary>
    public class CiudadService : ICiudadService
    {
        #region Fields
        private ICiudadDAO _CiudadDAO;
        private IMapper _Mapper;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="CiudadService"/>
        /// </summary>
        /// <param name="ciudadDAO">ciudad DAO</param>
        public CiudadService(ICiudadDAO ciudadDAO)
        {
            this._Mapper = Mapper.Instance;
            this._CiudadDAO = ciudadDAO;
        }
        #endregion


        #region Methods
        IQueryable<CiudadViewModel> ICiudadService.GetAllCiudades()
        {
            return this._Mapper.ProjectTo<CiudadViewModel>(this._CiudadDAO.GetAllCiudades());
        }

        IQueryable<CiudadViewModel> ICiudadService.GetCiudad(int idCiudad)
        {
            return this._Mapper.ProjectTo<CiudadViewModel>(this._CiudadDAO.GetCiudad(idCiudad));
        }
        #endregion
    }
}
