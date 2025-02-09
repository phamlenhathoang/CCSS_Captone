using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    public partial class CCSSDBContext : DbContext
    {
        public CCSSDBContext(DbContextOptions<CCSSDBContext> options) : base(options)
        {
        }
        public CCSSDBContext() { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountTask> AccountTasks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCategory> EventCategories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory()) // Đặt thư mục gốc
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Nạp tệp appsettings.json
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối
        //    optionsBuilder.UseSqlServer(connectionString); // Sử dụng chuỗi kết nối
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Server=localhost;Database=CCSSDB;Uid=sa;Password=12345;MultipleActiveResultSets=true;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships explicitly if needed

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountTasks)
                .WithOne(at => at.Account)
                .HasForeignKey(at => at.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Feedbacks)
                .WithOne(f => f.Account)
                .HasForeignKey(f => f.AccountId);

            modelBuilder.Entity<AccountTask>()
                .HasOne(at => at.Task)
                .WithMany(ac => ac.AccountTasks)
                .HasForeignKey(at => at.TaskId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.EventCategories)
                .WithOne(ec => ec.Category)
                .HasForeignKey(ec => ec.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Characters)
                .WithOne(ch => ch.Category)
                .HasForeignKey(ch => ch.CategoryId);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Images)
                .WithOne(i => i.Character)
                .HasForeignKey(i => i.CharacterId);

            modelBuilder.Entity<Contract>()
                .HasOne(a => a.Account)
                .WithOne(c => c.Contract)
                .HasForeignKey<Contract>(c => c.AccountId);

            modelBuilder.Entity<Contract>()
                .HasOne(e => e.Event)
                .WithOne(c => c.Contract)
                .HasForeignKey<Contract>(c => c.EventId);

            modelBuilder.Entity<EventCategory>()
                .HasOne(ec => ec.Event)
                .WithMany(e => e.EventCategories)
                .HasForeignKey(ec => ec.EventId);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Account)
                .WithOne(a => a.Image)
                .HasForeignKey<Image>(i => i.AccountId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Contract)
                .WithOne(c => c.Payment)
                .HasForeignKey<Payment>(p => p.ContractId);
            // Seed data for Roles
            modelBuilder.Entity<Role>().HasData(
       new Role { RoleId = "1", RoleName = (RoleEnum)1, Description = "Administrator role" },
       new Role { RoleId = "2", RoleName = (RoleEnum)2, Description = "Regular user role" }
   );

            // Seed data cho bảng Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = "account1",
                    Name = "Admin User",
                    Email = "admin@example.com",
                    Phone = 1234567890,
                    Birthday = DateTime.Parse("1990-01-01"),
                    Gender = true,
                    Address = "123 Admin Street",
                    CreateDate = DateTime.UtcNow,
                    IsActive = true,
                    Password = BCrypt.Net.BCrypt.HashPassword("password123"), // hashed password
                    RoleId = "1"
                },
                new Account
                {
                    AccountId = "account2",
                    Name = "Regular User",
                    Email = "user@example.com",
                    Phone = 0987654321,
                    Birthday = DateTime.Parse("2000-01-01"),
                    Gender = false,
                    Address = "456 User Lane",
                    CreateDate = DateTime.UtcNow,
                    IsActive = true,
                    Password = BCrypt.Net.BCrypt.HashPassword("password456"), // hashed password
                    RoleId = "2"
                }
            );

            // Seed data cho bảng Task
            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    TaskId = "task1",
                    Name = "Task 1",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    Location = "Location 1",
                    Description = "This is task 1",
                    IsActive = true
                },
                new Task
                {
                    TaskId = "task2",
                    Name = "Task 2",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    Location = "Location 2",
                    Description = "This is task 2",
                    IsActive = true
                }
            );

            // Seed data cho bảng AccountTask
            modelBuilder.Entity<AccountTask>().HasData(
                new AccountTask
                {
                    AccountTaskId = "accountTask1",
                    AccountId = "account1",
                    TaskId = "task1"
                },
                new AccountTask
                {
                    AccountTaskId = "accountTask2",
                    AccountId = "account2",
                    TaskId = "task2"
                }
            );

            // Seed data cho bảng Category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = "category1",
                    Name = "Category 1",
                    Description = "This is Category 1"
                },
                new Category
                {
                    CategoryId = "category2",
                    Name = "Category 2",
                    Description = "This is Category 2"
                }
            );

            // Seed data cho bảng Character
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    CharacterId = "character1",
                    CategoryId = "category1",
                    Name = "Character 1",
                    Description = "Description for Character 1",
                    Price = 100.50,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    IsActive = "true"
                },
                new Character
                {
                    CharacterId = "character2",
                    CategoryId = "category2",
                    Name = "Character 2",
                    Description = "Description for Character 2",
                    Price = 200.75,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    IsActive = "true"
                }
            );
            // Seed data cho bảng Event
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = "event1",
                    Name = "Event 1",
                    Description = "This is event 1",
                    Type = "Conference",
                    Status = (EventStatus)1,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null
                },
                new Event
                {
                    EventId = "event2",
                    Name = "Event 2",
                    Description = "This is event 2",
                    Type = "Workshop",
                    Status = (EventStatus)2,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                }
            );
             modelBuilder.Entity<EventCategory>().HasData(
                    new EventCategory
                    {
                        EventCategoryId = "eventcategory1",
                        CategoryId = "category1",
                        EventId = "event1",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = null
                    },
                    new EventCategory
                    {
                        EventCategoryId = "eventcategory2",
                        CategoryId = "category2",
                        EventId = "event2",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = null
                    }
                );

            // Seed data cho bảng Contract
            modelBuilder.Entity<Contract>().HasData(
                new Contract
                {
                    ContractId = "contract1",
                    AccountId = "account1",
                    EventId = "event1",
                    Description = "Contract for Event 1",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    Price = 500.00,
                    Signature = true,
                    Name = "Contract 1",
                    Deposit = 100,
                    Amount = 400.00
                },
                new Contract
                {
                    ContractId = "contract2",
                    AccountId = "account2",
                    EventId = "event2",
                    Description = "Contract for Event 2",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    Price = 800.00,
                    Signature = false,
                    Name = "Contract 2",
                    Deposit = 200,
                    Amount = 600.00
                }
            );
            // Seed data cho bảng Feedback
            modelBuilder.Entity<Feedback>().HasData(
        new Feedback
        {
            FeedbackId = "feedback1",
            AccountId = "account1", // Phải khớp với Account đã có
            Star = 5,
            Description = "Great service, highly recommended!",
            CreateDate = DateTime.UtcNow,
            UpdateDate = null
        },
        new Feedback
        {
            FeedbackId = "feedback2",
            AccountId = "account2",
            Star = 4,
            Description = "Good service, but there's room for improvement.",
            CreateDate = DateTime.UtcNow,
            UpdateDate = null
        }
    );
            // Seed data cho bảng Image
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    ImageId = "image1",
                    ImageUrl = "https://example.com/image1.jpg",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    AccountId = "account1",  // Hình ảnh thuộc về tài khoản admin
                    CharacterId = null       // Không gán cho Character
                },
                new Image
                {
                    ImageId = "image2",
                    ImageUrl = "https://example.com/image2.jpg",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    AccountId = "account2",  // Hình ảnh thuộc về tài khoản user
                    CharacterId = null
                },
                new Image
                {
                    ImageId = "image3",
                    ImageUrl = "https://example.com/image3.jpg",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    AccountId = null,        // Không gán cho Account
                    CharacterId = "character1" // Hình ảnh thuộc về nhân vật 1
                },
                new Image
                {
                    ImageId = "image4",
                    ImageUrl = "https://example.com/image4.jpg",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = null,
                    AccountId = null,        // Không gán cho Account
                    CharacterId = "character2" // Hình ảnh thuộc về nhân vật 2
                }
            );
            // Seed data cho bảng Payment
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentId = "payment1",
                    ContractId = "contract1",
                    Type = "Credit Card",
                    Status = PaymentStatus.Completed,
                    CreateDate = DateTime.UtcNow,
                    TransactionId = "TXN123456"
                },
                new Payment
                {
                    PaymentId = "payment2",
                    ContractId = "contract2",
                    Type = "Bank Transfer",
                    Status = PaymentStatus.Pending,
                    CreateDate = DateTime.UtcNow,
                    TransactionId = "TXN789012"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
