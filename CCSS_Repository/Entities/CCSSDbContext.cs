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
        public virtual DbSet<Notification> Notifications { get; set; }
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
        }
    }
}
