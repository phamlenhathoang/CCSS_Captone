using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  => optionsBuilder.UseSqlServer("Server=(local);Database=CCSSDB;Uid=sa;Password=12345;MultipleActiveResultSets=true;TrustServerCertificate=True");


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

            base.OnModelCreating(modelBuilder);
        }
    }
}
