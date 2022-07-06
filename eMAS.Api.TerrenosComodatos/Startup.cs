using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace eMAS.Api.TerrenosComodatos
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eMAS.Api.TerrenosComodatos", Version = "v1" });
            });

            services.AddServicesTramitesExtensions();
            services.AddServicesBeneficiariosExtensions();
            services.AddServicesGenericExtensions();
            services.AddSessionServicesExtensions();
            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3(c =>
                {
                    c.OAuth2Client = new NSwag.AspNetCore.OAuth2ClientSettings
                    {
                        ClientId = "133bb649-674c-4162-ab2c-cfff03911482",
                        AppName = "eMAS.Api.TerrenosComodatos"// Nombre
                    };
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
        }
    }
}
