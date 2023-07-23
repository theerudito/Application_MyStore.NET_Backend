using Microsoft.EntityFrameworkCore;
using Store.Database;
using Store.Repository;
using Store.Service;
using Store.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// ConnectionString
//string connectionString = builder.Configuration.GetConnectionString("MyConnectionDatabaseOne");
string baseDirectory = AppContext.BaseDirectory;

//var folder = builder.Configuration.GetConnectionString("MyConnectionDatabaseTwo");
string folder = "MyDatabase";
string database = "Store.db";
string databaseFilePath = Path.Combine(baseDirectory, folder, database);
var connectionString = $"Data Source={databaseFilePath}";

// Postgres
// builder.Services.AddDbContext<Application_ContextDB>(
//     options => options.UseNpgsql(connectionString)
// );

// Sqlite
builder.Services.AddDbContext<Application_ContextDB>(
    options => options.UseSqlite(connectionString)
);

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
