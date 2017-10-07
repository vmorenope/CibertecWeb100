using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using FluentValidation.AspNetCore;
using FluentValidation;
using Cibertec.Models;
using CIbertec.WebApi.Validators;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using CIbertec.WebApi.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CIbertec.WebApi
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
            services.AddSingleton<IUnitOfWork>
                (option => new NorthwindUnitOfWork
                    (
                        Configuration.GetConnectionString("Northwind")
                    )
                );
            services.AddMvc();
            // código para poder referenciar fluent validation desde el inyector de dependencias de Asp Net Core.
            // Se podria usar Using y llamar a una clase Validator donde esten todos los validadores generados
            // como services.AddTransient<IValidator<Customer>, CustomerValidator>();
            services.AddSingleton<IUnitOfWork>(option => new NorthwindUnitOfWork(Configuration.GetConnectionString("Northwind")));
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Customer>, CustomerValidator>();

            //Optimizar el servicio WebApi. 
            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

            //07.10 Autentificacion
            var tokenProvider = new RsaJwtTokenProvider("issuer", "audience", "token_cibertec_2017");
            services.AddSingleton<ITokenProvider>(tokenProvider);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; options.TokenValidationParameters = tokenProvider.GetValidationParameters();
            });


            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()

                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseResponseCompression();
            
            // 07.10 Autentificacion
            app.UseAuthentication();

            app.UseMvc();
        }

    }
}
