using AutoMapper;
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
        private readonly IMapper mapper;
        public PortfolioController(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// This endpoint returns token within the user portfolio
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PortfolioTokens>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("portfolio/current-user")]
        public async Task<IActionResult> GetPortfolio()
        {
            try
            {
                string userId = GetUserId();
                var portfolio = await uow.PortfolioRepo.GetPortfolio(userId);
                if (portfolio == null)
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

        /// <summary>
        /// This endpoint gets a specific user token by its id
        /// It returns the token information along with, annual yield and transactions attached
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<PortfolioToken>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("portfolio/current-user/{id}")]
        public async Task<IActionResult> GetPortfolioToken(int id)
        {
            try
            {
                string userId = GetUserId();
                var portfolioTkn = await uow.PortfolioRepo.GetPortfolioToken(id, userId);
                if (portfolioTkn == null)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                         "Token not found"
                    );
                    return BadRequest(errorResponse);
                }

                var response = new Response<PortfolioToken>
                {
                    Successful = true,
                    Message = "success",
                    Data = portfolioTkn
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
        /// This endpoints gets and returns portfolio transactions
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(DataResponseArrayDTO<TransactionListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("portfolio/current-user/transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var userId = GetUserId();
                var transactions = await uow.PortfolioRepo.GetTransactions(userId);
                if (transactions == null)
                {
                    var errorResponse = new ErrorResponseDTO(HttpStatusCode.BadRequest, "Invalid operation");
                    return BadRequest(errorResponse);
                }
                var txnDto = mapper.Map<IEnumerable<PortfolioTransaction>>(transactions);
                
                /*var user = new PortfolioTransactions
                {
                    Id = userId,
                    Transactions = txnDto
                };*/
                var response = new DataResponseArrayDTO<PortfolioTransaction>(
                    txnDto,
                    txnDto.Count(), // You can replace this count with the actual count needed
                    page: 1, // Specify the page number
                    size: 20, // Specify the size
                    statusCode: HttpStatusCode.OK,
                    isSuccess: true
                );

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
