namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Database.EF;
    using LicenseManagementApi.Database.EF.Models;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly DatabaseContext databaseContext;

        public UserController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet("create")]
        public async Task<IActionResult> Index()
        {
            User user = new User
            {
                Id = 1,
                Name = "Test",
                Username = "Test"
            };

            this.databaseContext.Users.Add(user);
            await this.databaseContext.SaveChangesAsync();

            return Ok("okay");
        }
    }
}
