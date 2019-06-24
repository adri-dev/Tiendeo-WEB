using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoApi.ApiModels
{
    /// <summary>
    /// ApiModel of Local
    /// </summary>
    public class LocalApiModel
    {
        #region Properties
        public int IdLocal { get; set; }
        public int IdCiudad { get; set; }
        public int IdNegocio { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Direccion { get; set; }
        #endregion
    }
}
