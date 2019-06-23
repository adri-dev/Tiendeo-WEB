using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiendeoApi.ApiModels;
using TiendeoApi.DAO;
using TiendeoApi.Models;

namespace TiendeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : ControllerBase
    {
        #region Fields
        private IMapper _Mapper;
        private ITiendaDAO _TiendaDAO;
        #endregion

        #region Constructors
        public TiendasController(ITiendaDAO tiendaDAO)
        {
            this._Mapper = Mapper.Instance;
            this._TiendaDAO = tiendaDAO;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<TiendaApiModel>> Get()
        {
            return this._Mapper.Map<List<Tienda>, List<TiendaApiModel>>(this._TiendaDAO.GetAllTiendas().ToList());
        }

        [HttpGet("Closest")]
        public ActionResult<TiendaApiModel> Get(decimal latitude, decimal longitude)
        {
            return this._Mapper.Map<Tienda, TiendaApiModel>(this._TiendaDAO.GetClosestTienda(latitude, longitude).FirstOrDefault());
        }

        [HttpGet("Closests")]
        public ActionResult<IEnumerable<TiendaApiModel>> Get(int top, decimal latitude, decimal longitude)
        {
            return this._Mapper.Map<List<Tienda>, List<TiendaApiModel>>(this._TiendaDAO.GetClosestTiendas(top, latitude, longitude).ToList());
        }
        #endregion
    }
}
