using AutoMapper;
using dellirium_hotel_data.Context;
using dellirium_hotel_infraestructure.Configuration;
using dellirium_hotel_services.Services;
using dellirium_hotel_services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Registrar AutoMapper
//builder.Services.AddAutoMapper(typeof(Mapper));

// Registrar IConfigProvider
builder.Services.AddTransient<IConfigurationApp, ConfigurationApp>();
builder.Services.AddTransient<IUsersService, UsersService>();

// Registrar DbContext
builder.Services.AddTransient<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
