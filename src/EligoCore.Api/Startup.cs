using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;
using EligoCore.Interfaces;
using EligoCore;
using EligoCore.Service;
using EligoCore.Data.MSSQL;
using EligoCore.Domain;

namespace EligoCore.Api
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
            services.AddHealthChecks();
            services.AddOptions();

            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMqConfiguration>();
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().AddFluentValidation();

            ConfigureSwagger(services);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var actionExecutingContext =
                        actionContext as ActionExecutingContext;

                    if (actionContext.ModelState.ErrorCount > 0
                        && actionExecutingContext?.ActionArguments.Count == actionContext.ActionDescriptor.Parameters.Count)
                    {
                        return new UnprocessableEntityObjectResult(actionContext.ModelState);
                    }

                    return new BadRequestObjectResult(actionContext.ModelState);
                };
            });

            services.AddScoped<IDataSource>(provider =>
                new EligoCoreDataSource(Configuration, "MyDb"));

            services.AddTransient<IUnitOfWork, MyDbContext>();

            services.AddTransient<Data.MSSQL.Repositories.RefCountryRepository>();

            services.AddTransient<RefCountryRepositoryResolver>(provider => key =>
            {
                switch (key)
                {
                    case "MSSQL":
                        return provider.GetService<Data.MSSQL.Repositories.RefCountryRepository>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddTransient<IRefCountryService, RefCountryService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EligoCoreApi 1",
                    Description = "EligoCoreApi 1 Description",
                    Contact = new OpenApiContact
                    {
                        Name = "Baris Kalaycioglu",
                        Email = "thecodemasterzz@gmail.com",
                        Url = new Uri("https://www.github.com/thecodemasterzz")
                    }
                });
            });
        }
    }

}
