using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Retail.Business.Concretes;
using Retail.Business.Interfaces;
using Retail.Business.IoC.Autofac;
using Retail.DataAccess.Concretes.EntityFramework;
using Retail.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Retail.Business.Validations.FluentValidation;
using Retail.Core.Extentions;
using Retail.Core.CustomExceptions;

namespace Retail.API
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

            //services.AddDbContext<RetailDbContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), sqlOptions =>
            //    {
            //        sqlOptions.MigrationsAssembly("Retail.DataAccess");
            //    });
            //});

            //çözüm için eklenen

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000"));
            });

            services.AddDbContext<RetailDbContext>();


            services.AddIdentity<IdentityUser, IdentityRole>(Opt =>
            {
                Opt.User.RequireUniqueEmail = true;
                Opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<RetailDbContext>().AddDefaultTokenProviders();




            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerDtoValidator>());
                //.AddJsonOptions(p => 
                //{
                //    p.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                //    p.JsonSerializerOptions.IgnoreNullValues = true;
                //});



            //.ConfigureApiBehaviorOptions(option => {

            //     option.InvalidModelStateResponseFactory = c =>
            //     {
            //         var errors = c.ModelState.Values.Where(p => p.Errors.Count > 0).SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
            //         var title = c.ModelState;
            //         return new BadRequestObjectResult(new BadRequestValidationResult
            //         {
            //             Description = "Validation Errors",
            //             ErrorCode = 400,
            //             Message = errors
            //         });
            //     };
            // })


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Retail.API", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ContainerModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Retail.API v1"));
            }

            app.UseCustomExceptionMiddleware();

            app.UseCors(builder =>
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());


            app.UseAuthentication();

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
