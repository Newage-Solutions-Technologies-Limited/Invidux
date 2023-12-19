using AutoMapper;
using Invidux_Core.Repository.Interfaces;
using Invidux_Core.Services;
using Invidux_Data.Dtos;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Invidux_Api.Controllers
{
    /// <summary>
    /// This controller handles user centric actions
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IUnitofWork uow;

        private readonly IMapper mapper;

        private readonly IPhotoService photoService;
        public UserController(IUnitofWork uow, IMapper mapper, IPhotoService photoService)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.photoService = photoService;
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
        [HttpGet("profile/current-user")]
        public async Task<IActionResult> GetUserById()
        {
            try
            {
                string userId = GetUserId();
                // Retrieving the user's profile using the provided userId
                var user = await uow.UserRepo.GetUserProfile(userId);

                if(user == null)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                         "User not found" 
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
                        "Unknown error occurred" 
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
        [HttpPatch("profile/current-user")]
        public async Task<IActionResult> UpdatePersonalInfo(PersonalInfoDto user)
        {
            try
            {
                string userId = GetUserId();
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Retrieving the user's information from the database using the provided userId
                var dbUserInfo = await uow.UserRepo.GetUserInfo(userId);

                if (dbUserInfo == null)
                {
                    // Returning a BadRequest response for an unknown error
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Unknown error occurred"
                    );
                    return BadRequest(errorResponse);
                }

                var file = await photoService.UploadPhoto(user.ProfileImage);

                dbUserInfo.ImageName = file?[0] ?? "";
                dbUserInfo.ImageUrl = file?[1] ?? "";

                // Updating the 'UpdatedAt' field to the current time
                dbUserInfo.UpdatedAt = DateTime.UtcNow;

                // Mapping the updated user information from the DTO to the entity
                mapper.Map(user, dbUserInfo);

                // Saving changes asynchronously
                await uow.SaveAsync();

                // Returning a 201 response after successful update
                return StatusCode(201);
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
        [HttpPost("profile/current-user/next-of-kin")]
        public async Task<IActionResult> CreateNextofKin(NextOfKinDto nextOfKin)
        {
            try
            {
                string userId = GetUserId();
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Checking if the user exists based on the provided UserId
                var dbUser = await uow.UserRepo.UserExists(userId);

                if (!dbUser)
                {
                    // Returning a BadRequest response for an unknown error
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Unknown error occurred"
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
        [HttpPatch("profile/current-user/next-of-kin")]
        public async Task<IActionResult> UpdateNextofKin(NextOfKinDto nextOfKin)
        {
            try
            {
                string userId = GetUserId();
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Retrieving the next-of-kin information based on the provided UserId
                var dbNextOfKin = await uow.UserRepo.GetUserNextOfKin(userId);

                if (dbNextOfKin == null)
                {
                    // Returning a BadRequest response for an unknown error
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Unknown error occurred" 
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
        [HttpPost("profile/current-user/security")]
        public async Task<IActionResult> UpdateSecurityInfo(SecurityDto securityDto)
        {
            try
            {
                string userId = GetUserId();
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                // Checking if the user exists based on the provided UserId
                var dbUser = await uow.UserRepo.UserExists(userId);

                // If the user does not exist, return a BadRequest response for an unknown error
                if (!dbUser)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Unknown error occurred"
                    );
                    return BadRequest(errorResponse);
                }

                // Attempt to update the security information for the user
                var result = await uow.UserRepo.UpdateSecurity(securityDto, userId);

                // If the update operation fails, return a BadRequest response for an unknown error
                if (!result)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Unknown error occurred"
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

        /// <summary>
        /// Endpoint that takes care of kyc verification
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("profile/current-user/set-kyc")]
        public async Task<ActionResult> SetKYC(KYCRequest kyc)
        {
            try
            {
                string userId = GetUserId();
                // Checking if the incoming model is valid
                if (!ModelState.IsValid)
                {
                    // Returning a BadRequest response with details of invalid ModelState
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }

                var kycInfo = await uow.UserRepo.GetKycInfo(userId);
                if (kycInfo == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Unknown error occurred"
                   );
                    return BadRequest(errorResponse);
                }

                var idType = await uow.UserRepo.GetIdType(kyc.IdTypeId);

                var file = await photoService.UploadPhoto(kyc.IdImage);

                kycInfo.IdType = idType.Name;
                kycInfo.CanExpire = idType.Expires;
                kycInfo.ImageName = file?[0] ?? "";
                kycInfo.ImageUrl = file?[1] ?? "";
                kycInfo.UpdatedAt = DateTime.UtcNow;
                mapper.Map(kyc, kycInfo);
                await uow.SaveAsync();
                var response = new MessageResponse
                {
                    Successful = true,
                    Message = "Kyc Verification is in progress"
                };
                return Ok(response);

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
