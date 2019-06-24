using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;
using TiendeoApi.Models;

namespace TiendeoApi.Utils.AutoMapperProfiles
{
    /// <summary>
    /// Mapper Profile betweeen <see cref="Tienda" /> and <see cref="TiendaApiModel"/> and <see cref="TiendaLocalApiModel"/>
    /// </summary>
    public class TiendaProfile : Profile
    {
        #region Constructors
        /// <summary>
        /// Creates a new instace of <see cref="TiendaProfile"/>
        /// </summary>
        public TiendaProfile()
        {
            this.CreateMap<Tienda, TiendaApiModel>()
                .ForMember(dest => dest.IdTienda, opts => opts.MapFrom(ori => ori.IdTienda))
                .ForMember(dest => dest.IdLocal, opts => opts.MapFrom(ori => ori.IdLocal))
                .ForMember(dest => dest.Nombre, opts => opts.MapFrom(ori => ori.Nombre))
                .ForMember(dest => dest.Rate, opts => opts.MapFrom(ori => ori.Rate));
            this.CreateMap<Tienda, TiendaLocalApiModel>()
                .ForMember(dest => dest.IdTienda, opts => opts.MapFrom(ori => ori.IdTienda))
                .ForMember(dest => dest.IdLocal, opts => opts.MapFrom(ori => ori.IdLocal))
                .ForMember(dest => dest.Nombre, opts => opts.MapFrom(ori => ori.Nombre))
                .ForMember(dest => dest.Rate, opts => opts.MapFrom(ori => ori.Rate))
                .ForMember(dest => dest.LocalTienda, opts => opts.MapFrom(ori => ori.IdLocalNavigation));
        }
        #endregion
    }
}
