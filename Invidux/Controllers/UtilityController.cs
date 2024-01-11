using AutoMapper;
using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Dtos.Response;
using Invidux_Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;

namespace Invidux_Api.Controllers
{
    /// <summary>
    /// Utitlities controlloer
    /// Handles utility related services
    /// </summary>
    [Route("api/v1/utilities")]
    [ApiController]
    //[Authorize]
    public class UtilityController : ControllerBase
    {
        /// <summary>
        /// Add injected services
        /// </summary>

        // Declare a private field to hold a reference to the Unit of Work (uow)
        private readonly IUnitofWork uow;

        // Declare a private field to hold a reference to the AutoMapper (mapper)
        private readonly IMapper mapper;

        // Constructor for the UtilityController class, which is used for dependency injection
        public UtilityController(IUnitofWork uow, IMapper mapper)
        {
            // Initialize the private field 'uow' with the provided Unit of Work instance
            this.uow = uow;

            // Initialize the private field 'mapper' with the provided AutoMapper instance
            this.mapper = mapper;
        }

        /// <summary>
        /// Enpoint to get list of all roles
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                
                // Attempt to retrieve a list of roles asynchronously
                var roles = await uow.UtitlityRepo.GetRolesAsync();

                // Check if no roles were retrieved
                if (roles == null)
                {
                    // Create an error response with a 400 Bad Request status and a message indicating no roles were created
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "No roles created" 
                    );
                    return BadRequest(errorResponse);
                }

                // Map the retrieved roles to RoleDto objects
                var rolesDto = mapper.Map<IEnumerable<RoleDto>>(roles);

