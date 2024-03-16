
using api.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using api.Interfaces;
using api.Repositorys;
using api.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<UserDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDbContext<BuchungDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IUserService, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthRepository>();
builder.Services.AddScoped<IBuchungService, BuchungRepository>();

builder.Services.AddSingleton<JwtServices>(provider =>
{
    var secretKey = "yachthafenkey";
    var issuer = "yachthafenissuer";

    return new JwtServices(secretKey, issuer);
});

static string Base64UrlDecode(string base64Url)
{
    string padded = base64Url.PadRight(base64Url.Length + (4 - base64Url.Length % 4) % 4, '=');
    byte[] base64Bytes = Convert.FromBase64String(padded.Replace('-', '+').Replace('_', '/'));
    return Encoding.UTF8.GetString(base64Bytes);
}

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();
app.MapControllers();

app.Run();

