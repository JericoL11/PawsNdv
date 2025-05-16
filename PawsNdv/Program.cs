using Microsoft.EntityFrameworkCore;
using Paws.Application.Interfaces;
using Paws.Application.Services;
using PawsNdv.Domain.Interfaces;
using PawsNdv.Infrastructure.Data;
using PawsNdv.Infrastructure.Repositories;
using FluentValidation;
using Paws.Application.Validators; // 👈 make sure this matches your validator namespace

var builder = WebApplication.CreateBuilder(args);

// 💾 SQL Server Configuration
builder.Services.AddDbContext<PawsNdvContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PawsNdvConnection")));

// 🧱 Unit of Work and Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// 🔁 AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 💼 Services
builder.Services.AddScoped<IOwnerService, OwnerService>();

// ✅ FluentValidation 
//will read all the validations bcs of FluentValidation.DependencyInjectionExtensions
//builder.Services.AddValidatorsFromAssemblyContaining<OwnerCreateValidator>();

// 🌐 Controllers
builder.Services.AddControllers();



// 🌍 CORS for Angular frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularFrontEnd", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 📖 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔧 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // 🚦 Enable Routing

app.UseCors("AllowAngularFrontEnd"); // 🔐 Enable CORS for Angular


// 🔍 Global FluentValidation error handler
//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next();
//    }
//    catch (ValidationException ex)
//    {
//        context.Response.StatusCode = 400;
//        await context.Response.WriteAsJsonAsync(new
//        {
//            Errors = ex.Errors.Select(e => e.ErrorMessage)
//        });
//    }
//});


app.UseAuthorization();

app.MapControllers();

app.Run();
