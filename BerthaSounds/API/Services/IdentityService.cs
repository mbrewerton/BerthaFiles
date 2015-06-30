using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.DbContexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace API.Services
{
    public class IdentityService : IUserService
    {
        private readonly BerthaContext _context;

        public IdentityService(BerthaContext context)
        {
            _context = context;
        }

        public IdentityUser GetUserByUserName(string userName)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
            return userManager.FindByName(userName);
        }

        public IdentityUser GetUserByEmail(string email)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
            return userManager.FindByEmail(email);
        }

        public IdentityUser GetUserById(string id)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
            return userManager.FindById(id);
        }

        public IdentityUser GetUser(UserLoginInfo user)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
            return userManager.Find(user);
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_context));
            if (userManager.Users.Any())
            {
                return userManager.Users.ToList();
            }

            throw new NullReferenceException("No users were found.");
        }
    }
}
