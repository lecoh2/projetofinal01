using Microsoft.OpenApi.Models;

namespace ContatosApp.Presentation.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
             services.AddSwaggerGen(options => options.SwaggerDoc("v1",
                new OpenApiInfo

                {
                    Title = "ContatoAPP - API para contantos",
                    Description = "API REST .NET com EntityFramework e XUnit",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Alex Sando Costa dos Santos",
                        Email = "lecoh2@hotmail.com",
                        Url = new Uri("http://www.lecoh2.com.br")
                    }
                }));
        }
    }
}
