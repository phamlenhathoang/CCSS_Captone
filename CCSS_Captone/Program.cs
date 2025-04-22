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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Google.Apis.Auth.OAuth2;

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
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<ICustomerCharacterImageRepository, CustomerCharacterImageRepository>();
builder.Services.AddScoped<ICustomerCharacterRepository, CustomerCharacterRepository>();
builder.Services.AddScoped<ICharacterImageRepository, CharacterImageRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartProductRepository, CartProductRepository>();
builder.Services.AddScoped<IBeginTransactionRepository, BeginTransactionRepository>();
builder.Services.AddScoped<IAccountImageRepository, AccountImageRepository>();
builder.Services.AddScoped<IRequestDatesRepository, RequestDatesRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();


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
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductImageServices, ProductImageServices>();
builder.Services.AddScoped<ICustomerCharacterService, CustomerCharacterService>();
builder.Services.AddScoped<ICharacterImageServices, CharacterImageServices>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddScoped<ICartProductServices, CartProductServices>();
builder.Services.AddScoped<IVNPayService, VNPayService>();
builder.Services.AddScoped<IServiceServices, ServiceServices>();
builder.Services.AddScoped<IAccountImageService, AccountImageService>();
builder.Services.AddScoped<IRequestDateServices, RequestDateServices>();
builder.Services.AddScoped<IActivityService, ActivityService>();




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
                               typeof(ActivityProfile),
                               typeof(FeedbackProfile),
                               typeof(OrderProfile),
                               typeof(OrderProductProfile));

builder.Services.AddSignalR();

builder.Services.AddDbContext<CCSSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<NotificationBackgroundService>();
builder.Services.AddHostedService<ContractBackgroudService>();
builder.Services.AddHostedService<OrderBackgroundService>();
builder.Services.AddHostedService<RequestBackgroundService>();
builder.Services.AddHostedService<PaymentBackgroundService>();

builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie(options => {
        options.Cookie.SameSite = SameSiteMode.None; // Try this if cross-site issues
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    })
    .AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Google:ClientId"];  
    options.ClientSecret = builder.Configuration["Google:ClientSecret"];
    options.CallbackPath = builder.Configuration["Google:CallbackPath"];

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



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token in the form 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
});
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapHub<NotificationHub>("/notificationHub");

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
