using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.Models;
using TiendeoApi.Utils;

namespace TiendeoApi.DAO
{
    /// <summary>
    /// Implementation of <see cref="ITiendaDAO"/>
    /// </summary>
    public class TiendaDAO : ITiendaDAO
    {
        #region Fields
        private masterContext _Context;
        private IDistanceCalculator _DistanceCalculator;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new intance of <see cref="TiendaDAO"/>
        /// </summary>
        /// <param name="distanceCalculator">Distance Calcultator</param>
        public TiendaDAO(IDistanceCalculator distanceCalculator)
        {
            this._Context = new masterContext();
            this._DistanceCalculator = distanceCalculator;
        }
        #endregion

        #region Methods
        IQueryable<Tienda> ITiendaDAO.GetAllTiendas()
        {
            return this._Context.Tienda.OrderBy(tienda => tienda.Rate).AsQueryable();
        }

        IQueryable<Tienda> ITiendaDAO.GetClosestTienda(decimal latitude, decimal longitude)
        {
            List<Tienda> tiendas = this._Context.Tienda.Include(tienda => tienda.IdLocalNavigation).ToList();
            double distance = -1;
            int closestTienda = 0;
            foreach(Tienda tienda in tiendas)
            {
                double distanceLocal = this._DistanceCalculator.GetDistance(latitude, tienda.IdLocalNavigation.Latitud, longitude, tienda.IdLocalNavigation.Longitud);
                if (distance == -1 || distance > distanceLocal)
                {
                    distance = distanceLocal;
                    closestTienda = tienda.IdTienda;
                }
            }
            return tiendas.Where(tienda => tienda.IdTienda == closestTienda).AsQueryable();
        }

        IEnumerable<Tienda> ITiendaDAO.GetClosestTiendas(int top, decimal latitude, decimal longitude)
        {
            List<Tienda> tiendas = this._Context.Tienda.Include(tienda => tienda.IdLocalNavigation).ToList();
            List<Tuple<double, int>> distancias = new List<Tuple<double, int>>();
            foreach (Tienda tienda in tiendas)
            {
                double distanceLocal = this._DistanceCalculator.GetDistance(latitude, tienda.IdLocalNavigation.Latitud, longitude, tienda.IdLocalNavigation.Longitud);
                if (distancias.Count < top)
                {
                    distancias.Add(new Tuple<double, int>(item1: distanceLocal, item2: tienda.IdTienda));
                }
                else
                {
                    Tuple<double, int> greaterDistanceShop = distancias.Where(gd => distanceLocal < gd.Item1).OrderByDescending(gd => gd.Item1).FirstOrDefault();
                    if(greaterDistanceShop != null)
                    {
                        distancias.Remove(greaterDistanceShop);
                        distancias.Add(new Tuple<double, int>(item1: distanceLocal, item2: tienda.IdTienda));
                    }
                }
            }
            distancias = distancias.OrderBy(distancia => distancia.Item1).ToList();
            List<Tienda> distanceOrderedTiendas = new List<Tienda>();
            foreach(Tuple<double, int> distancia in distancias)
            {
                distanceOrderedTiendas.Add(tiendas.Where(tienda => tienda.IdTienda == distancia.Item2).First());
            }
            return tiendas.Where(tienda => distancias.Select(distancia => distancia.Item2).Contains(tienda.IdTienda));
        }
        #endregion
    }
}
