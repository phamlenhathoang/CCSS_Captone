using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<TicketAccount> TicketAccounts { get; set; }
        
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

            //Account - Notification
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Notifications)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - AccountCoupon
            modelBuilder.Entity<Account>()
               .HasMany(a => a.AccountCoupons)
               .WithOne(r => r.Account)
               .HasForeignKey(a => a.AccountId)
               .OnDelete(DeleteBehavior.NoAction);

            //Account - RefreshToken
            modelBuilder.Entity<Account>()
                .HasMany(a => a.RefreshTokens)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
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

            //Account - EventCharacter
            modelBuilder.Entity<Account>()
                .HasOne(a => a.EventCharacter)
                .WithOne(r => r.Account)
                .HasForeignKey<EventCharacter>(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - ContractCharacter
            modelBuilder.Entity<Account>()
                .HasOne(a => a.ContractCharacter)
                .WithOne(r => r.Account)
                .HasForeignKey<ContractCharacter>(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - TicketAccount
            modelBuilder.Entity<Account>()
                .HasMany(a => a.TicketAccounts)
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

            //Order - Coupon 
            modelBuilder.Entity<Order>()
                .HasOne(a => a.Coupon)
                .WithOne(r => r.Order)
                .HasForeignKey<Order>(a => a.CouponId)
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
            
            //Ticket - TicketAccount
            modelBuilder.Entity<Ticket>()
                .HasMany(a => a.TicketAccounts)
                .WithOne(r => r.Ticket)
                .HasForeignKey(a => a.TicketId)
                .OnDelete(DeleteBehavior.NoAction);

            //TicketAccount - Payment
            modelBuilder.Entity<TicketAccount>()
               .HasOne(a => a.Payment)
               .WithOne(r => r.TicketAccount)
               .HasForeignKey<Payment>(a => a.TicketAccountId)
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

            //Contract - Payment
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.Payments)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Coupon - AccountCoupon
            modelBuilder.Entity<Coupon>()
               .HasMany(a => a.AccountCoupons)
               .WithOne(r => r.Coupon)
               .HasForeignKey(a => a.CouponId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - Coupon
            modelBuilder.Entity<Contract>()
               .HasOne(a => a.Coupon)
               .WithMany(r => r.Contracts)
               .HasForeignKey(a => a.CouponId)
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

            //Task - EventCharacter
            modelBuilder.Entity<Task>()
               .HasOne(a => a.EventCharacter)
               .WithOne(r => r.Task)
               .HasForeignKey<Task>(a => a.EventCharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //Task - ContractCharacter
            modelBuilder.Entity<Task>()
               .HasOne(a => a.ContractCharacter)
               .WithOne(r => r.Task)
               .HasForeignKey<Task>(a => a.ContractCharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            // --- SEED DATA (Dữ liệu khởi tạo mẫu) ---
            // Seed dữ liệu cho bảng Category
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "1", CategoryName = "Fantasy", Description = "Characters from fantasy world" },
                new Category { CategoryId = "2", CategoryName = "Sci-Fi", Description = "Characters from sci-fi universe" }
            );
            // Seed dữ liệu cho bảng Package
            modelBuilder.Entity<Package>().HasData(
                new Package
                {
                    PackageId = "PKG001",
                    PackageName = "Basic Cosplay Package",
                    Description = "Includes basic costume and props",
                    Price = 100.0
                },
                new Package
                {
                    PackageId = "PKG002",
                    PackageName = "Premium Cosplay Package",
                    Description = "Includes premium costume, props, and makeup",
                    Price = 300.0
                }
            );
            // Seed dữ liệu cho bảng Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = "0", RoleName = RoleName.Admin, Description = "Admin" },
                new Role { Id = "1", RoleName = RoleName.Manager, Description = "Manager" },
                new Role { Id = "2", RoleName = RoleName.Consultant, Description = "Consultant" },
                new Role { Id = "3", RoleName = RoleName.Cosplayer, Description = "Cosplayer" },
                new Role { Id = "4", RoleName = RoleName.Customer, Description = "Customer" }
            );

            // Seed dữ liệu cho bảng Account
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = "1",
                    Name = "John Doe",
                    Email = "john@example.com",
                    Password = "hashed_password",
                    RoleId = "1",
                    IsActive = true,
                    Birthday = new DateTime(1995, 5, 20),
                    Phone = 123456789
                },
                new Account
                {
                    AccountId = "2",
                    Name = "Glenn Quagmire",
                    Email = "phuongnam26012002@gmail.com",
                    Password = "giggity",
                    RoleId = "4",
                    IsActive = true,
                    Birthday = new DateTime(1995, 5, 20),
                    Phone = 123456789
                }
            );

            // Seed dữ liệu cho bảng Coupon
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    CouponId = "CPN001",
                    Condition = "First order",
                    Percent = 10,
                    Amount = 5,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                }
            );

            // Seed dữ liệu cho bảng Contract
            modelBuilder.Entity<Contract>().HasData(
                new Contract
                {
                    ContractId = "CON001",
                    AccountId = "2",
                    ContractName = "Hợp đồng thuê cosplayer",
                    ContractCode = "CT001",
                    Description = ContractDescription.RentCosplayer,
                    Price = 500.0,
                    Amount = 1,
                    Signature = true,
                    Deposit = "50%",
                    CharacterQuantity = 2,
                    Location = "Hà Nội",
                    Status = ContractStatus.Progressing,
                    StartDate = new DateTime(2025, 3, 10),
                    EndDate = new DateTime(2025, 3, 15),
                    PackageId = "PKG001",
                    CouponId = "CPN001"
                }
            );

            // Seed dữ liệu cho bảng Event
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    EventId = "E1",
                    EventName = "Cosplay Festival",
                    Description = "Annual cosplay event",
                    Location = "Tokyo",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3),
                    CreateDate = DateTime.Now,
                    IsActive = true
                }
            );

            // Seed dữ liệu cho bảng Cart
            modelBuilder.Entity<Cart>().HasData(
                new Cart { CartId = "CART001", AccountId = "1", TotalPrice = 100.0 },
                new Cart { CartId = "CART002", AccountId = "2", TotalPrice = 200.0 }
            );

            // Seed dữ liệu cho bảng Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = "P1",
                    ProductName = "Cosplay Sword",
                    Description = "A high-quality cosplay sword",
                    Quantity = 10,
                    Price = 50,
                    CreateDate = DateTime.Now,
                    IsActive = true
                }
            );

            // Seed dữ liệu cho bảng Character
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    CharacterId = "CH1",
                    CategoryId = "1",
                    CharacterName = "Elf Warrior",
                    Description = "A fantasy elf warrior",
                    Price = 100,
                    IsActive = true,
                    CreateDate = DateTime.Now
                }
            );

            // Seed dữ liệu cho bảng Ticket
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    TicketId = "T1",
                    EventId = "E1",
                    Quantity = 100,
                    Price = 20
                }
            );

            // Seed dữ liệu cho bảng TicketAccount
            modelBuilder.Entity<TicketAccount>().HasData(
                new TicketAccount { TicketAccountId = "1", AccountId = "2", TicketCode = "TCK001", quantitypurchased = 2, TotalPrice = 100.0, TicketId = "T1" }
            );

            // Seed dữ liệu cho bảng CartProduct
            modelBuilder.Entity<CartProduct>().HasData(
                new CartProduct { CartProductId = "1", ProductId = "P1", CartId = "CART001" }
            );

            // Seed dữ liệu cho bảng Order
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = "O1", CartId = "CART001", CouponId = "CPN001" }
            );

            // Seed dữ liệu cho bảng ContractCharacter
            modelBuilder.Entity<ContractCharacter>().HasData(
                new ContractCharacter { ContractCharacterId = "CC1", ContracId = "CON001", AccountId = "1", CharacterId = "CH1", Quantity = 2 }
            );

            // Seed dữ liệu cho bảng Feedback
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { FeedbackId = "F1", Star = 5, Description = "Great!", CreateDate = DateTime.UtcNow, ContractId = "CON001" }
            );

            // Seed dữ liệu cho bảng Payment
            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentId = "P1", Type = "Credit Card", Status = PaymentStatus.Cancel, Purpose = 0, Amount = 100.0, OrderId = "O1", CreatAt = DateTime.UtcNow }
            );

            // Seed dữ liệu cho bảng Task
            modelBuilder.Entity<Task>().HasData(
                new Task { TaskId = "T1", TaskName = "Setup Booth", Location = "Event Hall", Description = "Prepare the booth for the event", IsActive = true, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(1), Status = TaskStatus.Progressing, ContractCharacterId = "CC1" }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
