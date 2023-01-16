using BancoNorton.Api.Service;
using BancoNorton.Api.Validator;
using BancoNorton.DAL;
using BancoNorton.DAL.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IContaJuridicaRepository, ContaJuridicaRepository>();
builder.Services.AddScoped<IContaFisicaRepository, ContaFisicaRepository>();
builder.Services.AddTransient<ContaJuridicaDTOValidator>();
builder.Services.AddTransient<ContaFisicaDTOValidator>();


builder.Services.AddFluentValidation();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();//deu erro aqui

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
