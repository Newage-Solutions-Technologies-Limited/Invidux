using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Invidux_Api.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected string GetUserId()
        {
            Console.WriteLine(Request.Headers.Authorization);
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
