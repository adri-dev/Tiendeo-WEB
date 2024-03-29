﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TiendeoApi.AppService;
using TiendeoApi.DAO;
using TiendeoApi.Models;
using TiendeoApi.Utils;
using TiendeoApi.Utils.AutoMapperProfiles;

namespace TiendeoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<ITiendaDAO, TiendaDAO>();
            services.AddScoped<IDistanceCalculator, DistanceCalculator>();
            services.AddScoped<IServicioDAO, ServicioDAO>();
            services.AddScoped<ITiendaService, TiendaService>();
            services.AddScoped<IServicioService, ServicioService>();
            Mapper.Initialize(cfg => {
                cfg.AddProfile<TiendaProfile>();
                cfg.AddProfile<ServicioProfile>();
            });
            services.AddDbContext<masterContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TiendeoDatabase")));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
