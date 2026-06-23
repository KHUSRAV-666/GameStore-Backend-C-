using System.Text;
using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// token
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// games
builder.Services.AddValidation();
builder.AddGameStoreDb();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["AppSettings:Issuer"],
    ValidateAudience = true,
    ValidAudience = builder.Configuration["AppSettings:Audience"],
    ValidateLifetime = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
    ValidateIssuerSigningKey = true,
});

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// token
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// games
app.MapGamesEndpoints();
app.MapGenresEndpoints();
app.MigrateDb();
app.Run();
