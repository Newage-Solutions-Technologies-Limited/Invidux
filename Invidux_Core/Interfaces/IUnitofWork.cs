using Invidux_Core.Interfaces;

namespace Invidux_Core.Repository.Interfaces
{
    public interface IUnitofWork
    {
        IPortfolioRepo PortfolioRepo { get; }
        IRegistrationRepo RegistrationRepo { get; }
        IUserRepo UserRepo { get; }
        IUtitlityRepo UtitlityRepo { get; }
        IWalletRepo WalletRepo { get; }
        Task<bool> SaveAsync();
        Task<int> ValidateOtp(int otp, string email);
        Task<bool> AuditSaveAsync(CancellationToken cancellationToken = default);
    }
}
