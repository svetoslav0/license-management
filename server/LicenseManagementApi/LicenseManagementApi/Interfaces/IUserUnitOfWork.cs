namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Models.ParameterModels;

    public interface IUserUnitOfWork
    {
        public Task SaveUserAsync(CreateUserParameters parameters);

        public List<User> ListUsers();
    }
}
