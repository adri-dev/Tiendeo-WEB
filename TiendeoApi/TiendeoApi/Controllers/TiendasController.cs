using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TiendeoApi.ApiModels;
using TiendeoApi.AppService;

namespace TiendeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : ControllerBase
    {
        #region Fields
        private ITiendaService _TiendaService;
        #endregion

        #region Constructors
        public TiendasController(ITiendaService tiendaService)
        {
            this._TiendaService = tiendaService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<TiendaApiModel>> Get()
        {
            return this._TiendaService.GetAllTiendas().ToList();
        }

        [HttpGet("Closest")]
        public ActionResult<TiendaLocalApiModel> Get(decimal latitude, decimal longitude)
        {
            return this._TiendaService.GetClosestsTiendas(1, latitude, longitude).FirstOrDefault();
        }

        [HttpGet("Closests")]
        public ActionResult<IEnumerable<TiendaLocalApiModel>> Get(int top, decimal latitude, decimal longitude)
        {
            return this._TiendaService.GetClosestsTiendas(top, latitude, longitude);
        }
        #endregion
    }
}
