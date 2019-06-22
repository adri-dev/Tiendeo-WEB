using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoWEB.Models
{
    public class CityShopsViewModel
    {
        #region Constructors
        public CityShopsViewModel()
        {
            this.Shops = new List<ShopViewModel>();
        }
        #endregion

        #region Properties
        public CityViewModel City { get; set; }
        public List<ShopViewModel> Shops { get; set; }
        #endregion
    }
}
