using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
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
            modelBuilder.Entity<Request>()
               .HasOne(a => a.AccountCoupon)
               .WithMany(r => r.Requests)
               .HasForeignKey(a => a.AccountCouponId)
               .OnDelete(DeleteBehavior.NoAction);

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
               .WithOne(r => r.Task)
               .HasForeignKey<Task>(a => a.ContractCharacterId)
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
new Account { AccountId = "A001", Name = "John Doe", Email = "john@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 45000, IsActive = true, Height = 180, Weight = 75, AverageStar = 4.5 },
new Account { AccountId = "A002", Name = "Jane Smith", Email = "jane@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R001", SalaryIndex = null, IsActive = true },
new Account { AccountId = "A003", Name = "Nammmmmmmm", Email = "phuongnam26012002@gmail.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R005", SalaryIndex = null, IsActive = true },
new Account { AccountId = "A004", Name = "Bob Brown", Email = "bob@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 42000, IsActive = true, Height = 175, Weight = 80, AverageStar = 4.2 },
new Account { AccountId = "A005", Name = "Charlie White", Email = "charlie@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 35000, IsActive = true, Height = 182, Weight = 78, AverageStar = 3.5 },
new Account { AccountId = "A006", Name = "David Black", Email = "david@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R005", SalaryIndex = null, IsActive = true },
new Account { AccountId = "A007", Name = "Emma Green", Email = "emma@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 41000, IsActive = true, Height = 168, Weight = 60, AverageStar = 4.1 },
new Account { AccountId = "A008", Name = "Frank Blue", Email = "frank@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 46000, IsActive = true, Height = 185, Weight = 85, AverageStar = 4.6 },
new Account { AccountId = "A009", Name = "Grace Pink", Email = "grace@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R001", SalaryIndex = null, IsActive = true },
new Account { AccountId = "A010", Name = "Henry Purple", Email = "henry@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 25000, IsActive = true, Height = 178, Weight = 77, AverageStar = 2.5 },
new Account { AccountId = "A011", Name = "Isla Red", Email = "isla@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R005", SalaryIndex = null, IsActive = true },
new Account { AccountId = "A012", Name = "Jack Yellow", Email = "jack@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 38000, IsActive = true, Height = 172, Weight = 70, AverageStar = 3.8 },
new Account { AccountId = "A013", Name = "Katie Orange", Email = "katie@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 25000, IsActive = true, Height = 165, Weight = 55, AverageStar = 2.5 },
new Account { AccountId = "A014", Name = "Liam Gray", Email = "liam@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R005", SalaryIndex = null, IsActive = true },
new Account { AccountId = "A015", Name = "Mia Cyan", Email = "mia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 15000, IsActive = true, Height = 170, Weight = 65, AverageStar = 1.5 },
new Account { AccountId = "A016", Name = "Noah Silver", Email = "noah@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 37000, IsActive = true, Height = 175, Weight = 70, AverageStar = 3.7 },
new Account { AccountId = "A017", Name = "Olivia Gold", Email = "olivia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 48000, IsActive = true, Height = 168, Weight = 55 , AverageStar = 4.8 },
new Account { AccountId = "A018", Name = "William Amber", Email = "william@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 32000, IsActive = true, Height = 180, Weight = 75, AverageStar = 3.2 },
new Account { AccountId = "A019", Name = "Sophia Ivory", Email = "sophia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 33000, IsActive = true, Height = 165, Weight = 50, AverageStar = 3.3 },
new Account { AccountId = "A020", Name = "James Navy", Email = "james@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 34000, IsActive = true, Height = 178, Weight = 72, AverageStar = 3.4 },
new Account { AccountId = "A021", Name = "Ava Teal", Email = "ava@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 35000, IsActive = true, Height = 162, Weight = 48, AverageStar = 3.5 },
new Account { AccountId = "A022", Name = "Benjamin Lime", Email = "benjamin@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 36000, IsActive = true, Height = 177, Weight = 70, AverageStar = 3.6 },
new Account { AccountId = "A023", Name = "Charlotte Beige", Email = "charlotte@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 37000, IsActive = true, Height = 164, Weight = 52, AverageStar = 3.7 },
new Account { AccountId = "A024", Name = "Lucas Maroon", Email = "lucas@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 38000, IsActive = true, Height = 180, Weight = 74, AverageStar = 3.8 },
new Account { AccountId = "A025", Name = "Mia Pearl", Email = "mia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 39000, IsActive = true, Height = 159, Weight = 47, AverageStar = 3.9 },
new Account { AccountId = "A026", Name = "Ethan Olive", Email = "ethan@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 25000, IsActive = true, Height = 176, Weight = 71, AverageStar = 2.5 },
new Account { AccountId = "A027", Name = "Amelia Ruby", Email = "amelia@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 26000, IsActive = true, Height = 167, Weight = 53, AverageStar = 2.6 },
new Account { AccountId = "A028", Name = "Henry Saffron", Email = "henry@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 27000, IsActive = true, Height = 182, Weight = 76, AverageStar = 2.7 },
new Account { AccountId = "A029", Name = "Ella Coral", Email = "ella@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 28000, IsActive = true, Height = 160, Weight = 49, AverageStar = 2.8 },
new Account { AccountId = "A030", Name = "Daniel Cyan", Email = "daniel@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 29000, IsActive = true, Height = 175, Weight = 72, AverageStar = 2.9 },
new Account { AccountId = "A031", Name = "Logan Indigo", Email = "logan@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 30000, IsActive = true, Height = 180, Weight = 73, AverageStar = 3.0 },
new Account { AccountId = "A032", Name = "Lily Violet", Email = "lily@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 40000, IsActive = true, Height = 165, Weight = 52, AverageStar = 4.0 },
new Account { AccountId = "A033", Name = "Mason Turquoise", Email = "mason@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 41000, IsActive = true, Height = 178, Weight = 74, AverageStar = 4.1 },
new Account { AccountId = "A034", Name = "Zoe Lavender", Email = "zoe@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 42000, IsActive = true, Height = 160, Weight = 48, AverageStar = 4.2 },
new Account { AccountId = "A035", Name = "Elijah Crimson", Email = "elijah@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 43000, IsActive = true, Height = 182, Weight = 77, AverageStar = 4.3 },
new Account { AccountId = "A036", Name = "Aria Mint", Email = "aria@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 44000, IsActive = true, Height = 164, Weight = 50, AverageStar = 4.4 },
new Account { AccountId = "A037", Name = "Sebastian Bronze", Email = "sebastian@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 45000, IsActive = true, Height = 179, Weight = 72, AverageStar = 4.5 },
new Account { AccountId = "A038", Name = "Harper Rose", Email = "harper@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 46000, IsActive = true, Height = 168, Weight = 53, AverageStar = 4.6 },
new Account { AccountId = "A039", Name = "Caleb Onyx", Email = "caleb@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 47000, IsActive = true, Height = 181, Weight = 75, AverageStar = 4.7 },
new Account { AccountId = "A040", Name = "Scarlett Magenta", Email = "scarlett@example.com", Password = "ZkmcwLVZC7B06TE7qd/qoA==", RoleId = "R004", SalaryIndex = 48000, IsActive = true, Height = 162, Weight = 51, AverageStar = 4.8 }
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
     new Character { CharacterId = "CH001", CharacterName = "Naruto", CategoryId = "C3", Description = "Ninja from Konoha", Price = 100000, IsActive = true, MaxHeight = 180, MinHeight = 160, MaxWeight = 80, MinWeight = 50, Quantity = 5, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH002", CharacterName = "Sasuke", CategoryId = "C3", Description = "Naruto’s rival", Price = 120000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 3, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH003", CharacterName = "Goku", CategoryId = "C3", Description = "Saiyan warrior", Price = 150000, IsActive = true, MaxHeight = 190, MinHeight = 170, MaxWeight = 90, MinWeight = 60, Quantity = 4, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH004", CharacterName = "Luffy", CategoryId = "C4", Description = "Pirate King", Price = 110000, IsActive = true, MaxHeight = 175, MinHeight = 155, MaxWeight = 70, MinWeight = 45, Quantity = 6, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH005", CharacterName = "Ichigo", CategoryId = "C4", Description = "Soul Reaper", Price = 130000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 3, CreateDate = DateTime.UtcNow },

     new Character { CharacterId = "CH006", CharacterName = "Mario", CategoryId = "C14", Description = "Plumber hero", Price = 80000, IsActive = true, MaxHeight = 160, MinHeight = 140, MaxWeight = 70, MinWeight = 50, Quantity = 5, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH007", CharacterName = "Luigi", CategoryId = "C14", Description = "Mario’s brother", Price = 85000, IsActive = true, MaxHeight = 170, MinHeight = 150, MaxWeight = 75, MinWeight = 55, Quantity = 4, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH008", CharacterName = "Link", CategoryId = "C14", Description = "Hero of Hyrule", Price = 140000, IsActive = true, MaxHeight = 180, MinHeight = 160, MaxWeight = 80, MinWeight = 50, Quantity = 2, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH009", CharacterName = "Zelda", CategoryId = "C16", Description = "Hyrule princess", Price = 135000, IsActive = true, MaxHeight = 175, MinHeight = 155, MaxWeight = 70, MinWeight = 50, Quantity = 3, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH010", CharacterName = "Samus", CategoryId = "C16", Description = "Bounty hunter", Price = 145000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 3, CreateDate = DateTime.UtcNow },

     new Character { CharacterId = "CH011", CharacterName = "Cloud", CategoryId = "C13", Description = "Ex-SOLDIER", Price = 125000, IsActive = true, MaxHeight = 185, MinHeight = 165, MaxWeight = 85, MinWeight = 55, Quantity = 3, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH012", CharacterName = "Sephiroth", CategoryId = "C13", Description = "One-Winged Angel", Price = 155000, IsActive = true, MaxHeight = 190, MinHeight = 170, MaxWeight = 90, MinWeight = 60, Quantity = 2, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH013", CharacterName = "Kratos", CategoryId = "C8", Description = "God of War", Price = 160000, IsActive = true, MaxHeight = 195, MinHeight = 175, MaxWeight = 100, MinWeight = 70, Quantity = 2, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH014", CharacterName = "Pikachu", CategoryId = "C8", Description = "Electric Pokemon", Price = 90000, IsActive = true, MaxHeight = 50, MinHeight = 30, MaxWeight = 20, MinWeight = 10, Quantity = 10, CreateDate = DateTime.UtcNow },
     new Character { CharacterId = "CH015", CharacterName = "Kirby", CategoryId = "C8", Description = "Pink puffball", Price = 95000, IsActive = true, MaxHeight = 60, MinHeight = 40, MaxWeight = 25, MinWeight = 15, Quantity = 8, CreateDate = DateTime.UtcNow }
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
    new Product { ProductId = "P001", ProductName = "Naruto Wig", Description = "A wig for Naruto cosplay", Price = 30000, Quantity = 10, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P002", ProductName = "Mario Hat", Description = "A hat for Mario cosplay", Price = 20000, Quantity = 15, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P003", ProductName = "Sasuke Costume", Description = "Complete costume for Sasuke cosplay", Price = 80000, Quantity = 5, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P004", ProductName = "Zelda Sword", Description = "Replica sword from The Legend of Zelda", Price = 100000, Quantity = 7, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P005", ProductName = "One Piece Straw Hat", Description = "Iconic straw hat from One Piece", Price = 25000, Quantity = 20, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P006", ProductName = "Miku Wig", Description = "Hatsune Miku blue twin-tail wig", Price = 40000, Quantity = 12, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P007", ProductName = "Demon Slayer Earrings", Description = "Tanjiro's iconic hanafuda earrings", Price = 15000, Quantity = 30, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P008", ProductName = "Attack on Titan Jacket", Description = "Survey Corps uniform jacket", Price = 50000, Quantity = 10, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P009", ProductName = "Pikachu Onesie", Description = "Cozy Pikachu-themed onesie", Price = 60000, Quantity = 8, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P010", ProductName = "Cloud's Buster Sword", Description = "Final Fantasy VII replica sword", Price = 120000, Quantity = 4, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P011", ProductName = "Genshin Impact Vision", Description = "LED Vision accessory from Genshin Impact", Price = 35000, Quantity = 25, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P012", ProductName = "Jinx Wig", Description = "Jinx cosplay wig from Arcane", Price = 45000, Quantity = 6, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P013", ProductName = "Sailor Moon Tiara", Description = "Golden tiara from Sailor Moon", Price = 18000, Quantity = 15, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P014", ProductName = "Spider-Man Suit", Description = "High-quality Spider-Man suit", Price = 90000, Quantity = 3, CreateDate = DateTime.UtcNow, IsActive = true },
    new Product { ProductId = "P015", ProductName = "Harry Potter Wand", Description = "Replica wand from Harry Potter series", Price = 22000, Quantity = 50, CreateDate = DateTime.UtcNow, IsActive = true }
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
               new Order { OrderId = "O001", AccountId = "A003", OrderDate = DateTime.Parse("2024-03-01"), TotalPrice = 250000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O002", AccountId = "A006", OrderDate = DateTime.Parse("2024-03-05"), TotalPrice = 150000.5, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O003", AccountId = "A011", OrderDate = DateTime.Parse("2024-03-10"), TotalPrice = 300000.0, OrderStatus = OrderStatus.Cancel },
               new Order { OrderId = "O004", AccountId = "A014", OrderDate = DateTime.Parse("2024-03-12"), TotalPrice = 400000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O005", AccountId = "A003", OrderDate = DateTime.Parse("2024-03-15"), TotalPrice = 175000.0, OrderStatus = OrderStatus.Cancel },
               new Order { OrderId = "O006", AccountId = "A006", OrderDate = DateTime.Parse("2024-03-18"), TotalPrice = 225000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O007", AccountId = "A011", OrderDate = DateTime.Parse("2024-03-20"), TotalPrice = 350000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O008", AccountId = "A014", OrderDate = DateTime.Parse("2024-03-22"), TotalPrice = 275000.0, OrderStatus = OrderStatus.Cancel },
               new Order { OrderId = "O009", AccountId = "A003", OrderDate = DateTime.Parse("2024-03-25"), TotalPrice = 500000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O010", AccountId = "A006", OrderDate = DateTime.Parse("2024-03-28"), TotalPrice = 125000.0, OrderStatus = OrderStatus.Cancel },
               new Order { OrderId = "O011", AccountId = "A011", OrderDate = DateTime.Parse("2024-03-30"), TotalPrice = 325000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O012", AccountId = "A014", OrderDate = DateTime.Parse("2024-04-02"), TotalPrice = 410000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O013", AccountId = "A003", OrderDate = DateTime.Parse("2024-04-05"), TotalPrice = 280000.0, OrderStatus = OrderStatus.Cancel },
               new Order { OrderId = "O014", AccountId = "A006", OrderDate = DateTime.Parse("2024-04-07"), TotalPrice = 350000.0, OrderStatus = OrderStatus.Completed },
               new Order { OrderId = "O015", AccountId = "A011", OrderDate = DateTime.Parse("2024-04-10"), TotalPrice = 200000.0, OrderStatus = OrderStatus.Completed }
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
     new Contract { ContractId = "CT002", RequestId = "R002", Deposit = "100", TotalPrice = 500000, Amount = 0,CreateBy = "Admin", CreateDate = new DateTime(2025, 2, 1), ContractStatus = ContractStatus.Created, ContractName = "Character rental" },
     new Contract { ContractId = "CT005", RequestId = "R005", Deposit = "50", TotalPrice = 700000, Amount = 350000, CreateBy = "Admin", CreateDate = new DateTime(2025, 5, 1), ContractStatus = ContractStatus.Created, ContractName = "Character rental" },
     new Contract { ContractId = "CT008", RequestId = "R008", Deposit = "50", TotalPrice = 350000, Amount = 175000, CreateBy = "Admin", CreateDate = new DateTime(2025, 8, 10), ContractStatus = ContractStatus.Created, ContractName = "Character rental" },
     new Contract { ContractId = "CT010", RequestId = "R010", Deposit = "50", TotalPrice = 200000, Amount = 100000, CreateBy = "Admin", CreateDate = new DateTime(2025, 10, 20), ContractStatus = ContractStatus.Completed, ContractName = "Character rental" },
     new Contract { ContractId = "CT014", RequestId = "R014", Deposit = "100", TotalPrice = 600000, Amount = 0, CreateBy = "Admin", CreateDate = new DateTime(2025, 6, 25), ContractStatus = ContractStatus.Created, ContractName = "Character rental" }
 );
            #endregion

            #region Feedback
            modelBuilder.Entity<Feedback>().HasData(
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Great experience!", CreateDate = new DateTime(2025, 2, 15), CreateBy = "A001", AccountId = "A001", ContractCharacterId = "CC0021" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Loved the event!", CreateDate = new DateTime(2025, 3, 10), CreateBy = "A004", AccountId = "A004", ContractCharacterId = "CC0022" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Nice cosplay session!", CreateDate = new DateTime(2025, 4, 5), CreateBy = "A005", AccountId = "A005", ContractCharacterId = "CC0023" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Enjoyed the event!", CreateDate = new DateTime(2025, 6, 20), CreateBy = "A007", AccountId = "A007", ContractCharacterId = "CC0051" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Would love to join again!", CreateDate = new DateTime(2025, 7, 15), CreateBy = "A008", AccountId = "A008", ContractCharacterId = "CC0052" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "The atmosphere was amazing!", CreateDate = new DateTime(2025, 8, 25), CreateBy = "A010", AccountId = "A010", ContractCharacterId = "CC0053" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Best cosplay event!", CreateDate = new DateTime(2025, 9, 10), CreateBy = "A012", AccountId = "A012", ContractCharacterId = "CC0081" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Nice crowd and management!", CreateDate = new DateTime(2025, 10, 5), CreateBy = "A013", AccountId = "A013", ContractCharacterId = "CC0082" },
    new Feedback { FeedbackId = Guid.NewGuid().ToString(), Description = "Amazing experience!", CreateDate = new DateTime(2025, 11, 20), CreateBy = "A015", AccountId = "A015", ContractCharacterId = "CC0083" }
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
    new Request { RequestId = "R001", AccountId = "A001", Name = "Rent Naruto Costume", Description = RequestDescription.RentCostumes.ToString(), Price = 100000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2025, 1, 15), ServiceId = "S001", Location = "HCM", PackageId= "PKG001" },
    new Request { RequestId = "R002", AccountId = "A002", Name = "Rent Cosplayer for Event", Description = RequestDescription.RentCosplayer.ToString(), Price = 500000, Status = RequestStatus.Browsed, StartDate = new DateTime(2025, 2, 5), EndDate = new DateTime(2025, 2, 10), ServiceId = "S002", Location = "ĐN", Reason = "Cosplayer is busy" },
    new Request { RequestId = "R003", AccountId = "A003", Name = "Create Anime Festival", Description = RequestDescription.CreateEvent.ToString(), Price = 2000000, Status = RequestStatus.Pending, StartDate = new DateTime(2025, 3, 1), EndDate = new DateTime(2025, 3, 5), ServiceId = "S003", Location = "BD" },
    new Request { RequestId = "R004", AccountId = "A004", Name = "Rent Samurai Armor", Description = RequestDescription.RentCostumes.ToString(), Price = 150000, Status = RequestStatus.Cancel, StartDate = new DateTime(2025, 4, 10), EndDate = new DateTime(2025, 4, 15), ServiceId = "S002", Location = "HN" },
    new Request { RequestId = "R005", AccountId = "A005", Name = "Hire Professional Cosplayer", Description = RequestDescription.RentCosplayer.ToString(), Price = 700000, Status = RequestStatus.Browsed, StartDate = new DateTime(2025, 5, 3), EndDate = new DateTime(2025, 5, 7), ServiceId = "S002",Location = "BT", PackageId = "PKG002" },
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
    new Task { TaskId = "T012", TaskName = "CH011", Location = "Jakarta", Description = "Host main event", IsActive = true, StartDate = DateTime.Now.AddDays(22), EndDate = DateTime.Now.AddDays(23), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, Status = TaskStatus.Progressing, AccountId = "A007", EventCharacterId = "EC012" }

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


            #region AccountImage
            modelBuilder.Entity<AccountImage>().HasData(
     new AccountImage { AccountImageId = "AI1", AccountId = "A001", UrlImage = "https://example.com/admin.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI2", AccountId = "A002", UrlImage = "https://example.com/manager.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI3", AccountId = "A003", UrlImage = "https://example.com/user1.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI4", AccountId = "A004", UrlImage = "https://example.com/user2.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI5", AccountId = "A005", UrlImage = "https://example.com/user3.jpg", CreateDate = DateTime.UtcNow },

     new AccountImage { AccountImageId = "AI6", AccountId = "A006", UrlImage = "https://example.com/user4.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI7", AccountId = "A007", UrlImage = "https://example.com/user5.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI8", AccountId = "A008", UrlImage = "https://example.com/user6.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI9", AccountId = "A009", UrlImage = "https://example.com/user7.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI10", AccountId = "A010", UrlImage = "https://example.com/user8.jpg", CreateDate = DateTime.UtcNow },

     new AccountImage { AccountImageId = "AI11", AccountId = "A011", UrlImage = "https://example.com/user9.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI12", AccountId = "A012", UrlImage = "https://example.com/user10.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI13", AccountId = "A013", UrlImage = "https://example.com/user11.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI14", AccountId = "A014", UrlImage = "https://example.com/user12.jpg", CreateDate = DateTime.UtcNow },
     new AccountImage { AccountImageId = "AI15", AccountId = "A015", UrlImage = "https://example.com/user13.jpg", CreateDate = DateTime.UtcNow }
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
    new CharacterImage { CharacterImageId = "CI001", UrlImage = "https://example.com/img1.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH001" },
    new CharacterImage { CharacterImageId = "CI002", UrlImage = "https://example.com/img2.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH002" },
    new CharacterImage { CharacterImageId = "CI003", UrlImage = "https://example.com/img3.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH003" },
    new CharacterImage { CharacterImageId = "CI004", UrlImage = "https://example.com/img4.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH004" },
    new CharacterImage { CharacterImageId = "CI005", UrlImage = "https://example.com/img5.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH005" },
    new CharacterImage { CharacterImageId = "CI006", UrlImage = "https://example.com/img6.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH006" },
    new CharacterImage { CharacterImageId = "CI007", UrlImage = "https://example.com/img7.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH007" },
    new CharacterImage { CharacterImageId = "CI008", UrlImage = "https://example.com/img8.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH008" },
    new CharacterImage { CharacterImageId = "CI009", UrlImage = "https://example.com/img9.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH009" },
    new CharacterImage { CharacterImageId = "CI010", UrlImage = "https://example.com/img10.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH010" },
    new CharacterImage { CharacterImageId = "CI011", UrlImage = "https://example.com/img11.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH011" },
    new CharacterImage { CharacterImageId = "CI012", UrlImage = "https://example.com/img12.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH012" },
    new CharacterImage { CharacterImageId = "CI013", UrlImage = "https://example.com/img13.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH013" },
    new CharacterImage { CharacterImageId = "CI014", UrlImage = "https://example.com/img14.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH014" },
    new CharacterImage { CharacterImageId = "CI015", UrlImage = "https://example.com/img15.jpg", CreateDate = DateTime.UtcNow, CharacterId = "CH015" }
);
            #endregion


            #region EventImage
            modelBuilder.Entity<EventImage>().HasData(
    new EventImage { ImageId = "EI001", ImageUrl = "https://example.com/event1.jpg", CreateDate = DateTime.UtcNow, EventId = "E001" },
    new EventImage { ImageId = "EI002", ImageUrl = "https://example.com/event2.jpg", CreateDate = DateTime.UtcNow, EventId = "E002" },
    new EventImage { ImageId = "EI003", ImageUrl = "https://example.com/event3.jpg", CreateDate = DateTime.UtcNow, EventId = "E003" },
    new EventImage { ImageId = "EI004", ImageUrl = "https://example.com/event4.jpg", CreateDate = DateTime.UtcNow, EventId = "E004" },
    new EventImage { ImageId = "EI005", ImageUrl = "https://example.com/event5.jpg", CreateDate = DateTime.UtcNow, EventId = "E005" },
    new EventImage { ImageId = "EI006", ImageUrl = "https://example.com/event6.jpg", CreateDate = DateTime.UtcNow, EventId = "E006" },
    new EventImage { ImageId = "EI007", ImageUrl = "https://example.com/event7.jpg", CreateDate = DateTime.UtcNow, EventId = "E007" },
    new EventImage { ImageId = "EI008", ImageUrl = "https://example.com/event8.jpg", CreateDate = DateTime.UtcNow, EventId = "E008" },
    new EventImage { ImageId = "EI009", ImageUrl = "https://example.com/event9.jpg", CreateDate = DateTime.UtcNow, EventId = "E009" },
    new EventImage { ImageId = "EI010", ImageUrl = "https://example.com/event10.jpg", CreateDate = DateTime.UtcNow, EventId = "E010" },
    new EventImage { ImageId = "EI011", ImageUrl = "https://example.com/event11.jpg", CreateDate = DateTime.UtcNow, EventId = "E011" },
    new EventImage { ImageId = "EI012", ImageUrl = "https://example.com/event12.jpg", CreateDate = DateTime.UtcNow, EventId = "E012" }

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
    new ProductImage { ProductImageId = "IMG001", ProductId = "P001", UrlImage = "https://example.com/images/naruto_wig.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG002", ProductId = "P002", UrlImage = "https://example.com/images/mario_hat.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG003", ProductId = "P003", UrlImage = "https://example.com/images/sasuke_costume.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG004", ProductId = "P004", UrlImage = "https://example.com/images/zelda_sword.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG005", ProductId = "P005", UrlImage = "https://example.com/images/one_piece_hat.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG006", ProductId = "P006", UrlImage = "https://example.com/images/miku_wig.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG007", ProductId = "P007", UrlImage = "https://example.com/images/demon_slayer_earrings.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG008", ProductId = "P008", UrlImage = "https://example.com/images/aot_jacket.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG009", ProductId = "P009", UrlImage = "https://example.com/images/pikachu_onesie.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG010", ProductId = "P010", UrlImage = "https://example.com/images/buster_sword.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG011", ProductId = "P011", UrlImage = "https://example.com/images/genshin_vision.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG012", ProductId = "P012", UrlImage = "https://example.com/images/jinx_wig.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG013", ProductId = "P013", UrlImage = "https://example.com/images/sailor_moon_tiara.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG014", ProductId = "P014", UrlImage = "https://example.com/images/spiderman_suit.jpg", CreateDate = DateTime.UtcNow },
    new ProductImage { ProductImageId = "IMG015", ProductId = "P015", UrlImage = "https://example.com/images/harry_potter_wand.jpg", CreateDate = DateTime.UtcNow }
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
    new Payment { PaymentId = "P001", Type = "Online", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.BuyTicket, Amount = 250000.0, TransactionId = "TXN001", CreatAt = new DateTime(2024, 3, 2), TicketAccountId = "TA001", AccountCouponID = "AC001" },
    new Payment { PaymentId = "P002", Type = "Online", Status = PaymentStatus.Pending, Purpose = PaymentPurpose.BuyTicket, Amount = 150000.5, TransactionId = "TXN002", CreatAt = new DateTime(2024, 3, 6), TicketAccountId = "TA002" },
    new Payment { PaymentId = "P003", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.BuyTicket, Amount = 90000.0, TransactionId = "TXN003", CreatAt = new DateTime(2024, 3, 11), TicketAccountId = "TA003" },
    new Payment { PaymentId = "P004", Type = "Card", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.BuyTicket, Amount = 400000.0, TransactionId = "TXN004", CreatAt = new DateTime(2024, 3, 13), TicketAccountId = "TA004", AccountCouponID = "AC012" },
    new Payment { PaymentId = "P005", Type = "Online", Status = PaymentStatus.Cancel, Purpose = PaymentPurpose.BuyTicket, Amount = 175000.0, TransactionId = "TXN005", CreatAt = new DateTime(2024, 3, 16), TicketAccountId = "TA005" },

    new Payment { PaymentId = "P006", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.Order, Amount = 225000.0, TransactionId = "TXN006", CreatAt = new DateTime(2024, 3, 19), OrderId = "O006", AccountCouponID = "AC003" },
    new Payment { PaymentId = "P007", Type = "Online", Status = PaymentStatus.Pending, Purpose = PaymentPurpose.Order, Amount = 350000.0, TransactionId = "TXN007", CreatAt = new DateTime(2024, 3, 21), OrderId = "O007" },
    new Payment { PaymentId = "P008", Type = "Card", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.Order, Amount = 150000.0, TransactionId = "TXN008", CreatAt = new DateTime(2024, 3, 23), OrderId = "O008" },
    new Payment { PaymentId = "P009", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.Order, Amount = 500000.0, TransactionId = "TXN009", CreatAt = new DateTime(2024, 3, 26), OrderId = "O009" },
    new Payment { PaymentId = "P010", Type = "Online", Status = PaymentStatus.Cancel, Purpose = PaymentPurpose.Order, Amount = 125000.0, TransactionId = "TXN010", CreatAt = new DateTime(2024, 3, 29), OrderId = "O010", AccountCouponID = "AC004" },

    new Payment { PaymentId = "P011", Type = "Online", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.ContractDeposit, Amount = 325000.0, TransactionId = "TXN011", CreatAt = new DateTime(2024, 3, 31), ContractId = "CT002" },
    new Payment { PaymentId = "P012", Type = "Card", Status = PaymentStatus.Pending, Purpose = PaymentPurpose.ContractDeposit, Amount = 410000.0, TransactionId = "TXN012", CreatAt = new DateTime(2024, 4, 3), ContractId = "CT005" },
    new Payment { PaymentId = "P013", Type = "Cash", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.contractSettlement, Amount = 90000.0, TransactionId = "TXN013", CreatAt = new DateTime(2024, 4, 6), ContractId = "CT008" },
    new Payment { PaymentId = "P014", Type = "Online", Status = PaymentStatus.Cancel, Purpose = PaymentPurpose.contractSettlement, Amount = 350000.0, TransactionId = "TXN014", CreatAt = new DateTime(2024, 4, 8), ContractId = "CT010" },
    new Payment { PaymentId = "P015", Type = "Card", Status = PaymentStatus.Complete, Purpose = PaymentPurpose.contractSettlement, Amount = 200000.0, TransactionId = "TXN015", CreatAt = new DateTime(2024, 4, 11), ContractId = "CT002" }
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
        StartDate = DateTime.Parse("2025-01-11 14:30:00"),
        EndDate = DateTime.Parse("2025-01-11 14:30:00"),
    }, 
    new RequestDate
    {
        RequestDateId = "RD03",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-13 14:30:00"),
        EndDate = DateTime.Parse("2025-01-13 14:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD04",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-14 14:30:00"),
        EndDate = DateTime.Parse("2025-01-14 14:30:00"),
    },
    new RequestDate
    {
        RequestDateId = "RD05",
        RequestCharacterId = "RC01",
        Status = RequestDateStatus.Accept,
        StartDate = DateTime.Parse("2025-01-15 14:30:00"),
        EndDate = DateTime.Parse("2025-01-15 14:30:00"),
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
