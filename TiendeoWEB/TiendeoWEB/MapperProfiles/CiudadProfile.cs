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
    /// Mapping Profiles from <see cref="Ciudad"/> to <see cref="CiudadDropDownViewModel"/> and <see cref="CiudadViewModel"/>
    /// </summary>
    public class CiudadProfile : Profile
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="CiudadProfile"/>
        /// </summary>
        public CiudadProfile()
        {
            this.CreateMap<Ciudad, CiudadDropDownViewModel>()
                .ForMember(dest => dest.Nombre, opts => opts.MapFrom(ori => ori.Nombre))
                .ForMember(dest => dest.IdCiudad, opts => opts.MapFrom(ori => ori.IdCiudad));
            this.CreateMap<Ciudad, CiudadViewModel>()
                .ForMember(dest => dest.Nombre, opts => opts.MapFrom(ori => ori.Nombre))
                .ForMember(dest => dest.IdCiudad, opts => opts.MapFrom(ori => ori.IdCiudad))
                .ForMember(dest => dest.Latitud, opts => opts.MapFrom(ori => ori.Latitud))
                .ForMember(dest => dest.Longitud, opts => opts.MapFrom(ori => ori.Longitud))
                .ForMember(dest => dest.Provincia, opts => opts.MapFrom(ori => ori.Provincia))
                .ForMember(dest => dest.Rate, opts => opts.MapFrom(ori => ori.Rate));
        }
        #endregion
    }
}
