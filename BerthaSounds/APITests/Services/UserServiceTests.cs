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
	public class UserServiceTests : BaseServiceTests
	{
		[Fact]
		public void Get_User_Test()
		{
			var service = GetUserServiceMock();
			service.Setup(x => x.GetUserByUserName(It.IsAny<string>()))
				.Returns(new UserDto {Email = "testing@test.com", UserName = "Testuser", Id = "testuserid"})
				.Verifiable();
		}
	}
}
