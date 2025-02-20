using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Profiles;
using CCSS_Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Repositories
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


//Service
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


//AutoMapper
builder.Services.AddAutoMapper(typeof(PackageProfile),
                               typeof(CharacterProfile), 
                               typeof(CategoryProfile));

builder.Services.AddDbContext<CCSSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
