using LearningCenterAPI.Learning.Domain.Repositories;
using LearningCenterAPI.Learning.Domain.Services;
using LearningCenterAPI.Learning.Mapping;
using LearningCenterAPI.Learning.Persistance.Contexts;
using LearningCenterAPI.Learning.Persistance.Repositories;
using LearningCenterAPI.Learning.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

//Add LowerCase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);


//Dependency injection configuration

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, ICategoryService>();
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ITutorialService, TutorialService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



//AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));



////////////////////////////////////

var app = builder.Build();

//Validation for ensuring Database Objects are created

using (var scope =app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

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