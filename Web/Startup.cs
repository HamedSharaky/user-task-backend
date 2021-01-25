using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserTask.Presistence;
using UserTask.Application;
using FluentValidation.AspNetCore;

namespace UserTask.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining(typeof(Application.Common.Exceptions.ValidationException)));
            services.AddSingleton(Configuration);
            services.AddHttpContextAccessor();

            services.AddApplication();
            services.AddPersistence(Configuration);

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "HTTP API";
                    document.Info.Description = "Task CRUD Service HTTP API";
                    document.Info.TermsOfService = "Terms Of Service";

                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Task",
                        Email = string.Empty,
                        Url = string.Empty
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };

            });
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
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            ////app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserTask API V1");

            //    // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
            //    //c.RoutePrefix = string.Empty;
            //});

            app.UseHttpsRedirection();
            app.UseMvc();
            

            //Enable middleware to serve generated Swagger as a JSON endpoint.
#pragma warning disable CS0618 // Type or member is obsolete
            //app.UseSwagger();
#pragma warning restore CS0618 // Type or member is obsolete
            app.UseOpenApi();  //route defined in document: /swagger/v1/swagger.json
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                //    settings.DocumentPath = "/api/specification.json";   Enable when NSwag.MSBuild is upgraded to .NET Core 3.0
            });



        }
    }

}
