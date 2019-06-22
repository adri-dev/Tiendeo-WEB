using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoWEB.Models
{
    public class CityViewModel
    {
        #region Properties
        public float latitud { get; set; }
        public float longitud { get; set; }
        public string nombre { get; set; }
        public string provincia { get; set; }
        public int top { get; set; }
        #endregion
    }
}
