using Invidux_Core.Repository.Implementations;
using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Dtos;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Invidux_Api.Controllers
{
    
    public class AuthController : BaseController
    {
        private readonly IUnitofWork uow;
        public AuthController(IUnitofWork uow)
        {
            this.uow = uow;
        }

        [ProducesResponseType(typeof(Response<UserRegistrationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("v1/register")]
        public async Task<IActionResult> Register(RegistrationDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                if (!user.AgreeToTerm)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User must agree to terms and conditions." }
                    );
                    return BadRequest(errorResponse);
                }
                var userExists = await uow.RegistrationRepo.UserAlreadyExists(user.Email);
                if (userExists != null)
                {
                    if(userExists == RegistrationStatus.Restricted.ToString())
                    {
                        // Handle the case when registration fails
                        var errorResponse = new ErrorResponseDTO(
                            HttpStatusCode.BadRequest,
                            new List<string> { "User has been restricted" }
                        );
                        return BadRequest(errorResponse);
                    }

                    else if (userExists == RegistrationStatus.Active.ToString())
                    {
                        // Handle the case when registration fails
                        var errorResponse = new ErrorResponseDTO(
                            HttpStatusCode.BadRequest,
                            new List<string> { "User already registered" }
                        );
                        return BadRequest(errorResponse);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status203NonAuthoritative, "Please verify your account.");
                    }
                }
                // Call your registration logic here using the UnitofWork
                var result = await uow.RegistrationRepo.Register(user);

                if (result == null)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Registration failed." }
                    );
                    return BadRequest(errorResponse);
                }

                // Registration was successful; you can return a success response or any other data
                var response = new Response<UserRegistrationDto>
                {
                    Successful = true,
                    Message = "Registration successful.",
                    Data = result         
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

        [ProducesResponseType(typeof(Response<UserRegistrationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("v1/verify-otp")]
        public async Task<IActionResult> VerifyToken(VerifyOtp otp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var result = await uow.RegistrationRepo.VerifyOtp(otp.Otp);
                if (result != null && result == RegistrationStatus.Restricted.ToString())
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User has been restricted" }
                    );
                    return BadRequest(errorResponse);
                }
                // Registration was successful; you can return a success response or any other data
                var response = new Response<UserRegistrationDto>
                {
                    Successful = true,
                    Message = "Verification successful."
                }; 
                return Ok(response);
            }
            catch(Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("v1/request-otp")]
        public async Task<IActionResult> ResendToken(ResendOtpRequest user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var response = await uow.RegistrationRepo.ResendOtp(user.Email);
                if(response == -1)
                {
                    var errorResponse = new ErrorResponseDTO(
                      HttpStatusCode.BadRequest,
                      new List<string> { "User has been restricted." }
                  );
                    return BadRequest(errorResponse);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<UserRegistrationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("v1/complete-registration")]
        public async Task<IActionResult> CompleteRegistration(CompleteRegistration user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var result = await uow.RegistrationRepo.CompleteRegistration(user);
                if (!result)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Registration failed." }
                   );
                    return BadRequest(errorResponse);
                }
                // Registration was successful; you can return a success response or any other data
                var response = new Response<UserRegistrationDto>
                {
                    Successful = true,
                    Message = "Registration successful."
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
