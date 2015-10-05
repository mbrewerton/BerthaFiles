using API.Models.Dtos;

namespace API.Services
{
	public interface IUserProfileService
	{
		/// <summary>
		/// Gets the User Profile data for the current user.
		/// </summary>
		/// <returns>UserProfileDto</returns>
		UserProfileDto GetUserProfile();

		/// <summary>
		/// Gets the User Profile data for a user via their User Id.
		/// </summary>
		/// <param name="userId">The User Id of the User.</param>
		/// <returns>UserProfileDto</returns>
		UserProfileDto GetUserProfile(string userId);

		/// <summary>
		/// Gets the User Profile data for a user via the Profile Id.
		/// </summary>
		/// <param name="id">The id of the User Profile.</param>
		/// <returns>UserProfileDto</returns>
		UserProfileDto GetUserProfile(long id);
	}
}