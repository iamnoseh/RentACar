using Domain;
using Infrastructure.CarService;
using Infrastructure.CustomerService;
using Infrastructure.DataContext;
using Infrastructure.LocationService;
using Infrastructure.RentalService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<RentalService>();
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<RentalService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<IRentalService,RentalService>();
builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IRentalService,RentalService>();
builder.Services.AddScoped<ILocationService,LocationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapScalarApiReference();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebApp v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();