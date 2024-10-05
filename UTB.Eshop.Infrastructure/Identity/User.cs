using Microsoft.AspNetCore.Identity;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop.Infrastructure.Identity
{
    /// <summary>
    /// Our User class which can be modified
    /// </summary>
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}

