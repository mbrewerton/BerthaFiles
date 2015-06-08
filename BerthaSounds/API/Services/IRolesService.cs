using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public interface IRolesService
    {
        void CreateRole(IdentityRole role);
        void AddUserToRole(string userName, string roleName);
        IdentityRole GetRoleByName(string roleName);
        IEnumerable<IdentityRole> GetAllRoles();
    }
}