using Invidux_Core.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invidux_Api.Controllers
{
    [Route("api/v1/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitofWork uow;
        public UserController(IUnitofWork uow)
        {
            this.uow = uow;
        }
    }

    [HttpGet("current-user/{userId}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        
    }

    [HttpPatch("current-user/{userId}")]
    public async Task<IActionResult> UpdatePersonalInfo()
    {

    }

    [HttpPatch("current-user/next-of-kin/{userId}")]
    public async Task<IActionResult> UpdateNextofKin()
    {

    }

    [HttpPatch("current-user/security/{userId}")]
    public async Task<IActionResult> UpdatePersonalInfo()
    {

    }
}
