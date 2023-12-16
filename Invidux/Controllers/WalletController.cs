using Invidux_Data.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public WalletController() { }

        /// <summary>
        /// Endpoint to fetch user wallet by user Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("current-user/{userId}")]
        public async Task<IActionResult> GetUserWallet(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint to activate user wallet
        /// </summary>
        /// <param name="walletDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("current-user/activate")]
        public async Task<IActionResult> ActivateWallet(ActivateWalletDto walletDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint to set wallet pin
        /// </summary>
        /// <param name="setWalletPin"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IActionResult> SetWalletPin(SetWalletPinDto setWalletPin)
        {
            throw new NotImplementedException();
        }
    }
}
