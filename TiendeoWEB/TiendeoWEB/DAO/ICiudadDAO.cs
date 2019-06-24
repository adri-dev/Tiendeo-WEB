using System.Linq;
using TiendeoWEB.Models;

namespace TiendeoWEB.DAO
{
    /// <summary>
    /// DAO Layer of Ciudad
    /// </summary>
    public interface ICiudadDAO
    {
        #region Methods
        /// <summary>
        /// Gets a Ciudad
        /// </summary>
        /// <param name="idCiudad">id Ciudad</param>
        /// <returns>Returns a Ciudad</returns>
        IQueryable<CiudadViewModel> GetCiudad(int idCiudad);
        /// <summary>
        /// Gets All Ciudades
        /// </summary>
        /// <returns>Returns All Ciudades</returns>
        IQueryable<CiudadDropDownViewModel> GetAllCiudades();
        #endregion
    }
}
