using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models.DbContexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public class RolesService
    {

        private BerthaContext _context;
        public RolesService(BerthaContext context)
        {
            _context = context;
        }
        public void CreateRole(IdentityRole role)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            if (roleManager.RoleExists(role.Name))
            {
                roleManager.Update(role);
            }
            else
            {
                roleManager.Create(role);
            }
        }

        public void AddUserToRole(IdentityUser user, IdentityRole role)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));

            userManager.AddToRole(user.Id, role.Name);
        }

        public IdentityRole GetRoleByName(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            if (roleManager.Roles.Any())
            {
                return roleManager.FindByName(roleName);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            if (roleManager.Roles.Any())
            {
                return roleManager.Roles.ToList();
            }
            else
            {
                return new List<IdentityRole>();
            }
        }
    }
}
