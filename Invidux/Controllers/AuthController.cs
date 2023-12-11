using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Dtos;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Utilities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Net;

namespace Invidux_Api.Controllers
{

    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
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
        [HttpPost("register")]
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
                    Message = "Please check your mail for verification code.",
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
        [HttpPost("verify-email")]
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
                Console.WriteLine("Error", ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("request-otp")]
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
        [HttpPost("complete-registration")]
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

        [ProducesResponseType(typeof(Response<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var response = new Response<LoginResponse>();
                var userExists = await uow.UserRepo.Authenticate(user.Username, user.Password);
                if (userExists == null)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User not registered" }
                    );
                    return BadRequest(errorResponse);
                }
                else
                {
                    if (userExists.Status == RegistrationStatus.Restricted)
                    {
                        // Handle the case when registration fails
                        var errorResponse = new ErrorResponseDTO(
                            HttpStatusCode.BadRequest,
                            new List<string> { "User has been restricted" }
                        );
                        return BadRequest(errorResponse);
                    }

                    else if (userExists.Status == RegistrationStatus.Pending)
                    {
                        return StatusCode(StatusCodes.Status203NonAuthoritative, "Please verify your account.");
                    }
                }
                if (userExists.TwoFactorEnabled == true)
                {
                    response.Successful = true;
                    response.Message = "Please check your mail for verification token";
                    response.Data = userExists;
                    return Ok(response);
                }
                response.Successful = true;
                response.Message = "Login Succesfull";
                response.Data = userExists;
                // Set the JWT token in the response header
                Response.Headers.Add("Authorization", $"Bearer {userExists.Token}");
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                // You can also return an appropriate error response
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("verify-otp")]
        public async Task<IActionResult> Verify2Step(VerifyOtp otp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ModelStateErrorResponseDTO(HttpStatusCode.BadRequest,
                        ModelState));
                }
                var result = await uow.UserRepo.VerifyOtp(otp.Otp);
                if(result == null)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown" }
                    );
                    return BadRequest(errorResponse);
                }
                if (result != null && result.Status == RegistrationStatus.Restricted)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User has been restricted" }
                    );
                    return BadRequest(errorResponse);
                }
                // Registration was successful; you can return a success response or any other data
                var response = new Response<LoginResponse>
                {
                    Successful = true,
                    Message = "Login successful.",
                    Data = result,
                };
                // Set the JWT token in the response header
                Response.Headers.Add("Authorization", $"Bearer {result.Token}");
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
