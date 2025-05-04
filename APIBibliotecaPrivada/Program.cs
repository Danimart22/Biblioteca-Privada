using APIBibliotecaPrivada.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using APIBibliotecaPrivada.Utilidades;
using APIBibliotecaPrivada.DAO;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var mySQLConfiguraction = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton<MySQLConfiguration>(mySQLConfiguraction);

//builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));
builder.Services.AddScoped<ILibroNegocio, LibroNegocio>();
builder.Services.AddSingleton<ILibroDAO, LibroDAO>();
builder.Services.AddScoped<IClienteNegocio, ClienteNegocio>();
builder.Services.AddSingleton<IClienteDAO, ClienteDAO>();



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
