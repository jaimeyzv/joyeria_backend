using AutoMapper;
using Joyeria.Application.Interfaces;
using Joyeria.Application.Interfaces.Repositories;
using Joyeria.Application.Mapper;
using Joyeria.Application.UseCase.CategoryUC.Commands;
using Joyeria.Application.UseCase.CategoryUC.Queries;
using Joyeria.Application.UseCase.ComplaintUC.Commands;
using Joyeria.Application.UseCase.ComplaintUC.Queries;
using Joyeria.Application.UseCase.OrderUC.Commands;
using Joyeria.Application.UseCase.OrderUC.Queries;
using Joyeria.Persitance.Repositories;
using Joyeria.Persitance.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryCommands , CategoryCommands>();
builder.Services.AddScoped<ICategoryQueries, CategoryQueries>();
builder.Services.AddScoped<IComplaintCommands, ComplaintCommands>();
builder.Services.AddScoped<IComplaintQueries, ComplaintQueries>();
builder.Services.AddScoped<IOrderCommands, OrderCommands>();
builder.Services.AddScoped<IOrderQueries, OrderQueries>();



builder.Services.AddDbContext<JoyeriaDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("JoyeriaDb"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

builder.Services.AddCors(options => options.AddPolicy("AlloWebApp",
                                    builder => builder.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutorMapperProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AlloWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
