using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Repository.Entities
{
    public class CCSSDbContext : DbContext
    {
        public CCSSDbContext(DbContextOptions<CCSSDbContext> options) : base(options)
        {
        }
        public CCSSDbContext() { }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountCategory> AccountCategories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractCharacter> ContractCharacters { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCharacter> EventCharacters { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Đặt thư mục gốc
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Nạp tệp appsettings.json
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối
            optionsBuilder.UseSqlServer(connectionString); // Sử dụng chuỗi kết nối
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Account - Role
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - RefreshToken
            modelBuilder.Entity<Account>()
                .HasOne(a => a.RefreshToken)
                .WithOne(r => r.Account)
                .HasForeignKey<RefreshToken>(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - Cart
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Cart)
                .WithOne(r => r.Account)
                .HasForeignKey<Cart>(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - Contract
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Contracts)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - AccountCategory
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountCategories)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - Task
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Tasks)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - Ticket
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Tickets)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Cart - Order
            modelBuilder.Entity<Cart>()
                .HasOne(a => a.Order)
                .WithOne(r => r.Cart)
                .HasForeignKey<Order>(a => a.CartId)
                .OnDelete(DeleteBehavior.NoAction);

            //Cart - CartProduct
            modelBuilder.Entity<Cart>()
                .HasMany(a => a.CartProducts)
                .WithOne(r => r.Cart)
                .HasForeignKey(a => a.CartId)
                .OnDelete(DeleteBehavior.NoAction);

            //Order - Payment 
            modelBuilder.Entity<Order>()
                .HasOne(a => a.Payment)
                .WithOne(r => r.Order)
                .HasForeignKey<Payment>(a => a.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            //Product - CartProduct
            modelBuilder.Entity<CartProduct>()
               .HasOne(a => a.Product)
               .WithMany(r => r.CartProducts)
               .HasForeignKey(a => a.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

            //Product - Image
            modelBuilder.Entity<Product>()
               .HasMany(a => a.Images)
               .WithOne(r => r.Product)
               .HasForeignKey(a => a.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

            //Ticket - Event
            modelBuilder.Entity<Event>()
               .HasOne(a => a.Ticket)
               .WithOne(r => r.Event)
               .HasForeignKey<Ticket>(a => a.EventId)
               .OnDelete(DeleteBehavior.NoAction);

            //Ticket - Payment
            modelBuilder.Entity<Ticket>()
               .HasOne(a => a.Payment)
               .WithOne(r => r.Ticket)
               .HasForeignKey<Payment>(a => a.TicketId)
               .OnDelete(DeleteBehavior.NoAction);

            //Event - Image
            modelBuilder.Entity<Event>()
               .HasMany(a => a.Images)
               .WithOne(r => r.Event)
               .HasForeignKey(a => a.EventId)
               .OnDelete(DeleteBehavior.NoAction);

            //Event - EventCharacter
            modelBuilder.Entity<Event>()
               .HasMany(a => a.EventCharacters)
               .WithOne(r => r.Event)
               .HasForeignKey(a => a.EventId)
               .OnDelete(DeleteBehavior.NoAction);

            //Event - Task
            modelBuilder.Entity<Event>()
               .HasMany(a => a.Tasks)
               .WithOne(r => r.Event)
               .HasForeignKey(a => a.EventId)
               .OnDelete(DeleteBehavior.NoAction);

            //Task - Contract 
            modelBuilder.Entity<Task>()
               .HasOne(a => a.Contract)
               .WithMany(r => r.Tasks)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - Payment
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.Payments)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - Feedback
            modelBuilder.Entity<Contract>()
               .HasOne(a => a.Feedback)
               .WithOne(r => r.Contract)
               .HasForeignKey<Feedback>(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - Package
            modelBuilder.Entity<Contract>()
               .HasOne(a => a.Package)
               .WithMany(r => r.Contracts)
               .HasForeignKey(a => a.PackageId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - ContractCharacter
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.ContractCharacters)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContracId)
               .OnDelete(DeleteBehavior.NoAction);

            //Character - Image
            modelBuilder.Entity<Character>()
               .HasMany(a => a.Images)
               .WithOne(r => r.Character)
               .HasForeignKey(a => a.CharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //Character - EventCharacter
            modelBuilder.Entity<Character>()
               .HasMany(a => a.EventCharacters)
               .WithOne(r => r.Character)
               .HasForeignKey(a => a.CharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //Character - ContractCharacter
            modelBuilder.Entity<Character>()
               .HasMany(a => a.ContractCharacters)
               .WithOne(r => r.Character)
               .HasForeignKey(a => a.CharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //Character - Category
            modelBuilder.Entity<Character>()
               .HasOne(a => a.Category)
               .WithMany(r => r.Characters)
               .HasForeignKey(a => a.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);

            //Category - AccountCategory
            modelBuilder.Entity<Category>()
               .HasMany(a => a.AccountCategories)
               .WithOne(r => r.Category)
               .HasForeignKey(a => a.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);
            // --- SEED DATA (Dữ liệu khởi tạo mẫu) ---
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = "role1", RoleName = (RoleName?)1, Description = "Admin role" },
                new Role { Id = "role2", RoleName = (RoleName?)2, Description = "Manager role" },
                new Role { Id = "role3", RoleName = (RoleName?)3, Description = "Customer role" }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "cat1", CategoryName = "Category 1", Description = "Description for Category 1" },
                new Category { CategoryId = "cat2", CategoryName = "Category 2", Description = "Description for Category 2" }
            );

            // Seed Accounts
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = "acc1",
                    Name = "Admin User",
                    Email = "admin@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("password123"),
                    Description = "Administrator account",
                    Birthday = new DateTime(1990, 1, 1),
                    Phone = 123456789,
                    IsActive = true,
                    OnTask = false,
                    Leader = true,
                    Code = "CODE123",
                    ImageUrl = "https://example.com/admin.png",
                    TaskQuantity = 0,
                    RoleId = "role1"
                },
                new Account
                {
                    AccountId = "acc2",
                    Name = "Customer User",
                    Email = "customer@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("password456"),
                    Description = "Customer account",
                    Birthday = new DateTime(2000, 1, 1),
                    Phone = 987654321,
                    IsActive = true,
                    OnTask = false,
                    Leader = false,
                    Code = "CODE456",
                    ImageUrl = "https://example.com/customer.png",
                    TaskQuantity = 0,
                    RoleId = "role3"
                }
            );

            // Seed RefreshToken (1-1 với Account)
            modelBuilder.Entity<RefreshToken>().HasData(
                new RefreshToken
                {
                    RefreshTokenId = "rt1",
                    RefreshTokenValue = "sample_refresh_token",
                    RefreshTokenCode = "RTCODE1",
                    JwtId = "jwt1",
                    IsUsed = false,
                    IsRevoked = false,
                    CreateAt = new DateTime(2023, 1, 1),
                    ExpiresAt = new DateTime(2023, 1, 8),
                    AccountId = "acc1"
                }
            );

            // Seed Carts (1 Cart cho mỗi Account)
            modelBuilder.Entity<Cart>().HasData(
                new Cart { CartId = "cart1", AccountId = "acc1", TotalPrice = 0 },
                new Cart { CartId = "cart2", AccountId = "acc2", TotalPrice = 0 }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = "prod1",
                    ProductName = "Product 1",
                    Description = "Description of Product 1",
                    Quantity = 100,
                    Price = 10.0,
                    CreateDate = new DateTime(2023, 1, 1),
                    UpdateDate = null,
                    IsActive = true
                },
                new Product
                {
                    ProductId = "prod2",
                    ProductName = "Product 2",
                    Description = "Description of Product 2",
                    Quantity = 200,
                    Price = 20.0,
                    CreateDate = new DateTime(2023, 1, 2),
                    UpdateDate = null,
                    IsActive = true
                }
            );

            // Seed CartProducts
            modelBuilder.Entity<CartProduct>().HasData(
                new CartProduct { CartProductId = "cp1", CartId = "cart1", ProductId = "prod1" },
                new CartProduct { CartProductId = "cp2", CartId = "cart2", ProductId = "prod2" }
            );

            // Seed Orders (liên kết với Cart)
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = "order1", CartId = "cart1" }
            );

            // Seed Packages
            modelBuilder.Entity<Package>().HasData(
                new Package { PackageId = "pkg1", PackageName = "Basic Package", Description = "Basic service package", Price = 99.99 }
            );

            // Seed Contracts
            modelBuilder.Entity<Contract>().HasData(
                new Contract
                {
                    ContractId = "ctr1",
                    AccountId = "acc1",
                    ContractName = "Contract 1",
                    ContractCode = "C001",
                    Description = "Contract for Event 1",
                    Price = 500,
                    Amount = 450,
                    Signature = true,
                    Deposit = "50",
                    CharacterQuantity = 1,
                    Location = "Location 1",
                    Status = (ContractStatus)1,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 1, 31),
                    PackageId = "pkg1"
                },
                new Contract
                {
                    ContractId = "ctr2",
                    AccountId = "acc2",
                    ContractName = "Contract 2",
                    ContractCode = "C002",
                    Description = "Contract for Event 2",
                    Price = 800,
                    Amount = 750,
                    Signature = false,
                    Deposit = "50",
                    CharacterQuantity = 2,
                    Location = "Location 2",
                    Status = (ContractStatus)2,
                    StartDate = new DateTime(2023, 2, 1),
                    EndDate = new DateTime(2023, 3, 1),
                    PackageId = "pkg1"
                }
            );

            // Seed ContractCharacters (nối Contract với Character)
            modelBuilder.Entity<ContractCharacter>().HasData(
                new ContractCharacter { ContractCharacterId = "cc1", ContracId = "ctr1", CharacterId = "char1", Quantity = 1 },
                new ContractCharacter { ContractCharacterId = "cc2", ContracId = "ctr2", CharacterId = "char2", Quantity = 2 }
            );

            // Seed Characters
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    CharacterId = "char1",
                    CategoryId = "cat1",
                    CharacterName = "Character 1",
                    Price = 100,
                    IsActive = true,
                    CreateDate = new DateTime(2023, 1, 1),
                    UpdateDate = null
                },
                new Character
                {
                    CharacterId = "char2",
                    CategoryId = "cat2",
                    CharacterName = "Character 2",
                    Price = 150,
                    IsActive = true,
                    CreateDate = new DateTime(2023, 1, 2),
                    UpdateDate = null
                }
            );

            // Seed Events
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = "evt1",
                    EventName = "Event 1",
                    Description = "Description for Event 1",
                    Location = "Location 1",
                    IsActive = true,
                    StartDate = new DateTime(2023, 3, 1),
                    EndDate = new DateTime(2023, 3, 2),
                    CreateDate = new DateTime(2023, 2, 25),
                    UpdateDate = null,
                    CreateBy = "acc1"
                },
                new Event
                {
                    EventId = "evt2",
                    EventName = "Event 2",
                    Description = "Description for Event 2",
                    Location = "Location 2",
                    IsActive = true,
                    StartDate = new DateTime(2023, 4, 1),
                    EndDate = new DateTime(2023, 4, 2),
                    CreateDate = new DateTime(2023, 3, 25),
                    UpdateDate = null,
                    CreateBy = "acc2"
                }
            );

            // Seed EventCharacters
            modelBuilder.Entity<EventCharacter>().HasData(
                new EventCharacter { EventCharacterId = "ec1", EventId = "evt1", CharacterId = "char1" },
                new EventCharacter { EventCharacterId = "ec2", EventId = "evt2", CharacterId = "char2" }
            );

            // Seed AccountCategories (nối Account với Category)
            modelBuilder.Entity<AccountCategory>().HasData(
                new AccountCategory { AccountCategoryId = "acat1", AccountId = "acc1", CategoryId = "cat1" },
                new AccountCategory { AccountCategoryId = "acat2", AccountId = "acc2", CategoryId = "cat2" }
            );

            // Seed Feedback (1-1 với Contract)
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback
                {
                    FeedbackId = "fb1",
                    Star = 5,
                    Description = "Excellent service",
                    CreateDate = new DateTime(2023, 3, 5),
                    UpdateDate = null,
                    ContractId = "ctr1"
                }
            );

            // Seed Tasks
            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    TaskId = "tsk1",
                    AccountId = "acc1",
                    TaskName = "Task 1",
                    Location = "Location A",
                    Description = "Task for Event 1",
                    IsActive = true,
                    StartDate = new DateTime(2023, 3, 1, 9, 0, 0),
                    EndDate = new DateTime(2023, 3, 1, 12, 0, 0),
                    CreateDate = new DateTime(2023, 2, 28),
                    UpdateDate = null,
                    Status = (TaskStatus?)1,
                    EventId = "evt1",
                    ContractId = "ctr1"
                },
                new Task
                {
                    TaskId = "tsk2",
                    AccountId = "acc2",
                    TaskName = "Task 2",
                    Location = "Location B",
                    Description = "Task for Event 2",
                    IsActive = true,
                    StartDate = new DateTime(2023, 4, 1, 14, 0, 0),
                    EndDate = new DateTime(2023, 4, 1, 17, 0, 0),
                    CreateDate = new DateTime(2023, 3, 31),
                    UpdateDate = null,
                    Status = (TaskStatus?)2,
                    EventId = "evt2",
                    ContractId = "ctr2"
                }
            );

            // Seed Tickets
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    TicketId = "tkt1",
                    AccountId = "acc1",
                    Quantity = 1,
                    Price = 50,
                    EventId = "evt1"
                }
            );

            // Seed Payments (cho Order, Ticket và Contract)
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentId = "pay1",
                    Type = "Credit Card",
                    Status = (PaymentStatus?)1,
                    Amount = 100,
                    TransactionId = "TXN001",
                    CreatAt = "2023-01-01",
                    OrderId = "order1",
                    TicketId = null,
                    ContractId = null
                },
                new Payment
                {
                    PaymentId = "pay2",
                    Type = "Bank Transfer",
                    Status = (PaymentStatus?)2,
                    Amount = 150,
                    TransactionId = "TXN002",
                    CreatAt = "2023-01-02",
                    OrderId = null,
                    TicketId = "tkt1",
                    ContractId = null
                },
                new Payment
                {
                    PaymentId = "pay3",
                    Type = "PayPal",
                    Status = (PaymentStatus?)1,
                    Amount = 200,
                    TransactionId = "TXN003",
                    CreatAt = "2023-01-03",
                    OrderId = null,
                    TicketId = null,
                    ContractId = "ctr1"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
