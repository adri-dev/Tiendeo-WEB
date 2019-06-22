using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoWEB.Models
{
    public class ShopViewModel
    {
        #region Properties
        public float latitud { get; set; }
        public float longitud { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string negocio { get; set; }
        public int top { get; set; }
        public BrandViewModel Brand { get; set; }
        #endregion
    }
}
