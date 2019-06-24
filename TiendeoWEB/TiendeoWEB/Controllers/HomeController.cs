using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiendeoWEB.Models;
using TiendeoWEB.AppService;

namespace TiendeoWEB.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private ICiudadService _CiudadService;
        private ILocalTiendaNegocioService _LocalTiendaNegocioService;
        #endregion

        #region Constructors
        public HomeController(ICiudadService ciudadService, ILocalTiendaNegocioService localTiendaNegocioService)
        {
            this._CiudadService = ciudadService;
            this._LocalTiendaNegocioService = localTiendaNegocioService;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            this.AddCiudadesInViewBag();
            return View();
        }

        public IActionResult GetCityShops(int? top, int city)
        {
            return Json(this._LocalTiendaNegocioService.GetCiudadTiendas(top, city));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        #region Methods
        private void AddCiudadesInViewBag()
        {
            List<CiudadDropDownViewModel> ciudades =this._CiudadService.GetAllCiudades().ToList();
            ViewBag.Ciudades = new SelectList(ciudades, nameof(CiudadDropDownViewModel.IdCiudad), nameof(CiudadDropDownViewModel.Nombre));
        }
        #endregion
    }
}
