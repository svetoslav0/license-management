namespace LicenseManagementApi.Controllers
{
    using LicenseManagementApi.Models.ResponseModels;

    using Microsoft.AspNetCore.Mvc;

    public abstract class AbstractController : Controller
    {
        protected IActionResult BuildSuccessResponseMessage(string message)
        {
            ResponseMessage result = new ResponseMessage
            {
                Message = message
            };

            return this.Ok(result);
        }
    }
}
