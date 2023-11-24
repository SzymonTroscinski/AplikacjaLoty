using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AplikacjaLoty", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer(); //
builder.Services.AddControllers();
builder.Services.AddHttpClient(); // dodajemy 


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AplikacjaLoty v1"));

app.Run();
