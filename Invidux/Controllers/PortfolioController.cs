using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invidux_Api.Controllers
{
    [Route("api/v1/portfolio")]
    [ApiController]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
    }
}
