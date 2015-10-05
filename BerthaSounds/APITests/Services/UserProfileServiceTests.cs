using System;
using API.Models;
using API.Models.Dtos;
using API.Repositories;
using API.Services;
using APITests.Base_Classes;
using Moq;
using Xunit;

namespace APITests.Services
{
	public class UserProfileServiceTests : BaseServiceTests
	{
		[Fact]
		public void Get_User_Profile_By_Id_Test()
		{
			var service = GetUserProfileService();
		}
	}
}
