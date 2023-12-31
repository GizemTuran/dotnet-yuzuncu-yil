﻿using DotnetYuzuncuYil.API.Abstraction;
using DotnetYuzuncuYil.Core.Repositories;
using DotnetYuzuncuYil.Core.Services;
using DotnetYuzuncuYil.Core.UnitOfWorks;
using DotnetYuzuncuYil.Repo;
using DotnetYuzuncuYil.Repo.Repositories;
using DotnetYuzuncuYil.Repo.UnitOfWorks;
using DotnetYuzuncuYil.Service.Mapping;
using DotnetYuzuncuYil.Service.Services;
using DotnetYuzuncuYil.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<ITeamService, TeamService>();

//JWT Kütüphanesinin Tanıtılması
//builder.Services.AddSingleton<IJwtAuthenticationManager>(new IJwtAuthenticationManager());

builder.Services.AddControllers().AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>(); });

//AddDbContext işlemler

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
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
