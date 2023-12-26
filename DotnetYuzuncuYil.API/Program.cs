using DotnetYuzuncuYil.Core.Services;
using DotnetYuzuncuYil.Core.UnitOfWorks;
using DotnetYuzuncuYil.Repo;
using DotnetYuzuncuYil.Repo.Repositories;
using DotnetYuzuncuYil.Repo.UnitOfWorks;
using DotnetYuzuncuYil.Service;
using DotnetYuzuncuYil.Service.Mapping;
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
builder.Services.AddScoped(typeof(GenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddControllers()
    .AddFluentValidation(x =>
    {
        x.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<UserProfileValidator>();
    });

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
