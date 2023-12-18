using AutoMapper;
using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Context;
using Invidux_Data.Dtos;
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Invidux_Api.Controllers
{
    /// <summary>
    /// This controller takes care of user wallet functionalities
    /// </summary>
    [Route("api/v1/wallet")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly InviduxDBContext dc;
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;
        public WalletController(InviduxDBContext dc, IUnitofWork uow, IMapper mapper) 
        { 
            this.dc = dc;
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Endpoint to fetch user wallet by user Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<WalletResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status206PartialContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("current-user/{userId}")]
        public async Task<IActionResult> GetUserWallet(string userId)
        {
            try
            {
                var wallet = await uow.WalletRepo.GetWalletAsync(userId);
                if (wallet == null)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Wallet not found" }
                    );
                    return BadRequest(errorResponse);
                }
                if (!wallet.Active) 
                {
                    var response203 = new MessageResponse
                    {
                        Successful = true,
                        Message = "You need to activate your Wallet"
                    };
                    return StatusCode(StatusCodes.Status203NonAuthoritative, response203);
                }
                if(!wallet.PinSet) 
                {
                    var response206 = new MessageResponse
                    {
                        Successful = true,
                        Message = "You need to set your wallet pin"
                    };
                    return StatusCode(StatusCodes.Status206PartialContent, response206);
                }
                var walletDto = mapper.Map<WalletResponseDto>(wallet);
                var response = new Response<WalletResponseDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = walletDto
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
        /// Endpoint to activate user wallet
        /// </summary>
        /// <param name="walletDto"></param>
        /// <returns></returns>
        [HttpPatch("current-user/activate/{userId}")]
        public async Task<IActionResult> ActivateWallet(ActivateWalletDto walletDto, string userId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to set wallet pin
        /// </summary>
        /// <param name="setWalletPin"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch("current-user/set-wallet-pin/{userId}")]
        public async Task<IActionResult> SetWalletPin(SetWalletPinDto setWalletPin, string userId)
        {
            try
            {
                var setPin = await uow.WalletRepo.SetWalletPin(setWalletPin, userId);
                if (!setPin)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        new List<string> { "Invalid old pin" }
                    );
                    return BadRequest(errorResponse);
                }
                var response = new MessageResponse
                {
                    Successful = true,
                    Message = "success",
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
