using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DatabaseModels;

namespace TiendeoWEB.DAO
{
    /// <summary>
    /// Implmentation of <see cref="ICiudadDAO"/>
    /// </summary>
    public class CiudadDAO : ICiudadDAO
    {
        #region Fields
        private masterContext _Context;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="CiudadDAO"/>
        /// </summary>
        public CiudadDAO()
        {
            this._Context = new masterContext();
        }
        #endregion

        #region Methods
        IQueryable<Ciudad> ICiudadDAO.GetCiudad(int idCiudad)
        {
            return this._Context.Ciudad.Where(ciudad => ciudad.IdCiudad == idCiudad).Include(ciudad => ciudad.Local).AsQueryable();
        }

        IQueryable<Ciudad> ICiudadDAO.GetAllCiudades()
        {
            return this._Context.Ciudad.AsQueryable();
        }
        #endregion
    }
}
