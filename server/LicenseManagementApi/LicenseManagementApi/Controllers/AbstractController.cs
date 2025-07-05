namespace LicenseManagementApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public abstract class AbstractController : Controller
    {
        protected IActionResult BuildSuccessResponseMessage(string message)
        {
            var result = new
            {
                message
            };

            return this.Ok(result);
        }
    }
}
