using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fp_stack.core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<Context>(o => o.UseSqlServer(connection));

            services.AddCors(x =>
            {
                x.AddPolicy("Default",
                builder =>
                {
                    builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod(); ;
                });
            });




            services.AddMvc(
                options => 
                {
                    options.RespectBrowserAcceptHeader = true;
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Default");
            //app.UseMvc();
            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //     name: "default",
            //     template: "{controller=Perguntas}/{action=Index}");

            //    //routes.MapRoute(
            //    //   name: "autor",
            //    //   template: "autor/{nome}",
            //    //   defaults: new { controller = "Autor", action = "Index" });

            //    //routes.MapRoute(
            //    //        name: "topicosdacategoria",
            //    //        template: "{categoria}/{topico}",
            //    //        defaults: new { controller = "Topicos", action = "Index" });

            //    //routes.MapRoute(
            //    //   name: "autoresDoAno",
            //    //   template: "{ano:int}/autor",
            //    //   defaults: new { controller = "Autor", action = "ListaDosAutoresDoAno" });

            //});
        }
    }
}
