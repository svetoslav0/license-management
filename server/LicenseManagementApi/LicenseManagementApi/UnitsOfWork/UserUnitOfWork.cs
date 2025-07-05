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
            User user = new User(parameters.Username, parameters.Name);

            this.databaseContext.Users.Add(user);
            await this.databaseContext.SaveChangesAsync();
        }

        public List<User> ListUsers()
        {
            List<User> users = this.databaseContext.Users.ToList();

            return users;
        }

        public User GetUserByUsername(string username)
        {
            User user = this.databaseContext.Users.FirstOrDefault(u => u.Username == username);

            return user;
        }

        public int GetUsersWithLicenseCount()
        {
            return this.databaseContext
                .Users
                .Where(x => x.HasLicense == true)
                .Count();
        }
    }
}
