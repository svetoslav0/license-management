namespace LicenseManagementApi.Services
{
    using LicenseManagementApi.Database.EF;
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ParameterModels;

    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly DatabaseContext databaseContext;

        public UserUnitOfWork(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task SaveUserAsync(CreateUserParameters parameters)
        {
            User user = new User(parameters.Email, parameters.Name);

            this.databaseContext.Users.Add(user);
            await this.databaseContext.SaveChangesAsync();
        }

        public List<User> ListUsers()
        {
            List<User> users = this.databaseContext.Users.ToList();

            return users;
        }

        public User GetUserBy(string email)
        {
            User user = this.databaseContext.Users.FirstOrDefault(u => u.Email == email);

            return user;
        }

        public User GetUserBy(int id)
        {
            User user = this.databaseContext.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public int GetUsersWithLicenseCount()
        {
            return this.databaseContext
                .Users
                .Where(x => x.HasLicense == true)
                .Count();
        }

        public async Task UpdateLicenseStatus(int userId, bool shouldHaveLicense)
        {
            User user = this.databaseContext
                .Users
                .First(x => x.Id == userId);

            user.HasLicense = shouldHaveLicense;

            await this.databaseContext.SaveChangesAsync();
        }
    }
}
