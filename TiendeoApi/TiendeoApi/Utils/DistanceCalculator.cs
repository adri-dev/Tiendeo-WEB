using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoApi.Utils
{
    /// <summary>
    /// Implementation of <see cref="IDistanceCalculator"/>
    /// </summary>
    public class DistanceCalculator : IDistanceCalculator
    {
        #region Constants
        private const int EARTH_RADIUS = 6371;
        private const int RADIANS_CONVERSION = 180;
        #endregion

        #region Methods
        double IDistanceCalculator.GetDistance(decimal firstLatitude, decimal secondLatitude, decimal firstLongitude, decimal secondLongitude)
        {
            double latitudeDifference = this.DegreesToRadians(Convert.ToDouble(secondLatitude - firstLatitude));
            double longitudeDifference = this.DegreesToRadians(Convert.ToDouble(secondLongitude - firstLongitude));
            double a =
              Math.Sin(latitudeDifference / 2) * Math.Sin(latitudeDifference / 2) +
              Math.Cos(this.DegreesToRadians(Convert.ToDouble(firstLatitude))) * Math.Cos(this.DegreesToRadians(Convert.ToDouble(secondLatitude))) *
              Math.Sin(longitudeDifference / 2) * Math.Sin(longitudeDifference / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EARTH_RADIUS * c; 
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / RADIANS_CONVERSION);
        }
        #endregion
    }
}
