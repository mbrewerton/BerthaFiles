using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.DbContexts;
using API.Models.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace API.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
	    private readonly IRepository<UserProfile> _profileRepository;
	    private readonly IUserService _userService;

	    public UserProfileService(IUnitOfWork unitOfWork, IRepository<UserProfile> profileRepository, IUserService userService)
	    {
		    _unitOfWork = unitOfWork;
		    _profileRepository = profileRepository;
		    _userService = userService;
	    }

	    /// <summary>
        /// Gets the User Profile data for the current user.
        /// </summary>
        /// <returns>UserProfileDto</returns>
        public UserProfileDto GetUserProfile()
	    {
		    var user = _userService.GetCurrentUser();
		    return Mapper.Map<UserProfile, UserProfileDto>(user.UserProfile);
	    }

        /// <summary>
        /// Gets the User Profile data for a user via their User Id.
		/// </summary>
		/// <param name="userId">The User Id of the User.</param>
        /// <returns>UserProfileDto</returns>
        public UserProfileDto GetUserProfile(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the User Profile data for a user via the Profile Id.
        /// </summary>
        /// <param name="id">The id of the User Profile.</param>
        /// <returns>UserProfileDto</returns>
        public UserProfileDto GetUserProfile(long id)
        {
            throw new NotImplementedException();
        }
    }
}
