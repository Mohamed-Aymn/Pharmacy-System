using System.Text;
using AuthenticationService;
using AuthenticationService.MessageBroker;
using AuthenticationService.Presistence;
using ManagementService.MessageBroker.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
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

// message broker
builder.Services.Configure<MessageBrokerSettings>(builder.Configuration.GetSection("MessageBroker"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

// massTransit
builder.Services.AddMassTransit(busConfigurator =>
{
  busConfigurator.SetKebabCaseEndpointNameFormatter();

  busConfigurator.AddConsumer<UserCreatedEventConsumer>();
  busConfigurator.UsingRabbitMq((context, configurator) =>
  {
    MessageBrokerSettings settings = context.GetRequiredService<MessageBrokerSettings>();

    configurator.ReceiveEndpoint("my-queue", ep =>
    {
      ep.PrefetchCount = 16;
      ep.UseMessageRetry(r => r.Interval(2, 100));

      ep.ConfigureConsumers(context);
    });

    configurator.Host(new Uri(settings.Host), h =>
    {
      h.Username(settings.Username);
      h.Password(settings.Password);
    });
  });
});

// event bus
builder.Services.AddTransient<IEventBus, EventBus>();

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