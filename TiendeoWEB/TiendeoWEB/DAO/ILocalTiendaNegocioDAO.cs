using System.Linq;
using TiendeoWEB.Models;

namespace TiendeoWEB.DAO
{
    /// <summary>
    /// DAO Layer for LocalTiendaNegocio
    /// </summary>
    public interface ILocalTiendaNegocioDAO
    {
        #region Methods
        /// <summary>
        /// Get the Number of Tiendas in a Ciudad
        /// </summary>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns the Number of Tiendas in a Ciudad</returns>
        int GetNumberOfTiendasInCiudad(int idCiudad);
        /// <summary>
        /// Gets the top Tiendas in a Ciudad
        /// </summary>
        /// <param name="top">top number</param>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns the top Tiendas in a Ciudad</returns>
        IQueryable<LocalTiendaNegocioViewModel> GetAllLocalTiendaNeociosOfCiudad(int top, int idCiudad);
        #endregion
    }
}
