using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DatabaseModels;
using TiendeoWEB.Models;

namespace TiendeoWEB.MapperProfiles
{
    /// <summary>
    /// AutoMapper Profile from <see cref="VW_LocalTiendaNegocio"/> to <see cref="LocalTiendaNegocioViewModel"/>
    /// </summary>
    public class LocalTiendaNegocioProfile : Profile
    {
        #region Constructors
        /// <summary>
        /// Creates a new Instance of <see cref="LocalTiendaNegocioProfile"/>
        /// </summary>
        public LocalTiendaNegocioProfile()
        {
            this.CreateMap<VW_LocalTiendaNegocio, LocalTiendaNegocioViewModel>()
                .ForMember(dest => dest.Direccion, opts => opts.MapFrom(ori => ori.Direccion))
                .ForMember(dest => dest.IdCiudad, opts => opts.MapFrom(ori => ori.IdCiudad))
                .ForMember(dest => dest.IdLocal, opts => opts.MapFrom(ori => ori.IdLocal))
                .ForMember(dest => dest.IdNegocio, opts => opts.MapFrom(ori => ori.IdNegocio))
                .ForMember(dest => dest.IdTienda, opts => opts.MapFrom(ori => ori.IdTienda))
                .ForMember(dest => dest.Latitud, opts => opts.MapFrom(ori => ori.Latitud))
                .ForMember(dest => dest.Longitud, opts => opts.MapFrom(ori => ori.Longitud))
                .ForMember(dest => dest.Marker, opts => opts.MapFrom(ori => ori.Marker))
                .ForMember(dest => dest.NegocioNombre, opts => opts.MapFrom(ori => ori.NegocioNombre))
                .ForMember(dest => dest.TiendaNombre, opts => opts.MapFrom(ori => ori.TiendaNombre))
                .ForMember(dest => dest.TiendaRate, opts => opts.MapFrom(ori => ori.TiendaRate));
        }
        #endregion
    }
}
