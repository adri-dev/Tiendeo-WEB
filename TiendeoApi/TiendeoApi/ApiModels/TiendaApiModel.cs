using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoApi.ApiModels
{
    /// <summary>
    /// Models a Tienda
    /// </summary>
    public class TiendaApiModel
    {
        #region Properties
        public int IdTienda { get; set; }
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public int Rate { get; set; }
        #endregion
    }
}
