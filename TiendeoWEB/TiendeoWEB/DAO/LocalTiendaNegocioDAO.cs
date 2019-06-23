using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DatabaseModels;

namespace TiendeoWEB.DAO
{
    /// <summary>
    /// Implementation of <see cref="ILocalTiendaNegocioDAO"/>
    /// </summary>
    public class LocalTiendaNegocioDAO : ILocalTiendaNegocioDAO
    {
        #region Fields
        private masterContext _Context;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="LocalTiendaNegocioDAO"/>
        /// </summary>
        public LocalTiendaNegocioDAO()
        {
            this._Context = new masterContext();
        }
        #endregion


        #region Methods
        int ILocalTiendaNegocioDAO.GetNumberOfTiendasInCiudad(int idCiudad)
        {
            return this._Context.VW_LocalTiendaNegocio.Where(ltn => ltn.IdCiudad == idCiudad).Count();
        }

        IQueryable<VW_LocalTiendaNegocio> ILocalTiendaNegocioDAO.GetAllLocalTiendaNeociosOfCiudad(int top, int idCiudad)
        {
            IQueryable<VW_LocalTiendaNegocio> localesNegocios = this._Context.VW_LocalTiendaNegocio.Where(ltn => ltn.IdCiudad == idCiudad).OrderBy(ltn => ltn.TiendaRate);
            if (top > 0)
            {
                localesNegocios = localesNegocios.Take(top);
            }
            return localesNegocios;
        }
        #endregion
    }
}
