
using ProjectTemplateVP.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectTemplateVP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();
            var clientId = Configuration["APS_CLIENT_ID"];
            var callbackUrl = Configuration["APS_CALLBACK_URL"];
            /*            var clientSecret = Configuration["APS_CLIENT_SECRET"];
            */
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(callbackUrl))
            {
                throw new ApplicationException("Missing env variables client id and or callback url!");
            }
            serviceCollection.AddSingleton(new APS(clientId, callbackUrl));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
