using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.DbContexts;
using API.Models.Dtos;
using API.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace API.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateNewUserProfile(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BerthaContext()));
            var currentUser = userManager.FindById(id);
            currentUser.UserProfile = new UserProfile
            {
                DisplayName = currentUser.UserName,
				FirstName = "First",
				LastName = "Last"
            };

            _unitOfWork.Commit();
        }

        /// <summary>
        /// Gets the User Profile data for the current user.
        /// </summary>
        /// <returns>UserProfile</returns>
        public UserProfileDto GetUserProfile()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the User Profile data for a user by their id.
        /// </summary>
        /// <param name="id">The users' id.</param>
        /// <returns></returns>
        public UserProfileDto GetUserProfileById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the User Profile data for a user by their UserName
        /// </summary>
        /// <param name="userName">The users' username.</param>
        /// <returns></returns>
        public UserProfileDto GetUserProfileByUsername(string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the User Profile data for a user by their Email Address
        /// </summary>
        /// <param name="email">The users' email address.</param>
        /// <returns></returns>
        public UserProfileDto GetUserProfileByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
