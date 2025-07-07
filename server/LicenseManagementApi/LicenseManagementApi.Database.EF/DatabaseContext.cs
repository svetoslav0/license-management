namespace LicenseManagementApi.Database.EF
{
    using LicenseManagementApi.Database.EF.Models;

    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        private readonly string dbFileName = "license_management.db";

        public DbSet<User> Users { get; set; }

        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        public DbSet<Subscription> Subscription { get; set; }

        public string DbPath { get; set; }

        public DatabaseContext()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, this.dbFileName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={this.DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Subscription>()
                .HasOne<SubscriptionPlan>(x => x.Plan)
                .WithOne()
                .HasForeignKey<Subscription>(x => x.PlanId);
        }
    }
}
