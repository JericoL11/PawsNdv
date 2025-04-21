
using Microsoft.EntityFrameworkCore;
using PawsNdv.Domain.Interfaces;
using PawsNdv.Infrastructure.Data;
using PawsNdv.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PawsNdvContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PawsNdvConnection")));

// 🧱 Add Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 🎯 AutoMapper, FluentValidation, etc. (optional)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
