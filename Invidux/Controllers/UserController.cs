using AutoMapper;
using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Invidux_Api.Controllers
{
    [Route("api/v1/profile")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUnitofWork uow;

        private readonly IMapper mapper;
        public UserController(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [ProducesResponseType(typeof(Response<UserProfileDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("current-user/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await uow.UserRepo.GetUserProfile(userId);
                var userDto = mapper.Map<UserProfileDto>(user);
                if(userDto == null)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occured" }
                    );
                    return BadRequest(errorResponse);
                }
                var reponse = new Response<UserProfileDto> 
                { 
                    Successful = true,
                    Message = "User profile",
                    Data = userDto
                };
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /*[HttpPatch("current-user/{userId}")]
        public async Task<IActionResult> UpdatePersonalInfo()
        {

        }

        [HttpPatch("current-user/next-of-kin/{userId}")]
        public async Task<IActionResult> UpdateNextofKin()
        {

        }

        [HttpPatch("current-user/security/{userId}")]
        public async Task<IActionResult> UpdateSecurityInfo()
        {

        }*/
    }
}
