using FinalProjectWebAPI.BusinessLogic.Contracts;
using FinalProjectWebAPI.BusinessLogic.Services;
using FinalProjectWebAPI.Model;
using FinalProjectWebAPI.Repositories.Interfaces;
using FinalProjectWebAPI.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
#region Connections to Database
var connectionString = builder.Configuration.GetConnectionString("MyDatabaseConnection");
builder.Services.AddDbContext<SellingDbContext>(options => options.UseSqlServer(connectionString, sqlServerOptionsAction: s => s.EnableRetryOnFailure()));
builder.Services.AddScoped<DbContext, SellingDbContext>();
#endregion

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IContactPersonRepository, ContactPersonRepository>(); // Add this line
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IContactPersonService, ContactPersonService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

