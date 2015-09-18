using System.Collections.Generic;
using API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public interface IUserService
    {
        IdentityUser GetUserByUserName(string userName);
        IdentityUser GetUserByEmail(string email);
        IdentityUser GetUserById(string id);
        IdentityUser GetUser(UserLoginInfo user);
        IEnumerable<IdentityUser> GetAllUsers();
		IdentityResult CreateUser(ApplicationUser user, string password);
    }
}