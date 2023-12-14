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

        private readonly IUnitofWork uow;
        private readonly IMapper mapper;
        public UtilityController(IUnitofWork uow, IMapper mapper) 
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles")]
        public async Task<IActionResult> GetRoles() 
        {
            try
            {
                var roles = await uow.UtitlityRepo.GetRolesAsync();
                if (roles == null) 
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "No roles created" }
                    );
                    return BadRequest(errorResponse);
                }
                var rolesDto = mapper.Map<IEnumerable<RoleDto>>(roles);
                var response = new ResponseArrayDTO<RoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (RoleDto)rolesDto,

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles/{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            try
            {
                var role = await uow.UtitlityRepo.GetRoleByIdAsync(id);
                if (role == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Role not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var roleDto = mapper.Map<RoleDto>(role);
                var response = new Response<RoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = roleDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<SubRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles/{roleId}/roles-sub")]
        public async Task<IActionResult> GetRolesSub(string roleId)
        {
            try
            {
                var subRoles = await uow.UtitlityRepo.GetRoleSubRolesAsync(roleId);
                if (subRoles == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Role not found or Sub Roles not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var subRoleDto = mapper.Map<IEnumerable<SubRoleDto>>(subRoles);
                var response = new ResponseArrayDTO<SubRoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (SubRoleDto)subRoleDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<SubRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles-sub")]
        public async Task<IActionResult> GetSubRoles()
        {
            try
            {
                var subRoles = await uow.UtitlityRepo.GetSubRolesAsync();
                if (subRoles == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Sub Roles not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var subRoleDto = mapper.Map<IEnumerable<SubRoleDto>>(subRoles);
                var response = new ResponseArrayDTO<SubRoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (SubRoleDto)subRoleDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<SubRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/roles-sub/{subRoleId}")]
        public async Task<IActionResult> GetSubRoleById(string subRoleId)
        {
            try
            {
                var subRoles = await uow.UtitlityRepo.GetSubRoleAsync(subRoleId);
                if (subRoles == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Sub Role not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var subRoleDto = mapper.Map<SubRoleDto>(subRoles);
                var response = new Response<SubRoleDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = subRoleDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<KycStatusDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-status")]
        public async Task<IActionResult> GetKycStatuses()
        {
            try
            {
                var kycStatus = await uow.UtitlityRepo.GetKycStatusesAsync();
                if (kycStatus == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                      HttpStatusCode.BadRequest,
                      new List<string> { "Kyc Statuses not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var kycDto = mapper.Map<IEnumerable<KycStatusDto>>(kycStatus);
                var response = new ResponseArrayDTO<KycStatusDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (KycStatusDto)kycDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<KycStatusDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-status/{id}")]
        public async Task<IActionResult> GetKycStatus(int id)
        {
            try
            {
                var status = await uow.UtitlityRepo.GetKycStatusAsync(id);
                if (status == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                     HttpStatusCode.BadRequest,
                     new List<string> { "Kyc Status not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var statusDto = mapper.Map<KycStatusDto>(status);
                var response = new Response<KycStatusDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = statusDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<KycLevelDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-level")]
        public async Task<IActionResult> GetKycLevels()
        {
            try
            {
                var level = await uow.UtitlityRepo.GetKycLevelsAsync();
                if (level == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Kyc levels not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var levelDto = mapper.Map<IEnumerable<KycLevelDto>>(level);
                var response = new ResponseArrayDTO<KycLevelDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (KycLevelDto)levelDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<KycLevelDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-level/{id}")]
        public async Task<IActionResult> GetKyclevel(int id)
        {
            try
            {
                var level = await uow.UtitlityRepo.GetKycLevelAsync(id);

                if (level == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Kyc level not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var levelDto = mapper.Map<KycLevelDto>(level);
                var response = new Response<KycLevelDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = levelDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<KycIdCardDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-idcard")]
        public async Task<IActionResult> GetKycIdCards()
        {
            try
            {
                var idCards = await uow.UtitlityRepo.GetKycIdCardsAsync();
                if (idCards == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Kyc id cards not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var idCardDto = mapper.Map<IEnumerable<KycIdCardDto>>(idCards);
                var response = new ResponseArrayDTO<KycIdCardDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (KycIdCardDto)idCardDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<KycIdCardDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/kyc-idcard/{id}")]
        public async Task<IActionResult> GetKycIdCard(int id)
        {
            try
            {
                var idCard = await uow.UtitlityRepo.GetKycIdCardAsync(id);

                if (idCard == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Kyc id card not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var idCardDto = mapper.Map<KycIdCardDto>(idCard);
                var response = new Response<KycIdCardDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = idCardDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<SecurityTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/security-type")]
        public async Task<IActionResult> GetSecurityTypes()
        {
            try
            {
                var types = await uow.UtitlityRepo.GetSecurityTypesAsync();
                if(types == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Security types not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var typeDto = mapper.Map<IEnumerable<SecurityTypeDto>>(types);
                var response = new ResponseArrayDTO<SecurityTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (SecurityTypeDto)typeDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<SecurityTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/security-type/{id}")]
        public async Task<IActionResult> GetSecurityType(int id)
        {
            try
            {
                var types = await uow.UtitlityRepo.GetSecurityTypeAsync(id);
                if (types == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Security types not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var typeDto = mapper.Map<SecurityTypeDto>(types);
                var response = new Response<SecurityTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<TwoFactorCoverDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-cover")]
        public async Task<IActionResult> Get2faCovers()
        {
            try
            {
                var covers = await uow.UtitlityRepo.GetTwoFactorCoversAsync();
                if (covers == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Two factor covers not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var coverDto = mapper.Map<IEnumerable<TwoFactorCoverDto>>(covers);
                var response = new ResponseArrayDTO<TwoFactorCoverDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (TwoFactorCoverDto)coverDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<TwoFactorCoverDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-cover/{id}")]
        public async Task<IActionResult> Get2faCover(int id)
        {
            try
            {
                var cover = await uow.UtitlityRepo.GetTwoFactorCoverAsync(id);
                if (cover == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Two factor covers not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var coverDto = mapper.Map<TwoFactorCoverDto>(cover);
                var response = new Response<TwoFactorCoverDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = coverDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<TwoFactorTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-type")]
        public async Task<IActionResult> Get2faTypes()
        {
            try
            {
                var types = await uow.UtitlityRepo.GetTwoFactorTypes();
                if (types == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Two factor types not created" }
                    );
                    return BadRequest(errorResponse);
                }
                var typeDto = mapper.Map<IEnumerable<TwoFactorTypeDto>>(types);
                var response = new ResponseArrayDTO<TwoFactorTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (TwoFactorTypeDto)typeDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<TwoFactorTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("users/2fa-type/{id}")]
        public async Task<IActionResult> Get2faType(int id)
        {
            try
            {
                var type = await uow.UtitlityRepo.GetTwoFactorTypeAsync(id);
                if (type == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       new List<string> { "Two factor type not found" }
                    );
                    return BadRequest(errorResponse);
                }
                var typeDto = mapper.Map<TwoFactorTypeDto>(type);
                var response = new Response<TwoFactorTypeDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = typeDto
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/listing-status")]
        public async Task<IActionResult> GetListingStatuses()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/listing-status/{id}")]
        public async Task<IActionResult> GetListingStatus(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/property-class")]
        public async Task<IActionResult> GetPropClasses()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/property-class/{id}")]
        public async Task<IActionResult> GetPropClass(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/investment-type")]
        public async Task<IActionResult> GetInvestTypes()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/investment-type/{id}")]
        public async Task<IActionResult> GetInvestType(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/transaction-type")]
        public async Task<IActionResult> GetTokenTransactTypes()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("tokens/transaction-type/{id}")]
        public async Task<IActionResult> GetTokenTransactType(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/transaction-type")]
        public async Task<IActionResult> GetTransactTypes()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/transaction-type/{id}")]
        public async Task<IActionResult> GetTransactType(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [ProducesResponseType(typeof(ResponseArrayDTO<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/payment-method")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("transactions/payment-method/{id}")]
        public async Task<IActionResult> GetPaymentMethod(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
