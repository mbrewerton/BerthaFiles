using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Exceptions;
using API.Models.Dtos;
using API.Services;

namespace BerthaSounds.API.Users
{
	[RoutePrefix("api/UserProfile")]
	public class UserProfileApiController : ApiController
	{
		private readonly IUserProfileService _profileService;

		public UserProfileApiController(IUserProfileService profileService)
		{
			_profileService = profileService;
		}

		[HttpGet]
		[Route("GetCurrentUserProfile")]
		public HttpResponseMessage GetCurrentUserProfile()
		{
			var profile = _profileService.GetUserProfile();
			return Request.CreateResponse(HttpStatusCode.OK, profile);
		}

		[HttpPut]
		[Route("UpdateUserProfile")]
		public HttpResponseMessage UpdateUserProfile(UserProfileDto profile)
		{
			try
			{
				_profileService.UpdateUserProfile(profile);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (InvalidActionException exception)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, exception);
			}
			
		}
	}
}