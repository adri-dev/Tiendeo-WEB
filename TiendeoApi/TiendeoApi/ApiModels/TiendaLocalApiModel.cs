using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.Models;

namespace TiendeoApi.ApiModels
{
    public class TiendaLocalApiModel
    {
        #region Properties
        public int IdTienda { get; set; }
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public int Rate { get; set; }

        public LocalApiModel LocalTienda { get; set; }
        #endregion
    }
}
