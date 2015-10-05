using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Services;

namespace BerthaSounds.API.Users
{
	[Route("api/UserProfile")]
	public class UserProfileApiController : ApiController
	{
		private readonly IUserProfileService _profileService;

		public UserProfileApiController(IUserProfileService profileService)
		{
			_profileService = profileService;
		}

		[HttpGet]
		[Route("GetUserProfileForCurrentUser")]
		public HttpResponseMessage GetUserProfileForCurrentUser()
		{
			var profile = _profileService.GetUserProfile();
			return Request.CreateResponse(HttpStatusCode.OK, profile);
		}
	}
}