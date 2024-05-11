namespace FSMS.Services.User
{
    public interface IUserService
    {
        Task<Entities.User?> GetUser(string username, CancellationToken cancellationToken);
    }
}
