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

        //[ProducesResponseType(typeof(Response<UserProfileDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch("current-user/personal-info/{userId}")]
        public async Task<IActionResult> UpdatePersonalInfo(PersonalInfoDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var dbUserInfo = await uow.UserRepo.GetUserInfo(user.UserId);
                if (dbUserInfo == null)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occured" }
                    );
                    return BadRequest(errorResponse);
                }
                dbUserInfo.UpdatedAt = DateTime.UtcNow;
                mapper.Map(dbUserInfo, user);
                await uow.SaveAsync();
                return StatusCode(203);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("current-user/next-of-kin/{userId}")]
        public async Task<IActionResult> CreateNextofKin(NextOfKinDto nextOfKin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var dbUser = await uow.UserRepo.UserExists(nextOfKin.UserId);
                if (!dbUser)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occured" }
                    );
                    return BadRequest(errorResponse);
                }
                mapper.Map<NextOfKin>(nextOfKin);
                await uow.SaveAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch("current-user/next-of-kin/{userId}")]
        public async Task<IActionResult> UpdateNextofKin(NextOfKinDto nextOfKin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var dbNextOfKin = await uow.UserRepo.GetUserNextOfKin(nextOfKin.UserId);
                if(dbNextOfKin == null)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occured" }
                    );
                    return BadRequest(errorResponse);
                }
                dbNextOfKin.UpdatedAt = DateTime.Now;
                mapper.Map(dbNextOfKin, nextOfKin);
                await uow.SaveAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("current-user/security/{userId}")]
        public async Task<IActionResult> UpdateSecurityInfo(SecurityDto securityDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var dbUser = await uow.UserRepo.UserExists(securityDto.UserId);
                if (!dbUser)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occured" }
                    );
                    return BadRequest(errorResponse);
                }
                var result = await uow.UserRepo.UpdateSecurity(securityDto);
                if (!result)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occured" }
                    );
                    return BadRequest(errorResponse);
                }
                await uow.SaveAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
