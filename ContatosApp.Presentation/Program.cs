using ContatosApp.Domain.Interfaces.Repositories;
using ContatosApp.Domain.Interfaces.Services;
using ContatosApp.Domain.Services;
using ContatosApp.Infra.Data.Repositories;
using ContatosApp.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
SwaggerConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);
JwtBearerConfiguration.Configure(builder.Services);
builder.Services.AddTransient<IUsuarioDomainService,
UsuarioDomainService>();
builder.Services.AddTransient<IContatosDomainService,
ContatosDomainService>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IContatosRepository, ContatosRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(CorsConfiguration.PolicyName);

app.Run();
public partial class Program { }
