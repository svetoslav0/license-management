namespace LicenseManagementApi.Database.EF
{
    using LicenseManagementApi.Database.EF.Models;

    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        private readonly string dbFileName = "license_management.db";

        public DbSet<User> Users { get; set; }

        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        public string DbPath { get; set; }

        public DatabaseContext()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, this.dbFileName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={this.DbPath}");
    }
}
