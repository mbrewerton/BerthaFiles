using System.Collections.Generic;
using API.Models;
using API.Models.Dtos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public interface IUserService
    {
		UserDto GetUserByUserName(string userName);
        UserDto GetUserByEmail(string email);
		UserDto GetUserById(string id);
		IEnumerable<UserDto> GetAllUsers();
	    ApplicationUser GetCurrentUser();
    }
}