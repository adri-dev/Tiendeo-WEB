using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendeoApi.ApiModels;
using TiendeoApi.Models;

namespace TiendeoApi.Utils.AutoMapperProfiles
{
    public class ServicioProfile:Profile
    {
        #region Constructors
        /// <summary>
        /// Creates a new instace of <see cref="TiendaProfile"/>
        /// </summary>
        public ServicioProfile()
        {
            this.CreateMap<Servicio, ServicioApiModel>()
                .ForMember(dest => dest.IdServicio, opts => opts.MapFrom(ori => ori.IdServicio))
                .ForMember(dest => dest.IdLocal, opts => opts.MapFrom(ori => ori.IdLocal))
                .ForMember(dest => dest.IdTipoServicio, opts => opts.MapFrom(ori => ori.IdTipoServicio))
                .ForMember(dest => dest.Nombre, opts => opts.MapFrom(ori => ori.Nombre))
                .ForMember(dest => dest.Rate, opts => opts.MapFrom(ori => ori.Rate));
        }
        #endregion
    }
}
