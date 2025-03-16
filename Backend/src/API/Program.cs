using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.Mapper;
using Infrastructure.Data;


var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<CourseMapperProfile>();
});

IMapper mapper = mapperConfig.CreateMapper();
//services.AddSingleton(mapper);

var builder = WebApplication.CreateBuilder(args);

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Controllers
builder.Services.AddControllers();

// Add Swagger (OpenAPI) Support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();
