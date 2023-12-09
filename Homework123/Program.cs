using Homework123.Controllers;
using Homework123.Data;
using Homework123.Repositores.Abstract;
using Homework123.Repositores.Concrete;
using Homework123.Services;
using Homework123.Services.Abstract;
using Homework123.Services.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<BackgroundWorkerService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGetMovieService, GetMovieService>();
builder.Services.AddScoped<MovieController>();

var connection = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<MovieDBContext>(opt =>
{
    opt.UseSqlServer(connection);

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
