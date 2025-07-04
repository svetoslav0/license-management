namespace LicenseManagementApi.Services
{
    using LicenseManagementApi.Database.EF;
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Models.ParameterModels;

    public class UserUnitOfWork
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
    }
}
