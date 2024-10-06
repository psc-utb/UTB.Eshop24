using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Infrastructure.Identity.Enums;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IAccountService
    {
        Task<bool> Login(LoginViewModel vm);
        Task Logout();

        Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);
    }
}

