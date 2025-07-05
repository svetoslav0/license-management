namespace LicenseManagementApi.Validators
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ParameterModels;

    public class UserValidator : IUserValidator
    {
        private readonly IUserUnitOfWork unitOfWork;

        public UserValidator(IUserUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void ValidateCreateUserParameters(CreateUserParameters parameters)
        {
            this.ValidateUsername(parameters.Username);
            this.ValidateName(parameters.Name);
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new BadHttpRequestException("username is required");
            }

            User user = this.unitOfWork.GetUserBy(username);

            if (user != null)
            {
                throw new BadHttpRequestException($"Username {username} already exists");
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new BadHttpRequestException("name is required");
            }
        }
    }
}
