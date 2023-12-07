using Invidux_Domain.Models;

namespace Invidux_Core.Repository.Interfaces
{
    public interface IUserRepo
    {
        Task<AppUser> Authenticate(string userName, string password);
    }
}
