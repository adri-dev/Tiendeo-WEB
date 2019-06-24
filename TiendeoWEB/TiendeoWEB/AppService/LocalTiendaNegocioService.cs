using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DAO;
using TiendeoWEB.DatabaseModels;
using TiendeoWEB.Models;

namespace TiendeoWEB.AppService
{
    /// <summary>
    /// Implementation of <see cref="ILocalTiendaNegocioService"/>
    /// </summary>
    public class LocalTiendaNegocioService : ILocalTiendaNegocioService
    {
        #region Fields
        private ICiudadDAO _CiudadDAO;
        private ILocalTiendaNegocioDAO _LocalTiendaNegocioDAO;
        private IMapper _Mapper;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a New Instance of <see cref="LocalTiendaNegocioService"/>
        /// </summary>
        /// <param name="ciudadDAO">Ciudad DAO</param>
        /// <param name="localTiendaNegocioDAO">LocalTiendaNegocio DAO</param>
        public LocalTiendaNegocioService(ICiudadDAO ciudadDAO, ILocalTiendaNegocioDAO localTiendaNegocioDAO)
        {
            this._Mapper = Mapper.Instance;
            this._CiudadDAO = ciudadDAO;
            this._LocalTiendaNegocioDAO = localTiendaNegocioDAO;
        }
        #endregion

        #region Methods
        TiendasCiudadViewModel ILocalTiendaNegocioService.GetCiudadTiendas(int? top, int idCiudad)
        {
            TiendasCiudadViewModel tiendasCiudad = this._Mapper.Map<Ciudad, TiendasCiudadViewModel>(this._CiudadDAO.GetCiudad(idCiudad).FirstOrDefault());
            if (tiendasCiudad != null)
            {
                tiendasCiudad.Tiendas = this._Mapper.Map<List<VW_LocalTiendaNegocio>, List<LocalTiendaNegocioViewModel>>(this._LocalTiendaNegocioDAO.GetAllLocalTiendaNeociosOfCiudad(top ?? 0, idCiudad).ToList());
                tiendasCiudad.NumeroTotalTiendas = this._LocalTiendaNegocioDAO.GetNumberOfTiendasInCiudad(idCiudad);
            }
            return tiendasCiudad;
        }
        #endregion
    }
}
