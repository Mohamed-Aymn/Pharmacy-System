using System.Text;
using AuthenticationService;
using AuthenticationService.Presistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// mongodb
// builder.Services.AddSingleton<MongoDBService>();
// builder.Services.AddScoped<IMongoDBService, MongoDBService>();
builder.Services.AddScoped<IMongoDbContext>(provider =>
{
    MongoDbContextSettings contextSettings = new(
        MyConfig.GetValue<string>("MongoDB:ConnectionURI")!,
        MyConfig.GetValue<string>("MongoDB:DatabaseName")!
    );

    return new MongoDbContext(contextSettings);
});
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
builder.Services.AddAuthorization();
builder.Services.AddRepositories();

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

// to use this class in test classes
public partial class Program { }