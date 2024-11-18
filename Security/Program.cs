using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Security.Models;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_URI"));
var database = client.GetDatabase("users");

builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
);

// Add services to the container.

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
