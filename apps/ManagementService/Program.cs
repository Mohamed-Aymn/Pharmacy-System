using System.Reflection;
using ManagementService.ControllersPipelineHandlers;
using ManagementService.Persistence;
using MapsterMapper;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add<ValidationExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbConnectionString));
builder.Services.AddSingleton<IMapper, Mapper>();

// mediator and validators
builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// generic repository
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

// pipeline behaviours
builder.Services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

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
