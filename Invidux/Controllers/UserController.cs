using AutoMapper;
using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Data.Dtos;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Invidux_Api.Controllers
{
    /// <summary>
    /// This controller handles user centric actions
    /// </summary>
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

        /// <summary>
        /// Endpoint to get the user profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<UserProfileDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("current-user/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                // Retrieving the user's profile using the provided userId
                var user = await uow.UserRepo.GetUserProfile(userId);

                if(user == null)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User not found" }
                    );
                    return BadRequest(errorResponse);
                }

                // Mapping the retrieved user profile to a DTO (Data Transfer Object)
                var userDto = mapper.Map<UserProfileDto>(user);

                if (userDto == null)
                {
                    // Returning a BadRequest response for an unknown error
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occurred" }
                    );
                    return BadRequest(errorResponse);
                }

                // Creating a response for the user's profile
                var response = new Response<UserProfileDto>
                {
                    Successful = true,
                    Message = "User profile",
                    Data = userDto
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to update the personal information of the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //[ProducesResponseType(typeof(Response<UserProfileDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch("current-user/personal-info/{userId}")]
        public async Task<IActionResult> UpdatePersonalInfo(PersonalInfoDto user)
        {
            try
            {
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Retrieving the user's information from the database using the provided userId
                var dbUserInfo = await uow.UserRepo.GetUserInfo(user.UserId);

                if (dbUserInfo == null)
                {
                    // Returning a BadRequest response for an unknown error
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occurred" }
                    );
                    return BadRequest(errorResponse);
                }

                // Updating the 'UpdatedAt' field to the current time
                dbUserInfo.UpdatedAt = DateTime.UtcNow;

                // Mapping the updated user information from the DTO to the entity
                mapper.Map(user, dbUserInfo);

                // Saving changes asynchronously
                await uow.SaveAsync();

                // Returning a 203 Non-Authoritative response after successful update
                return StatusCode(203);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                Console.WriteLine(ex.Message);

                // Returning a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint for user to create their next of kin
        /// </summary>
        /// <param name="nextOfKin"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("current-user/next-of-kin/{userId}")]
        public async Task<IActionResult> CreateNextofKin(NextOfKinDto nextOfKin)
        {
            try
            {
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Checking if the user exists based on the provided UserId
                var dbUser = await uow.UserRepo.UserExists(nextOfKin.UserId);

                if (!dbUser)
                {
                    // Returning a BadRequest response for an unknown error
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occurred" }
                    );
                    return BadRequest(errorResponse);
                }

                // Mapping the NextOfKinDto to a UserNextOfKin entity
                var kin = mapper.Map<UserNextOfKin>(nextOfKin);

                // Setting CreatedAt and UpdatedAt timestamps to the current UTC time
                kin.CreatedAt = DateTime.UtcNow;
                kin.UpdatedAt = DateTime.UtcNow;

                // Creating the next-of-kin entry
                uow.UserRepo.CreateNextOfKin(kin);

                // Saving changes asynchronously
                await uow.SaveAsync();

                Console.WriteLine(kin);

                // Returning a 201 Created response after successful creation
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint for user to update their next of kin
        /// </summary>
        /// <param name="nextOfKin"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch("current-user/next-of-kin/{userId}")]
        public async Task<IActionResult> UpdateNextofKin(NextOfKinDto nextOfKin)
        {
            try
            {
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Retrieving the next-of-kin information based on the provided UserId
                var dbNextOfKin = await uow.UserRepo.GetUserNextOfKin(nextOfKin.UserId);

                if (dbNextOfKin == null)
                {
                    // Returning a BadRequest response for an unknown error
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occurred" }
                    );
                    return BadRequest(errorResponse);
                }

                // Updating the 'UpdatedAt' field to the current time
                dbNextOfKin.UpdatedAt = DateTime.Now;

                // Mapping the updated next-of-kin information from the DTO to the entity
                mapper.Map(nextOfKin, dbNextOfKin);

                // Saving changes asynchronously
                await uow.SaveAsync();

                // Returning a 201 Created response after successful update
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to update user security info
        /// </summary>
        /// <param name="securityDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("current-user/security/{userId}")]
        public async Task<IActionResult> UpdateSecurityInfo(SecurityDto securityDto)
        {
            try
            {
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Checking if the user exists based on the provided UserId
                var dbUser = await uow.UserRepo.UserExists(securityDto.UserId);

                // If the user does not exist, return a BadRequest response for an unknown error
                if (!dbUser)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occurred" }
                    );
                    return BadRequest(errorResponse);
                }

                // Attempt to update the security information for the user
                var result = await uow.UserRepo.UpdateSecurity(securityDto);

                // If the update operation fails, return a BadRequest response for an unknown error
                if (!result)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occurred" }
                    );
                    return BadRequest(errorResponse);
                }

                // Save the changes asynchronously
                await uow.SaveAsync();

                // Return a 201 status code for successful update
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
