using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoWEB.DatabaseModels;
using TiendeoWEB.Models;

namespace TiendeoWEB.MapperProfiles
{
    public class CiudadProfile:Profile
    {
        #region Constructors
        /// <summary>
        /// Creates a new instace of <see cref="CiudadProfile"/>
        /// </summary>
        public CiudadProfile()
        {
            this.CreateMap<Ciudad, TiendasCiudadViewModel>()
                .ForMember(dest => dest.IdCiudad, opts => opts.MapFrom(ori => ori.IdCiudad))
                .ForMember(dest => dest.Latitud, opts => opts.MapFrom(ori => ori.Latitud))
                .ForMember(dest => dest.Longitud, opts => opts.MapFrom(ori => ori.Longitud))
                .ForMember(dest => dest.Nombre, opts => opts.MapFrom(ori => ori.Nombre))
                .ForMember(dest => dest.NumeroTotalTiendas, opts => opts.Ignore())
                .ForMember(dest => dest.Tiendas, opts => opts.Ignore());
        }
        #endregion
    }
}
