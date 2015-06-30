using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models.DbContexts;
using API.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public class RolesService : IRolesService
    {

        private readonly BerthaContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly UserService _userService;
        public RolesService(BerthaContext context, IUnitOfWork unitOfWork)
            //UserService userService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            //_userService = userService;
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

        public void AddUserToRole(string userName, string roleName)
        {
            //var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
            //var user = _userService.GetUserByUserName(userName);
            //var role = GetRoleByName(roleName);

            //userManager.AddToRole(user.Id, role.Name);
        }

        public IdentityRole GetRoleByName(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            if (roleManager.Roles.Any())
            {
                return roleManager.FindByName(roleName);
            }

            return null;
            
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
