using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TiendeoWEB.DAO;
using TiendeoWEB.DatabaseModels;
using TiendeoWEB.Models;

namespace TiendeoWEB.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private ICiudadDAO _CiudadDAO;
        private ILocalTiendaNegocioDAO _LocalTiendaNegocioDAO;
        private IMapper _Mapper;
        #endregion

        #region Constructors
        public HomeController(ICiudadDAO ciudadDAO, ILocalTiendaNegocioDAO localTiendaNegocioDAO)
        {
            this._Mapper = Mapper.Instance;
            this._CiudadDAO = ciudadDAO;
            this._LocalTiendaNegocioDAO = localTiendaNegocioDAO;
        }
        #endregion

        public IActionResult Index()
        {
            this.AddCiudadesInViewBag();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetCityShops(int? top, int city)
        {
            TiendasCiudadViewModel tiendasCiudad = this._Mapper.Map<Ciudad, TiendasCiudadViewModel>(this._CiudadDAO.GetCiudad(city).FirstOrDefault());
            if (tiendasCiudad != null)
            {
                tiendasCiudad.Tiendas = this._Mapper.Map<List<VW_LocalTiendaNegocio>, List<LocalTiendaNegocioViewModel>>(this._LocalTiendaNegocioDAO.GetAllLocalTiendaNeociosOfCiudad(top ?? 0, city).ToList());
                tiendasCiudad.NumeroTotalTiendas = this._LocalTiendaNegocioDAO.GetNumberOfTiendasInCiudad(city);
            }
            return Json(tiendasCiudad);
        }

        private void AddCiudadesInViewBag()
        {
            List<CiudadViewModel> ciudades = this._Mapper.Map<List<Ciudad>, List<CiudadViewModel>>(this._CiudadDAO.GetAllCiudades().ToList());
            ViewBag.Ciudades = new SelectList(ciudades, nameof(CiudadViewModel.IdCiudad), nameof(CiudadViewModel.Nombre));
        }
    }
}
