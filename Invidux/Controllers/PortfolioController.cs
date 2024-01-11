using Invidux_Core.Repository.Interfaces;
using Invidux_Data.Dtos;
using Invidux_Data.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Invidux_Api.Controllers
{
    /// <summary>
    /// This controller takes care or portfolio related endpoints
    /// </summary>
    public class PortfolioController : BaseController
    {
        private readonly IUnitofWork uow;
        public PortfolioController(IUnitofWork uow) 
        { 
            this.uow = uow;
        }

        /// <summary>
        /// This endpoint returns token within the user portfolio
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PortfolioTokens>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("/portfolio/current-user")]
        public async Task<IActionResult> GetPortfolio()
        {
            try
            {
                string userId = GetUserId();
                var portfolio = await uow.PortfolioRepo.GetPortfolio(userId);
                if(portfolio == null)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                         "portfolio not found"
                    );
                    return BadRequest(errorResponse);
                }

                var response = new Response<PortfolioTokens>
                {
                   Successful = true,
                   Message = "success",
                   Data = portfolio
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
