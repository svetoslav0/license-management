namespace LicenseManagementApi.Validators
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ParameterModels;

    using System.Net.Mail;

    public class UserValidator : IUserValidator
    {
        private readonly IUserUnitOfWork unitOfWork;

        public UserValidator(IUserUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void ValidateCreateUserParameters(CreateUserParameters parameters)
        {
            this.ValidateEmail(parameters.Email);
            this.ValidateName(parameters.Name);
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new BadHttpRequestException("email is required");
            }

            User user = this.unitOfWork.GetUserBy(email);

            if (user != null)
            {
                throw new BadHttpRequestException($"Email {email} already exists");
            }

            try
            {
                new MailAddress(email);
            }
            catch (Exception)
            {
                throw new BadHttpRequestException($"Invalid email: {email}");
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
