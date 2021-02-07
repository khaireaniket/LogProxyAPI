using LogProxyAPI.BusinessLogic;
using LogProxyAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using System;
using System.Threading.Tasks;

namespace LogProxyAPI
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
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IHandler, Handler>();

            services.AddControllers();

            // Add basic authentication
            services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "Log Delegator API",
                    Version = "v1"
                });
                options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapWhen(context => InvalidQueryStringParam(context), (IApplicationBuilder applicationBuilder) =>
            {
                applicationBuilder.Run(async context =>
                {
                    await Task.FromResult(context.Response.StatusCode = StatusCodes.Status400BadRequest);
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// If query string parameter max records to fetch is less than 1, 400 bad request is returned
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool InvalidQueryStringParam(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("maxRecordsToFetch"))
            {
                context.Request.Query.TryGetValue("maxRecordsToFetch", out StringValues maxRecords);
                if (maxRecords.Count > 0)
                {
                    Int32.TryParse(maxRecords[0], out int intMaxRecords);
                    if (intMaxRecords <= 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
