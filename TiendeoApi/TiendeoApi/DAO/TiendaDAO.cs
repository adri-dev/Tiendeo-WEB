using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;
using TiendeoApi.Models;
using TiendeoApi.Utils;

namespace TiendeoApi.DAO
{
    /// <summary>
    /// Implementation of <see cref="ITiendaDAO"/>
    /// </summary>
    public class TiendaDAO : ITiendaDAO
    {
        #region Fields
        private masterContext _Context;
        private IMapper _Mapper;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new intance of <see cref="TiendaDAO"/>
        /// </summary>
        public TiendaDAO()
        {
            this._Context = new masterContext();
            this._Mapper = Mapper.Instance;
        }
        #endregion

        #region Methods
        IQueryable<TiendaApiModel> ITiendaDAO.GetAllTiendas()
        {
            return this._Mapper.ProjectTo<TiendaApiModel>(this._Context.Tienda.OrderBy(tienda => tienda.Rate).AsQueryable());
        }

        IQueryable<TiendaLocalApiModel> ITiendaDAO.GetAllTiendasWithLocal()
        {
            return this._Mapper.ProjectTo<TiendaLocalApiModel>(this._Context.Tienda.Include(tienda => tienda.IdLocalNavigation).OrderBy(tienda => tienda.Rate).AsQueryable());
        }
        #endregion
    }
}
