using Invidux_Domain.Models;
using Invidux_Data.Dtos.Response;

namespace Invidux_Core.Repository.Interfaces
{
    public interface IUserRepo
    {
        Task<LoginResponse> Authenticate(string userName, string password);
        Task<LoginResponse> VerifyOtp(int otp);
    }
}
