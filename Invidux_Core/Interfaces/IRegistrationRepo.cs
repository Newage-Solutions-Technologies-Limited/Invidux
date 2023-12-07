
using Invidux_Data.Dtos.Request;
using Invidux_Data.Dtos.Response;

namespace Invidux_Core.Repository.Interfaces
{
    public interface IRegistrationRepo
    {
        Task<UserRegistrationDto> Register(RegistrationDTO user);
        Task<bool> CompleteRegistration(CompleteRegistration user);
        Task<string> VerifyOtp(int otp);
        Task<int> ResendOtp(string email);
        Task<string> UserAlreadyExists(string email);
    }
}
