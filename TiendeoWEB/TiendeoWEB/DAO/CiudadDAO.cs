using AutoMapper;
using System.Linq;
using TiendeoWEB.DatabaseModels;
using TiendeoWEB.Models;

namespace TiendeoWEB.DAO
{
    /// <summary>
    /// Implmentation of <see cref="ICiudadDAO"/>
    /// </summary>
    public class CiudadDAO : ICiudadDAO
    {
        #region Fields
        private masterContext _Context;
        private IMapper _Mapper;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="CiudadDAO"/>
        /// </summary>
        public CiudadDAO()
        {
            this._Context = new masterContext();
            this._Mapper = Mapper.Instance;
        }
        #endregion

        #region Methods
        IQueryable<CiudadViewModel> ICiudadDAO.GetCiudad(int idCiudad)
        {
            return this._Mapper.ProjectTo<CiudadViewModel>(this._Context.Ciudad.Where(ciudad => ciudad.IdCiudad == idCiudad).AsQueryable());
        }

        IQueryable<CiudadDropDownViewModel> ICiudadDAO.GetAllCiudades()
        {
            return this._Mapper.ProjectTo<CiudadDropDownViewModel>(this._Context.Ciudad.OrderBy(Ciudad => Ciudad.Rate).AsQueryable());
        }
        #endregion
    }
}
