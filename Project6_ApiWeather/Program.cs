using Microsoft.EntityFrameworkCore;
using Project6_ApiWeather.context;

var builder = WebApplication.CreateBuilder(args);

// Connection string'i appsettings.json'dan alıyoruz
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i ekliyoruz
builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// ✅ Swagger servislerini ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Swagger middleware'i aktif et
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
