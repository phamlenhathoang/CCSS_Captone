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
        public virtual DbSet<AccountCoupon> AccountCoupons { get; set; }
        public virtual DbSet<AccountImage> AccountImages { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterImage> CharacterImages { get; set; }
        public virtual DbSet<Request> Contracts { get; set; }
        public virtual DbSet<RequestCharacter> ContractCharacters { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventActivity> EventActivities { get; set; }
        public virtual DbSet<EventCharacter> EventCharacters { get; set; }
        public virtual DbSet<EventImage> EventImages { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
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

            //Account - Requests
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Requests)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - AccountImage
            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountImages)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - Task
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Task)
                .WithOne(r => r.Account)
                .HasForeignKey<Task>(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - TicketAccount
            modelBuilder.Entity<Account>()
                .HasMany(a => a.TicketAccounts)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            //Account - Feedback
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Feedbacks)
                .WithOne(r => r.Account)
                .HasForeignKey(a => a.AccountId)
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
            
            //Order - OrderProduct 
            modelBuilder.Entity<Order>()
                .HasMany(a => a.OrderProducts)
                .WithOne(r => r.Order)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            //Product - CartProduct
            modelBuilder.Entity<CartProduct>()
               .HasOne(a => a.Product)
               .WithMany(r => r.CartProducts)
               .HasForeignKey(a => a.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

            //Product - ProductImage
            modelBuilder.Entity<Product>()
               .HasMany(a => a.ProductImages)
               .WithOne(r => r.Product)
               .HasForeignKey(a => a.ProductId)
               .OnDelete(DeleteBehavior.NoAction);
            
            //Product - OrderProduct
            modelBuilder.Entity<Product>()
               .HasMany(a => a.OrderProducts)
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

            //Event - EventImage
            modelBuilder.Entity<Event>()
               .HasMany(a => a.EventImages)
               .WithOne(r => r.Event)
               .HasForeignKey(a => a.EventId)
               .OnDelete(DeleteBehavior.NoAction);

            //Event - EventCharacter
            modelBuilder.Entity<Event>()
               .HasMany(a => a.EventCharacters)
               .WithOne(r => r.Event)
               .HasForeignKey(a => a.EventId)
               .OnDelete(DeleteBehavior.NoAction);

            //Event - EventActivity
            modelBuilder.Entity<Event>()
               .HasMany(a => a.EventActivities)
               .WithOne(r => r.Event)
               .HasForeignKey(a => a.EventId)
               .OnDelete(DeleteBehavior.NoAction);

            //EventActivity - Activity
            modelBuilder.Entity<Activity>()
               .HasMany(a => a.EventActivities)
               .WithOne(r => r.Activity)
               .HasForeignKey(a => a.ActivityId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - Payment
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.Payments)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - Request
            modelBuilder.Entity<Contract>()
               .HasOne(a => a.Request)
               .WithOne(r => r.Contract)
               .HasForeignKey<Contract>(a => a.RequestId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - Feedback
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.Feedbacks)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - ContractCharacter
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.ContractCharacters)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Coupon - AccountCoupon
            modelBuilder.Entity<Coupon>()
               .HasMany(a => a.AccountCoupons)
               .WithOne(r => r.Coupon)
               .HasForeignKey(a => a.CouponId)
               .OnDelete(DeleteBehavior.NoAction);

            //Coupon - Request
            modelBuilder.Entity<Coupon>()
               .HasMany(a => a.Requests)
               .WithOne(r => r.Coupon)
               .HasForeignKey(a => a.CouponId)
               .OnDelete(DeleteBehavior.NoAction);

            //Request - Service
            modelBuilder.Entity<Request>()
               .HasOne(a => a.Service)
               .WithMany(r => r.Requests)
               .HasForeignKey(a => a.RequestId)
               .OnDelete(DeleteBehavior.NoAction);

            //Request - RequestCharacter
            modelBuilder.Entity<Request>()
               .HasMany(a => a.RequestCharacters)
               .WithOne(r => r.Request)
               .HasForeignKey(a => a.RequestId)
               .OnDelete(DeleteBehavior.NoAction);

            //Character - CharacterImage
            modelBuilder.Entity<Character>()
               .HasMany(a => a.CharacterImages)
               .WithOne(r => r.Character)
               .HasForeignKey(a => a.CharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //Character - RequestCharacter
            modelBuilder.Entity<Character>()
               .HasMany(a => a.RequestCharacters)
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

            //Service - Package 
            modelBuilder.Entity<Service>()
               .HasMany(a => a.Packages)
               .WithOne(r => r.Service)
               .HasForeignKey(a => a.ServiceId)
               .OnDelete(DeleteBehavior.NoAction);


            // --- SEED DATA (Dữ liệu khởi tạo mẫu) ---
            // Seed dữ liệu cho bảng Category
            //modelBuilder.Entity<Category>().HasData(
            //    new Category { CategoryId = "1", CategoryName = "Fantasy", Description = "Characters from fantasy world" },
            //    new Category { CategoryId = "2", CategoryName = "Sci-Fi", Description = "Characters from sci-fi universe" }
            //);
            //// Seed dữ liệu cho bảng Package
            //modelBuilder.Entity<Package>().HasData(
            //    new Package
            //    {
            //        PackageId = "PKG001",
            //        PackageName = "Basic Cosplay Package",
            //        Description = "Includes basic costume and props",
            //        Price = 100.0
            //    },
            //    new Package
            //    {
            //        PackageId = "PKG002",
            //        PackageName = "Premium Cosplay Package",
            //        Description = "Includes premium costume, props, and makeup",
            //        Price = 300.0
            //    }
            //);
            //// Seed dữ liệu cho bảng Role
            //modelBuilder.Entity<Role>().HasData(
            //    new Role { Id = "0", RoleName = RoleName.Admin, Description = "Admin" },
            //    new Role { Id = "1", RoleName = RoleName.Manager, Description = "Manager" },
            //    new Role { Id = "2", RoleName = RoleName.Consultant, Description = "Consultant" },
            //    new Role { Id = "3", RoleName = RoleName.Cosplayer, Description = "Cosplayer" },
            //    new Role { Id = "4", RoleName = RoleName.Customer, Description = "Customer" }
            //);

            //// Seed dữ liệu cho bảng Account
            //modelBuilder.Entity<Account>().HasData(
            //    new Account
            //    {
            //        AccountId = "1",
            //        Name = "John Doe",
            //        Email = "john@example.com",
            //        Password = "ZkmcwLVZC7B06TE7qd/qoA==",
            //        RoleId = "1",
            //        IsActive = true,
            //        Birthday = new DateTime(1995, 5, 20),
            //        Phone = "123456789"
            //    },
            //    new Account
            //    {
            //        AccountId = "2",
            //        Name = "Glenn Quagmire",
            //        Email = "phuongnam26012002@gmail.com",
            //        Password = "ZkmcwLVZC7B06TE7qd/qoA==",
            //        RoleId = "4",
            //        IsActive = true,
            //        Birthday = new DateTime(1995, 5, 20),
            //        Phone = "123456789"
            //    }
            //);

            //// Seed dữ liệu cho bảng Coupon
            //modelBuilder.Entity<Coupon>().HasData(
            //    new Coupon
            //    {
            //        CouponId = "CPN001",
            //        Condition = "First order",
            //        Percent = 10,
            //        Amount = 5,
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now.AddMonths(1)
            //    }
            //);

            //// Seed dữ liệu cho bảng Contract
            //modelBuilder.Entity<Request>().HasData(
            //    new Request
            //    {
            //        ContractId = "CON001",
            //        AccountId = "2",
            //        ContractName = "Hợp đồng thuê cosplayer",
            //        ContractCode = "CT001",
            //        Description = ContractDescription.RentCosplayer,
            //        Price = 500.0,
            //        Amount = 1,
            //        Signature = true,
            //        Deposit = "50%",
            //        CharacterQuantity = 2,
            //        Location = "Hà Nội",
            //        Status = ContractStatus.Progressing,
            //        StartDate = new DateTime(2025, 3, 10),
            //        EndDate = new DateTime(2025, 3, 15),
            //        PackageId = "PKG001",
            //        CouponId = "CPN001"
            //    }
            //);

            //// Seed dữ liệu cho bảng Event
            //modelBuilder.Entity<Event>().HasData(
            //    new Event
            //    {
            //        EventId = "E1",
            //        EventName = "Cosplay Festival",
            //        Description = "Annual cosplay event",
            //        Location = "Tokyo",
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now.AddDays(3),
            //        CreateDate = DateTime.Now,
            //        IsActive = true
            //    }
            //);

            //// Seed dữ liệu cho bảng Cart
            //modelBuilder.Entity<Cart>().HasData(
            //    new Cart { CartId = "CART001", AccountId = "1", TotalPrice = 100.0 },
            //    new Cart { CartId = "CART002", AccountId = "2", TotalPrice = 200.0 }
            //);

            //// Seed dữ liệu cho bảng Product
            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        ProductId = "P1",
            //        ProductName = "Cosplay Sword",
            //        Description = "A high-quality cosplay sword",
            //        Quantity = 10,
            //        Price = 50,
            //        CreateDate = DateTime.Now,
            //        IsActive = true
            //    }
            //);

            //// Seed dữ liệu cho bảng Character
            //modelBuilder.Entity<Character>().HasData(
            //    new Character
            //    {
            //        CharacterId = "CH1",
            //        CategoryId = "1",
            //        CharacterName = "Elf Warrior",
            //        Description = "A fantasy elf warrior",
            //        Price = 100,
            //        IsActive = true,
            //        CreateDate = DateTime.Now,
            //        Quantity = 50
            //    }
            //);

            //// Seed dữ liệu cho bảng Ticket
            //modelBuilder.Entity<Ticket>().HasData(
            //    new Ticket
            //    {
            //        TicketId = "T1",
            //        EventId = "E1",
            //        Quantity = 100,
            //        Price = 20
            //    }
            //);

            //// Seed dữ liệu cho bảng TicketAccount
            //modelBuilder.Entity<TicketAccount>().HasData(
            //    new TicketAccount { TicketAccountId = "1", AccountId = "2", TicketCode = "TCK001", Quantity = 2, TotalPrice = 100.0, TicketId = "T1" }
            //);

            //// Seed dữ liệu cho bảng CartProduct
            //modelBuilder.Entity<CartProduct>().HasData(
            //    new CartProduct { CartProductId = "1", ProductId = "P1", CartId = "CART001" }
            //);

            //// Seed dữ liệu cho bảng ContractCharacter
            //modelBuilder.Entity<RequestCharacter>().HasData(
            //    new RequestCharacter { ContractCharacterId = "CC1", ContracId = "CON001", AccountId = "1", CharacterId = "CH1", Quantity = 2 }
            //);

            //// Seed dữ liệu cho bảng Feedback
            //modelBuilder.Entity<Feedback>().HasData(
            //    new Feedback { FeedbackId = "F1", Star = 5, Description = "Great!", CreateDate = DateTime.UtcNow, ContractId = "CON001" }
            //);

            //// Seed dữ liệu cho bảng Payment
            //modelBuilder.Entity<Payment>().HasData(
            //    new Payment { PaymentId = "P1", Type = "Credit Card", Status = PaymentStatus.Cancel, Purpose = 0, Amount = 100.0, OrderId = "O1", CreatAt = DateTime.UtcNow }
            //);

            //// Seed dữ liệu cho bảng Task
            //modelBuilder.Entity<Task>().HasData(
            //    new Task { TaskId = "T1", TaskName = "Setup Booth", Location = "Event Hall", Description = "Prepare the booth for the event", IsActive = true, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(1), Status = TaskStatus.Progressing, ContractCharacterId = "CC1" }
            //);


            base.OnModelCreating(modelBuilder);
        }
    }
}
