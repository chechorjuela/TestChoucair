using Microsoft.AspNetCore.Authorization;

namespace TestChoucair.Infrastructure.Authentication {
    public class PermissionRequirement : IAuthorizationRequirement{
        public string Permission { get; set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}