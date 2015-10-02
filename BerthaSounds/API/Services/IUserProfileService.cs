using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Models;
using API.Models.Dtos;

namespace API.Services
{
    public interface IUserProfileService
    {
        void CreateNewUserProfile(string id);
        UserProfileDto GetUserProfile();
        UserProfileDto GetUserProfileById(int id);
        UserProfileDto GetUserProfileByUsername(string userName);
        UserProfileDto GetUserProfileByEmail(string email);
    }
}
