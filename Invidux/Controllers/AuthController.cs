using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Dtos;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Invidux_Domain.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Invidux_Api.Controllers
{
    /// <summary>
    /// Authentication controller
    /// Handles authentication related services
    /// </summary>

    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitofWork uow;
        public AuthController(IUnitofWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Endpoint for user registration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<UserRegistrationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDTO user)
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

                // Checking if the user has agreed to terms and conditions
                if (!user.AgreeToTerm)
                {
                    // Returning a BadRequest response indicating the user must agree to terms
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User must agree to terms and conditions." }
                    );
                    return BadRequest(errorResponse);
                }

                // Checking if the user already exists
                var userExists = await uow.RegistrationRepo.UserAlreadyExists(user.Email);
                if (userExists != null)
                {
                    if (userExists == RegistrationStatus.Restricted.ToString())
                    {
                        // Returning a BadRequest response indicating the user is restricted
                        var errorResponse = new ErrorResponseDTO(
                            HttpStatusCode.BadRequest,
                            new List<string> { "User has been restricted" }
                        );
                        return BadRequest(errorResponse);
                    }
                    else if (userExists == RegistrationStatus.Active.ToString())
                    {
                        // Returning a BadRequest response indicating the user is already registered
                        var errorResponse = new ErrorResponseDTO(
                            HttpStatusCode.BadRequest,
                            new List<string> { "User already registered" }
                        );
                        return BadRequest(errorResponse);
                    }
                    else
                    {
                        // Asking the user to verify the account
                        return StatusCode(StatusCodes.Status203NonAuthoritative, "Please verify your account.");
                    }
                }

                // Calling registration logic using the UnitOfWork
                var result = await uow.RegistrationRepo.Register(user);

                if (result == null)
                {
                    // Returning a BadRequest response indicating registration failure
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Registration failed." }
                    );
                    return BadRequest(errorResponse);
                }

                // Registration was successful; returning success response with registration details
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
                // Handling exceptions and logging errors
                // Returning a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to verify user registration email using otp
        /// </summary>
        /// <param name="otp"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<UserRegistrationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyToken(VerifyOtp otp)
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

                // Verifying the OTP (One-Time Password) using UnitOfWork
                var result = await uow.RegistrationRepo.VerifyOtp(otp.Otp);

                if (result != null && result == RegistrationStatus.Restricted.ToString())
                {
                    // Returning a BadRequest response indicating the user is restricted
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User has been restricted" }
                    );
                    return BadRequest(errorResponse);
                }

                // Returning a success response for a successful verification
                var response = new Response<UserRegistrationDto>
                {
                    Successful = true,
                    Message = "Verification successful."
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handling exceptions and logging errors
                Console.WriteLine("Error", ex.Message);

                // Returning a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to request for new otp if previous otp expires
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("request-otp")]
        public async Task<IActionResult> ResendToken(ResendOtpRequest user)
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

                // Requesting to resend OTP using the provided email
                var response = await uow.RegistrationRepo.ResendOtp(user.Email);

                if (response == -1)
                {
                    // Returning a BadRequest response indicating the user is restricted
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "User has been restricted." }
                    );
                    return BadRequest(errorResponse);
                }

                // Returning a success response with the response from ResendOtp method
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handling exceptions and logging errors
                // Returning a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to complete user registration after verifying email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<UserRegistrationDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("complete-registration")]
        public async Task<IActionResult> CompleteRegistration(CompleteRegistration user)
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

                // Completing user registration using the provided details
                var result = await uow.RegistrationRepo.CompleteRegistration(user);

                if (!result)
                {
                    // Returning a BadRequest response indicating registration failure
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Registration failed." }
                   );
                    return BadRequest(errorResponse);
                }

                // Returning a success response for a successful registration completion
                var response = new Response<UserRegistrationDto>
                {
                    Successful = true,
                    Message = "Registration successful."
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                // Handling exceptions and logging errors
                // Returning a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to login, sends an otp to email if 
        /// two step verification is setup or respond with JWT token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO user)
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

                // Initializing a response object for the login attempt
                var response = new Response<LoginResponse>();

                // Authenticating the user credentials
                var userExists = await uow.UserRepo.Authenticate(user.Username, user.Password);

                if (userExists == null)
                {
                    // Returning a BadRequest response indicating the user is not registered
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
                        // Returning a BadRequest response indicating the user is restricted
                        var errorResponse = new ErrorResponseDTO(
                            HttpStatusCode.BadRequest,
                            new List<string> { "User has been restricted" }
                        );
                        return BadRequest(errorResponse);
                    }
                    else if (userExists.Status == RegistrationStatus.Pending)
                    {
                        // Returning a 203 Non-Authoritative response asking to verify the account
                        return StatusCode(StatusCodes.Status203NonAuthoritative, "Please verify your account.");
                    }
                }

                // Handling scenarios based on two-factor authentication
                if (userExists.TwoFactorEnabled == true)
                {
                    // Providing a response to enable verification token via mail
                    response.Successful = true;
                    response.Message = "Please check your mail for verification token";
                    response.Data = userExists;
                    return Ok(response);
                }

                // If login is successful, set response data and return an Ok response
                response.Successful = true;
                response.Message = "Login Successful";
                response.Data = userExists;

                // Set the JWT token in the response header
                Response.Headers.Add("Authorization", $"Bearer {userExists.Token}");
                return Ok(response);
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
        /// Endpoint to verify two step login
        /// </summary>
        /// <param name="otp"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("verify-otp")]
        public async Task<IActionResult> Verify2Step(VerifyOtp otp)
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

                // Verifying the OTP (Two-step verification) using the provided OTP
                var result = await uow.UserRepo.VerifyOtp(otp.Otp);

                if (result == null)
                {
                    // Handle the case when registration fails
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Unknown error occured" }
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
