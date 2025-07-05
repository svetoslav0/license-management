namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Models.ParameterModels;

    public interface IUserUnitOfWork
    {
        public Task SaveUserAsync(CreateUserParameters parameters);
    }
}
