using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.BackgroundServices;
using CCSS_Service.Hubs;
using CCSS_Service.Profiles;
using CCSS_Service.Services;
using Microsoft.EntityFrameworkCore;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CCSS_Service;
using Microsoft.OpenApi.Models;
using CCSS_Service.Libraries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
});
builder.Services.Configure<MomoOptionModel>(builder.Configuration.GetSection("MomoAPI"));
builder.Services.AddScoped<IMomoService, MomoService>();


//Repositories
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IContractRespository, ContractRespository>();
builder.Services.AddScoped<IContractCharacterRepository, ContractCharacterRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();  
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketAccountRepository, TicketAccountRepository>();
builder.Services.AddScoped<IEventCharacterRepository, EventCharacterRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IDashBoardRepository, DashBoardRepository>();
builder.Services.AddScoped<IAccountCouponRepository, AccountCouponRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestCharacterRepository, RequestCharacterRepository>();
builder.Services.AddScoped<IEventChacracterRepository, EventChacracterRepository>();
builder.Services.AddScoped<IAccountCouponRepository, AccountCouponRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();


//Service
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IContractServices, ContractServices>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITicketAccountService, TicketAccountService>();
builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddScoped<IDashBoardService, DashBoardService>();
builder.Services.AddScoped<IRequestServices, RequestServices>();
builder.Services.AddScoped<IRequestCharacterService, RequestCharacterService>();
builder.Services.AddScoped<IFeedbackService, FeebackService>();
builder.Services.AddScoped<IContractCharacterService, ContractCharacterService>();
builder.Services.AddScoped<IPdfService, Pdf>();


//Libraries
builder.Services.AddScoped<Image>();
builder.Services.AddScoped<Pdf>();
builder.Services.AddScoped<SendMail>();


//AutoMapper
builder.Services.AddAutoMapper(typeof(PackageProfile),
                               typeof(CharacterProfile), 
                               typeof(CategoryProfile),
                               typeof(TaskProfile),
                               typeof(AccountProfile),
                               typeof(EventProfile),
                               typeof(TicketProfile),
                               typeof(TicketAccountProfile),
                               typeof(EventCharacterProfile),
                               typeof(EventActivitProfile),
                               typeof(ActivityProfile));

builder.Services.AddSignalR();

builder.Services.AddDbContext<CCSSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<NotificationBackgroundService>();
builder.Services.AddHostedService<ContractBackgroudService>();

builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

builder.Services.AddScoped<IVNPayService, VNPayService>();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapHub<NotificationHub>("/notificationHub");

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
