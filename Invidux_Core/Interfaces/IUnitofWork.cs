namespace Invidux_Core.Repository.Interfaces
{
    public interface IUnitofWork
    {
        IRegistrationRepo RegistrationRepo { get; }
        IUserRepo UserRepo { get; }
        Task<bool> SaveAsync();
    }
}
