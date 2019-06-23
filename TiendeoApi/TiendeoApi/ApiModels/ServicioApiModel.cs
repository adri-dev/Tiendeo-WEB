using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoApi.ApiModels
{
    /// <summary>
    /// Models a Servicio
    /// </summary>
    public class ServicioApiModel
    {
        #region Properties
        public int IdServicio { get; set; }
        public int IdLocal { get; set; }
        public int IdTipoServicio { get; set; }
        public int Nombre { get; set; }
        public int Rate { get; set; }
        #endregion
    }
}
