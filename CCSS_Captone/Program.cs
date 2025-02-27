using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.BackgroundServices;
using CCSS_Service.Hubs;
using CCSS_Service.Profiles;
using CCSS_Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Repositories
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IContractRespository, ContractRespository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();  


//Service
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IContractServices, ContractServices>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IEmailService, EmailService>();


//AutoMapper
builder.Services.AddAutoMapper(typeof(PackageProfile),
                               typeof(CharacterProfile), 
                               typeof(CategoryProfile),
                               typeof(TaskProfile),
                               typeof(AccountProfile),
                               typeof(AccountResponseProfile));

builder.Services.AddSignalR();

builder.Services.AddDbContext<CCSSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<NotificationBackgroundService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapHub<TaskHub>("/taskHub");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
