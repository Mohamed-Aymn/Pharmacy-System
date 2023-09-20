using System.Text;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// mongodb
// builder.Services.AddSingleton<MongoDBService>();
builder.Services.AddScoped<IMongoDBService, MongoDBService>();

// logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
        };
    });
// builder.Services.AddAuthentication(x =>
// {
//     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(x =>
// {
//     x.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidIssuer = MyConfig.GetValue<string>("JwtSettings:Issuer"),
//         ValidAudience = MyConfig.GetValue<string>("JwtSettings:Audience"),
//         IssuerSigningKey = new SymmetricSecurityKey
//             (Encoding.UTF8.GetBytes(MyConfig.GetValue<string>("JwtSettings:Audience")!)),
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true
//     };
// });
builder.Services.AddAuthorization();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// generice request pipline
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
