using Microsoft.AspNetCore.Authorization;
using TestChoucair.Domain.Enum;

namespace TestChoucair.Infrastructure.Authentication
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(PermissionEnum permission) : base(policy: permission.ToString())
        {

        }

    }
}