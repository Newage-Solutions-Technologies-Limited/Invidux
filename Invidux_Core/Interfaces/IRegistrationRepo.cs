
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;

namespace Invidux_Core.Repository.Interfaces
{
    public interface IRegistrationRepo
    {
        Task<UserRegistrationDto> Register(RegistrationDTO user);
        Task<UserRegistrationDto> CompleteRegistration(CompleteRegistration user);
        Task<bool> CheckOtp(int otp, string email);
        Task<string> VerifyOtp(int otp, string email);
        Task<int> ResendOtp(string email);
        Task<string> UserAlreadyExists(string email);
    }
}
