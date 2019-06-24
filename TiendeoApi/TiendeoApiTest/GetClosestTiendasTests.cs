using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TiendeoApi.ApiModels;
using TiendeoApi.AppService;
using TiendeoApi.DAO;
using TiendeoApi.Utils;

namespace TiendeoApiTest
{
    [TestFixture]
    public class GetClosestTiendasTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ClosestTienda_NoTop()
        {
            ///Arrange
            LocalApiModel firstLocal = new LocalApiModel() { Latitud = 1m, Longitud = 1m};
            TiendaLocalApiModel firstTienda = new TiendaLocalApiModel() { IdTienda = 1, LocalTienda = firstLocal };
            LocalApiModel secondLocal = new LocalApiModel() { Latitud = 2m, Longitud = 2m };
            TiendaLocalApiModel secondTienda = new TiendaLocalApiModel() {IdTienda = 2, LocalTienda = secondLocal };
            IQueryable<TiendaLocalApiModel> fakeTiendas = (new List<TiendaLocalApiModel>() { firstTienda, secondTienda }).AsQueryable();
            Mock<ITiendaDAO> mockTiendaDAO = new Mock<ITiendaDAO>();
            mockTiendaDAO.Setup(p => p.GetAllTiendasWithLocal()).Returns(fakeTiendas);
            Mock<IDistanceCalculator> mockDistanceCalculator = new Mock<IDistanceCalculator>();
            mockDistanceCalculator.Setup(p => p.GetDistance(0m, 0m, 1m, 1m)).Returns(100D);
            mockDistanceCalculator.Setup(p => p.GetDistance(0m, 0m, 2m, 2m)).Returns(200D);
            decimal originalLatitude = 0m;
            decimal originalLongitude = 0m;
            ITiendaService tiendaService = new TiendaService(mockTiendaDAO.Object, mockDistanceCalculator.Object);
            int top = 0;
            ///Action
            List<TiendaLocalApiModel> closestTiendas = tiendaService.GetClosestsTiendas(top, originalLatitude, originalLongitude);
            ///Assert
            Assert.That(closestTiendas.Count == fakeTiendas.ToList().Count);
        }

        [Test]
        public void ClosestTienda_Top()
        {
            ///Arrange
            LocalApiModel firstLocal = new LocalApiModel() { Latitud = 1m, Longitud = 1m };
            TiendaLocalApiModel firstTienda = new TiendaLocalApiModel() { IdTienda = 1, LocalTienda = firstLocal };
            LocalApiModel secondLocal = new LocalApiModel() { Latitud = 2m, Longitud = 2m };
            TiendaLocalApiModel secondTienda = new TiendaLocalApiModel() { IdTienda = 2, LocalTienda = secondLocal };
            IQueryable<TiendaLocalApiModel> fakeTiendas = (new List<TiendaLocalApiModel>() { firstTienda, secondTienda }).AsQueryable();
            Mock<ITiendaDAO> mockTiendaDAO = new Mock<ITiendaDAO>();
            mockTiendaDAO.Setup(p => p.GetAllTiendasWithLocal()).Returns(fakeTiendas);
            Mock<IDistanceCalculator> mockDistanceCalculator = new Mock<IDistanceCalculator>();
            mockDistanceCalculator.Setup(p => p.GetDistance(0m, 0m, 1m, 1m)).Returns(100D);
            mockDistanceCalculator.Setup(p => p.GetDistance(0m, 0m, 2m, 2m)).Returns(200D);
            decimal originalLatitude = 0m;
            decimal originalLongitude = 0m;
            ITiendaService tiendaService = new TiendaService(mockTiendaDAO.Object, mockDistanceCalculator.Object);
            int top = 1;
            ///Action
            List<TiendaLocalApiModel> closestTiendas = tiendaService.GetClosestsTiendas(top, originalLatitude, originalLongitude);
            ///Assert
            Assert.That(closestTiendas.Count == top);
        }

        [Test]
        public void ClosestTienda_DistanceOrdered()
        {
            ///Arrange
            LocalApiModel firstLocal = new LocalApiModel() { Latitud = 1m, Longitud = 1m };
            TiendaLocalApiModel firstTienda = new TiendaLocalApiModel() { IdTienda = 1, LocalTienda = firstLocal };
            LocalApiModel secondLocal = new LocalApiModel() { Latitud = 2m, Longitud = 2m };
            TiendaLocalApiModel secondTienda = new TiendaLocalApiModel() { IdTienda = 2, LocalTienda = secondLocal };
            IQueryable<TiendaLocalApiModel> fakeTiendas = (new List<TiendaLocalApiModel>() { secondTienda, firstTienda }).AsQueryable();
            Mock<ITiendaDAO> mockTiendaDAO = new Mock<ITiendaDAO>();
            mockTiendaDAO.Setup(p => p.GetAllTiendasWithLocal()).Returns(fakeTiendas);
            Mock<IDistanceCalculator> mockDistanceCalculator = new Mock<IDistanceCalculator>();
            mockDistanceCalculator.Setup(p => p.GetDistance(0m, 1m, 0m, 1m)).Returns(100D);
            mockDistanceCalculator.Setup(p => p.GetDistance(0m, 2m, 0m, 2m)).Returns(200D);
            decimal originalLatitude = 0m;
            decimal originalLongitude = 0m;
            ITiendaService tiendaService = new TiendaService(mockTiendaDAO.Object, mockDistanceCalculator.Object);
            int top = 0;
            ///Action
            List<TiendaLocalApiModel> closestTiendas = tiendaService.GetClosestsTiendas(top, originalLatitude, originalLongitude);
            ///Assert
            Assert.That(closestTiendas.First().IdTienda == firstTienda.IdTienda && closestTiendas.Last().IdTienda == secondTienda.IdTienda);
        }
    }
}
