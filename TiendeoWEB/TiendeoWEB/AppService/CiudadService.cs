using System.Linq;
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
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="CiudadService"/>
        /// </summary>
        /// <param name="ciudadDAO">ciudad DAO</param>
        public CiudadService(ICiudadDAO ciudadDAO)
        {
            this._CiudadDAO = ciudadDAO;
        }
        #endregion


        #region Methods
        IQueryable<CiudadDropDownViewModel> ICiudadService.GetAllCiudades()
        {
            return this._CiudadDAO.GetAllCiudades();
        }

        IQueryable<CiudadViewModel> ICiudadService.GetCiudad(int idCiudad)
        {
            return this._CiudadDAO.GetCiudad(idCiudad);
        }
        #endregion
    }
}
