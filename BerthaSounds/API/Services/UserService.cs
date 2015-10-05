using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using API.Models;
using API.Models.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace API.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<ApplicationUser> _userRepository;

		public UserService(IRepository<ApplicationUser> userRepository)
		{
			_userRepository = userRepository;
		}

		public ApplicationUser GetCurrentUser()
		{
			var userName = HttpContext.Current.User.Identity.Name;
			return _userRepository.GetSingleOrDefaultWhere(x => x.UserName == userName);
		}

		/// <summary>
		/// Gets the current User by Username.
		/// </summary>
		/// <param name="userName">The username to search with.</param>
		/// <returns></returns>
		public UserDto GetUserByUserName(string userName)
		{
			var user = _userRepository.GetAllWhere(x => x.UserName.ToLower().Contains(userName.ToLower())).SingleOrDefault();
			return Mapper.Map<ApplicationUser, UserDto>(user);
		}

		/// <summary>
		/// Gets the current User by Email.
		/// </summary>
		/// <param name="email">The Email to search with.</param>
		/// <returns></returns>
		public UserDto GetUserByEmail(string email)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the current User by Id.
		/// </summary>
		/// <param name="id">The Id to search with.</param>
		/// <returns></returns>
		public UserDto GetUserById(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<UserDto> GetAllUsers()
		{
			throw new NotImplementedException();
		}
	}
}
