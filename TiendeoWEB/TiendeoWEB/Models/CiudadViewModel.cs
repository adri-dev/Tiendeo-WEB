﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendeoWEB.Models
{
    /// <summary>
    /// Models a Ciudad
    /// </summary>
    public class CiudadViewModel
    {
        #region Properties
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int Rate { get; set; }
        #endregion
    }
}
