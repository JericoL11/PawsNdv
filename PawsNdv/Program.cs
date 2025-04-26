
using Microsoft.EntityFrameworkCore;
using Paws.Application.Interfaces;
using Paws.Application.Services;
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

builder.Services.AddScoped<IOwnerService, OwnerService>();

builder.Services.AddControllers();


//Importtant for angular connection
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularFrontEnd", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


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

//impolrtant =>>>> head
app.UseRouting(); // Add this line for enabling routing middleware

app.UseCors("AllowAngularFrontEnd"); // Must come after UseRouting and before UseAuthorization
// <=== Tail
app.UseAuthorization();

app.MapControllers();

app.Run();
