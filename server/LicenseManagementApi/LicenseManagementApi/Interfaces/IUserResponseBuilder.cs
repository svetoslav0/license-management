namespace LicenseManagementApi.Interfaces
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Models.ResponseModels.User;

    public interface IUserResponseBuilder
    {
        public UserResponse BuildGetUsersListResponse(List<User> usersList);
    }
}
