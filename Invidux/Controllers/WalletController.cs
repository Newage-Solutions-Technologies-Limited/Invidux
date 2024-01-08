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
    public class WalletController : BaseController
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
        [HttpGet("wallet/current-user")]
        public async Task<IActionResult> GetUserWallet()
        {
            try
            {
                string userId = GetUserId();
                var wallet = await uow.WalletRepo.GetWalletAsync(userId);
                if (wallet == null)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                         "Wallet not found"
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
                if (!wallet.PinSet)
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
        /// <returns></returns>]
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch("wallet/current-user/activate")]
        public async Task<IActionResult> ActivateWallet(ActivateWalletDto walletDto)
        {
            try
            {
                string userId = GetUserId();
                var result = await uow.WalletRepo.ActivateWallet(walletDto, userId);
                if (!result)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Error activating wallet"
                   );
                    return BadRequest(errorResponse);
                }
                var response = new MessageResponse
                {
                    Successful = true,
                    Message = "Walletc activated successfully",
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
        /// Endpoint to set wallet pin
        /// </summary>
        /// <param name="setWalletPin"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPatch("wallet/current-user/set-wallet-pin")]
        public async Task<IActionResult> SetWalletPin(SetWalletPinDto setWalletPin)
        {
            try
            {
                string userId = GetUserId();
                var setPin = await uow.WalletRepo.SetWalletPin(setWalletPin, userId);
                if (!setPin)
                {
                    // Returning a BadRequest response indicating the user is not found
                    var errorResponse = new ErrorResponseDTO(
                        HttpStatusCode.BadRequest,
                        "Invalid old pin"
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

        /// <summary>
        ///  Endpoint for user to fund their wallet
        /// </summary>
        /// <param name="walletDto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("wallet/current-user/fund")]
        public async Task<IActionResult> FundWallet(FundWalletDto walletDto)
        {
            try
            {
                string userId = GetUserId();
                var result = await uow.WalletRepo.FundWallet(walletDto, userId);
                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Invalid operation"
                   );
                    return BadRequest(errorResponse);
                }
                var resultDto = mapper.Map<TransactionResponse>(result);
                var response = new Response<TransactionResponse>
                {
                    Successful = true,
                    Message = "success",
                    Data = resultDto,
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
        /// Endpoint that handle transfer of funds
        /// </summary>
        /// <param name="tranferFunds"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("wallet/current-user/transfer")]
        public async Task<IActionResult> TransferFund(TranferFundsDto tranferFunds)
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.TransferFunds(tranferFunds, userId);
                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Invalid operation"
                   );
                    return BadRequest(errorResponse);
                }
                var resultDto = mapper.Map<TransactionResponse>(result);
                var response = new Response<TransactionResponse>
                {
                    Successful = true,
                    Message = "success",
                    Data = resultDto,
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
        /// Endpoint to withdraw to bank
        /// Not fully implemented, requires proper setting up of paystack
        /// </summary>
        /// <param name="withdrawTo"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("wallet/current-user/withdraw-to-bank")]
        public async Task<IActionResult> WithdrawToBank(WithdrawToBankDto withdrawTo)
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.WithdrawToBank(withdrawTo, userId);
                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Invalid operation"
                   );
                    return BadRequest(errorResponse);
                }
                var resultDto = mapper.Map<TransactionResponse>(result);
                var response = new Response<TransactionResponse>
                {
                    Successful = true,
                    Message = "success",
                    Data = resultDto,
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [ProducesResponseType(typeof(Response<AccountResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("wallet/current-user/add-withdrawal-accounts")]
        public async Task<IActionResult> AddWithdrawalAccount(AddWithdrawalAccountDto addWithdrawal)
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.AddWithdrawalAccount(addWithdrawal, userId);
                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Invalid operation"
                   );
                    return BadRequest(errorResponse);
                }
                var response = new Response<AccountResponseDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = result,
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
        /// End point to get list of withdrawal account
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<AccountResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("wallet/current-user/withdrawal-accounts")]
        public async Task<IActionResult> GetWithdrawalAccount()
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.GetWithdrawalAccounts(userId);
                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                       HttpStatusCode.BadRequest,
                       "Invalid operation"
                   );
                    return BadRequest(errorResponse);
                }
                var resultDto = mapper.Map<IEnumerable<AccountResponseDto>>(result);
                var response = new Response<AccountResponseDto>
                {
                    Successful = true,
                    Message = "success",
                    Data = (AccountResponseDto)resultDto,
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
        /// This endpoint is to take care of withdrawal to stellar network
        /// It has not being fully implemented
        /// </summary>
        /// <param name="toStellar"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("wallet/current-user/withdraw-to-stellar")]
        public async Task<IActionResult> WithdrawToStellar(WithdrawToStellar toStellar)
        {
            try
            {
                var userId = GetUserId();
                throw new NotImplementedException("Not completely implemented");
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint to add stellar wallet Id
        /// </summary>
        /// <param name="addStellar"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status203NonAuthoritative)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("wallet/current-user/add-stellar-accounts")]
        public async Task<IActionResult> AddStellarAccount(AddStellarDto addStellar)
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.AddStellarAccount(addStellar, userId);
                if (result == -1)
                {
                    var response203 = new MessageResponse
                    {
                        Successful = true,
                        Message = "You need to activate your Wallet"
                    };
                    return StatusCode(StatusCodes.Status203NonAuthoritative, response203);
                }
                if (result == 0)
                {
                    var errorResponse = new ErrorResponseDTO(
                      HttpStatusCode.BadRequest,
                      "Invalid wallet pin"
                  );
                    return BadRequest(errorResponse);
                }
                var response = new MessageResponse
                {
                    Successful = true,
                    Message = "success"
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
        /// Endpoint to get the recent transactions
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TransactionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("wallet/current-user/recent-transactions")]
        public async Task<IActionResult> GetRecentTransactions()
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.RecentTransactions(userId);
                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(
                      HttpStatusCode.BadRequest,
                      "Invalid operation"
                  );
                    return BadRequest(errorResponse);
                }
                var resultDto = mapper.Map<IEnumerable<TransactionResponse>>(result);
                var response = new Response<TransactionResponse>
                {
                    Successful = true,
                    Message = "success",
                    Data = (TransactionResponse)resultDto
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
        /// Endpoint to get all transactions carried out by the user
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(DataResponseArrayDTO<TransactionListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("wallet/current-user/transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.GetTransactions(userId);

                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(HttpStatusCode.BadRequest, "Invalid operation");
                    return BadRequest(errorResponse);
                }

                var resultDto = mapper.Map<IEnumerable<TransactionListResponse>>(result);
                var response = new DataResponseArrayDTO<TransactionListResponse>(
                    resultDto,
                    resultDto.Count(), // You can replace this count with the actual count needed
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

        /// <summary>
        /// Endpoint to get a specific transaction by ref
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(Response<TransactionListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet("wallet/current-user/transactions/{transactionRef}")]
        public async Task<IActionResult> GetTransactionByRef(string transactionRef)
        {
            try
            {
                var result = await uow.WalletRepo.GetTransactionByRef(transactionRef);

                if (result == null)
                {
                    var errorResponse = new ErrorResponseDTO(HttpStatusCode.BadRequest, "Invalid operation");
                    return BadRequest(errorResponse);
                }

                var resultDto = mapper.Map<TransactionListResponse>(result);
                var response = new Response<TransactionListResponse>
                {
                    Successful = true,
                    Message = "success",
                    Data = resultDto
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
        /// This endpoint sends a mail to with statement of account to the user
        /// Unit of work to be completely implemented when a pdf creator has been configured
        /// </summary>
        /// <param name="statementReq"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [ProducesResponseType(typeof(MessageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("wallet/current-user/statement")]
        public async Task<IActionResult> GetStatement(StatementReq statementReq)
        {
            try
            {
                var userId = GetUserId();
                var result = await uow.WalletRepo.GetStatement(statementReq, userId);
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }
    }
}
