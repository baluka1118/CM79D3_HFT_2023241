using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Logic.Classes;
using CM79D3_HFT_2023241.Logic.Interfaces;
using CM79D3_HFT_2023241.Models;
using CM79D3_HFT_2023241.Repository.Database;
using CM79D3_HFT_2023241.Repository.Interfaces;
using CM79D3_HFT_2023241.Repository.ModelRepositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using CM79D3_HFT_2023241.Endpoint.Services;

namespace CM79D3_HFT_2023241.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FireFightingDbContext>();

            services.AddTransient<IRepository<FireStation>, FireStationRepository>();
            services.AddTransient<IRepository<Firefighter>, FirefighterRepository>();
            services.AddTransient<IRepository<Equipment>, EquipmentRepository>();
            services.AddTransient<IRepository<EmergencyCall>, EmergencyCallRepository>();

            services.AddTransient<IFireStationLogic, FireStationLogic>();
            services.AddTransient<IFirefighterLogic, FirefighterLogic>();
            services.AddTransient<IEquipmentLogic, EquipmentLogic>();
            services.AddTransient<IEmergencyCallLogic, EmergencyCallLogic>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CM79D3_HFT_2023241.Endpoint", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CM79D3_HFT_2023241.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<SignalRHub>("/hub");
                endpoints.MapControllers();
            });
        }
    }
}
