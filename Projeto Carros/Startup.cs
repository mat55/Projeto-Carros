using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto_Carros.Services;
using Projeto_Carros.Services.Implementation;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto_Carros
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers()
                .AddNewtonsoftJson();

            //services.AddSwaggerGen(d =>
            //    {
            //        d.SwaggerDoc("v1", new Info { Title = "Carros API", Description = "Projeto de cadastro de Carros e Revisões usando WEB API REST com Asp.Net Core", Version = "v1" });
            //    });

            var connection = Configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection)
            );

            services.AddScoped<ICarrosServices, CarrosServicesImpl>();
            services.AddScoped<IRevisoesServices, RevisoesServicesImpl>();

            //services.AddAutoMapper(profileAssembly1, profileAssembly2 /*, ...*/);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseSwaggerUI(d =>
            //{
            //    d.SwaggerEndpoint("/swagger/v1/swagger.json", "Carros API");
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
