namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Models.ParameterModels;

    public interface IUserValidator
    {
        public void ValidateCreateUserParameters(CreateUserParameters parameters);

        public void ValidateUserExistanceBy(int userId);
    }
}
