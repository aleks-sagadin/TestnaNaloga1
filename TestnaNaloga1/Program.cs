using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestnaNaloga.Application;
using TestnaNaloga.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Add the converter for enums to be serialized as strings
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Configuration
ConfigurationManager configuration = builder.Configuration;


//Add Database Service
builder.Services.AddDbContext<ZahtevekDbContext>(static options =>
    options.UseInMemoryDatabase("ZahtevekDB"));
builder.Services.AddScoped<IZahtevekService, ZahtevekService>();
builder.Services.AddScoped<IZahtevekRepository, ZahtevekRepository>();
// Uporabite Newtonsoft.Json za serializacijo
var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
    
    //redirect na swagger when start program
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next();
    });
}



app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

