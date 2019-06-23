using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoApi.Utils
{
    /// <summary>
    /// Calculates Distances
    /// </summary>
    public interface IDistanceCalculator
    {
        #region Methods
        /// <summary>
        /// Calculates Distances Between two points
        /// </summary>
        /// <param name="firstLatitude">Latitude 1</param>
        /// <param name="secondLatitude">Latitude 2</param>
        /// <param name="firstLongitude">Longitude 1</param>
        /// <param name="secondLongitude">Longitude 2</param>
        /// <returns></returns>
        double GetDistance(decimal firstLatitude, decimal secondLatitude, decimal firstLongitude, decimal secondLongitude);
        #endregion
    }
}
