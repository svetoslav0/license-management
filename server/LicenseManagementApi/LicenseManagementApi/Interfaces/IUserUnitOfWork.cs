namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Models.ParameterModels;

    public interface IUserUnitOfWork
    {
        public Task SaveUserAsync(CreateUserParameters parameters);

        public List<User> ListUsers();

        public User GetUserBy(string username);

        public User GetUserBy(int id);

        public int GetUsersWithLicenseCount();

        public Task UpdateLicenseStatus(int userId, bool shouldHaveLicense);
    }
}