                // Create a successful response with a 200 OK status, success message, and the mapped roles
                var response = new ResponseArrayDTO<RoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = rolesDto,
                };
                // Return the successful response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors, then return a 500 Internal Server Error response with the error message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a particular role by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles/{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            try
            {
                // Attempt to retrieve a role by its ID asynchronously
                var role = await uow.UtitlityRepo.GetRoleByIdAsync(id);

                // Check if the role was not found
                if (role == null)
                {
                    // Create an error response with a 400 Bad Request status and a message indicating the role was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Role not found"
                    );
                    return BadRequest(errorResponse);
                }

                // Map the retrieved role to a RoleDto object
                var roleDto = mapper.Map<RoleDto>(role);

                // Create a successful response with a 200 OK status, success message, and the mapped role
                var response = new Response<RoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = roleDto
                };

                // Return the successful response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors, then return a 500 Internal Server Error response with the error message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get subroles of a particular role provided the id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<SubRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles/{roleId}/roles-sub")]
        public async Task<IActionResult> GetRolesSub(string roleId)
        {
            try
            {
                // Attempt to retrieve sub-roles for a specific role ID asynchronously
                var subRoles = await uow.UtitlityRepo.GetRoleSubRolesAsync(roleId);

                // Check if no sub-roles were retrieved or the role was not found
                if (subRoles == null)
                {
                    // Create an error response with a 400 Bad Request status and a message indicating the role was not found or sub-roles not created
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Role not found or Sub Roles not created"
                    );
                    return BadRequest(errorResponse);
                }

                // Map the retrieved sub-roles to SubRoleDto objects
                var subRoleDto = mapper.Map<IEnumerable<SubRoleDto>>(subRoles);

                // Create a successful response with a 200 OK status, success message, and the mapped sub-roles
                var response = new ResponseArrayDTO<SubRoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = subRoleDto
                };

                // Return the successful response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors, then return a 500 Internal Server Error response with the error message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get subroles
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<SubRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles-sub")]
        public async Task<IActionResult> GetSubRoles()
        {
            try
            {
                // Attempt to retrieve all sub-roles asynchronously
                var subRoles = await uow.UtitlityRepo.GetSubRolesAsync();

                // Check if no sub-roles were retrieved
                if (subRoles == null)
                {
                    // Create an error response with a 400 Bad Request status and a message indicating that sub-roles were not created
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Sub Roles not created"
                    );
                    return BadRequest(errorResponse);
                }

                // Map the retrieved sub-roles to SubRoleDto objects
                var subRoleDto = mapper.Map<IEnumerable<SubRoleDto>>(subRoles);

                // Create a successful response with a 200 OK status, success message, and the mapped sub-roles
                var response = new ResponseArrayDTO<SubRoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = subRoleDto
                };

                // Return the successful response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors, then return a 500 Internal Server Error response with the error message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a single subrole by id
        /// </summary>
        /// <param name="subRoleId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<SubRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles-sub/{subRoleId}")]
        public async Task<IActionResult> GetSubRoleById(string subRoleId)
        {
            try
            {
                // Attempt to retrieve a sub-role by its ID asynchronously
                var subRole = await uow.UtitlityRepo.GetSubRoleAsync(subRoleId);

                // Check if the sub-role was not found
                if (subRole == null)
                {
                    // Create an error response with a 400 Bad Request status and a message indicating that the sub-role was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Sub Role not found"
                    );
                    return BadRequest(errorResponse);
                }

                // Map the retrieved sub-role to a SubRoleDto object
                var subRoleDto = mapper.Map<SubRoleDto>(subRole);

                // Create a successful response with a 200 OK status, success message, and the mapped sub-role
                var response = new Response<SubRoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = subRoleDto
                };

                // Return the successful response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors, then return a 500 Internal Server Error response with the error message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get all kyc statuses
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<KycStatusDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-status")]
        public async Task<IActionResult> GetKycStatuses()
        {
            try
            {
                // Attempt to retrieve KYC statuses asynchronously
                var kycStatus = await uow.UtitlityRepo.GetKycStatusesAsync();

                // Check if KYC statuses were not found
                if (kycStatus == null)
                {
                    // Create an error response with a 400 Bad Request status and a message indicating that KYC statuses were not found
                    var errorResponse = new ErrorResponseDTO(
                      HttpStatusCode.BadRequest,
                      "Kyc Statuses not created"
                    );
                    return BadRequest(errorResponse);
                }

                // Map the retrieved KYC statuses to KycStatusDto objects
                var kycDto = mapper.Map<IEnumerable<KycStatusDto>>(kycStatus);

                // Create a successful response with a 200 OK status, success message, and the mapped KYC statuses
                var response = new ResponseArrayDTO<KycStatusDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = kycDto
                };

                // Return the successful response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors, then return a 500 Internal Server Error response with the error message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a particular kyc status by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<KycStatusDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-status/{id}")]
        public async Task<IActionResult> GetKycStatus(int id)
        {
            try
            {
                // Attempt to retrieve KYC status using the provided ID
                var status = await uow.UtitlityRepo.GetKycStatusAsync(id);

                // Check if the status is null (indicating not found)
                if (status == null)
                {
                    // Create an error response indicating KYC status not found
                    var errorResponse = new ErrorResponseDTO(
                     HttpStatusCode.BadRequest,
                     "Kyc Status not found"
                    );

                    // Return a BadRequest with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved status to a DTO (Data Transfer Object)
                var statusDto = mapper.Map<KycStatusDto>(status);

                // Create a successful response with the status DTO
                var response = new Response<KycStatusDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = statusDto
                };

                // Return the successful response
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Endpoint to get all kyc levels
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<KycLevelDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-level")]
        public async Task<IActionResult> GetKycLevels()
        {
            try
            {
                // Asynchronously retrieve KYC levels from the repository
                var level = await uow.UtitlityRepo.GetKycLevelsAsync();

                // Check if the retrieved levels are null (indicating they haven't been created)
                if (level == null)
                {
                    // Create an error response indicating KYC levels are not created
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Kyc levels not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved levels to a collection of Data Transfer Objects (DTOs)
                var levelDto = mapper.Map<IEnumerable<KycLevelDto>>(level);

                // Create a response object to encapsulate the successful retrieval of data
                var response = new ResponseArrayDTO<KycLevelDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = levelDto
                };

                // Return an Ok status with the response object
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the operation

                // Logging of the exception should be done here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Endpoint to get a particular kyc level by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<KycLevelDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-level/{id}")]
        public async Task<IActionResult> GetKyclevel(int id)
        {
            try
            {
                // Attempt to retrieve a specific KYC level using the provided ID
                var level = await uow.UtitlityRepo.GetKycLevelAsync(id);

                // Check if the retrieved level is null, indicating it wasn't found
                if (level == null)
                {
                    // Create an error response indicating the specified KYC level was not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Kyc level not found"
                    );

                    // Return a BadRequest with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved level to a Data Transfer Object (DTO)
                var levelDto = mapper.Map<KycLevelDto>(level);

                // Create a successful response including the mapped level DTO
                var response = new Response<KycLevelDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = levelDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// End point to get all types of kyc idcards
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<KycIdCardDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-idcard")]
        public async Task<IActionResult> GetKycIdCards()
        {
            try
            {
                // Asynchronously retrieve a list of KYC ID cards
                var idCards = await uow.UtitlityRepo.GetKycIdCardsAsync();

                // Check if the retrieved list is null, indicating no ID cards were created
                if (idCards == null)
                {
                    // Create an error response indicating the absence of KYC ID cards
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Kyc id cards not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved ID cards to a collection of Data Transfer Objects (DTOs)
                var idCardDto = mapper.Map<IEnumerable<KycIdCardDto>>(idCards);

                // Create a successful response with the mapped ID card DTOs
                var response = new ResponseArrayDTO<KycIdCardDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = idCardDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a specific kyc idcard type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<KycIdCardDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-idcard/{id}")]
        public async Task<IActionResult> GetKycIdCard(int id)
        {
            try
            {
                // Asynchronously retrieve a specific KYC ID card using the provided ID
                var idCard = await uow.UtitlityRepo.GetKycIdCardAsync(id);

                // Check if the retrieved ID card is null, indicating it wasn't found
                if (idCard == null)
                {
                    // Create an error response indicating the specified KYC ID card was not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Kyc id card not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved ID card to a Data Transfer Object (DTO)
                var idCardDto = mapper.Map<KycIdCardDto>(idCard);

                // Create a successful response including the mapped ID card DTO
                var response = new Response<KycIdCardDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = idCardDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get all security verification types
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<SecurityTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/security-type")]
        public async Task<IActionResult> GetSecurityTypes()
        {
            try
            {
                // Asynchronously retrieve a list of security types
                var types = await uow.UtitlityRepo.GetSecurityTypesAsync();

                // Check if the retrieved list is null, indicating no security types were created
                if (types == null)
                {
                    // Create an error response indicating the absence of security types
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Security types not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved types to a collection of Data Transfer Objects (DTOs)
                var typeDto = mapper.Map<IEnumerable<SecurityTypeDto>>(types);

                // Create a successful response with the mapped security type DTOs
                var response = new ResponseArrayDTO<SecurityTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a particula security verification type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<SecurityTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/security-type/{id}")]
        public async Task<IActionResult> GetSecurityType(int id)
        {
            try
            {
                // Asynchronously retrieve a specific security type using the provided ID
                var type = await uow.UtitlityRepo.GetSecurityTypeAsync(id);

                // Check if the retrieved type is null, indicating it wasn't found
                if (type == null)
                {
                    // Create an error response indicating the specified security type was not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Security type not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved type to a Data Transfer Object (DTO)
                var typeDto = mapper.Map<SecurityTypeDto>(type);

                // Create a successful response including the mapped type DTO
                var response = new Response<SecurityTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Enpoint to get all two factor cover types
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<TwoFactorCoverDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-cover")]
        public async Task<IActionResult> Get2faCovers()
        {
            try
            {
                // Asynchronously retrieve a collection of 2FA covers
                var covers = await uow.UtitlityRepo.GetTwoFactorCoversAsync();

                // Check if the retrieved collection is null, indicating no 2FA covers were created
                if (covers == null)
                {
                    // Create an error response indicating the absence of 2FA covers
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Two factor covers not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved covers to a collection of Data Transfer Objects (DTOs)
                var coverDto = mapper.Map<IEnumerable<TwoFactorCoverDto>>(covers);

                // Create a successful response with the mapped 2FA cover DTOs
                var response = new ResponseArrayDTO<TwoFactorCoverDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = coverDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a partcular two factor cover by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TwoFactorCoverDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-cover/{id}")]
        public async Task<IActionResult> Get2faCover(int id)
        {
            try
            {
                // Asynchronously retrieve a specific 2FA cover using the provided ID
                var cover = await uow.UtitlityRepo.GetTwoFactorCoverAsync(id);

                // Check if the retrieved 2FA cover is null, indicating it wasn't found
                if (cover == null)
                {
                    // Create an error response indicating the specified 2FA cover was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                        "Two factor cover not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved cover to a Data Transfer Object (DTO)
                var coverDto = mapper.Map<TwoFactorCoverDto>(cover);

                // Create a successful response including the mapped cover DTO
                var response = new Response<TwoFactorCoverDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = coverDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Endpoint to get all types of two factor authentication medium
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<TwoFactorTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-type")]
        public async Task<IActionResult> Get2faTypes()
        {
            try
            {
                // Asynchronously retrieve a list of 2FA types
                var types = await uow.UtitlityRepo.GetTwoFactorTypes();

                // Check if the retrieved list is null, indicating no 2FA types were created
                if (types == null)
                {
                    // Create an error response indicating the absence of 2FA types
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Two factor types not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved types to a collection of Data Transfer Objects (DTOs)
                var typeDto = mapper.Map<IEnumerable<TwoFactorTypeDto>>(types);

                // Create a successful response with the mapped 2FA type DTOs
                var response = new ResponseArrayDTO<TwoFactorTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a type of two factor authentication medium by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TwoFactorTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-type/{id}")]
        public async Task<IActionResult> Get2faType(int id)
        {
            try
            {
                // Asynchronously retrieve a specific 2FA type using the provided ID
                var type = await uow.UtitlityRepo.GetTwoFactorTypeAsync(id);

                // Check if the retrieved 2FA type is null, indicating it wasn't found
                if (type == null)
                {
                    // Create an error response indicating the specified 2FA type was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Two factor type not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved type to a Data Transfer Object (DTO)
                var typeDto = mapper.Map<TwoFactorTypeDto>(type);

                // Create a successful response including the mapped type DTO
                var response = new Response<TwoFactorTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get token listing statuses
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<TokenListingStatusDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/listing-status")]
        public async Task<IActionResult> GetListingStatuses()
        {
            try
            {
                // Asynchronously retrieve a list of token listing statuses
                var statuses = await uow.UtitlityRepo.GetListingStatusesAsync();

                // Check if the retrieved list is null, indicating no token listing statuses were created
                if (statuses == null)
                {
                    // Create an error response indicating the absence of token listing statuses
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Token listing statuses not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved statuses to a collection of Data Transfer Objects (DTOs)
                var statusDto = mapper.Map<IEnumerable<TokenListingStatusDto>>(statuses);

                // Create a successful response with the mapped token listing status DTOs
                var response = new ResponseArrayDTO<TokenListingStatusDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = statusDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpooin to get a particular token listing status by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TokenListingStatusDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/listing-status/{id}")]
        public async Task<IActionResult> GetListingStatus(int id)
        {
            try
            {
                // Asynchronously retrieve a specific token listing status using the provided ID
                var status = await uow.UtitlityRepo.GetListingStatusAsync(id);

                // Check if the retrieved status is null, indicating it wasn't found
                if (status == null)
                {
                    // Create an error response indicating the specified token listing status was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Token listing status not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved status to a Data Transfer Object (DTO)
                var statusDto = mapper.Map<TokenListingStatusDto>(status);

                // Create a successful response including the mapped status DTO
                var response = new Response<TokenListingStatusDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = statusDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get all property classes
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<PropertyClassDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/property-class")]
        public async Task<IActionResult> GetPropClasses()
        {
            try
            {
                // Asynchronously retrieve a list of property classes
                var propClasses = await uow.UtitlityRepo.GetPropertyClassesAsync();

                // Check if the retrieved list is null, indicating no property classes were created
                if (propClasses == null)
                {
                    // Create an error response indicating the absence of property classes
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Property classes not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved property classes to a collection of Data Transfer Objects (DTOs)
                var classDto = mapper.Map<IEnumerable<PropertyClassDto>>(propClasses);

                // Create a successful response with the mapped property class DTOs
                var response = new ResponseArrayDTO<PropertyClassDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = classDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a specific property class by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PropertyClassDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/property-class/{id}")]
        public async Task<IActionResult> GetPropClass(int id)
        {
            try
            {
                // Asynchronously retrieve a specific property class using the provided ID
                var propClass = await uow.UtitlityRepo.GetPropertyClassAsync(id);

                // Check if the retrieved property class is null, indicating it wasn't found
                if (propClass == null)
                {
                    // Create an error response indicating that the specified property class was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Property class not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved property class to a Data Transfer Object (DTO)
                var classDto = mapper.Map<PropertyClassDto>(propClass);

                // Create a successful response including the mapped property class DTO
                var response = new Response<PropertyClassDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = classDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get all investment types
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<InvestmentTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/investment-type")]
        public async Task<IActionResult> GetInvestTypes()
        {
            try
            {
                // Asynchronously retrieve a list of investment types
                var types = await uow.UtitlityRepo.GetInvestmentTypesAsync();

                // Check if the retrieved list is null, indicating no investment types were created
                if (types == null)
                {
                    // Create an error response indicating the absence of investment types
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Investment types not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved investment types to a collection of Data Transfer Objects (DTOs)
                var typeDto = mapper.Map<IEnumerable<InvestmentTypeDto>>(types);

                // Create a successful response with the mapped investment type DTOs
                var response = new ResponseArrayDTO<InvestmentTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a specific investment type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<InvestmentTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/investment-type/{id}")]
        public async Task<IActionResult> GetInvestType(int id)
        {
            try
            {
                // Asynchronously retrieve a specific investment type using the provided ID
                var type = await uow.UtitlityRepo.GetInvestmentTypeAsync(id);

                // Check if the retrieved investment type is null, indicating it wasn't found
                if (type == null)
                {
                    // Create an error response indicating that the specified investment type was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Investment type not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved investment type to a Data Transfer Object (DTO)
                var typeDto = mapper.Map<InvestmentTypeDto>(type);

                // Create a successful response including the mapped investment type DTO
                var response = new Response<InvestmentTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get all token transaction types
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<TokenTransactionTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/transaction-type")]
        public async Task<IActionResult> GetTokenTransactTypes()
        {
            try
            {
                // Asynchronously retrieve a list of token transaction types
                var types = await uow.UtitlityRepo.GetTokenTransactionTypes();

                // Check if the retrieved list is null, indicating no token transaction types were created
                if (types == null)
                {
                    // Create an error response indicating the absence of token transaction types
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Token transaction types not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved token transaction types to a collection of Data Transfer Objects (DTOs)
                var typeDto = mapper.Map<IEnumerable<TokenTransactionTypeDto>>(types);

                // Create a successful response with the mapped token transaction type DTOs
                var response = new ResponseArrayDTO<TokenTransactionTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a specific token transaction type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TokenTransactionTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/transaction-type/{id}")]
        public async Task<IActionResult> GetTokenTransactType(int id)
        {
            try
            {
                // Asynchronously retrieve a specific token transaction type using the provided ID
                var type = await uow.UtitlityRepo.GetTokenTransactionType(id);

                // Check if the retrieved token transaction type is null, indicating it wasn't found
                if (type == null)
                {
                    // Create an error response indicating that the specified token transaction type was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Token Transaction type not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved token transaction type to a Data Transfer Object (DTO)
                var typeDto = mapper.Map<TokenTransactionTypeDto>(type);

                // Create a successful response including the mapped token transaction type DTO
                var response = new Response<TokenTransactionTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get all transaction types
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<TransactionTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/transaction-type")]
        public async Task<IActionResult> GetTransactTypes()
        {
            try
            {
                // Asynchronously retrieve a list of transaction types
                var types = await uow.UtitlityRepo.GetTransactionTypesAsync();

                // Check if the retrieved list is null, indicating no transaction types were created
                if (types == null)
                {
                    // Create an error response indicating the absence of transaction types
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Transaction types not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved transaction types to a collection of Data Transfer Objects (DTOs)
                var typeDto = mapper.Map<IEnumerable<TransactionTypeDto>>(types);

                // Create a successful response with the mapped transaction type DTOs
                var response = new ResponseArrayDTO<TransactionTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a specific transaction type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TransactionTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/transaction-type/{id}")]
        public async Task<IActionResult> GetTransactType(int id)
        {
            try
            {
                // Asynchronously retrieve a specific transaction type using the provided ID
                var type = await uow.UtitlityRepo.GetTransactionTypeAsync(id);

                // Check if the retrieved transaction type is null, indicating it wasn't found
                if (type == null)
                {
                    // Create an error response indicating that the specified transaction type was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Transaction type not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved transaction type to a Data Transfer Object (DTO)
                var typeDto = mapper.Map<TransactionTypeDto>(type);

                // Create a successful response including the mapped transaction type DTO
                var response = new Response<TransactionTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Endpoint to get all payment methods
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<PaymentMethodDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/payment-method")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            try
            {
                // Asynchronously retrieve a list of payment methods
                var methods = await uow.UtitlityRepo.GetPaymentMethodsAsync();

                // Check if the retrieved list is null, indicating no payment methods were created
                if (methods == null)
                {
                    // Create an error response indicating the absence of payment methods
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Payment methods not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved payment methods to a collection of Data Transfer Objects (DTOs)
                var methodDto = mapper.Map<IEnumerable<PaymentMethodDto>>(methods);

                // Create a successful response with the mapped payment method DTOs
                var response = new ResponseArrayDTO<PaymentMethodDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = methodDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// Endpoint to get a specific paymenth method by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PaymentMethodDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/payment-method/{id}")]
        public async Task<IActionResult> GetPaymentMethod(int id)
        {
            try
            {
                // Asynchronously retrieve a specific payment method using the provided ID
                var method = await uow.UtitlityRepo.GetPaymentMethodAsync(id);

                // Check if the retrieved payment method is null, indicating it wasn't found
                if (method == null)
                {
                    // Create an error response indicating that the specified payment method was not found
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Payment method not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }

                // Map the retrieved payment method to a Data Transfer Object (DTO)
                var methodDto = mapper.Map<PaymentMethodDto>(method);

                // Create a successful response including the mapped payment method DTO
                var response = new Response<PaymentMethodDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = methodDto
                };

                // Return the successful response with OK status
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get all countries
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseArrayDTO<CountryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("locations/countries")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await uow.UtitlityRepo.GetCountriesAsync();
                if (countries == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Countries not created"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }
                var countriesDto = mapper.Map<IEnumerable<CountryResponse>>(countries);
                var response = new ResponseArrayDTO<CountryResponse>
                {
                    Successful = true,
                    Message= "success",
                    Data = countriesDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to get a specific country by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<CountryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("locations/countries/{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            try
            {
                var country = await uow.UtitlityRepo.GetCountryAsync(id);
                if (country == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Country not found"
                    );

                    // Return a BadRequest status with the error response
                    return BadRequest(errorResponse);
                }
                var countryDto = mapper.Map<CountryResponse>(country);
                var response = new Response<CountryResponse>
                {
                    Successful = true,
                    Message = "success",
                    Data = countryDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process

                // Log the exception here (code for logging is not shown)

                // Return a 500 Internal Server Error with the exception message
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
