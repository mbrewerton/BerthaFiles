using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Exceptions;
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

	    public UserProfileDto UpdateUserProfile(UserProfileDto profile)
	    {
		    if (profile.FirstName == null || profile.DisplayName == null || profile.LastName == null)
		    {
			    throw new InvalidActionException("One of the profile fields are empty.");
		    }

		    var profiles = _profileRepository.GetAll();
			if (profiles.SingleOrDefault(x => x.DisplayName.ToLower() == profile.DisplayName.ToLower() && x.Id != profile.Id) != null)
				throw new InvalidActionException("A profile with that Display Name already exists.");

		    var oldProfile = profiles.Single(x => x.Id == profile.Id);

		    if (oldProfile.FirstName.ToLower() == profile.FirstName.ToLower() &&
		        oldProfile.DisplayName.ToLower() == profile.DisplayName.ToLower() &&
		        oldProfile.LastName.ToLower() == profile.LastName.ToLower())
		    {
			    return null;
		    }

			//oldProfile = Mapper.Map<UserProfileDto, UserProfile>(profile);
		    oldProfile.FirstName = profile.FirstName;
		    oldProfile.DisplayName = profile.DisplayName;
		    oldProfile.LastName = profile.LastName;

			_profileRepository.Update(oldProfile);
			_unitOfWork.Commit();

		    return Mapper.Map<UserProfile, UserProfileDto>(oldProfile);
	    }
    }
}
