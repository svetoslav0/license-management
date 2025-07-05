namespace LicenseManagementApi.ResponseBuilders
{
    using LicenseManagementApi.Database.EF.Models;
    using LicenseManagementApi.Interfaces;
    using LicenseManagementApi.Models.ResponseModels.User;

    using System.Collections.Generic;

    public class UserResponseBuilder : IUserResponseBuilder
    {
        public UserResponse BuildGetUsersListResponse(List<User> usersList)
        {
            List<UserResponseItem> items = usersList
                .Select(u => new UserResponseItem
                {
                    Id = u.Id,
                    Name = u.Name,
                    Username = u.Username,
                    HasLicense = u.HasLicense,
                })
                .ToList();

            UserResponseData data = new UserResponseData
            {
                Users = items,
                Count = usersList.Count
            };

            UserResponse response = new UserResponse
            {
                Data = data
            };

            return response;
        }
    }
}
