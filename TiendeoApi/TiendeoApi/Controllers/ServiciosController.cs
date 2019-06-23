using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;
using TiendeoApi.DAO;
using TiendeoApi.Models;

namespace TiendeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController:ControllerBase
    {
        #region Fields
        private IMapper _Mapper;
        private IServicioDAO _ServicioDAO;
        #endregion

        #region Constructors
        public ServiciosController(IServicioDAO tiendaDAO)
        {
            this._Mapper = Mapper.Instance;
            this._ServicioDAO = tiendaDAO;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<ServicioApiModel>> Get(int ciudad)
        {
            return this._Mapper.Map<List<Servicio>, List<ServicioApiModel>>(this._ServicioDAO.GetAllCiudadServicios(ciudad).ToList());
        }
        #endregion
    }
}
