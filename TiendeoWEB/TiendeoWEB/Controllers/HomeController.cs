using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TiendeoWEB.Models;

namespace TiendeoWEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Cities = new SelectList(this.GetAllCities(), nameof(CityViewModel.nombre), nameof(CityViewModel.nombre));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<CityViewModel> GetAllCities()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            string json = string.Empty;
            using (Stream resourceStream = assembly.GetManifestResourceStream("TiendeoWEB.Resources.Cities.json"))
            using (var reader = new StreamReader(resourceStream))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<CityViewModel>>(json).OrderBy(city => city.top).ToList();
        }

        private CityViewModel GetOneCity(string city)
        {
            return this.GetAllCities().Where(ct => ct.nombre == city).FirstOrDefault();
        }

        private List<ShopViewModel> GetAllShops()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            string json = string.Empty;
            using (Stream resourceStream = assembly.GetManifestResourceStream("TiendeoWEB.Resources.Shops.json"))
            using (var reader = new StreamReader(resourceStream))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<ShopViewModel>>(json).OrderBy(shop => shop.top).ToList();
        }

        private List<BrandViewModel> GetAllBrands()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            string json = string.Empty;
            using (Stream resourceStream = assembly.GetManifestResourceStream("TiendeoWEB.Resources.Brands.json"))
            using (var reader = new StreamReader(resourceStream))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<BrandViewModel>>(json).OrderBy(shop => shop.top).ToList();
        }

        private List<ShopViewModel> GetAllCityShops(string city)
        {
            return this.GetAllShops().Where(shop => shop.ciudad == city).ToList();
        }

        private BrandViewModel GetShopBrand(string shop)
        {
            return this.GetAllBrands().Where(brand => brand.nombre == shop).FirstOrDefault();
        }

        private CityShopsViewModel GetCityShopss(string city)
        {
            CityShopsViewModel cityShops = new CityShopsViewModel();
            cityShops.City = this.GetOneCity(city);
            cityShops.Shops = this.GetAllCityShops(city);
            foreach(ShopViewModel shop in cityShops.Shops)
            {
                shop.Brand = this.GetShopBrand(shop.negocio);
            }
            return cityShops;
        }

        public IActionResult GetCity(string city)
        {
            return Json(this.GetOneCity(city));
        }

        public IActionResult GetCityShops(string city)
        {
            return Json(this.GetCityShopss(city));
        }
    }
}
