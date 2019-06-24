using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TiendeoApi.ApiModels;
using TiendeoApi.AppService;

namespace TiendeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController:ControllerBase
    {
        #region Fields
        private IServicioService _ServicioService;
        #endregion

        #region Constructors
        public ServiciosController(IServicioService servicioService)
        {
            this._ServicioService = servicioService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<ServicioApiModel>> Get(int ciudad)
        {
            return this._ServicioService.GetAllCiudadServicios(ciudad).ToList();
        }
        #endregion
    }
}
