using Invidux_Core.Interfaces;

namespace Invidux_Core.Repository.Interfaces
{
    public interface IUnitofWork
    {
        IRegistrationRepo RegistrationRepo { get; }
        IUserRepo UserRepo { get; }
        IUtitlityRepo UtitlityRepo { get; }
        IWalletRepo WalletRepo { get; }
        Task<bool> SaveAsync();
        Task<bool> AuditSaveAsync(CancellationToken cancellationToken = default);
    }
}
