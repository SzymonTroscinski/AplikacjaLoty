

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer(); //
builder.Services.AddControllers();
builder.Services.AddHttpClient(); // dodajemy 
builder.Services.AddSwaggerGen(); //

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlightInfoAPI v1"));

app.Run();
