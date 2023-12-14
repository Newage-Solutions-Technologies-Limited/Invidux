using Invidux_Core.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invidux_Api.Controllers
{
    [Route("api/v1/utilities")]
    [ApiController]
    [Authorize]
    public class UtilityController : ControllerBase
    {

        private readonly IUnitofWork uow;
        public UtilityController(IUnitofWork uow) 
        {
            this.uow = uow;
        }


    }
}
