using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<CustomerCharacter> CustomerCharacters { get; set; }
        public virtual DbSet<ContractImage> ContractImages { get; set; }
        public virtual DbSet<ContractRefund> ContractRefunds { get; set; }
        public virtual DbSet<CustomerCharacterImage> CustomerCharacterImages { get; set; }
        public virtual DbSet<ContractCharacter> ContractCharacters { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestDate> RequestDates { get; set; }
        public virtual DbSet<RequestCharacter> RequestsCharacters { get; set; }
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
                .HasMany(a => a.Tasks)  
                .WithOne(t => t.Account) 
                .HasForeignKey(t => t.AccountId) 
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
                .HasMany(a => a.Payment)
                .WithOne(r => r.Order)
                .HasForeignKey(a => a.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            //Order - Account 
            modelBuilder.Entity<Order>()
                .HasOne(a => a.Account)
                .WithMany(r => r.Orders)
                .HasForeignKey(a => a.AccountId)
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
               .HasMany(a => a.Ticket)
               .WithOne(r => r.Event)
               .HasForeignKey(a => a.EventId)
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

            //Contract - ContractImage
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.ContractImages)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - ContractRefund
            modelBuilder.Entity<Contract>()
               .HasOne(a => a.ContractRefund)
               .WithOne(r => r.Contract)
               .HasForeignKey<ContractRefund>(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);

            //ContractCharacter - Feedback
            modelBuilder.Entity<Feedback>()
               .HasOne(a => a.ContractCharacter)
               .WithOne(r => r.Feedback)
               .HasForeignKey<Feedback>(a => a.ContractCharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //Contract - ContractCharacter
            modelBuilder.Entity<Contract>()
               .HasMany(a => a.ContractCharacters)
               .WithOne(r => r.Contract)
               .HasForeignKey(a => a.ContractId)
               .OnDelete(DeleteBehavior.NoAction);
            
            //Request - AccountCoupon
            //modelBuilder.Entity<Request>()
            //   .HasOne(a => a.AccountCoupon)
            //   .WithMany(r => r.Requests)
            //   .HasForeignKey(a => a.AccountCouponId)
            //   .OnDelete(DeleteBehavior.NoAction);

            //Coupon - AccountCoupon
            modelBuilder.Entity<Coupon>()
               .HasMany(a => a.AccountCoupons)
               .WithOne(r => r.Coupon)
               .HasForeignKey(a => a.CouponId)
               .OnDelete(DeleteBehavior.NoAction);

            //AccountCoupon - Payment
            modelBuilder.Entity<AccountCoupon>()
                 .HasOne(a => a.Payment)
                 .WithOne(r => r.AccountCoupon)
                 .HasForeignKey<Payment>(p => p.AccountCouponID) 
                 .OnDelete(DeleteBehavior.NoAction);

            //Request - Service
            modelBuilder.Entity<Request>()
               .HasOne(a => a.Service)
               .WithMany(r => r.Requests)
               .HasForeignKey(a => a.ServiceId)
               .OnDelete(DeleteBehavior.NoAction);

            //Request - RequestCharacter
            modelBuilder.Entity<Request>()
               .HasMany(a => a.RequestCharacters)
               .WithOne(r => r.Request)
               .HasForeignKey(a => a.RequestId)
               .OnDelete(DeleteBehavior.NoAction);

            //RequestDate - RequestCharacter
            modelBuilder.Entity<RequestDate>()
               .HasOne(a => a.RequestCharacter)
               .WithMany(r => r.RequestDates)
               .HasForeignKey(a => a.RequestCharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //RequestDate - ContractCharacter
            modelBuilder.Entity<RequestDate>()
               .HasOne(a => a.ContractCharacter)
               .WithMany(r => r.RequestDates)
               .HasForeignKey(a => a.ContractCharacterId)
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

            //CustomerCharacter - Category
            modelBuilder.Entity<CustomerCharacter>()
               .HasOne(a => a.Category)
               .WithMany(r => r.CustomerCharacters)
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
               .WithMany(r => r.Tasks)
               .HasForeignKey(a => a.ContractCharacterId)
               .OnDelete(DeleteBehavior.NoAction);

            //Request - Package 
            modelBuilder.Entity<Request>()
               .HasOne(a => a.Package)
               .WithMany(r => r.Requests)
               .HasForeignKey(a => a.PackageId)
               .OnDelete(DeleteBehavior.NoAction);

            //CustomerCharacter - CustomerCharacterImage 
            modelBuilder.Entity<CustomerCharacter>()
               .HasMany(a => a.CustomerCharacterImages)
               .WithOne(r => r.CustomerCharacter)
               .HasForeignKey(a => a.CustomerCharacterId)
               .OnDelete(DeleteBehavior.NoAction);


            // --- SEED DATA (Dữ liệu khởi tạo mẫu) ---
            #region Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = "R001", RoleName = RoleName.Admin, Description = "System Administrator" },
                new Role { Id = "R002", RoleName = RoleName.Manager, Description = "Event and Service Manager" },
                new Role { Id = "R003", RoleName = RoleName.Consultant, Description = "Customer Service Consultant" },
                new Role { Id = "R004", RoleName = RoleName.Cosplayer, Description = "Professional Cosplayer" },
                new Role { Id = "R005", RoleName = RoleName.Customer, Description = "Regular Customer" }

   );
            #endregion

            #region Account

            modelBuilder.Entity<Account>().HasData(
new Account { AccountId = "A001", Name = "John Doe", Email = "john@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 45000, IsActive = true, Height = 180, Weight = 75, AverageStar = 4.5, IsLock = false },
new Account { AccountId = "A002", Name = "Jane Smith", Email = "jane@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R001", SalaryIndex = null, IsActive = true, IsLock = false },
new Account { AccountId = "A003", Name = "Nammmmmmmm", Email = "phuongnam26012002@gmail.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R005", SalaryIndex = null, IsActive = true, IsLock = false },
new Account { AccountId = "A004", Name = "Bob Brown", Email = "bob@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 42000, IsActive = true, Height = 175, Weight = 80, AverageStar = 4.2, IsLock = false },
new Account { AccountId = "A005", Name = "Charlie White", Email = "charlie@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 35000, IsActive = true, Height = 182, Weight = 78, AverageStar = 3.5, IsLock = false },
new Account { AccountId = "A006", Name = "David Black", Email = "david@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R005", SalaryIndex = null, IsActive = true, IsLock = false },
new Account { AccountId = "A007", Name = "Emma Green", Email = "emma@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 41000, IsActive = true, Height = 168, Weight = 60, AverageStar = 4.1, IsLock = false },
new Account { AccountId = "A008", Name = "Frank Blue", Email = "frank@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 46000, IsActive = true, Height = 185, Weight = 85, AverageStar = 4.6, IsLock = false },
new Account { AccountId = "A009", Name = "Grace Pink", Email = "grace@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R001", SalaryIndex = null, IsActive = true, IsLock = false },
new Account { AccountId = "A010", Name = "Henry Purple", Email = "henry@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 25000, IsActive = true, Height = 178, Weight = 77, AverageStar = 2.5, IsLock = false },
new Account { AccountId = "A011", Name = "Isla Red", Email = "isla@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = null, IsActive = true, IsLock = false },
new Account { AccountId = "A012", Name = "Jack Yellow", Email = "jack@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 38000, IsActive = true, Height = 172, Weight = 70, AverageStar = 3.8, IsLock = false },
new Account { AccountId = "A013", Name = "Katie Orange", Email = "katie@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 25000, IsActive = true, Height = 165, Weight = 55, AverageStar = 2.5, IsLock = false },
new Account { AccountId = "A014", Name = "Liam Gray", Email = "liam@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R005", SalaryIndex = null, IsActive = true, IsLock = false },
new Account { AccountId = "A015", Name = "Mia Cyan", Email = "mia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 15000, IsActive = true, Height = 170, Weight = 65, AverageStar = 1.5, IsLock = false },
new Account { AccountId = "A016", Name = "Noah Silver", Email = "noah@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 37000, IsActive = true, Height = 175, Weight = 70, AverageStar = 3.7, IsLock = false },
new Account { AccountId = "A017", Name = "Olivia Gold", Email = "olivia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 48000, IsActive = true, Height = 168, Weight = 55 , AverageStar = 4.8 },
new Account { AccountId = "A018", Name = "William Amber", Email = "william@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 32000, IsActive = true, Height = 180, Weight = 75, AverageStar = 3.2, IsLock = false },
new Account { AccountId = "A019", Name = "Sophia Ivory", Email = "sophia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 33000, IsActive = true, Height = 165, Weight = 50, AverageStar = 3.3, IsLock = false },
new Account { AccountId = "A020", Name = "James Navy", Email = "james@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 34000, IsActive = true, Height = 178, Weight = 72, AverageStar = 3.4, IsLock = false },
new Account { AccountId = "A021", Name = "Ava Teal", Email = "ava@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 35000, IsActive = true, Height = 162, Weight = 48, AverageStar = 3.5, IsLock = false },
new Account { AccountId = "A022", Name = "Benjamin Lime", Email = "benjamin@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 36000, IsActive = true, Height = 177, Weight = 70, AverageStar = 3.6, IsLock = false },
new Account { AccountId = "A023", Name = "Charlotte Beige", Email = "charlotte@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 37000, IsActive = true, Height = 164, Weight = 52, AverageStar = 3.7, IsLock = false },
new Account { AccountId = "A024", Name = "Lucas Maroon", Email = "lucas@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 38000, IsActive = true, Height = 180, Weight = 74, AverageStar = 3.8, IsLock = false },
new Account { AccountId = "A025", Name = "Mia Pearl", Email = "mia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 39000, IsActive = true, Height = 159, Weight = 47, AverageStar = 3.9, IsLock = false },
new Account { AccountId = "A026", Name = "Ethan Olive", Email = "ethan@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 25000, IsActive = true, Height = 176, Weight = 71, AverageStar = 2.5, IsLock = false },
new Account { AccountId = "A027", Name = "Amelia Ruby", Email = "amelia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 26000, IsActive = true, Height = 167, Weight = 53, AverageStar = 2.6, IsLock = false },
new Account { AccountId = "A028", Name = "Henry Saffron", Email = "henry@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 27000, IsActive = true, Height = 182, Weight = 76, AverageStar = 2.7, IsLock = false },
new Account { AccountId = "A029", Name = "Ella Coral", Email = "ella@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 28000, IsActive = true, Height = 160, Weight = 49, AverageStar = 2.8, IsLock = false },
new Account { AccountId = "A030", Name = "Daniel Cyan", Email = "daniel@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 29000, IsActive = true, Height = 175, Weight = 72, AverageStar = 2.9, IsLock = false },
new Account { AccountId = "A031", Name = "Logan Indigo", Email = "logan@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 30000, IsActive = true, Height = 180, Weight = 73, AverageStar = 3.0, IsLock = false },
new Account { AccountId = "A032", Name = "Lily Violet", Email = "lily@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 40000, IsActive = true, Height = 165, Weight = 52, AverageStar = 4.0, IsLock = false },
new Account { AccountId = "A033", Name = "Mason Turquoise", Email = "mason@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 41000, IsActive = true, Height = 178, Weight = 74, AverageStar = 4.1, IsLock = false },
new Account { AccountId = "A034", Name = "Zoe Lavender", Email = "zoe@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 42000, IsActive = true, Height = 160, Weight = 48, AverageStar = 4.2, IsLock = false },
new Account { AccountId = "A035", Name = "Elijah Crimson", Email = "elijah@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 43000, IsActive = true, Height = 182, Weight = 77, AverageStar = 4.3, IsLock = false },
new Account { AccountId = "A036", Name = "Aria Mint", Email = "aria@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 44000, IsActive = true, Height = 164, Weight = 50, AverageStar = 4.4, IsLock = false },
new Account { AccountId = "A037", Name = "Sebastian Bronze", Email = "sebastian@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 45000, IsActive = true, Height = 179, Weight = 72, AverageStar = 4.5, IsLock = false },
new Account { AccountId = "A038", Name = "Harper Rose", Email = "harper@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 46000, IsActive = true, Height = 168, Weight = 53, AverageStar = 4.6, IsLock = false },
new Account { AccountId = "A039", Name = "Caleb Onyx", Email = "caleb@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 47000, IsActive = true, Height = 181, Weight = 75, AverageStar = 4.7, IsLock = false },
new Account { AccountId = "A040", Name = "Scarlett Magenta", Email = "scarlett@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 48000, IsActive = true, Height = 162, Weight = 51, AverageStar = 4.8, IsLock = false },
new Account { AccountId = "A041", Name = "Manager", Email = "manager@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R002", IsActive = true, IsLock = false },
new Account { AccountId = "A042", Name = "Consultant", Email = "consultant@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R003", IsActive = true, IsLock = false }
);

            #endregion

            #region AccountImage

            modelBuilder.Entity<AccountImage>().HasData(
                new AccountImage { AccountImageId = "AI01", AccountId = "A001", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://tftravel.com.vn/wp-content/uploads/2021/02/team-1.jpg" },
                new AccountImage { AccountImageId = "AI02", AccountId = "A001", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/originals/a6/bc/25/a6bc259bd4209b1f9dddf93607f68644.jpg" },
                new AccountImage { AccountImageId = "AI03", AccountId = "A001", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/a9/2a/9e/a92a9ed46b8cc1067dc20840d3c4fee5.jpg" },
                new AccountImage { AccountImageId = "AI04", AccountId = "A001", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/4e/86/e2/4e86e2cfd4b1b45e5faa6cf872b1a905.jpg" },

                new AccountImage { AccountImageId = "AI05", AccountId = "A002", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/f1/82/ce/f182ce676795a62d00036da861a90c33.jpg" },
                new AccountImage { AccountImageId = "AI06", AccountId = "A002", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/aa/95/35/aa953549f4b2bb159d9e726e3ff3a2ed.jpg" },
                new AccountImage { AccountImageId = "AI07", AccountId = "A002", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/3b/d8/1b/3bd81b616374e74b3fa33dbc916dbfcc.jpg" },
                new AccountImage { AccountImageId = "AI08", AccountId = "A002", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/93/f9/d8/93f9d842e536468ff7503d6ceda91dca.jpg" },

                new AccountImage { AccountImageId = "AI09", AccountId = "A005", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/15/f5/46/15f546b7df5498113d23bb5b02497548.jpg" },
                new AccountImage { AccountImageId = "AI10", AccountId = "A005", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/b0/8c/a9/b08ca9db4b5c47fe25428da2823c9a41.jpg" },
                new AccountImage { AccountImageId = "AI11", AccountId = "A005", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/fb/ec/67/fbec67d903362ff4ffd6bc4489f4910d.jpg" },
                new AccountImage { AccountImageId = "AI12", AccountId = "A005", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/6f/86/0a/6f860aa99e78fdd33ad516dfb84fb13f.jpg" },

                new AccountImage { AccountImageId = "AI13", AccountId = "A007", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/ca/42/d9/ca42d9541580d5542fa29a568a68a714.jpg" },
                new AccountImage { AccountImageId = "AI14", AccountId = "A007", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/3e/ba/30/3eba305131695dd20a6a1203fe955c04.jpg" },
                new AccountImage { AccountImageId = "AI15", AccountId = "A007", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/15/0c/3c/150c3c6df16d0f3b976f07529801a8e5.jpg" },
                new AccountImage { AccountImageId = "AI16", AccountId = "A007", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/04/56/a8/0456a8ccfe96917fdc56703d2e3cca17.jpg" },

                new AccountImage { AccountImageId = "AI17", AccountId = "A008", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/4a/1d/4d/4a1d4d05f09b833adb9a78af8be2137f.jpg" },
                new AccountImage { AccountImageId = "AI18", AccountId = "A008", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/2b/80/60/2b8060ca82bfb42642f1ec4aefe39428.jpg" },
                new AccountImage { AccountImageId = "AI19", AccountId = "A008", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/81/6b/79/816b79ab93e73d6240177d7da8e345a8.jpg" },
                new AccountImage { AccountImageId = "AI20", AccountId = "A008", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/da/69/57/da695796f69212dfb2440d2b2e3f6800.jpg" },

                new AccountImage { AccountImageId = "AI21", AccountId = "A010", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/a5/67/52/a56752ef994d5c6cf6499b4cef52e2f7.jpg" },
                new AccountImage { AccountImageId = "AI22", AccountId = "A010", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/e8/79/74/e87974221b2c629e6b8652d69e8d137d.jpg" },
                new AccountImage { AccountImageId = "AI23", AccountId = "A010", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/99/84/d9/9984d9e425ac3663fe5d24e49cb38eed.jpg" },
                new AccountImage { AccountImageId = "AI24", AccountId = "A010", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/47/ec/be/47ecbea5cfac28fafe8e19faaa355342.jpg" },

                new AccountImage { AccountImageId = "AI25", AccountId = "A012", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/ef/ba/25/efba25ef9c63e7294340de6f14048795.jpg" },
                new AccountImage { AccountImageId = "AI26", AccountId = "A012", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/93/d2/55/93d2552c5c6a0f90d867c4617f33d0d1.jpg" },
                new AccountImage { AccountImageId = "AI27", AccountId = "A012", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/7e/62/d7/7e62d70e323b92b166026ab145e1703e.jpg" },
                new AccountImage { AccountImageId = "AI28", AccountId = "A012", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/42/de/11/42de11b557fe83b3040178671db20b73.jpg" },  
                
                new AccountImage { AccountImageId = "AI29", AccountId = "A016", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/c6/49/e8/c649e8f88170ebf177e6910bfc518696.jpg" },
                new AccountImage { AccountImageId = "AI30", AccountId = "A016", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/77/3d/e8/773de85e694e8f88ed08ff5509ae4355.jpg" },
                new AccountImage { AccountImageId = "AI31", AccountId = "A016", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/26/94/bd/2694bd3519bcfd0cdf518d6b5ead8684.jpg" },
                new AccountImage { AccountImageId = "AI32", AccountId = "A016", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/83/67/8f/83678f4941b8d106136201deebb26bc7.jpg" },

                new AccountImage { AccountImageId = "AI33", AccountId = "A017", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/95/57/ce/9557ce89bef894c11242f90d0e11ed88.jpg" },
                new AccountImage { AccountImageId = "AI34", AccountId = "A017", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/6c/3d/32/6c3d329db2a87ce681754b0a70040d07.jpg" },
                new AccountImage { AccountImageId = "AI35", AccountId = "A017", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/04/5b/91/045b9179ebdede69c3aba42195fd47b2.jpg" },
                new AccountImage { AccountImageId = "AI36", AccountId = "A017", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/05/7c/0a/057c0a4c922c6f98b8d9715bb537ab83.jpg" },

                new AccountImage { AccountImageId = "AI37", AccountId = "A018", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/8a/ef/b2/8aefb28db28939806440e3de90c5b029.jpg" },
                new AccountImage { AccountImageId = "AI38", AccountId = "A018", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/53/75/08/537508f69d893602a3cbb031ae699ba5.jpg" },
                new AccountImage { AccountImageId = "AI39", AccountId = "A018", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/0f/f2/67/0ff26774a0f4fd7745a77d92dc1a3443.jpg" },
                new AccountImage { AccountImageId = "AI40", AccountId = "A018", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/dd/a5/9b/dda59b436bb82a60da6910e9b556b932.jpg" },

                new AccountImage { AccountImageId = "AI41", AccountId = "A019", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/6b/c9/c4/6bc9c4075b37202e3bdaa445e0337b13.jpg" },
                new AccountImage { AccountImageId = "AI42", AccountId = "A019", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/14/a7/87/14a7874490c3b61fab4651ae5ff4112f.jpg" },
                new AccountImage { AccountImageId = "AI43", AccountId = "A019", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/20/54/f4/2054f48bdc17b91f279938674cbd33ad.jpg" },
                new AccountImage { AccountImageId = "AI44", AccountId = "A019", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/60/9c/43/609c434fb92fa95266c7be06fe96efbc.jpg" },

                new AccountImage { AccountImageId = "AI45", AccountId = "A020", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/b8/27/d8/b827d8c8a295985347865df94088c597.jpg" },
                new AccountImage { AccountImageId = "AI46", AccountId = "A020", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/7b/34/c1/7b34c1cd28ce80067fa749c5009ac7c7.jpg" },
                new AccountImage { AccountImageId = "AI47", AccountId = "A020", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/95/88/d1/9588d11d286959114820ba9db75495dd.jpg" },
                new AccountImage { AccountImageId = "AI48", AccountId = "A020", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/6e/2d/24/6e2d2433a754c2c40da9b43a8f8ddeb5.jpg" },

                new AccountImage { AccountImageId = "AI49", AccountId = "A021", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/5e/42/2d/5e422d974040651b04ed142b92b458dc.jpg" },
                new AccountImage { AccountImageId = "AI50", AccountId = "A021", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/38/9f/7b/389f7b75e44c3ac7b6a88822fc750a07.jpg" },
                new AccountImage { AccountImageId = "AI51", AccountId = "A021", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/20/47/c7/2047c724f925d1245fa8fe16d2358e34.jpg" },
                new AccountImage { AccountImageId = "AI52", AccountId = "A021", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/81/99/9a/81999a3e8311019965629487ead07a76.jpg" },

                new AccountImage { AccountImageId = "AI53", AccountId = "A022", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/cd/87/ed/cd87ed57b54707beda273ab7859e0aa2.jpg" },
                new AccountImage { AccountImageId = "AI54", AccountId = "A022", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/9a/38/21/9a3821d24193b383790a027b4010a90e.jpg" },
                new AccountImage { AccountImageId = "AI55", AccountId = "A022", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/e8/29/e0/e829e0a56266a7ad2e1cb246d3ae8485.jpg" },
                new AccountImage { AccountImageId = "AI56", AccountId = "A022", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/62/b2/41/62b241944f967787d4f42e1bb8f39150.jpg" },

                new AccountImage { AccountImageId = "AI57", AccountId = "A023", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/06/fc/aa/06fcaa6e24a14618e2b311626f0e1731.jpg" },
                new AccountImage { AccountImageId = "AI58", AccountId = "A023", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/c9/1b/40/c91b40ea5039f9ba77c6818c562c5e03.jpg" },
                new AccountImage { AccountImageId = "AI59", AccountId = "A023", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/12/bc/af/12bcaf16db2536b5efcd0151e4b3961f.jpg" },
                new AccountImage { AccountImageId = "AI60", AccountId = "A023", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/da/0e/62/da0e62808a44ae34ea64fbed4d53d985.jpg" },

                new AccountImage { AccountImageId = "AI61", AccountId = "A024", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/62/28/d6/6228d67af0d1ec8fb29c6c2a4caab140.jpg" },
                new AccountImage { AccountImageId = "AI62", AccountId = "A024", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/16/f2/ed/16f2ed550316d9b9e6b711bf5db48199.jpg" },
                new AccountImage { AccountImageId = "AI63", AccountId = "A024", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/24/0c/a6/240ca6f928fd4a14f5d374587a79ca15.jpg" },
                new AccountImage { AccountImageId = "AI64", AccountId = "A024", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/08/5b/6f/085b6fea8dec2b94ae9f61b7371bd673.jpg" },

                new AccountImage { AccountImageId = "AI65", AccountId = "A026", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/29/27/31/29273169c4efa0a8e6046a12f2da2acc.jpg" },
                new AccountImage { AccountImageId = "AI66", AccountId = "A026", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/ac/88/35/ac88358182a19358f733c55167609eca.jpg" },
                new AccountImage { AccountImageId = "AI67", AccountId = "A026", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/77/62/ab/7762abfda62f20753c0178876c1d2502.jpg" },
                new AccountImage { AccountImageId = "AI68", AccountId = "A026", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/04/12/23/041223a462f501f104f50ff14db702f6.jpg" },

                new AccountImage { AccountImageId = "AI69", AccountId = "A027", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/1f/ab/c6/1fabc6a5b521f216a23f342e4a0d6693.jpg" },
                new AccountImage { AccountImageId = "AI70", AccountId = "A027", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/16/8b/93/168b93c1d23074062772105e918cc6fb.jpg" },
                new AccountImage { AccountImageId = "AI71", AccountId = "A027", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/5d/b4/0f/5db40fd8b35c811b26766a82b7bdc3fe.jpg" },
                new AccountImage { AccountImageId = "AI72", AccountId = "A027", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/db/7c/11/db7c11ca40d3a7a298b5883f59212e6f.jpg" },

                new AccountImage { AccountImageId = "AI73", AccountId = "A030", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/4c/4d/f1/4c4df13ca300caf1b6b44e04d7bc850b.jpg" },
                new AccountImage { AccountImageId = "AI74", AccountId = "A030", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/01/3b/f2/013bf2519246b18ad649a2b46fb555fb.jpg" },
                new AccountImage { AccountImageId = "AI75", AccountId = "A030", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/92/c0/94/92c094471ff7fd4f62c5ffb60ecbb631.jpg" },
                new AccountImage { AccountImageId = "AI76", AccountId = "A030", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/8b/5f/c4/8b5fc4a0731c8f1b2e0a260990f4a652.jpg" },

                new AccountImage { AccountImageId = "AI77", AccountId = "A031", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/fa/11/d0/fa11d0ff1344020f8836c36a65750588.jpg" },
                new AccountImage { AccountImageId = "AI78", AccountId = "A031", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/32/2e/c3/322ec31c264453cb1cefe341c33bab47.jpg" },
                new AccountImage { AccountImageId = "AI79", AccountId = "A031", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/a9/76/07/a97607d31abf66ac67fe1e98cca5b1d5.jpg" },
                new AccountImage { AccountImageId = "AI80", AccountId = "A031", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/b0/45/2d/b0452d15257ce22d4c714cb3256f5223.jpg" },

                new AccountImage { AccountImageId = "AI81", AccountId = "A032", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/b9/ba/fd/b9bafd46360e4fe812a98b64959eacaf.jpg" },
                new AccountImage { AccountImageId = "AI82", AccountId = "A032", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/b8/e6/76/b8e67682a4b3d90285c1c703b1ab09eb.jpg" },
                new AccountImage { AccountImageId = "AI83", AccountId = "A032", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/b3/74/c4/b374c47dd21214efb855a4f4549c41c4.jpg" },
                new AccountImage { AccountImageId = "AI84", AccountId = "A032", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/5b/7c/54/5b7c54189d8ce4d3bf9b2cc01eeef1fc.jpg" },

                new AccountImage { AccountImageId = "AI85", AccountId = "A033", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/34/18/22/34182254b22d2132d36b4d78a6b263e5.jpg" },
                new AccountImage { AccountImageId = "AI86", AccountId = "A033", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/d2/37/86/d237864b3e34810b5433b9526ae4ad0b.jpg" },
                new AccountImage { AccountImageId = "AI87", AccountId = "A033", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/54/cd/6c/54cd6c312e0dc5066d2c9fbdf6f43868.jpg" },
                new AccountImage { AccountImageId = "AI88", AccountId = "A033", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/63/71/9c/63719c13e8f733cdd977a4b53aaba0b3.jpg" },

                new AccountImage { AccountImageId = "AI89", AccountId = "A034", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/eb/a4/99/eba4995776296a9e7976cfd8910fe89d.jpg" },
                new AccountImage { AccountImageId = "AI90", AccountId = "A034", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/56/07/bf/5607bf1c6dccf0b3ebc2c4c6d7a52acf.jpg" },
                new AccountImage { AccountImageId = "AI91", AccountId = "A034", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/2e/e6/50/2ee650a3044c4874fdc1179c25f4fa6c.jpg" },
                new AccountImage { AccountImageId = "AI92", AccountId = "A034", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/9f/86/9a/9f869a68e316f2ee6e38fe0f0e8526d4.jpg" },

                new AccountImage { AccountImageId = "AI93", AccountId = "A035", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/c0/95/f2/c095f2e3430c2558ad3c8df49c97637b.jpg" },
                new AccountImage { AccountImageId = "AI94", AccountId = "A035", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/c6/43/a4/c643a40e94d0a38453ea5de5fd25258d.jpg" },
                new AccountImage { AccountImageId = "AI95", AccountId = "A035", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/84/d2/49/84d249395f122117ecebd58329c4f6fa.jpg" },
                new AccountImage { AccountImageId = "AI96", AccountId = "A035", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/3b/e4/2f/3be42fafce1256eb99727fcb3b6ef6c9.jpg" },

                new AccountImage { AccountImageId = "AI97", AccountId = "A036", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/9b/00/c0/9b00c0393fa9b8b34fc0646984c0cd28.jpg" },
                new AccountImage { AccountImageId = "AI98", AccountId = "A036", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/c4/ef/c4/c4efc41aa1272888f3900a4e84c11050.jpg" },
                new AccountImage { AccountImageId = "AI99", AccountId = "A036", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/2e/aa/04/2eaa0421302548f3844c2cb37f0c8d26.jpg" },
                new AccountImage { AccountImageId = "AI100", AccountId = "A036", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/af/be/4f/afbe4f62dff502301f9548ac69878f58.jpg" },

                new AccountImage { AccountImageId = "AI101", AccountId = "A037", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/74/2b/1e/742b1ee0648e30cf46515a001b69e950.jpg" },
                new AccountImage { AccountImageId = "AI102", AccountId = "A037", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/43/25/52/432552136be3eec79b86c1612918718d.jpg" },
                new AccountImage { AccountImageId = "AI103", AccountId = "A037", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/66/da/19/66da19604347b4eb703df694703dbafe.jpg" },
                new AccountImage { AccountImageId = "AI104", AccountId = "A037", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/09/85/bd/0985bdb9abb1ba2006ea5bbaa0156216.jpg" },

                new AccountImage { AccountImageId = "AI105", AccountId = "A038", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/32/af/33/32af3330425fb3506f3dc3b26f42977d.jpg" },
                new AccountImage { AccountImageId = "AI106", AccountId = "A038", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/51/f6/0f/51f60f776fd573c1a5c0e0c40dea6ce4.jpg" },
                new AccountImage { AccountImageId = "AI107", AccountId = "A038", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/bc/01/96/bc019677d32019f157b65a1b52cf8525.jpg" },
                new AccountImage { AccountImageId = "AI108", AccountId = "A038", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/21/ab/2e/21ab2ea44c87f1ccb5a045fbc108fd5b.jpg" },

                new AccountImage { AccountImageId = "AI109", AccountId = "A039", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/ea/0d/7d/ea0d7d7bea568bb90db6249962a47e44.jpg" },
                new AccountImage { AccountImageId = "AI110", AccountId = "A039", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/83/ee/3f/83ee3fabf7711cf45ffe138f56e721cb.jpg" },
                new AccountImage { AccountImageId = "AI111", AccountId = "A039", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/7d/e4/20/7de420bbb605367225dcf49c8bc1dfc5.jpg" },
                new AccountImage { AccountImageId = "AI112", AccountId = "A039", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/cd/1e/69/cd1e695a7a4975899d35355af795a1b4.jpg" },

                new AccountImage { AccountImageId = "AI113", AccountId = "A040", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/96/5f/0d/965f0d17bb49f04319ff92d8386f376b.jpg" },
                new AccountImage { AccountImageId = "AI114", AccountId = "A040", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/44/87/2d/44872d8ee209e36937d28ce37d9185b2.jpg" },
                new AccountImage { AccountImageId = "AI115", AccountId = "A040", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/2c/a9/7f/2ca97f876142eb705b5e7b4f2575921f.jpg" },
                new AccountImage { AccountImageId = "AI116", AccountId = "A040", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/28/3a/6f/283a6fe7b75a8fac14f39e455c5ddf3e.jpg" },

                new AccountImage { AccountImageId = "AI117", AccountId = "A013", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/61/d6/b1/61d6b1e5b709639b723bb5089152d6d3.jpg" },
                new AccountImage { AccountImageId = "AI118", AccountId = "A013", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/50/ae/27/50ae27b2034b85d2a7bf4d034d5e572a.jpg" },
                new AccountImage { AccountImageId = "AI119", AccountId = "A013", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/39/16/78/391678508450a4ee33776c39fdf2c1ef.jpg" },
                new AccountImage { AccountImageId = "AI120", AccountId = "A013", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/69/15/b9/6915b9ffa19b89e6f1543e05b5b26f70.jpg" },

                new AccountImage { AccountImageId = "AI121", AccountId = "A028", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/14/ca/61/14ca61522c3d813c3ea62c4710828ce2.jpg" },
                new AccountImage { AccountImageId = "AI122", AccountId = "A028", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/4e/97/cc/4e97ccc8f6959a693ac2ad75c13604c7.jpg" },
                new AccountImage { AccountImageId = "AI123", AccountId = "A028", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/474x/d0/47/cb/d047cbd5b9af39284b7196b273d133a3.jpg" },
                new AccountImage { AccountImageId = "AI124", AccountId = "A028", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/dc/61/5d/dc615d9f585f76243510fb7e8c7af1d8.jpg" },

                new AccountImage { AccountImageId = "AI125", AccountId = "A029", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/16/d8/88/16d8888fe52fedf56766a7511c42be69.jpg" },
                new AccountImage { AccountImageId = "AI126", AccountId = "A029", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/e0/e1/0a/e0e10ace79a99cc678fe9aedfbfdfa83.jpg" },
                new AccountImage { AccountImageId = "AI127", AccountId = "A029", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/3e/6c/cd/3e6ccdb41eed4ac91ac04b39a4b15694.jpg" },
                new AccountImage { AccountImageId = "AI128", AccountId = "A029", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/eb/58/42/eb58427dffb8c0c20637df1713a583a8.jpg" },

                new AccountImage { AccountImageId = "AI129", AccountId = "A025", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/cd/ab/48/cdab4817b7b49287dc3a9531ac99dfae.jpg" },
                new AccountImage { AccountImageId = "AI130", AccountId = "A025", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/30/34/ea/3034ea8302054e693520957c194decae.jpg" },
                new AccountImage { AccountImageId = "AI131", AccountId = "A025", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/f4/4b/de/f44bdec05cf7826b67c2030613374ecb.jpg" },
                new AccountImage { AccountImageId = "AI132", AccountId = "A025", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/fa/c1/ef/fac1efe39388d64003b1ec4c7d2d05e8.jpg" },

                new AccountImage { AccountImageId = "AI133", AccountId = "A015", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/94/c2/69/94c269ee90d0d8a5584a7a48207f50ca.jpg" },
                new AccountImage { AccountImageId = "AI134", AccountId = "A015", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/2d/96/29/2d96299467843d2876516493ade1eea3.jpg" },
                new AccountImage { AccountImageId = "AI135", AccountId = "A015", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/e4/df/f6/e4dff6f0e30260a73019f5d1a44cd8ec.jpg" },
                new AccountImage { AccountImageId = "AI136", AccountId = "A015", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/9e/4f/2a/9e4f2ab84f5d8e3c4e36ad2c5c3962e2.jpg" },

                new AccountImage { AccountImageId = "AI137", AccountId = "A011", CreateDate = DateTime.Now, IsAvatar = true, UrlImage = "https://i.pinimg.com/736x/fc/32/5f/fc325f1a000313529aaf6dd0653bfaca.jpg" },
                new AccountImage { AccountImageId = "AI138", AccountId = "A011", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/a5/e2/55/a5e255b0fe8d64fd9178b912069c13c4.jpg" },
                new AccountImage { AccountImageId = "AI139", AccountId = "A011", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/39/bc/ca/39bccadc5344e7e653c21c8b8722d0d7.jpg" },
                new AccountImage { AccountImageId = "AI140", AccountId = "A011", CreateDate = DateTime.Now, IsAvatar = false, UrlImage = "https://i.pinimg.com/736x/13/12/c1/1312c16d2b1ad283e850918f0e7910b2.jpg" }
                );

            #endregion

            #region Category

            modelBuilder.Entity<Category>().HasData(
new Category { CategoryId = "C3", CategoryName = "Manga", Description = "Manga characters" },
new Category { CategoryId = "C4", CategoryName = "Movie", Description = "Movie characters" },
new Category { CategoryId = "C5", CategoryName = "Comic", Description = "Comic book characters" },
new Category { CategoryId = "C6", CategoryName = "Mythology", Description = "Mythological characters" },
new Category { CategoryId = "C7", CategoryName = "Fantasy", Description = "Fantasy world characters" },
new Category { CategoryId = "C8", CategoryName = "Sci-Fi", Description = "Science fiction characters" },
new Category { CategoryId = "C9", CategoryName = "Superhero", Description = "Superhero characters" },
new Category { CategoryId = "C10", CategoryName = "Villains", Description = "Famous villain characters" },
new Category { CategoryId = "C11", CategoryName = "Robot", Description = "AI and robot characters" },
new Category { CategoryId = "C12", CategoryName = "Historical", Description = "Historical figures in fiction" },
new Category { CategoryId = "C13", CategoryName = "Horror", Description = "Horror and thriller characters" },
new Category { CategoryId = "C14", CategoryName = "Detective", Description = "Famous detective characters" },
new Category { CategoryId = "C15", CategoryName = "Sports", Description = "Characters from sports anime/manga" },
new Category { CategoryId = "C16", CategoryName = "Magic", Description = "Characters using magic or spells" },
new Category { CategoryId = "C17", CategoryName = "Slice of Life", Description = "Everyday life characters" }
);

            #endregion


            #region Character
            modelBuilder.Entity<Character>().HasData(
     new Character { CharacterId = "CH001", CharacterName = "Naruto", CategoryId = "C3", Description = "Ninja from Konoha", Price = 100000, IsActive = true, MaxHeight = 180, MinHeight = 160, MaxWeight = 80, MinWeight = 50, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH002", CharacterName = "Sasuke", CategoryId = "C3", Description = "Naruto’s rival", Price = 120000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH003", CharacterName = "Goku", CategoryId = "C3", Description = "Saiyan warrior", Price = 150000, IsActive = true, MaxHeight = 190, MinHeight = 170, MaxWeight = 90, MinWeight = 60, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH004", CharacterName = "Luffy", CategoryId = "C4", Description = "Pirate King", Price = 110000, IsActive = true, MaxHeight = 175, MinHeight = 155, MaxWeight = 70, MinWeight = 45, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH005", CharacterName = "Ichigo", CategoryId = "C4", Description = "Soul Reaper", Price = 130000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 100, CreateDate = DateTime.UtcNow },

     new Character { CharacterId = "CH006", CharacterName = "Mario", CategoryId = "C14", Description = "Plumber hero", Price = 80000, IsActive = true, MaxHeight = 180, MinHeight = 160, MaxWeight = 80, MinWeight = 60, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH007", CharacterName = "Luigi", CategoryId = "C14", Description = "Mario’s brother", Price = 85000, IsActive = true, MaxHeight = 170, MinHeight = 150, MaxWeight = 75, MinWeight = 55, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH008", CharacterName = "Link", CategoryId = "C14", Description = "Hero of Hyrule", Price = 140000, IsActive = true, MaxHeight = 180, MinHeight = 160, MaxWeight = 80, MinWeight = 50, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH009", CharacterName = "Zelda", CategoryId = "C16", Description = "Hyrule princess", Price = 135000, IsActive = true, MaxHeight = 175, MinHeight = 155, MaxWeight = 70, MinWeight = 50, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH010", CharacterName = "Samus", CategoryId = "C16", Description = "Bounty hunter", Price = 145000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 100, CreateDate = DateTime.UtcNow },

     new Character { CharacterId = "CH011", CharacterName = "Cloud", CategoryId = "C13", Description = "Ex-SOLDIER", Price = 125000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH012", CharacterName = "Sephiroth", CategoryId = "C13", Description = "One-Winged Angel", Price = 155000, IsActive = true, MaxHeight = 190, MinHeight = 170, MaxWeight = 90, MinWeight = 60, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH013", CharacterName = "Kratos", CategoryId = "C8", Description = "God of War", Price = 160000, IsActive = true, MaxHeight = 195, MinHeight = 175, MaxWeight = 100, MinWeight = 70, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH014", CharacterName = "Pikachu", CategoryId = "C8", Description = "Electric Pokemon", Price = 90000, IsActive = true, MaxHeight = 180, MinHeight = 160, MaxWeight = 80, MinWeight = 60, Quantity = 100, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH015", CharacterName = "Kirby", CategoryId = "C8", Description = "Pink puffball", Price = 95000, IsActive = true, MaxHeight = 180, MinHeight = 160, MaxWeight = 80, MinWeight = 60, Quantity = 100, CreateDate = DateTime.UtcNow }
 );
            #endregion


            #region Service
            modelBuilder.Entity<Service>().HasData(
    new Service { ServiceId = "S001", ServiceName = "Character Rental", Description = "Rent characters for events and parties", CreateDate = DateTime.UtcNow },
    new Service { ServiceId = "S002", ServiceName = "Cosplay Rental", Description = "Live cosplay performances at events", CreateDate = DateTime.UtcNow },
    new Service { ServiceId = "S003", ServiceName = "Create event", Description = "Professional photoshoot with cosplayers", CreateDate = DateTime.UtcNow }
);
            #endregion

            #region Product
            modelBuilder.Entity<Product>().HasData(
     new Product { ProductId = "P001", ProductName = "Naruto Wig", Description = "A wig for Naruto cosplay", Price = 30000, Quantity = 10, CreateDate = DateTime.UtcNow, IsActive = true, weight = 200, length = 30, width = 20, height = 10 },
     new Product { ProductId = "P002", ProductName = "Mario Hat", Description = "A hat for Mario cosplay", Price = 20000, Quantity = 15, CreateDate = DateTime.UtcNow, IsActive = true, weight = 100, length = 25, width = 25, height = 15 },
     new Product { ProductId = "P003", ProductName = "Sasuke Costume", Description = "Complete costume for Sasuke cosplay", Price = 80000, Quantity = 5, CreateDate = DateTime.UtcNow, IsActive = true, weight = 800, length = 50, width = 40, height = 15 },
     new Product { ProductId = "P004", ProductName = "Zelda Sword", Description = "Replica sword from The Legend of Zelda", Price = 100000, Quantity = 7, CreateDate = DateTime.UtcNow, IsActive = true, weight = 1500, length = 120, width = 15, height = 5 },
     new Product { ProductId = "P005", ProductName = "One Piece Straw Hat", Description = "Iconic straw hat from One Piece", Price = 25000, Quantity = 20, CreateDate = DateTime.UtcNow, IsActive = true, weight = 300, length = 35, width = 35, height = 10 },
     new Product { ProductId = "P006", ProductName = "Miku Wig", Description = "Hatsune Miku blue twin-tail wig", Price = 40000, Quantity = 12, CreateDate = DateTime.UtcNow, IsActive = true, weight = 150, length = 40, width = 25, height = 5 },
     new Product { ProductId = "P007", ProductName = "Demon Slayer Earrings", Description = "Tanjiro's iconic hanafuda earrings", Price = 15000, Quantity = 30, CreateDate = DateTime.UtcNow, IsActive = true, weight = 50, length = 5, width = 5, height = 3 },
     new Product { ProductId = "P008", ProductName = "Attack on Titan Jacket", Description = "Survey Corps uniform jacket", Price = 50000, Quantity = 10, CreateDate = DateTime.UtcNow, IsActive = true, weight = 800, length = 50, width = 40, height = 5 },
     new Product { ProductId = "P009", ProductName = "Pikachu Onesie", Description = "Cozy Pikachu-themed onesie", Price = 60000, Quantity = 8, CreateDate = DateTime.UtcNow, IsActive = true, weight = 700, length = 60, width = 50, height = 10 },
     new Product { ProductId = "P010", ProductName = "Cloud's Buster Sword", Description = "Final Fantasy VII replica sword", Price = 120000, Quantity = 4, CreateDate = DateTime.UtcNow, IsActive = true, weight = 2000, length = 160, width = 25, height = 10 },
     new Product { ProductId = "P011", ProductName = "Genshin Impact Vision", Description = "LED Vision accessory from Genshin Impact", Price = 35000, Quantity = 25, CreateDate = DateTime.UtcNow, IsActive = true, weight = 100, length = 10, width = 10, height = 5 },
     new Product { ProductId = "P012", ProductName = "Jinx Wig", Description = "Jinx cosplay wig from Arcane", Price = 45000, Quantity = 6, CreateDate = DateTime.UtcNow, IsActive = true, weight = 250, length = 40, width = 25, height = 10 },
     new Product { ProductId = "P013", ProductName = "Sailor Moon Tiara", Description = "Golden tiara from Sailor Moon", Price = 18000, Quantity = 15, CreateDate = DateTime.UtcNow, IsActive = true, weight = 50, length = 15, width = 15, height = 5 },
     new Product { ProductId = "P014", ProductName = "Spider-Man Suit", Description = "High-quality Spider-Man suit", Price = 90000, Quantity = 3, CreateDate = DateTime.UtcNow, IsActive = true, weight = 1500, length = 70, width = 40, height = 5 },
     new Product { ProductId = "P015", ProductName = "Harry Potter Wand", Description = "Replica wand from Harry Potter series", Price = 22000, Quantity = 50, CreateDate = DateTime.UtcNow, IsActive = true, weight = 200, length = 35, width = 5, height = 5 }
 );

            #endregion


            #region Event
            modelBuilder.Entity<Event>().HasData(
    new Event { EventId = "E001", EventName = "New Year Festival", Description = "A grand celebration to welcome the new year", Location = "Times Square, New York", IsActive = true, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 1, 2), CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new Event { EventId = "E002", EventName = "Spring Blossom Fest", Description = "Experience the beauty of cherry blossoms", Location = "Kyoto, Japan", IsActive = true, StartDate = new DateTime(2025, 2, 10), EndDate = new DateTime(2025, 2, 12), CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new Event { EventId = "E003", EventName = "Tech Innovation Summit", Description = "Showcasing the latest in technology and AI", Location = "Silicon Valley", IsActive = true, StartDate = new DateTime(2025, 3, 5), EndDate = new DateTime(2025, 3, 7), CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new Event { EventId = "E004", EventName = "Music Fest", Description = "Live performances from top artists", Location = "Coachella, California", IsActive = true, StartDate = new DateTime(2025, 4, 15), EndDate = new DateTime(2025, 4, 17), CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new Event { EventId = "E005", EventName = "Comic-Con International", Description = "A must-attend event for comic book fans", Location = "San Diego Convention Center", IsActive = true, StartDate = new DateTime(2025, 5, 22), EndDate = new DateTime(2025, 5, 24), CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new Event { EventId = "E006", EventName = "Anime Expo", Description = "Largest anime convention in the world", Location = "Los Angeles Convention Center", IsActive = true, StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 6, 12), CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new Event { EventId = "E007", EventName = "Gaming Expo", Description = "Latest trends and releases in gaming", Location = "Las Vegas Convention Center", IsActive = true, StartDate = new DateTime(2025, 7, 18), EndDate = new DateTime(2025, 7, 20), CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new Event { EventId = "E008", EventName = "Summer Festival", Description = "A fun-filled summer celebration", Location = "Miami Beach, Florida", IsActive = true, StartDate = new DateTime(2025, 8, 8), EndDate = new DateTime(2025, 8, 10), CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new Event { EventId = "E009", EventName = "Cosplay Festival", Description = "A paradise for cosplayers", Location = "Tokyo Big Sight", IsActive = true, StartDate = new DateTime(2025, 9, 12), EndDate = new DateTime(2025, 9, 14), CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new Event { EventId = "E010", EventName = "Film Festival", Description = "Showcasing the best movies of the year", Location = "Cannes, France", IsActive = true, StartDate = new DateTime(2025, 10, 3), EndDate = new DateTime(2025, 10, 5), CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new Event { EventId = "E011", EventName = "Halloween Night", Description = "Spooky celebrations and costume parties", Location = "Salem, Massachusetts", IsActive = true, StartDate = new DateTime(2025, 11, 1), EndDate = new DateTime(2025, 11, 2), CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new Event { EventId = "E012", EventName = "Christmas Market", Description = "Festive shopping and holiday cheer", Location = "Nuremberg, Germany", IsActive = true, StartDate = new DateTime(2025, 12, 20), EndDate = new DateTime(2025, 12, 24), CreateDate = DateTime.UtcNow, CreateBy = "Admin" }
);
            #endregion

            #region Order
            modelBuilder.Entity<Order>().HasData(
   new Order { OrderId = "O001", AccountId = "A003", OrderDate = DateTime.Parse("2024-03-01"), TotalPrice = 250000.0, OrderStatus = OrderStatus.Completed, Address = "123 Main St", Phone = "0901234567", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S001", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O002", AccountId = "A006", OrderDate = DateTime.Parse("2024-03-05"), TotalPrice = 150000.5, OrderStatus = OrderStatus.Completed, Address = "456 Elm St", Phone = "0902345678", ShipStatus = ShipStatus.Cancel, ShipCode = "S002", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O003", AccountId = "A011", OrderDate = DateTime.Parse("2024-03-10"), TotalPrice = 300000.0, OrderStatus = OrderStatus.Cancel, Address = "789 Pine St", Phone = "0903456789", ShipStatus = ShipStatus.InTransit, ShipCode = "S003", to_ward_code = "90767", to_district_id = 3695, CancelDate = DateTime.Parse("2024-03-10") },
   new Order { OrderId = "O004", AccountId = "A014", OrderDate = DateTime.Parse("2024-03-12"), TotalPrice = 400000.0, OrderStatus = OrderStatus.Completed, Address = "101 Oak St", Phone = "0904567890", ShipStatus = ShipStatus.WaitConfirm, ShipCode = "S004", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O005", AccountId = "A003", OrderDate = DateTime.Parse("2024-03-15"), TotalPrice = 175000.0, OrderStatus = OrderStatus.Cancel, Address = "123 Main St", Phone = "0901234567", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S005", to_ward_code = "90767", to_district_id = 3695, CancelDate = DateTime.Parse("2024-03-15") },
   new Order { OrderId = "O006", AccountId = "A006", OrderDate = DateTime.Parse("2024-03-18"), TotalPrice = 225000.0, OrderStatus = OrderStatus.Completed, Address = "456 Elm St", Phone = "0902345678", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S006", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O007", AccountId = "A011", OrderDate = DateTime.Parse("2024-03-20"), TotalPrice = 350000.0, OrderStatus = OrderStatus.Completed, Address = "789 Pine St", Phone = "0903456789", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S007", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O008", AccountId = "A014", OrderDate = DateTime.Parse("2024-03-22"), TotalPrice = 275000.0, OrderStatus = OrderStatus.Cancel, Address = "101 Oak St", Phone = "0904567890", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S008", to_ward_code = "90767", to_district_id = 3695, CancelDate = DateTime.Parse("2024-03-22") },
   new Order { OrderId = "O009", AccountId = "A003", OrderDate = DateTime.Parse("2024-03-25"), TotalPrice = 500000.0, OrderStatus = OrderStatus.Completed, Address = "123 Main St", Phone = "0901234567", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S009", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O010", AccountId = "A006", OrderDate = DateTime.Parse("2024-03-28"), TotalPrice = 125000.0, OrderStatus = OrderStatus.Cancel, Address = "456 Elm St", Phone = "0902345678", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S010", to_ward_code = "90767", to_district_id = 3695, CancelDate = DateTime.Parse("2024-03-28") },
   new Order { OrderId = "O011", AccountId = "A011", OrderDate = DateTime.Parse("2024-03-30"), TotalPrice = 325000.0, OrderStatus = OrderStatus.Completed, Address = "789 Pine St", Phone = "0903456789", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S011", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O012", AccountId = "A014", OrderDate = DateTime.Parse("2024-04-02"), TotalPrice = 410000.0, OrderStatus = OrderStatus.Completed, Address = "101 Oak St", Phone = "0904567890", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S012", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O013", AccountId = "A003", OrderDate = DateTime.Parse("2024-04-05"), TotalPrice = 280000.0, OrderStatus = OrderStatus.Cancel, Address = "123 Main St", Phone = "0901234567", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S013", to_ward_code = "90767", to_district_id = 3695, CancelDate = DateTime.Parse("2024-04-05") },
   new Order { OrderId = "O014", AccountId = "A006", OrderDate = DateTime.Parse("2024-04-07"), TotalPrice = 350000.0, OrderStatus = OrderStatus.Completed, Address = "456 Elm St", Phone = "0902345678", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S014", to_ward_code = "90767", to_district_id = 3695, CancelDate = null },
   new Order { OrderId = "O015", AccountId = "A011", OrderDate = DateTime.Parse("2024-04-10"), TotalPrice = 200000.0, OrderStatus = OrderStatus.Completed, Address = "789 Pine St", Phone = "0903456789", ShipStatus = ShipStatus.WaitToPick, ShipCode = "S015", to_ward_code = "90767", to_district_id = 3695, CancelDate = null }
);

            #endregion

            #region Coupon
            modelBuilder.Entity<Coupon>().HasData(
    new Coupon { CouponId = "CP001", Condition = "Min order 500", Percent = 10, Amount = 50000, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 31), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP002", Condition = "Min order 1000", Percent = 15, Amount = 150000, StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2024, 4, 30), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP003", Condition = "Min contract 2000", Percent = 20, Amount = 400000, StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 31), Type = CouponType.ForContract },
    new Coupon { CouponId = "CP004", Condition = "Min order 1500", Percent = 12, Amount = 180000, StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 30), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP005", Condition = "Min contract 3000", Percent = 25, Amount = 750000, StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 31), Type = CouponType.ForContract },

    new Coupon { CouponId = "CP006", Condition = "New customers only", Percent = 10, Amount = 100000, StartDate = new DateTime(2024, 8, 1), EndDate = new DateTime(2024, 8, 31), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP007", Condition = "Holiday Special", Percent = 20, Amount = 200000, StartDate = new DateTime(2024, 12, 1), EndDate = new DateTime(2024, 12, 25), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP008", Condition = "VIP customers", Percent = 30, Amount = 600000, StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30), Type = CouponType.ForContract },
    new Coupon { CouponId = "CP009", Condition = "Summer Sale", Percent = 15, Amount = 120000, StartDate = new DateTime(2024, 6, 15), EndDate = new DateTime(2024, 7, 15), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP010", Condition = "Black Friday", Percent = 50, Amount = 1000000, StartDate = new DateTime(2024, 11, 25), EndDate = new DateTime(2024, 11, 30), Type = CouponType.ForContract },

    new Coupon { CouponId = "CP011", Condition = "Back to School", Percent = 10, Amount = 75000, StartDate = new DateTime(2024, 8, 10), EndDate = new DateTime(2024, 9, 10), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP012", Condition = "Min contract 5000", Percent = 35, Amount = 1750000, StartDate = new DateTime(2024, 10, 1), EndDate = new DateTime(2024, 10, 31), Type = CouponType.ForContract },
    new Coupon { CouponId = "CP013", Condition = "Loyal Customers", Percent = 20, Amount = 250000, StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 31), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP014", Condition = "Cyber Monday", Percent = 40, Amount = 800000, StartDate = new DateTime(2024, 11, 26), EndDate = new DateTime(2024, 11, 27), Type = CouponType.ForOrder },
    new Coupon { CouponId = "CP015", Condition = "Referral Bonus", Percent = 10, Amount = 50000, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 12, 31), Type = CouponType.ForOrder }
);
            #endregion


            #region Ticket
            modelBuilder.Entity<Ticket>().HasData(
    new Ticket { TicketId = 1, Quantity = 500, Price = 50000.0, EventId = "E001", ticketType = ticketType.Nomal, Description="Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 2, Quantity = 300, Price = 40000.0, EventId = "E002", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 3, Quantity = 200, Price = 30000.0, EventId = "E003", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 4, Quantity = 600, Price = 60000.0, EventId = "E004", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 5, Quantity = 400, Price = 45000.0, EventId = "E005", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 6, Quantity = 350, Price = 55000.0, EventId = "E006", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 7, Quantity = 250, Price = 35000.0, EventId = "E007", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 8, Quantity = 450, Price = 50000.0, EventId = "E008", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 9, Quantity = 550, Price = 65000.0, EventId = "E009", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 10, Quantity = 700, Price = 70000.0, EventId = "E010", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 11, Quantity = 150, Price = 25000.0, EventId = "E011", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 12, Quantity = 800, Price = 75000.0, EventId = "E012", ticketType = ticketType.Nomal, Description = "Được giao lưu với các idol cosplayer ", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 13, Quantity = 500, Price = 75000.0, EventId = "E001", ticketType = ticketType.Premium, Description = "Được tham gia các hoạt động do chương trình tổ chức", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 14, Quantity = 500, Price = 60000.0, EventId = "E002", ticketType = ticketType.Premium, Description = "Được tham gia các hoạt động do chương trình tổ chức", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 15, Quantity = 500, Price = 45000.0, EventId = "E003", ticketType = ticketType.Premium, Description = "Được tham gia các hoạt động do chương trình tổ chức", ticketStatus = ticketStatus.valid },
    new Ticket { TicketId = 16, Quantity = 500, Price = 90000.0, EventId = "E004", ticketType = ticketType.Premium, Description = "Được tham gia các hoạt động do chương trình tổ chức", ticketStatus = ticketStatus.valid }


);
            #endregion


            #region Contract
            modelBuilder.Entity<Contract>().HasData(
     new Contract { ContractId = "CT002", RequestId = "R002", Deposit = "100", TotalPrice = 500000, Amount = 0,CreateBy = "A002", CreateDate = new DateTime(2025, 2, 1), ContractStatus = ContractStatus.Completed, ContractName = "Character rental" },
     new Contract { ContractId = "CT005", RequestId = "R005", Deposit = "50", TotalPrice = 700000, Amount = 350000, CreateBy = "A005", CreateDate = new DateTime(2025, 5, 1), ContractStatus = ContractStatus.Completed, ContractName = "Character rental" },
     new Contract { ContractId = "CT008", RequestId = "R008", Deposit = "50", TotalPrice = 350000, Amount = 175000, CreateBy = "A008", CreateDate = new DateTime(2025, 8, 10), ContractStatus = ContractStatus.Created, ContractName = "Character rental" },
     new Contract { ContractId = "CT010", RequestId = "R010", Deposit = "50", TotalPrice = 200000, Amount = 100000, CreateBy = "A010", CreateDate = new DateTime(2025, 10, 20), ContractStatus = ContractStatus.Deposited, DeliveryStatus = DeliveryStatus.Delivering, ContractName = "Character rental" },
     new Contract { ContractId = "CT014", RequestId = "R014", Deposit = "100", TotalPrice = 600000, Amount = 0, CreateBy = "A014", CreateDate = new DateTime(2025, 6, 25), ContractStatus = ContractStatus.Created, ContractName = "Character rental" }
 );
            #endregion

            #region Feedback
            modelBuilder.Entity<Feedback>().HasData(
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Great experience!", CreateDate = new DateTime(2025, 2, 15), CreateBy = "A001", AccountId = "A001", ContractCharacterId = "CC0021", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Loved the event!", CreateDate = new DateTime(2025, 3, 10), CreateBy = "A004", AccountId = "A004", ContractCharacterId = "CC0022", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Nice cosplay session!", CreateDate = new DateTime(2025, 4, 5), CreateBy = "A005", AccountId = "A005", ContractCharacterId = "CC0023", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Enjoyed the event!", CreateDate = new DateTime(2025, 6, 20), CreateBy = "A007", AccountId = "A007", ContractCharacterId = "CC0051", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Would love to join again!", CreateDate = new DateTime(2025, 7, 15), CreateBy = "A008", AccountId = "A008", ContractCharacterId = "CC0052", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "The atmosphere was amazing!", CreateDate = new DateTime(2025, 8, 25), CreateBy = "A010", AccountId = "A010", ContractCharacterId = "CC0053", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Best cosplay event!", CreateDate = new DateTime(2025, 9, 10), CreateBy = "A012", AccountId = "A012", ContractCharacterId = "CC0081", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Nice crowd and management!", CreateDate = new DateTime(2025, 10, 5), CreateBy = "A013", AccountId = "A013", ContractCharacterId = "CC0082", Star = 5 },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Amazing experience!", CreateDate = new DateTime(2025, 11, 20), CreateBy = "A015", AccountId = "A015", ContractCharacterId = "CC0083", Star = 5 }
);
            #endregion



            #region Notication
            modelBuilder.Entity<Notification>().HasData(
    new Notification { Id = "N001", AccountId = "A001", Message = "Welcome to the system!", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N002", AccountId = "A002", Message = "Your account has been upgraded.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N003", AccountId = "A003", Message = "New promotional offer available!", IsRead = true, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N004", AccountId = "A004", Message = "Your request has been approved.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N005", AccountId = "A005", Message = "System maintenance scheduled.", IsRead = true, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N006", AccountId = "A006", Message = "Your order has been shipped!", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N007", AccountId = "A007", Message = "New event registration open.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N008", AccountId = "A008", Message = "Reminder: Payment due soon.", IsRead = true, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N009", AccountId = "A009", Message = "Your password was changed.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N010", AccountId = "A010", Message = "Admin announcement update.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N011", AccountId = "A011", Message = "New message from support.", IsRead = true, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N012", AccountId = "A012", Message = "Upcoming event invitation.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N013", AccountId = "A013", Message = "New cosplayer contest.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N014", AccountId = "A014", Message = "Loyalty points updated.", IsRead = true, IsSentMail = true, CreatedAt = DateTime.UtcNow },
    new Notification { Id = "N015", AccountId = "A015", Message = "Your subscription expired.", IsRead = false, IsSentMail = true, CreatedAt = DateTime.UtcNow }
);
            #endregion

            #region Cart
            modelBuilder.Entity<Cart>().HasData(
    new Cart { CartId = "C001", AccountId = "A003", TotalPrice = 0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
    new Cart { CartId = "C002", AccountId = "A006", TotalPrice = 0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
    new Cart { CartId = "C003", AccountId = "A011", TotalPrice = 0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
    new Cart { CartId = "C004", AccountId = "A014", TotalPrice = 0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow }
);
            #endregion

            #region Request
            modelBuilder.Entity<Request>().HasData(
    new Request { RequestId = "R001", AccountId = "A001", Name = "Rent Naruto Costume", Description = RequestDescription.RentCostumes.ToString(), Price = 100000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2025, 1, 14), ServiceId = "S003", Location = "HCM", PackageId= "PKG001" },
    new Request { RequestId = "R002", AccountId = "A002", Name = "Rent Cosplayer for Event", Description = RequestDescription.RentCosplayer.ToString(), Price = 500000, Status = RequestStatus.Browsed, StartDate = new DateTime(2025, 2, 5), EndDate = new DateTime(2025, 2, 10), ServiceId = "S002", Location = "ĐN", Reason = "Cosplayer is busy" },
    new Request { RequestId = "R003", AccountId = "A003", Name = "Create Anime Festival", Description = RequestDescription.CreateEvent.ToString(), Price = 2000000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 3, 1), EndDate = new DateTime(2025, 3, 5), ServiceId = "S003", Location = "BD" },
    new Request { RequestId = "R004", AccountId = "A004", Name = "Rent Samurai Armor", Description = RequestDescription.RentCostumes.ToString(), Price = 150000, Status = RequestStatus.Cancel, StartDate = new DateTime(2025, 4, 10), EndDate = new DateTime(2025, 4, 15), ServiceId = "S002", Location = "HN" },
    new Request { RequestId = "R005", AccountId = "A002", Name = "Hire Professional Cosplayer", Description = RequestDescription.RentCosplayer.ToString(), Price = 700000, Status = RequestStatus.Browsed, StartDate = new DateTime(2025, 5, 3), EndDate = new DateTime(2025, 5, 7), ServiceId = "S002",Location = "BT", PackageId = "PKG002" },
    new Request { RequestId = "R006", AccountId = "A006", Name = "Organize Comic Convention", Description = RequestDescription.CreateEvent.ToString(), Price = 5000000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 6, 12), EndDate = new DateTime(2025, 6, 15), ServiceId = "S001", Location = "HCM" },
    new Request { RequestId = "R007", AccountId = "A007", Name = "Rent Victorian Costume", Description = RequestDescription.RentCostumes.ToString(), Price = 120000, Status = RequestStatus.Cancel, StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 7, 5), ServiceId = "S002", Location = "HCM", Reason = "Cosplayer is busy" },
    new Request { RequestId = "R008", AccountId = "A008", Name = "Book Cosplayer for Birthday Party", Description = RequestDescription.RentCosplayer.ToString(), Price = 350000, Status = RequestStatus.Browsed, StartDate = new DateTime(2025, 8, 15), EndDate = new DateTime(2025, 8, 18), ServiceId = "S003", Location = "QN" },
    new Request { RequestId = "R009", AccountId = "A009", Name = "Plan Fantasy Fair", Description = RequestDescription.CreateEvent.ToString(), Price = 3000000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 9, 10), EndDate = new DateTime(2025, 9, 15), ServiceId = "S003", Location = "CM" },
    new Request { RequestId = "R010", AccountId = "A010", Name = "Rent Halloween Costumes", Description = RequestDescription.RentCostumes.ToString(), Price = 200000, Status = RequestStatus.Browsed, StartDate = new DateTime(2025, 10, 25), EndDate = new DateTime(2025, 10, 25), ServiceId = "S001", Location = "LĐ" },
    new Request { RequestId = "R011", AccountId = "A011", Name = "Hire Cosplayer for Wedding", Description = RequestDescription.RentCosplayer.ToString(), Price = 800000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 11, 20), EndDate = new DateTime(2025, 11, 20), ServiceId = "S001", Location = "NT", PackageId = "PKG010" },
    new Request { RequestId = "R012", AccountId = "A012", Name = "Create Sci-Fi Convention", Description = RequestDescription.CreateEvent.ToString(), Price = 4500000, Status = RequestStatus.Cancel, StartDate = new DateTime(2025, 12, 5), EndDate = new DateTime(2025, 12, 10), ServiceId = "S002", Location = "VT" },
    new Request { RequestId = "R013", AccountId = "A013", Name = "Rent Santa Claus Costume", Description = RequestDescription.RentCostumes.ToString(), Price = 130000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 12, 20), EndDate = new DateTime(2025, 12, 25), ServiceId = "S003", Location = "HCM" },
    new Request { RequestId = "R014", AccountId = "A014", Name = "Book Cosplayer for Product Launch", Description = RequestDescription.RentCosplayer.ToString(), Price = 600000, Status = RequestStatus.Browsed, StartDate = new DateTime(2025, 6, 30), EndDate = new DateTime(2025, 7, 2), ServiceId = "S001", Location = "HN" },
    new Request { RequestId = "R015", AccountId = "A015", Name = "Host Christmas Event", Description = RequestDescription.CreateEvent.ToString(), Price = 5500000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 12, 15), EndDate = new DateTime(2025, 12, 15), ServiceId = "S002", Location = "HCM", PackageId = "PKG015" }
);
            #endregion

            #region Task
            modelBuilder.Entity<Task>().HasData(
    new Task { TaskId = "T001", TaskName = "CH001", Location = "Tokyo", Description = "Cosplay as anime characters", IsActive = true, StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(3), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Pending, AccountId = "A001", EventCharacterId = "EC001" },
    new Task { TaskId = "T002", TaskName = "CH002", Location = "Los Angeles", Description = "Join cosplay contest", IsActive = true, StartDate = DateTime.Now.AddDays(4), EndDate = DateTime.Now.AddDays(5), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Assignment, AccountId = "A004", EventCharacterId = "EC002" },
    new Task { TaskId = "T003", TaskName = "CH003", Location = "New York", Description = "Teach costume making", IsActive = true, StartDate = DateTime.Now.AddDays(6), EndDate = DateTime.Now.AddDays(7), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Progressing, AccountId = "A005", EventCharacterId = "EC003" },
    new Task { TaskId = "T004", TaskName = "CH004", Location = "Online", Description = "Host a live event", IsActive = true, StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(1), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Completed, AccountId = "A007", EventCharacterId = "EC004" },
    new Task { TaskId = "T005", TaskName = "CH005", Location = "Paris", Description = "Professional cosplay photoshoot", IsActive = true, StartDate = DateTime.Now.AddDays(8), EndDate = DateTime.Now.AddDays(9), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Pending, AccountId = "A008", EventCharacterId = "EC005" },
    new Task { TaskId = "T006", TaskName = "CH006", Location = "Berlin", Description = "Evaluate contestants", IsActive = true, StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(11), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Assignment, AccountId = "A010", EventCharacterId = "EC006" },
    new Task { TaskId = "T007", TaskName = "CH007", Location = "Seoul", Description = "Walk in parade", IsActive = true, StartDate = DateTime.Now.AddDays(12), EndDate = DateTime.Now.AddDays(13), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Progressing, AccountId = "A012", EventCharacterId = "EC007" },
    new Task { TaskId = "T008", TaskName = "CH008", Location = "London", Description = "Perform on live TV", IsActive = true, StartDate = DateTime.Now.AddDays(14), EndDate = DateTime.Now.AddDays(15), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Completed, AccountId = "A013", EventCharacterId = "EC008" },
    new Task { TaskId = "T009", TaskName = "CH008", Location = "Sydney", Description = "Perform for charity", IsActive = true, StartDate = DateTime.Now.AddDays(16), EndDate = DateTime.Now.AddDays(17), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Cancel, AccountId = "A015", EventCharacterId = "EC009" },
    new Task { TaskId = "T010", TaskName = "CH009", Location = "San Diego", Description = "Talk about cosplay industry", IsActive = true, StartDate = DateTime.Now.AddDays(18), EndDate = DateTime.Now.AddDays(19), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Pending, AccountId = "A005", EventCharacterId = "EC010" },
    new Task { TaskId = "T011", TaskName = "CH010", Location = "Bangkok", Description = "New character shoot", IsActive = true, StartDate = DateTime.Now.AddDays(20), EndDate = DateTime.Now.AddDays(21), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Assignment, AccountId = "A008", EventCharacterId = "EC011" },
    new Task { TaskId = "T012", TaskName = "CH011", Location = "Jakarta", Description = "Host main event", IsActive = true, StartDate = DateTime.Now.AddDays(22), EndDate = DateTime.Now.AddDays(23), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Progressing, AccountId = "A007", EventCharacterId = "EC012" },

    new Task { TaskId = "T013", TaskName = "CH012", Location = "Tokyo", Description = "Contract cosplay event", IsActive = true, StartDate = DateTime.Now.AddDays(24), EndDate = DateTime.Now.AddDays(25), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Completed, AccountId = "A013", ContractCharacterId = "CC0021" },
    new Task { TaskId = "T014", TaskName = "CH013", Location = "New York", Description = "Contract cosplay photoshoot", IsActive = true, StartDate = DateTime.Now.AddDays(26), EndDate = DateTime.Now.AddDays(27), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Completed, AccountId = "A011", ContractCharacterId = "CC0051" },
    new Task { TaskId = "T015", TaskName = "CH014", Location = "Los Angeles", Description = "Contract character performance", IsActive = true, StartDate = DateTime.Now.AddDays(28), EndDate = DateTime.Now.AddDays(29), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Progressing, AccountId = "A012", ContractCharacterId = "CC0081" },
    new Task { TaskId = "T016", TaskName = "CH015", Location = "Seoul", Description = "Contract parade participation", IsActive = true, StartDate = DateTime.Now.AddDays(30), EndDate = DateTime.Now.AddDays(31), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Completed, AccountId = "A013", ContractCharacterId = "CC0101" },
    new Task { TaskId = "T017", TaskName = "CH015", Location = "Paris", Description = "Contract cosplay workshop", IsActive = true, StartDate = DateTime.Now.AddDays(32), EndDate = DateTime.Now.AddDays(33), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Pending, AccountId = "A014", ContractCharacterId = "CC0141" }


);
            #endregion


            #region TicketAccount
            modelBuilder.Entity<TicketAccount>().HasData(
   new TicketAccount { TicketAccountId = "TA001", AccountId = "A003", TicketCode = "TC001", TicketId = 1, Quantity = 2, TotalPrice = 100000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA002", AccountId = "A006", TicketCode = "TC002", TicketId = 2, Quantity = 1, TotalPrice = 40000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA003", AccountId = "A011", TicketCode = "TC003", TicketId = 3, Quantity = 3, TotalPrice = 90000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA004", AccountId = "A014", TicketCode = "TC004", TicketId = 4, Quantity = 2, TotalPrice = 120000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA005", AccountId = "A003", TicketCode = "TC005", TicketId = 5, Quantity = 4, TotalPrice = 180000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA006", AccountId = "A006", TicketCode = "TC006", TicketId = 6, Quantity = 2, TotalPrice = 110000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA007", AccountId = "A011", TicketCode = "TC007", TicketId = 7, Quantity = 1, TotalPrice = 35000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA008", AccountId = "A014", TicketCode = "TC008", TicketId = 8, Quantity = 3, TotalPrice = 150000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA009", AccountId = "A003", TicketCode = "TC009", TicketId = 9, Quantity = 2, TotalPrice = 130000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA010", AccountId = "A006", TicketCode = "TC010", TicketId = 10, Quantity = 1, TotalPrice = 70000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA011", AccountId = "A011", TicketCode = "TC011", TicketId = 11, Quantity = 5, TotalPrice = 125000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA012", AccountId = "A014", TicketCode = "TC012", TicketId = 12, Quantity = 2, TotalPrice = 150000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA013", AccountId = "A003", TicketCode = "TC013", TicketId = 3, Quantity = 3, TotalPrice = 90000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA014", AccountId = "A006", TicketCode = "TC014", TicketId = 5, Quantity = 2, TotalPrice = 90000.0, participantQuantity = 0 },
   new TicketAccount { TicketAccountId = "TA015", AccountId = "A011", TicketCode = "TC015", TicketId = 7, Quantity = 1, TotalPrice = 35000.0, participantQuantity = 0 }
);
            #endregion

            #region ContractCharacter
            modelBuilder.Entity<ContractCharacter>().HasData(
    // ContractId = CT002
    new ContractCharacter { ContractCharacterId = "CC0021", CharacterId = "CH001", ContractId = "CT002", TotalPrice = 150000, CreateDate = new DateTime(2025, 2, 2), Description = "Character 1 for CT002", Quantity = 1},
    new ContractCharacter { ContractCharacterId = "CC0022", CharacterId = "CH002", ContractId = "CT002", TotalPrice = 180000, CreateDate = new DateTime(2025, 2, 2), Description = "Character 2 for CT002", Quantity = 5 },
    new ContractCharacter { ContractCharacterId = "CC0023", CharacterId = "CH003", ContractId = "CT002", TotalPrice = 170000, CreateDate = new DateTime(2025, 2, 2), Description = "Character 3 for CT002", Quantity = 3 },

    // ContractId = CT005
    new ContractCharacter { ContractCharacterId = "CC0051", CharacterId = "CH004", ContractId = "CT005", TotalPrice = 200000, CreateDate = new DateTime(2025, 5, 2), Description = "Character 1 for CT005", Quantity = 2},
    new ContractCharacter { ContractCharacterId = "CC0052", CharacterId = "CH005", ContractId = "CT005", TotalPrice = 250000, CreateDate = new DateTime(2025, 5, 2), Description = "Character 2 for CT005", Quantity = 4},
    new ContractCharacter { ContractCharacterId = "CC0053", CharacterId = "CH006", ContractId = "CT005", TotalPrice = 250000, CreateDate = new DateTime(2025, 5, 2), Description = "Character 3 for CT005", Quantity = 6},

    // ContractId = CT008
    new ContractCharacter { ContractCharacterId = "CC0081", CharacterId = "CH007", ContractId = "CT008", TotalPrice = 120000, CreateDate = new DateTime(2025, 8, 11), Description = "Character 1 for CT008", Quantity = 1, CosplayerId = "A001" },
    new ContractCharacter { ContractCharacterId = "CC0082", CharacterId = "CH008", ContractId = "CT008", TotalPrice = 130000, CreateDate = new DateTime(2025, 8, 11), Description = "Character 2 for CT008", Quantity = 1, CosplayerId = "A008" },
    new ContractCharacter { ContractCharacterId = "CC0083", CharacterId = "CH009", ContractId = "CT008", TotalPrice = 100000, CreateDate = new DateTime(2025, 8, 11), Description = "Character 3 for CT008", Quantity = 1, CosplayerId = "A040" },

    // ContractId = CT010
    new ContractCharacter { ContractCharacterId = "CC0101", CharacterId = "CH010", ContractId = "CT010", TotalPrice = 70000, CreateDate = new DateTime(2025, 10, 21), Description = "Character 1 for CT010", Quantity = 1, CosplayerId = "A040" },
    new ContractCharacter { ContractCharacterId = "CC0102", CharacterId = "CH011", ContractId = "CT010", TotalPrice = 80000, CreateDate = new DateTime(2025, 10, 21), Description = "Character 2 for CT010", Quantity = 1, CosplayerId = "A039" },
    new ContractCharacter { ContractCharacterId = "CC0103", CharacterId = "CH012", ContractId = "CT010", TotalPrice = 50000, CreateDate = new DateTime(2025, 10, 21), Description = "Character 3 for CT010", Quantity = 1, CosplayerId = "A038" },

    // ContractId = CT014
    new ContractCharacter { ContractCharacterId = "CC0141", CharacterId = "CH013", ContractId = "CT014", TotalPrice = 200000, CreateDate = new DateTime(2025, 6, 26), Description = "Character 1 for CT014", Quantity = 1, CosplayerId = "A035" },
    new ContractCharacter { ContractCharacterId = "CC0142", CharacterId = "CH014", ContractId = "CT014", TotalPrice = 250000, CreateDate = new DateTime(2025, 6, 26), Description = "Character 2 for CT014", Quantity = 1, CosplayerId = "A040" },
    new ContractCharacter { ContractCharacterId = "CC0143", CharacterId = "CH015", ContractId = "CT014", TotalPrice = 150000, CreateDate = new DateTime(2025, 6, 26), Description = "Character 3 for CT014", Quantity = 1 , CosplayerId = "A005" }
);
            #endregion

            #region EventCharacter
            modelBuilder.Entity<EventCharacter>().HasData(
new EventCharacter { EventCharacterId = "EC001", EventId = "E001", CharacterId = "CH001", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC002", EventId = "E002", CharacterId = "CH002", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC003", EventId = "E003", CharacterId = "CH003", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC004", EventId = "E004", CharacterId = "CH004", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC005", EventId = "E005", CharacterId = "CH005", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC006", EventId = "E006", CharacterId = "CH006", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC007", EventId = "E007", CharacterId = "CH007", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC008", EventId = "E008", CharacterId = "CH008", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC009", EventId = "E009", CharacterId = "CH009", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC010", EventId = "E010", CharacterId = "CH010", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC011", EventId = "E011", CharacterId = "CH011", CreateDate = DateTime.Now, IsAssign = true },
new EventCharacter { EventCharacterId = "EC012", EventId = "E012", CharacterId = "CH012", CreateDate = DateTime.Now, IsAssign = true }

);
            #endregion


            #region EventActivity
            modelBuilder.Entity<EventActivity>().HasData(
    new EventActivity { EventActivityId = "EA001", EventId = "E001", ActivityId = "ACT001", Description = "Yoga for a fresh start", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new EventActivity { EventActivityId = "EA002", EventId = "E001", ActivityId = "ACT005", Description = "Tech trends in the new year", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new EventActivity { EventActivityId = "EA003", EventId = "E002", ActivityId = "ACT004", Description = "Painting cherry blossoms", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new EventActivity { EventActivityId = "EA004", EventId = "E003", ActivityId = "ACT013", Description = "AI and future coding", CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new EventActivity { EventActivityId = "EA005", EventId = "E004", ActivityId = "ACT009", Description = "Dance battles live", CreateDate = DateTime.UtcNow, CreateBy = "Manager" },

    new EventActivity { EventActivityId = "EA006", EventId = "E005", ActivityId = "ACT003", Description = "Comic-Con live music", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new EventActivity { EventActivityId = "EA007", EventId = "E006", ActivityId = "ACT007", Description = "Anime and book discussions", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new EventActivity { EventActivityId = "EA008", EventId = "E007", ActivityId = "ACT010", Description = "Chess and gaming", CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new EventActivity { EventActivityId = "EA009", EventId = "E008", ActivityId = "ACT011", Description = "Outdoor movie fun", CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new EventActivity { EventActivityId = "EA010", EventId = "E009", ActivityId = "ACT015", Description = "Meditation for cosplayers", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },

    new EventActivity { EventActivityId = "EA011", EventId = "E010", ActivityId = "ACT012", Description = "Science in filmmaking", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new EventActivity { EventActivityId = "EA012", EventId = "E011", ActivityId = "ACT006", Description = "Halloween charity run", CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new EventActivity { EventActivityId = "EA013", EventId = "E012", ActivityId = "ACT014", Description = "Christmas gardening", CreateDate = DateTime.UtcNow, CreateBy = "Admin" },
    new EventActivity { EventActivityId = "EA014", EventId = "E004", ActivityId = "ACT002", Description = "Cooking for music lovers", CreateDate = DateTime.UtcNow, CreateBy = "Manager" },
    new EventActivity { EventActivityId = "EA015", EventId = "E003", ActivityId = "ACT008", Description = "Photography in tech", CreateDate = DateTime.UtcNow, CreateBy = "Manager" }
);
            #endregion



            #region AccountCoupon
            modelBuilder.Entity<AccountCoupon>().HasData(
    new AccountCoupon { AccountCouponId = "AC001", AccountId = "A001", CouponId = "CP001", IsActive = true, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 31) },
    new AccountCoupon { AccountCouponId = "AC002", AccountId = "A002", CouponId = "CP002", IsActive = false, StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2024, 4, 30) },
    new AccountCoupon { AccountCouponId = "AC003", AccountId = "A003", CouponId = "CP003", IsActive = true, StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 31) },
    new AccountCoupon { AccountCouponId = "AC004", AccountId = "A004", CouponId = "CP004", IsActive = true, StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 30) },
    new AccountCoupon { AccountCouponId = "AC005", AccountId = "A005", CouponId = "CP005", IsActive = false, StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 31) },

    new AccountCoupon { AccountCouponId = "AC006", AccountId = "A001", CouponId = "CP006", IsActive = true, StartDate = new DateTime(2024, 8, 1), EndDate = new DateTime(2024, 8, 31) },
    new AccountCoupon { AccountCouponId = "AC007", AccountId = "A002", CouponId = "CP007", IsActive = true, StartDate = new DateTime(2024, 12, 1), EndDate = new DateTime(2024, 12, 25) },
    new AccountCoupon { AccountCouponId = "AC008", AccountId = "A003", CouponId = "CP008", IsActive = false, StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30) },
    new AccountCoupon { AccountCouponId = "AC009", AccountId = "A004", CouponId = "CP009", IsActive = true, StartDate = new DateTime(2024, 6, 15), EndDate = new DateTime(2024, 7, 15) },
    new AccountCoupon { AccountCouponId = "AC010", AccountId = "A005", CouponId = "CP010", IsActive = true, StartDate = new DateTime(2024, 11, 25), EndDate = new DateTime(2024, 11, 30) },

    new AccountCoupon { AccountCouponId = "AC011", AccountId = "A006", CouponId = "CP011", IsActive = false, StartDate = new DateTime(2024, 8, 10), EndDate = new DateTime(2024, 9, 10) },
    new AccountCoupon { AccountCouponId = "AC012", AccountId = "A007", CouponId = "CP012", IsActive = true, StartDate = new DateTime(2024, 10, 1), EndDate = new DateTime(2024, 10, 31) },
    new AccountCoupon { AccountCouponId = "AC013", AccountId = "A008", CouponId = "CP013", IsActive = true, StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 31) },
    new AccountCoupon { AccountCouponId = "AC014", AccountId = "A009", CouponId = "CP014", IsActive = false, StartDate = new DateTime(2024, 11, 26), EndDate = new DateTime(2024, 11, 27) },
    new AccountCoupon { AccountCouponId = "AC015", AccountId = "A010", CouponId = "CP015", IsActive = true, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 12, 31) }
);
            #endregion


            #region Activity
            modelBuilder.Entity<Activity>().HasData(
     new Activity { ActivityId = "ACT001", Name = "Yoga Class", Description = "A relaxing yoga session", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT002", Name = "Cooking Workshop", Description = "Learn to cook delicious meals", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT003", Name = "Music Concert", Description = "Live music performance", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT004", Name = "Art Exhibition", Description = "Showcase of local artists", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT005", Name = "Tech Talk", Description = "Discussion on latest technology trends", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },

     new Activity { ActivityId = "ACT006", Name = "Charity Run", Description = "5K run for a good cause", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT007", Name = "Book Club", Description = "Monthly book discussion", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT008", Name = "Photography Workshop", Description = "Learn photography skills", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT009", Name = "Dance Competition", Description = "Dance battle for all ages", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT010", Name = "Chess Tournament", Description = "Competitive chess matches", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },

     new Activity { ActivityId = "ACT011", Name = "Movie Night", Description = "Outdoor movie screening", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT012", Name = "Science Fair", Description = "Showcase of scientific projects", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT013", Name = "Coding Bootcamp", Description = "Intensive coding workshop", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT014", Name = "Gardening Workshop", Description = "Learn gardening techniques", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow },
     new Activity { ActivityId = "ACT015", Name = "Meditation Session", Description = "Guided meditation practice", CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow }
 );
            #endregion

            #region CartProduct
            modelBuilder.Entity<CartProduct>().HasData(
    // Cart C001
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C001", ProductId = "P001", Price = 30000, Quantity = 2, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C001", ProductId = "P002", Price = 20000, Quantity = 1, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C001", ProductId = "P003", Price = 80000, Quantity = 1, CreatedDate = DateTime.UtcNow },

    // Cart C002
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C002", ProductId = "P004", Price = 100000, Quantity = 1, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C002", ProductId = "P005", Price = 25000, Quantity = 3, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C002", ProductId = "P006", Price = 40000, Quantity = 2, CreatedDate = DateTime.UtcNow },

    // Cart C003
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C003", ProductId = "P007", Price = 15000, Quantity = 5, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C003", ProductId = "P008", Price = 50000, Quantity = 2, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C003", ProductId = "P009", Price = 60000, Quantity = 1, CreatedDate = DateTime.UtcNow },

    // Cart C004
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C004", ProductId = "P010", Price = 120000, Quantity = 1, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C004", ProductId = "P011", Price = 35000, Quantity = 2, CreatedDate = DateTime.UtcNow },
    new CartProduct { CartProductId = Guid.NewGuid().ToString(), CartId = "C004", ProductId = "P012", Price = 45000, Quantity = 1, CreatedDate = DateTime.UtcNow }
);
            #endregion

            #region CharacterImage
            modelBuilder.Entity<CharacterImage>().HasData(
    new CharacterImage { CharacterImageId = "CI001", UrlImage = "https://ae01.alicdn.com/kf/HTB1gQt5aO6guuRkSnb4q6zu4XXaw/Naruto-Cosplay-Costumes-Anime-Naruto-Outfit-For-Man-Show-Suits-Japanese-Cartoon-Costumes-Naruto-Coat-Top.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH001" },
    new CharacterImage { CharacterImageId = "CI002", UrlImage = "https://lzd-img-global.slatic.net/g/ff/kf/Sfedbbf9e61af4bc5a4ce107829ab12ffP.jpg_720x720q80.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH002" },
    new CharacterImage { CharacterImageId = "CI003", UrlImage = "https://tse2.mm.bing.net/th/id/OIP.7wO0lin122XZz8cW6QwMPwHaNK?rs=1&pid=ImgDetMain", CreateDate = DateTime.UtcNow, CharacterId = "CH003" },
    new CharacterImage { CharacterImageId = "CI004", UrlImage = "https://th.bing.com/th/id/R.a547136c5dc32ca575032d919b616c81?rik=QB63jSYlpxVIDg&pid=ImgRaw&r=0", CreateDate = DateTime.UtcNow, CharacterId = "CH004" },
    new CharacterImage { CharacterImageId = "CI005", UrlImage = "https://tse3.mm.bing.net/th/id/OIP.Iv-VMJCvgXjXP3seS54VUQHaIj?rs=1&pid=ImgDetMain", CreateDate = DateTime.UtcNow, CharacterId = "CH005" },
    new CharacterImage { CharacterImageId = "CI006", UrlImage = "https://i.pinimg.com/736x/88/67/c2/8867c200a089728d7e5fc0893c4b768d.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH006" },
    new CharacterImage { CharacterImageId = "CI007", UrlImage = "https://tse1.explicit.bing.net/th/id/OIP.v9qz5NCIL7XhgBUU1rnkLQHaKL?rs=1&pid=ImgDetMain", CreateDate = DateTime.UtcNow, CharacterId = "CH007" },
    new CharacterImage { CharacterImageId = "CI008", UrlImage = "https://cdn.openart.ai/stable_diffusion/43d1f34dddfdcdfefa54b8984be0a96159b200a8_2000x2000.webp", CreateDate = DateTime.UtcNow, CharacterId = "CH008" },
    new CharacterImage { CharacterImageId = "CI009", UrlImage = "https://tse1.mm.bing.net/th/id/OIP.dX8f8uziv7-sVE-MGmiKMwHaHa?rs=1&pid=ImgDetMain", CreateDate = DateTime.UtcNow, CharacterId = "CH009" },
    new CharacterImage { CharacterImageId = "CI010", UrlImage = "https://tse3.mm.bing.net/th/id/OIP.GLTrvuL5642aAYTOFxC0eAHaJQ?rs=1&pid=ImgDetMain", CreateDate = DateTime.UtcNow, CharacterId = "CH010" },
    new CharacterImage { CharacterImageId = "CI011", UrlImage = "https://th.bing.com/th/id/R.1a1aeceee8146ba95dd2a8f69c3f182f?rik=T9YeKcs%2b27tcsg&pid=ImgRaw&r=0", CreateDate = DateTime.UtcNow, CharacterId = "CH011" },
    new CharacterImage { CharacterImageId = "CI012", UrlImage = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/7b60d23e-2e8e-44da-a221-dc39a83c4f3f/der5hqx-ee11482f-b214-4b25-bfee-88dc11a8c4fe.jpg/v1/fill/w_1280,h_1814,q_75,strp/sephiroth__full_body__by_akonyah_der5hqx-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzdiNjBkMjNlLTJlOGUtNDRkYS1hMjIxLWRjMzlhODNjNGYzZlwvZGVyNWhxeC1lZTExNDgyZi1iMjE0LTRiMjUtYmZlZS04OGRjMTFhOGM0ZmUuanBnIiwiaGVpZ2h0IjoiPD0xODE0Iiwid2lkdGgiOiI8PTEyODAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uud2F0ZXJtYXJrIl0sIndtayI6eyJwYXRoIjoiXC93bVwvN2I2MGQyM2UtMmU4ZS00NGRhLWEyMjEtZGMzOWE4M2M0ZjNmXC9ha29ueWFoLTQucG5nIiwib3BhY2l0eSI6OTUsInByb3BvcnRpb25zIjowLjQ1LCJncmF2aXR5IjoiY2VudGVyIn19.e9IstlpQcF1QRaMoUKkr41MQ7pekjWh_iOje74x3coY", CreateDate = DateTime.UtcNow, CharacterId = "CH012" },
    new CharacterImage { CharacterImageId = "CI013", UrlImage = "https://tse1.mm.bing.net/th/id/OIP.uCp4Whd_B4z4Zw8C7wvjxwHaLH?rs=1&pid=ImgDetMain", CreateDate = DateTime.UtcNow, CharacterId = "CH013" },
    new CharacterImage { CharacterImageId = "CI014", UrlImage = "https://tse3.mm.bing.net/th/id/OIP.3ADDr3lt8PYxM6KP10OtwwAAAA?rs=1&pid=ImgDetMain", CreateDate = DateTime.UtcNow, CharacterId = "CH014" },
    new CharacterImage { CharacterImageId = "CI015", UrlImage = "https://thatparkplace.com/wp-content/uploads/2023/04/kirby-e1681312791814.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH015" }
);
            #endregion


            #region EventImage
            modelBuilder.Entity<EventImage>().HasData(
    new EventImage { ImageId = "EI001", ImageUrl = "https://cdn-i.vtcnews.vn/resize/th/upload/2020/01/20/1-08485735.jpg", CreateDate = DateTime.UtcNow, EventId = "E001", IsAvatar = true},
    new EventImage { ImageId = "EI002", ImageUrl = "https://file.hstatic.net/200000833669/article/1_d82dc925795b42c29f8bd09558e1e0f9.png", CreateDate = DateTime.UtcNow, EventId = "E001", IsAvatar = false },
    new EventImage { ImageId = "EI003", ImageUrl = "https://mcdn.coolmate.me/image/May2022/top-le-hoi-cosplay-festival-noi-tieng_735.jpg", CreateDate = DateTime.UtcNow, EventId = "E001", IsAvatar = false },
    new EventImage { ImageId = "EI004", ImageUrl = "https://i.vietgiaitri.com/2011/7/0/chien-binh-king-of-fighters-giuong-oai-o-le-hoi-cosplay-26cc13.jpg", CreateDate = DateTime.UtcNow, EventId = "E001", IsAvatar = false },


    new EventImage { ImageId = "EI005", ImageUrl = "https://media.wnyc.org/i/1500/996/l/80/1/BBG_SakuraMatsuri_CosplayFashions_Ratliff.jpg", CreateDate = DateTime.UtcNow, EventId = "E002", IsAvatar = true },
    new EventImage { ImageId = "EI006", ImageUrl = "https://www.vice.com/wp-content/uploads/sites/2/2024/07/photos-of-cherry-blossoms-and-cosplay-costumes-at-a-kawaii-festival-592-1462476637.jpg", CreateDate = DateTime.UtcNow, EventId = "E002", IsAvatar = false },
    new EventImage { ImageId = "EI007", ImageUrl = "https://www.vice.com/wp-content/uploads/sites/2/2016/05/photos-of-cherry-blossoms-and-cosplay-costumes-at-a-kawaii-festival-1462476813.jpg", CreateDate = DateTime.UtcNow, EventId = "E002", IsAvatar = false },
    new EventImage { ImageId = "EI008", ImageUrl = "https://s.hdnux.com/photos/01/37/11/15/24941427/3/ratio3x2_960.jpg", CreateDate = DateTime.UtcNow, EventId = "E002", IsAvatar = false },


    new EventImage { ImageId = "EI009", ImageUrl = "https://capetownguy.co.za/wp-content/uploads/2023/02/Comic-Con-Cape-Town-2023-Cosplay.png", CreateDate = DateTime.UtcNow, EventId = "E003",IsAvatar = true},
    new EventImage { ImageId = "EI010", ImageUrl = "https://i.pinimg.com/736x/63/77/6f/63776facb73bf3f2ed8530a94cf592ca.jpg", CreateDate = DateTime.UtcNow, EventId = "E003", IsAvatar = false },
    new EventImage { ImageId = "EI011", ImageUrl = "https://i.pinimg.com/736x/2f/94/3c/2f943c92510f7ad55e221289a9534a48.jpg", CreateDate = DateTime.UtcNow, EventId = "E003", IsAvatar = false },
    new EventImage { ImageId = "EI012", ImageUrl = "https://i.pinimg.com/736x/5a/25/ce/5a25ce753b5fbcf92653809ca3325adb.jpg", CreateDate = DateTime.UtcNow, EventId = "E003", IsAvatar = false },

    new EventImage { ImageId = "EI013", ImageUrl = "https://i.pinimg.com/736x/82/2e/55/822e554280de23126220adeeaf6a7631.jpg", CreateDate = DateTime.UtcNow, EventId = "E004", IsAvatar = true },
    new EventImage { ImageId = "EI014", ImageUrl = "https://i.pinimg.com/736x/0a/73/7b/0a737b3f0f73fcf845a1311f73077bdf.jpg", CreateDate = DateTime.UtcNow, EventId = "E004", IsAvatar = false },
    new EventImage { ImageId = "EI015", ImageUrl = "https://i.pinimg.com/736x/c1/e1/61/c1e161a1e6b1f27ab79100674ce715c2.jpg", CreateDate = DateTime.UtcNow, EventId = "E004", IsAvatar = false },
    new EventImage { ImageId = "EI016", ImageUrl = "https://i.pinimg.com/736x/ff/29/f7/ff29f7e84980b8f649a0b655013e6afa.jpg", CreateDate = DateTime.UtcNow, EventId = "E004", IsAvatar = false },

    new EventImage { ImageId = "EI017", ImageUrl = "https://i.pinimg.com/736x/64/91/68/649168c18bd7d4665c4bfe032a2e3cb1.jpg", CreateDate = DateTime.UtcNow, EventId = "E005", IsAvatar = true },
    new EventImage { ImageId = "EI018", ImageUrl = "https://i.pinimg.com/736x/c3/ee/73/c3ee73dc1432a9aefe4bc23ca9205b49.jpg", CreateDate = DateTime.UtcNow, EventId = "E005", IsAvatar = false },
    new EventImage { ImageId = "EI019", ImageUrl = "https://i.pinimg.com/736x/f4/2f/f0/f42ff0521385be118d2ed5ca19fa7416.jpg", CreateDate = DateTime.UtcNow, EventId = "E005", IsAvatar = false },
    new EventImage { ImageId = "EI020", ImageUrl = "https://i.pinimg.com/736x/59/80/d6/5980d6150aff50f385f509c75d9b9cb5.jpg", CreateDate = DateTime.UtcNow, EventId = "E005", IsAvatar = false },

    new EventImage { ImageId = "EI021", ImageUrl = "https://i.pinimg.com/736x/1f/b6/b4/1fb6b49b7e7b1faa3743a74d631f8ee0.jpg", CreateDate = DateTime.UtcNow, EventId = "E006", IsAvatar = true },
    new EventImage { ImageId = "EI022", ImageUrl = "https://i.pinimg.com/736x/6f/2a/1c/6f2a1c31e1caab9245f4ee67bbff1a8a.jpg", CreateDate = DateTime.UtcNow, EventId = "E006", IsAvatar = false },
    new EventImage { ImageId = "EI023", ImageUrl = "https://i.pinimg.com/736x/5e/2a/37/5e2a375a7bc3bc8f53a3bda093685afc.jpg", CreateDate = DateTime.UtcNow, EventId = "E006", IsAvatar = false },
    new EventImage { ImageId = "EI024", ImageUrl = "https://i.pinimg.com/736x/1e/23/fc/1e23fcbdbe84a87de180f1214ab970df.jpg", CreateDate = DateTime.UtcNow, EventId = "E006", IsAvatar = false },

    new EventImage { ImageId = "EI025", ImageUrl = "https://i.pinimg.com/736x/e0/52/52/e052529f9d0df8ca08e0bfd0d609ff33.jpg", CreateDate = DateTime.UtcNow, EventId = "E007", IsAvatar = true },
    new EventImage { ImageId = "EI026", ImageUrl = "https://i.pinimg.com/736x/79/b5/6f/79b56f067960f2f8780c87d6d1be5f69.jpg", CreateDate = DateTime.UtcNow, EventId = "E007", IsAvatar = false },
    new EventImage { ImageId = "EI027", ImageUrl = "https://i.pinimg.com/736x/89/a1/8f/89a18f6bfb85722c64bcfa4b687c4502.jpg", CreateDate = DateTime.UtcNow, EventId = "E007", IsAvatar = false },
    new EventImage { ImageId = "EI028", ImageUrl = "https://i.pinimg.com/736x/7c/57/da/7c57dac7ca005402b824f56c44e4ac7b.jpg", CreateDate = DateTime.UtcNow, EventId = "E007", IsAvatar = false },

    new EventImage { ImageId = "EI029", ImageUrl = "https://i.pinimg.com/736x/f3/4d/ca/f34dcaadcedb9848b6ac6419f65c3b9d.jpg", CreateDate = DateTime.UtcNow, EventId = "E008", IsAvatar = true },
    new EventImage { ImageId = "EI030", ImageUrl = "https://i.pinimg.com/736x/98/a0/ed/98a0ed924ea799cd3612a3bb5e3aee61.jpg", CreateDate = DateTime.UtcNow, EventId = "E008", IsAvatar = false },
    new EventImage { ImageId = "EI031", ImageUrl = "https://i.pinimg.com/736x/73/1c/f4/731cf48f181b3bf7fc71d80baa3656f1.jpg", CreateDate = DateTime.UtcNow, EventId = "E008", IsAvatar = false },
    new EventImage { ImageId = "EI032", ImageUrl = "https://i.pinimg.com/736x/a3/50/52/a35052bc18722657ab0db440e4f8a8e5.jpg", CreateDate = DateTime.UtcNow, EventId = "E008", IsAvatar = false },

    new EventImage { ImageId = "EI033", ImageUrl = "https://i.pinimg.com/736x/7f/bd/72/7fbd72289fecd220453a16d062273ee5.jpg", CreateDate = DateTime.UtcNow, EventId = "E009", IsAvatar = true },
    new EventImage { ImageId = "EI034", ImageUrl = "https://i.pinimg.com/736x/34/d1/4a/34d14a51253bb4e9ff3ae3134ec76b68.jpg", CreateDate = DateTime.UtcNow, EventId = "E009", IsAvatar = false },
    new EventImage { ImageId = "EI035", ImageUrl = "https://i.pinimg.com/736x/b0/34/df/b034df343ed32c11f2d62e07420e1998.jpg", CreateDate = DateTime.UtcNow, EventId = "E009", IsAvatar = false },
    new EventImage { ImageId = "EI036", ImageUrl = "https://i.pinimg.com/736x/ec/0e/36/ec0e363bf99880faa216b6152819ee83.jpg", CreateDate = DateTime.UtcNow, EventId = "E009", IsAvatar = false },

    new EventImage { ImageId = "EI037", ImageUrl = "https://i.pinimg.com/736x/a2/7b/b5/a27bb57604f07d1346d91d5fbd15f4a3.jpg", CreateDate = DateTime.UtcNow, EventId = "E010", IsAvatar = true },
    new EventImage { ImageId = "EI038", ImageUrl = "https://i.pinimg.com/736x/6d/be/09/6dbe0978d8e5cc1c3a471588b38249aa.jpg", CreateDate = DateTime.UtcNow, EventId = "E010", IsAvatar = false },
    new EventImage { ImageId = "EI039", ImageUrl = "https://i.pinimg.com/736x/dd/66/1b/dd661b664fe68d74c187f35a5246e36a.jpg", CreateDate = DateTime.UtcNow, EventId = "E010", IsAvatar = false },
    new EventImage { ImageId = "EI040", ImageUrl = "https://i.pinimg.com/736x/8f/30/f3/8f30f3582ba3ad998c74ee5e771eb364.jpg", CreateDate = DateTime.UtcNow, EventId = "E010", IsAvatar = false },

    new EventImage { ImageId = "EI041", ImageUrl = "https://i.pinimg.com/736x/20/3e/88/203e883cc5ac82f26e2bf8a1d4eefe36.jpg", CreateDate = DateTime.UtcNow, EventId = "E011", IsAvatar = true },
    new EventImage { ImageId = "EI042", ImageUrl = "https://i.pinimg.com/736x/60/fc/fd/60fcfd76e8b418743b04d4347459cb37.jpg", CreateDate = DateTime.UtcNow, EventId = "E011", IsAvatar = false },
    new EventImage { ImageId = "EI043", ImageUrl = "https://i.pinimg.com/736x/e2/48/6d/e2486ddc382f7b87edfb422e46de3aca.jpg", CreateDate = DateTime.UtcNow, EventId = "E011", IsAvatar = false },
    new EventImage { ImageId = "EI044", ImageUrl = "https://i.pinimg.com/736x/ce/2a/c5/ce2ac53f28e0dccf609b835418cdff89.jpg", CreateDate = DateTime.UtcNow, EventId = "E011", IsAvatar = false },

    new EventImage { ImageId = "EI045", ImageUrl = "https://i.pinimg.com/736x/5b/17/a0/5b17a0593a7e9b7d69d9b6cceef06897.jpg", CreateDate = DateTime.UtcNow, EventId = "E012", IsAvatar = true },
    new EventImage { ImageId = "EI046", ImageUrl = "https://i.pinimg.com/736x/09/68/8b/09688bd8893f39a83e0e9e6b3073f2de.jpg", CreateDate = DateTime.UtcNow, EventId = "E012", IsAvatar = false },
    new EventImage { ImageId = "EI047", ImageUrl = "https://i.pinimg.com/736x/73/9f/ad/739fad57ea629dc30f5bfc5a2ae0052b.jpg", CreateDate = DateTime.UtcNow, EventId = "E012", IsAvatar = false },
    new EventImage { ImageId = "EI048", ImageUrl = "https://i.pinimg.com/736x/d1/a9/d5/d1a9d54239ffab7c036f7b5b6853f204.jpg", CreateDate = DateTime.UtcNow, EventId = "E012", IsAvatar = false }

);
            #endregion

            #region OrderProduct
            modelBuilder.Entity<OrderProduct>().HasData(
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O001", ProductId = "P001", Price = 30000, Quantity = 3, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O001", ProductId = "P002", Price = 20000, Quantity = 5, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O002", ProductId = "P003", Price = 80000, Quantity = 1, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O002", ProductId = "P004", Price = 100000, Quantity = 1, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O003", ProductId = "P005", Price = 25000, Quantity = 2, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O003", ProductId = "P006", Price = 40000, Quantity = 3, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O004", ProductId = "P007", Price = 15000, Quantity = 4, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O004", ProductId = "P008", Price = 50000, Quantity = 2, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O005", ProductId = "P009", Price = 60000, Quantity = 1, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O005", ProductId = "P010", Price = 120000, Quantity = 1, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O006", ProductId = "P011", Price = 35000, Quantity = 2, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O006", ProductId = "P012", Price = 45000, Quantity = 3, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O007", ProductId = "P013", Price = 18000, Quantity = 5, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O007", ProductId = "P014", Price = 90000, Quantity = 2, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O008", ProductId = "P015", Price = 22000, Quantity = 4, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O008", ProductId = "P001", Price = 30000, Quantity = 1, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O009", ProductId = "P002", Price = 20000, Quantity = 6, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O009", ProductId = "P003", Price = 80000, Quantity = 2, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O010", ProductId = "P004", Price = 100000, Quantity = 1, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O010", ProductId = "P005", Price = 25000, Quantity = 3, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O011", ProductId = "P006", Price = 40000, Quantity = 2, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O011", ProductId = "P007", Price = 15000, Quantity = 4, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O012", ProductId = "P008", Price = 50000, Quantity = 2, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O012", ProductId = "P009", Price = 60000, Quantity = 1, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O013", ProductId = "P010", Price = 120000, Quantity = 1, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O013", ProductId = "P011", Price = 35000, Quantity = 2, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O014", ProductId = "P012", Price = 45000, Quantity = 3, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O014", ProductId = "P013", Price = 18000, Quantity = 5, CreateDate = DateTime.UtcNow },

new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O015", ProductId = "P014", Price = 90000, Quantity = 2, CreateDate = DateTime.UtcNow },
new OrderProduct { OrderProductId = Guid.NewGuid().ToString(), OrderId = "O015", ProductId = "P015", Price = 22000, Quantity = 4, CreateDate = DateTime.UtcNow }
);
            #endregion

            #region Package
            modelBuilder.Entity<Package>().HasData(
    new Package { PackageId = "PKG001", PackageName = "Basic Character Rental", Description = "Rent a single character for an event", Price = 100000.0 },
    new Package { PackageId = "PKG002", PackageName = "Deluxe Character Rental", Description = "Rent multiple characters with costumes", Price = 250000.0 },
    new Package { PackageId = "PKG003", PackageName = "Ultimate Character Rental", Description = "Full-day character rental service", Price = 500000.0 },

    new Package { PackageId = "PKG004", PackageName = "Standard Cosplay Performance", Description = "Basic cosplay performance at an event", Price = 150000.0 },
    new Package { PackageId = "PKG005", PackageName = "Premium Cosplay Performance", Description = "Advanced performance with choreography", Price = 300000.0 },
    new Package { PackageId = "PKG006", PackageName = "VIP Cosplay Performance", Description = "Exclusive show with audience interaction", Price = 500000.0 },

    new Package { PackageId = "PKG007", PackageName = "Mini Photography Session", Description = "30-minute photoshoot with cosplayers", Price = 80000.0 },
    new Package { PackageId = "PKG008", PackageName = "Standard Photography Session", Description = "1-hour professional photoshoot", Price = 150000.0 },
    new Package { PackageId = "PKG009", PackageName = "Full Photography Package", Description = "Complete photoshoot with editing", Price = 300000.0 },

    new Package { PackageId = "PKG010", PackageName = "Basic Merchandise Pack", Description = "Includes exclusive cosplay merchandise", Price = 50000.0 },
    new Package { PackageId = "PKG011", PackageName = "Deluxe Merchandise Pack", Description = "Premium cosplay collectibles", Price = 150000.0 },
    new Package { PackageId = "PKG012", PackageName = "Ultimate Merchandise Pack", Description = "Limited edition cosplay items", Price = 300000.0 },

    new Package { PackageId = "PKG013", PackageName = "Cosplay Basics Workshop", Description = "Beginner-friendly cosplay training", Price = 100000.0 },
    new Package { PackageId = "PKG014", PackageName = "Advanced Cosplay Training", Description = "In-depth cosplay and makeup course", Price = 2500000 },
    new Package { PackageId = "PKG015", PackageName = "Master Cosplay Workshop", Description = "Professional-level training for cosplayers", Price = 500000.0 }
);
            #endregion

            #region ProductImage
            modelBuilder.Entity<ProductImage>().HasData(
    new ProductImage { ProductImageId = "IMG001", ProductId = "P001", UrlImage = "https://i.pinimg.com/736x/5b/d5/22/5bd522817214385b4673af094a9ddb25.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG002", ProductId = "P001", UrlImage = "https://i.pinimg.com/736x/6e/22/65/6e22657c7a91292b46fb727671e2e3f2.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG003", ProductId = "P001", UrlImage = "https://i.pinimg.com/736x/7d/c0/97/7dc09783c0757b5761a327e0f1908b8a.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG004", ProductId = "P001", UrlImage = "https://i.pinimg.com/736x/c3/9b/87/c39b87b5994c805893e36939ea71f4d8.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },


    new ProductImage { ProductImageId = "IMG005", ProductId = "P002", UrlImage = "https://i.pinimg.com/736x/c2/83/bd/c283bd289da144479eba982d37a21023.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG006", ProductId = "P002", UrlImage = "https://i.pinimg.com/736x/da/6e/9c/da6e9c955676f70ee5ea549866f68b8e.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG007", ProductId = "P002", UrlImage = "https://i.pinimg.com/736x/17/33/0a/17330a9c865ea4116ea4f4531bbaaaa3.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG008", ProductId = "P002", UrlImage = "https://i.pinimg.com/736x/87/5f/2c/875f2c6e0ddc5fa194c072be3f0a620f.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG009", ProductId = "P003", UrlImage = "https://i.pinimg.com/736x/6d/e7/eb/6de7eb00ca29991cc8c01f24ef66ee01.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG0010", ProductId = "P003", UrlImage = "https://i.pinimg.com/736x/d4/ce/c3/d4cec31b0cadfc10a6a10fa560260b65.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG011", ProductId = "P003", UrlImage = "https://i.pinimg.com/736x/78/97/12/78971296728a3b39b8de627a6993e110.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG012", ProductId = "P003", UrlImage = "https://i.pinimg.com/736x/c7/77/37/c77737d95e245f66d50cd681705d6d94.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG013", ProductId = "P004", UrlImage = "https://i.pinimg.com/736x/6d/ff/62/6dff62b556d097a31cacb345051b6a51.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG014", ProductId = "P004", UrlImage = "https://i.pinimg.com/736x/cf/1c/63/cf1c63218c1c3b6b0c3133c9d18eeb65.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG015", ProductId = "P004", UrlImage = "https://i.pinimg.com/736x/fd/62/37/fd62370a4e5c8487aa7375a94b1a1cd4.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG016", ProductId = "P004", UrlImage = "https://i.pinimg.com/736x/d9/f4/65/d9f4652af418f7f08e9c0dd20cd48e38.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG017", ProductId = "P005", UrlImage = "https://i.pinimg.com/736x/0f/a9/75/0fa9756da968f296b0652351c88359bb.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG018", ProductId = "P005", UrlImage = "https://i.pinimg.com/736x/a1/89/af/a189af181a4b9368d3a07281077446e5.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG019", ProductId = "P005", UrlImage = "https://i.pinimg.com/736x/59/98/2d/59982d1537b336ab322e6d4e0177cf97.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG020", ProductId = "P005", UrlImage = "https://i.pinimg.com/736x/2c/65/70/2c65702a200aec274b0ada18203b2711.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },


    new ProductImage { ProductImageId = "IMG021", ProductId = "P006", UrlImage = "https://i.pinimg.com/736x/b0/39/73/b039737d55a68818f0ac547fdbaf7815.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG022", ProductId = "P006", UrlImage = "https://i.pinimg.com/736x/a3/31/81/a331810d4d85ae1fa1df5fe83b53b74c.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG023", ProductId = "P006", UrlImage = "https://i.pinimg.com/736x/13/1e/f5/131ef5b06ee95d29011cb76aff94ef63.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG024", ProductId = "P006", UrlImage = "https://i.pinimg.com/736x/16/49/09/164909996c0e0c6dc1d68e278efbc04c.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG025", ProductId = "P007", UrlImage = "https://i.pinimg.com/736x/f6/b4/2b/f6b42bd8c809edc47c8095776c22a283.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG026", ProductId = "P007", UrlImage = "https://i.pinimg.com/736x/db/f9/d9/dbf9d9ed33a32f4c71f68f9c1b578104.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG027", ProductId = "P007", UrlImage = "https://i.pinimg.com/736x/ca/70/a3/ca70a3442377fad4cc2cd1be7648dcba.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG028", ProductId = "P007", UrlImage = "https://i.pinimg.com/736x/1d/34/a9/1d34a9e9bc035715cfd19023287ea85f.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG029", ProductId = "P008", UrlImage = "https://i.pinimg.com/736x/b1/da/b9/b1dab9d33e6d035bdde006a105eeadef.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG030", ProductId = "P008", UrlImage = "https://i.pinimg.com/736x/62/ac/61/62ac610d8bc2584d633d1814fb6b18b7.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG031", ProductId = "P008", UrlImage = "https://i.pinimg.com/736x/75/26/76/752676ee949f782d4cadc0d999195ce6.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG032", ProductId = "P008", UrlImage = "https://i.pinimg.com/736x/01/1d/61/011d614a9a40efeb72f96008ed501e24.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG033", ProductId = "P009", UrlImage = "https://i.pinimg.com/736x/65/d7/2e/65d72ed8d39d3b65d1c13e621ad12dff.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG034", ProductId = "P009", UrlImage = "https://i.pinimg.com/736x/9e/9a/7e/9e9a7eb75a0f0f438cdaa417d9ed598d.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG035", ProductId = "P009", UrlImage = "https://i.pinimg.com/736x/fa/c1/6d/fac16d229965d9e35ad9e15d7f8737bc.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG036", ProductId = "P009", UrlImage = "https://i.pinimg.com/736x/41/64/bc/4164bcd05287c90a6ba3452f3c0620dd.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG037", ProductId = "P010", UrlImage = "https://i.pinimg.com/736x/76/b5/f4/76b5f4bce572053343da266875956ee7.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG038", ProductId = "P010", UrlImage = "https://i.pinimg.com/736x/6e/80/32/6e8032f27f8eadd8be17bf84f0d3eb1d.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG039", ProductId = "P010", UrlImage = "https://i.pinimg.com/736x/ad/97/ed/ad97ed1142ab1af8a4f2aa72bc9929df.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG040", ProductId = "P010", UrlImage = "https://i.pinimg.com/736x/29/39/80/293980992371bec074c437a122cf50a6.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG041", ProductId = "P011", UrlImage = "https://i.pinimg.com/736x/c2/78/46/c2784664ee92b7b68d13636a1bb225ba.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG042", ProductId = "P011", UrlImage = "https://i.pinimg.com/736x/7b/79/8b/7b798b0b6f554f39fc3c627896d10505.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG043", ProductId = "P011", UrlImage = "https://i.pinimg.com/736x/48/a2/39/48a23998808e6bc0cebedda709b1bc09.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG044", ProductId = "P011", UrlImage = "https://i.pinimg.com/736x/82/af/d0/82afd0193f6db6964ed98f70377907aa.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG045", ProductId = "P012", UrlImage = "https://i.pinimg.com/736x/75/5b/05/755b05d7e05e3fddf7ce40087954c291.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG046", ProductId = "P012", UrlImage = "https://i.pinimg.com/736x/c0/00/22/c000227c9f4552613b74e05abb01ff39.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG047", ProductId = "P012", UrlImage = "https://i.pinimg.com/736x/1f/46/00/1f4600b358bd2c80841a8de451c8d9e8.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG048", ProductId = "P012", UrlImage = "https://i.pinimg.com/736x/3d/82/2f/3d822ffe72bc0e042e05d880cff43b80.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG049", ProductId = "P013", UrlImage = "https://i.pinimg.com/736x/53/aa/1d/53aa1d016627f6aa7a93dd5ac0eaa6d6.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG050", ProductId = "P013", UrlImage = "https://i.pinimg.com/736x/b6/f5/4d/b6f54d32184f0180a19ede274b2ef3e8.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG051", ProductId = "P013", UrlImage = "https://i.pinimg.com/736x/4d/3c/92/4d3c92588e4300ff2f078018f12932a6.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG052", ProductId = "P013", UrlImage = "https://i.pinimg.com/736x/bb/d5/38/bbd53811a73fdeee8a1beb431ad98dec.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG053", ProductId = "P014", UrlImage = "https://i.pinimg.com/736x/01/7e/88/017e8893693250c62ee4dc8a059fc28f.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG054", ProductId = "P014", UrlImage = "https://i.pinimg.com/736x/bf/f9/8c/bff98c45138233055df0518b98ba1c8a.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG055", ProductId = "P014", UrlImage = "https://i.pinimg.com/736x/62/c1/6a/62c16adfe9d21528e4fbda326c7f9c4e.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG056", ProductId = "P014", UrlImage = "https://i.pinimg.com/736x/41/dc/84/41dc846bb27211bf1ee05868b3d9d913.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },

    new ProductImage { ProductImageId = "IMG057", ProductId = "P015", UrlImage = "https://i.pinimg.com/736x/2b/fc/86/2bfc86cdf9e672dd654eccc1b39e2aa2.jpg", CreateDate = DateTime.UtcNow, IsAvatar = true },
    new ProductImage { ProductImageId = "IMG058", ProductId = "P015", UrlImage = "https://i.pinimg.com/736x/b4/9a/fb/b49afbd899c56e9ea9cd4b7b157766e5.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG059", ProductId = "P015", UrlImage = "https://i.pinimg.com/736x/d0/6c/1b/d06c1b7556183644da554ba5c9bafddc.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false },
    new ProductImage { ProductImageId = "IMG060", ProductId = "P015", UrlImage = "https://i.pinimg.com/736x/33/1d/1b/331d1bbe075950dce9c99b6736fba3ae.jpg", CreateDate = DateTime.UtcNow, IsAvatar = false }
);
            #endregion

            #region RequestCharacter
            modelBuilder.Entity<RequestCharacter>().HasData(
    new RequestCharacter { RequestCharacterId = "RC01", RequestId = "R001", CharacterId = "CH001", TotalPrice = 50000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH001", CosplayerId = "A025", Quantity = 1},
    new RequestCharacter { RequestCharacterId = "RC02", RequestId = "R002", CharacterId = "CH002", TotalPrice = 60000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH002", CosplayerId = "A026", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC03", RequestId = "R003", CharacterId = "CH003", TotalPrice = 70000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH003", CosplayerId = "A027", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC04", RequestId = "R004", CharacterId = "CH004", TotalPrice = 80000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH004", CosplayerId = "A028", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC05", RequestId = "R005", CharacterId = "CH005", TotalPrice = 90000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH005", CosplayerId = "A029", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC06", RequestId = "R006", CharacterId = "CH006", TotalPrice = 100000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH006", Quantity = 5 },
    new RequestCharacter { RequestCharacterId = "RC07", RequestId = "R007", CharacterId = "CH007", TotalPrice = 110000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH007", CosplayerId = "A031", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC08", RequestId = "R008", CharacterId = "CH008", TotalPrice = 120000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH008", Quantity = 7},
    new RequestCharacter { RequestCharacterId = "RC09", RequestId = "R009", CharacterId = "CH009", TotalPrice = 130000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH009", CosplayerId = "A033", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC10", RequestId = "R010", CharacterId = "CH010", TotalPrice = 140000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH010", Quantity = 9},
    new RequestCharacter { RequestCharacterId = "RC11", RequestId = "R011", CharacterId = "CH011", TotalPrice = 150000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH011", CosplayerId = "A035", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC12", RequestId = "R012", CharacterId = "CH012", TotalPrice = 160000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH012", CosplayerId = "A036", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC13", RequestId = "R013", CharacterId = "CH013", TotalPrice = 170000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH013", Quantity = 10 },
    new RequestCharacter { RequestCharacterId = "RC14", RequestId = "R014", CharacterId = "CH014", TotalPrice = 180000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH014", CosplayerId = "A038", Quantity = 1 },
    new RequestCharacter { RequestCharacterId = "RC15", RequestId = "R015", CharacterId = "CH015", TotalPrice = 190000.0, CreateDate = DateTime.UtcNow, UpdateDate = DateTime.UtcNow, Description = "Yêu cầu cosplay nhân vật CH015", CosplayerId = "A039", Quantity = 1 }
);
            #endregion

            #region Payment
            modelBuilder.Entity<Payment>().HasData(
    new Payment { PaymentId = "P001", Type = "Online", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.BuyTicket, Amount = 250000.0, TransactionId = "TXN001", CreatAt = new DateTime(2025, 3, 2), TicketAccountId = "TA001", AccountCouponID = "AC001" },
    new Payment { PaymentId = "P002", Type = "Online", Status = PaymentStatus.Pending, Purpose = PaymentPurpose.BuyTicket, Amount = 150000.5, TransactionId = "TXN002", CreatAt = new DateTime(2025, 3, 6), TicketAccountId = "TA002" },
    new Payment { PaymentId = "P003", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.BuyTicket, Amount = 90000.0, TransactionId = "TXN003", CreatAt = new DateTime(2025, 3, 11), TicketAccountId = "TA003" },
    new Payment { PaymentId = "P004", Type = "Card", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.BuyTicket, Amount = 400000.0, TransactionId = "TXN004", CreatAt = new DateTime(2025, 3, 13), TicketAccountId = "TA004", AccountCouponID = "AC012" },
    new Payment { PaymentId = "P005", Type = "Online", Status = PaymentStatus.Cancel, Purpose = PaymentPurpose.BuyTicket, Amount = 175000.0, TransactionId = "TXN005", CreatAt = new DateTime(2025, 3, 16), TicketAccountId = "TA005" },

    new Payment { PaymentId = "P006", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.Order, Amount = 225000.0, TransactionId = "TXN006", CreatAt = new DateTime(2025, 3, 19), OrderId = "O006", AccountCouponID = "AC003" },
    new Payment { PaymentId = "P007", Type = "Online", Status = PaymentStatus.Pending, Purpose = PaymentPurpose.Order, Amount = 350000.0, TransactionId = "TXN007", CreatAt = new DateTime(2025, 3, 21), OrderId = "O007" },
    new Payment { PaymentId = "P008", Type = "Card", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.Order, Amount = 150000.0, TransactionId = "TXN008", CreatAt = new DateTime(2025, 3, 23), OrderId = "O008" },
    new Payment { PaymentId = "P009", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.Order, Amount = 500000.0, TransactionId = "TXN009", CreatAt = new DateTime(2025, 3, 26), OrderId = "O009" },
    new Payment { PaymentId = "P010", Type = "Online", Status = PaymentStatus.Cancel, Purpose = PaymentPurpose.Order, Amount = 125000.0, TransactionId = "TXN010", CreatAt = new DateTime(2025, 3, 29), OrderId = "O010", AccountCouponID = "AC004" },

    new Payment { PaymentId = "P011", Type = "Online", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.ContractDeposit, Amount = 325000.0, TransactionId = "TXN011", CreatAt = new DateTime(2025, 3, 31), ContractId = "CT002" },
    new Payment { PaymentId = "P012", Type = "Card", Status = PaymentStatus.Pending, Purpose = PaymentPurpose.ContractDeposit, Amount = 410000.0, TransactionId = "TXN012", CreatAt = new DateTime(2025, 4, 3), ContractId = "CT005" },
    new Payment { PaymentId = "P013", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.contractSettlement, Amount = 90000.0, TransactionId = "TXN013", CreatAt = new DateTime(2025, 4, 6), ContractId = "CT008" },
    new Payment { PaymentId = "P014", Type = "Online", Status = PaymentStatus.Cancel, Purpose = PaymentPurpose.contractSettlement, Amount = 350000.0, TransactionId = "TXN014", CreatAt = new DateTime(2025, 4, 8), ContractId = "CT010" },
    new Payment { PaymentId = "P015", Type = "Card", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.contractSettlement, Amount = 200000.0, TransactionId = "TXN015", CreatAt = new DateTime(2025, 4, 11), ContractId = "CT002" }
);
            #endregion

            #region RequestDate
            modelBuilder.Entity<RequestDate>().HasData(
    new RequestDate
    {
        RequestDateId = "RD01",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-10 08:30:00"),
        EndDate = DateTime.Parse("2025-01-10 16:30:00"), 
    },
    new RequestDate
    {
        RequestDateId = "RD02",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-11 08:30:00"),
        EndDate = DateTime.Parse("2025-01-11 14:30:00"),
    }, new RequestDate
    {
        RequestDateId = "RD03",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-12 08:30:00"),
        EndDate = DateTime.Parse("2025-01-12 14:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD04",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-13 08:30:00"),
        EndDate = DateTime.Parse("2025-01-13 14:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD05",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-14 08:30:00"),
        EndDate = DateTime.Parse("2025-01-14 14:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD06",
        RequestCharacterId = "RC02",
        Status = RequestDateStatus.Reject,
        Reason = "Cosplayer is busy"
    },
    new RequestDate
    {
        RequestDateId = "RD07",
        RequestCharacterId = "RC04",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-04-10 09:00:00"),
        EndDate = DateTime.Parse("2025-04-10 17:00:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD08",
        RequestCharacterId = "RC04",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-04-11 09:00:00"),
        EndDate = DateTime.Parse("2025-04-11 17:00:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD09",
        RequestCharacterId = "RC04",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-04-12 09:00:00"),
        EndDate = DateTime.Parse("2025-04-12 17:00:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD10",
        RequestCharacterId = "RC04",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-04-13 09:00:00"),
        EndDate = DateTime.Parse("2025-04-13 17:00:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD11",
        RequestCharacterId = "RC04",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-04-14 09:00:00"),
        EndDate = DateTime.Parse("2025-04-14 17:00:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD12",
        RequestCharacterId = "RC04",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-04-15 09:00:00"),
        EndDate = DateTime.Parse("2025-04-15 17:00:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD13",
        RequestCharacterId = "RC05",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-05-03 08:30:00"),
        EndDate = DateTime.Parse("2025-05-03 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD14",
        RequestCharacterId = "RC05",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-05-04 08:30:00"),
        EndDate = DateTime.Parse("2025-05-04 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD15",
        RequestCharacterId = "RC05",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-05-05 08:30:00"),
        EndDate = DateTime.Parse("2025-05-05 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD16",
        RequestCharacterId = "RC05",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-05-06 08:30:00"),
        EndDate = DateTime.Parse("2025-05-06 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD17",
        RequestCharacterId = "RC05",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-05-07 08:30:00"),
        EndDate = DateTime.Parse("2025-05-07 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD18",
        RequestCharacterId = "RC06",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-06-12 08:30:00"),
        EndDate = DateTime.Parse("2025-06-12 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD19",
        RequestCharacterId = "RC06",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-06-13 08:30:00"),
        EndDate = DateTime.Parse("2025-06-13 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD20",
        RequestCharacterId = "RC06",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-06-14 08:30:00"),
        EndDate = DateTime.Parse("2025-06-14 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD21",
        RequestCharacterId = "RC06",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-06-15 08:30:00"),
        EndDate = DateTime.Parse("2025-06-15 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD22",
        RequestCharacterId = "RC07",
        Status = RequestDateStatus.Reject,
        Reason = "Cosplayer is busy"
    },
    new RequestDate
    {
        RequestDateId = "RD23",
        RequestCharacterId = "RC10",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-10-25 08:30:00"),
        EndDate = DateTime.Parse("2025-10-25 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD24",
        RequestCharacterId = "RC11",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-11-20 08:30:00"),
        EndDate = DateTime.Parse("2025-11-20 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD25",
        RequestCharacterId = "RC12",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-12-05 08:30:00"),
        EndDate = DateTime.Parse("2025-12-05 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD26",
        RequestCharacterId = "RC12",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-12-06 08:30:00"),
        EndDate = DateTime.Parse("2025-12-06 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD27",
        RequestCharacterId = "RC12",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-12-07 08:30:00"),
        EndDate = DateTime.Parse("2025-12-07 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD28",
        RequestCharacterId = "RC12",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-12-08 08:30:00"),
        EndDate = DateTime.Parse("2025-12-08 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD29",
        RequestCharacterId = "RC12",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-12-09 08:30:00"),
        EndDate = DateTime.Parse("2025-12-09 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD30",
        RequestCharacterId = "RC12",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-12-10 08:30:00"),
        EndDate = DateTime.Parse("2025-12-10 16:30:00"),
    }, 
    new RequestDate
    {
        RequestDateId = "RD31",
        RequestCharacterId = "RC14",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-06-30 08:30:00"),
        EndDate = DateTime.Parse("2025-06-30 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD32",
        RequestCharacterId = "RC14",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-07-01 08:30:00"),
        EndDate = DateTime.Parse("2025-07-01 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD33",
        RequestCharacterId = "RC14",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-07-02 08:30:00"),
        EndDate = DateTime.Parse("2025-07-02 16:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD34",
        RequestCharacterId = "RC15",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-12-15 08:30:00"),
        EndDate = DateTime.Parse("2025-12-15 16:30:00"),
    }

);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
