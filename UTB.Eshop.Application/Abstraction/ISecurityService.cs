using System.Security.Claims;
using UTB.Eshop.Infrastructure.Identity;

namespace UTB.Eshop.Application.Abstraction
{
    public interface ISecurityService
    {
        Task<User> FindUserByUsername(string username);
        Task<User> FindUserByEmail(string email);
        Task<IList<string>> GetUserRoles(User user);
        Task<User> GetCurrentUser(ClaimsPrincipal principal);
    }
}
