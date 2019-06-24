using System.Linq;
using TiendeoWEB.DAO;
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
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a New Instance of <see cref="LocalTiendaNegocioService"/>
        /// </summary>
        /// <param name="ciudadDAO">Ciudad DAO</param>
        /// <param name="localTiendaNegocioDAO">LocalTiendaNegocio DAO</param>
        public LocalTiendaNegocioService(ICiudadDAO ciudadDAO, ILocalTiendaNegocioDAO localTiendaNegocioDAO)
        {
            this._CiudadDAO = ciudadDAO;
            this._LocalTiendaNegocioDAO = localTiendaNegocioDAO;
        }
        #endregion

        #region Methods
        TiendasCiudadViewModel ILocalTiendaNegocioService.GetCiudadTiendas(int? top, int idCiudad)
        {
            TiendasCiudadViewModel tiendasCiudad = new TiendasCiudadViewModel();
            tiendasCiudad.Ciudad = this._CiudadDAO.GetCiudad(idCiudad).FirstOrDefault();
            if (tiendasCiudad.Ciudad != null)
            {
                tiendasCiudad.Tiendas = this._LocalTiendaNegocioDAO.GetAllLocalTiendaNeociosOfCiudad(top ?? 0, idCiudad).ToList();
                tiendasCiudad.NumeroTotalTiendas = this._LocalTiendaNegocioDAO.GetNumberOfTiendasInCiudad(idCiudad);
            }
            return tiendasCiudad;
        }
        #endregion
    }
}
