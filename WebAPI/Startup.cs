using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
        //Build-in mimari yokken aþaðýdakiler bu iþi yapmayý saðlýyordu(IoC Container altyapýsý saðlýyordu)
        //AutoFac,Ninject, CastelWindsor, StructureMap, LightInject,DryInject --> IoC Container
        //AutoFac - AOP imkaný saðlýyor, projeye dahil edicez

            services.AddControllers();
        //*** IProductService tipinde bir baðýmlýlýk görürsen product manager oluþtur/newle/referans ver, benim yerime sen yap
        // Biri senden IProductService isterse ona bir tane product manager newle arkaplanda
        //AddSingleton - Data tutulmuyorsa Singleton kullan
        //AddScoped - veri tutuluyorsa
            services.AddSingleton<IProductService,ProductManager>();
            services.AddSingleton<IProductDal, EfProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
