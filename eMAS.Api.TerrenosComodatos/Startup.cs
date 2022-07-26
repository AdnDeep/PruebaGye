using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddHttpServices();
            services.AddServicesTramitesExtensions();
            services.AddServicesBeneficiariosExtensions();
            services.AddServicesGenericExtensions();
            services.AddSessionServicesExtensions();
            services.AddSwaggerConfiguration();
            services.AddHelperExtensions();
            services.AddAuthenticatinServices(Configuration);
            services.AddServicesTelemetry();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }
            app.UseOpenApi();
            app.UseSwaggerUi3(c =>
            {
                c.OAuth2Client = new NSwag.AspNetCore.OAuth2ClientSettings
                {
                    ClientId = "133bb649-674c-4162-ab2c-cfff03911482",
                    AppName = "eMAS.Api.TerrenosComodatos"// Nombre
                };
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
        }
    }
}
