using System.Text.Json.Serialization;
using ViagemApp.API.Extensions;
using ViagemAApp.Repository.Extensions;
using DomainSharedLib.Domain.Shared;
using ViagemApp.Application.Extensions;
using ViagemApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
      // Configura o JSON para preservar referências circulares durante a serialização
      options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
  });

builder.Services.AddRouting(routing => routing.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Services.Extensions
builder.Services.AddDependecyInjection();
builder.Services.AddCorsConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddEntityFramework(builder.Configuration, (AmbienteEnum)Enum.Parse(typeof(AmbienteEnum), builder.Environment.EnvironmentName));
builder.Services.AddMapper();
builder.Services.DTOAddDependecyInjection();
#endregion Services.Extensions

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorsConfig();
app.UseHttpsRedirection();

#region Middlewares.Extensions 
app.UseMiddleware<ValidationExceptionMiddleware>();
#endregion  Middlewares.Extensions 


#region App.Extensions 
app.UseSwaggerConfig();
#endregion App.Extensions 

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }