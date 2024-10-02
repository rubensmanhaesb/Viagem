using System.Text.Json.Serialization;
using ViagemApp.API.Extensions;
using ViagemAApp.Repository.Extensions;
using DomainSharedLib.Domain.Shared;

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


#region Extensoes
builder.Services.AddDependecyInjection();
//builder.Services.AddCorsConfig();
builder.Services.AddEntityFramework(builder.Configuration, (AmbienteEnum)Enum.Parse(typeof(AmbienteEnum), builder.Environment.EnvironmentName));
builder.Services.AddMapper();
#endregion Extensoes

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorsConfig();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }