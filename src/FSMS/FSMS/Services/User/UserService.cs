using FSMS.Data;
using Microsoft.EntityFrameworkCore;

namespace FSMS.Services.User
{
    public class UserService(AppDbContext context) : IUserService
    {
        public async Task<Entities.User?> GetUser(string username, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .AsNoTracking()
                .Where(u => u.Username == username && !u.IsDeleted)
                .Include(u => u.Role)
                .SingleOrDefaultAsync(cancellationToken);

            return user;
        }
    }
}
