using System;
using System.Collections.Generic;
using System.Linq;
using TiendeoApi.ApiModels;
using TiendeoApi.DAO;
using TiendeoApi.Utils;

namespace TiendeoApi.AppService
{
    /// <summary>
    /// Implementation of <see cref="ITiendaService"/>
    /// </summary>
    public class TiendaService : ITiendaService
    {
        #region Fields
        private ITiendaDAO _TiendaDAO;
        private IDistanceCalculator _DistanceCalculator;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new Intance of <see cref="TiendaService"/>
        /// </summary>
        /// <param name="tiendaDAO">Tienda DAO</param>
        /// <param name="distanceCalculator">Distance Calculator</param>
        public TiendaService(ITiendaDAO tiendaDAO, IDistanceCalculator distanceCalculator)
        {
            this._TiendaDAO = tiendaDAO;
            this._DistanceCalculator = distanceCalculator;
        }
        #endregion

        #region Methods
        IQueryable<TiendaApiModel> ITiendaService.GetAllTiendas()
        {
            return this._TiendaDAO.GetAllTiendas();
        }

        List<TiendaLocalApiModel> ITiendaService.GetClosestsTiendas(int top, decimal latitude, decimal longitude)
        {
            List<TiendaLocalApiModel> tiendas = this._TiendaDAO.GetAllTiendasWithLocal().ToList();
            List<Tuple<double, int>> distancias = new List<Tuple<double, int>>();
            foreach (TiendaLocalApiModel tienda in tiendas)
            {
                double distanceLocal = this._DistanceCalculator.GetDistance(latitude, tienda.LocalTienda.Latitud, longitude, tienda.LocalTienda.Longitud);
                distancias.Add(new Tuple<double, int>(item1: distanceLocal, item2: tienda.IdTienda));
            }
            if(top > 0)
            {
                distancias = distancias.OrderBy(distancia => distancia.Item1).Take(top).ToList();
            }
            List<TiendaLocalApiModel> distanceOrderedTiendas = new List<TiendaLocalApiModel>();
            foreach (Tuple<double, int> distancia in distancias.OrderBy(distancia => distancia.Item1))
            {
                distanceOrderedTiendas.Add(tiendas.Where(tienda => tienda.IdTienda == distancia.Item2).First());
            }
            return distanceOrderedTiendas;
        }
        #endregion
    }
}
