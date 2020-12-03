using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Controllers;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.PictureRequestModels;
using IT_Projektas_Backend.Services.AuthService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IT_Projektas_Backend
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
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<it_projektasContext>(x =>
                x.UseMySql("server=127.0.0.1;port=3306;user=root;password=;database=it_projektas"));
            // <-- Add CORS policy to allow frontend to access the API -->
            services.AddCors(options =>
                options.AddPolicy("MyPolicy", builder =>
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyMethod().AllowAnyHeader()
                    ));
            // ----------------------------------
            // Add dependency injections
            // ----------------------------------
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPictureService, PictureService>();
            // ----------------------------------
            services.AddSwaggerGen(x => { x.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Animal Hotel WEB-API", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("swagger/V1/swagger.json", "WEB-API");
                x.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("MyPolicy"); // use created cors policy
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "ProfilePictureStorage")),
                RequestPath = new PathString("/ProfilePictureStorage")
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
