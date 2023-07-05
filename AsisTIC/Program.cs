using AsisTIC;
using AsisTIC.Contexts;
using AsisTIC.Models.Dto;
using AsisTIC.Repositorio;
using AsisTIC.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("CnACO"));

});


builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddScoped<ITicketRepositorio, TicketRepositorio>();

builder.Services.AddScoped<ITicketTipoSolicitudRepositorio, TicketTipoSolicitudRepositorio>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
