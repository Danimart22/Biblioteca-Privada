using APIBibliotecaPrivada.Negocio;
using Microsoft.EntityFrameworkCore;
using APIBibliotecaPrivada.Utilidades;
using APIBibliotecaPrivada.DAO;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var mySQLConfiguraction = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton<MySQLConfiguration>(mySQLConfiguraction);


builder.Services.AddScoped<ILibroNegocio, LibroNegocio>();
builder.Services.AddSingleton<ILibroDAO, LibroDAO>();
builder.Services.AddScoped<IClienteNegocio, ClienteNegocio>();
builder.Services.AddSingleton<IClienteDAO, ClienteDAO>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
