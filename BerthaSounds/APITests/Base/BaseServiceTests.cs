using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Repositories;
using API.Services;
using Moq;
using APITests.Base;

namespace APITests.Base_Classes
{
	public class BaseServiceTests : BaseTests
	{
		protected Mock<IRepository<ApplicationUser>> _userRepository = new Mock<IRepository<ApplicationUser>>();
		protected Mock<IRepository<UserProfile>> _userProfileRepository = new Mock<IRepository<UserProfile>>();
		protected Mock<IUnitOfWork> _uow = new Mock<IUnitOfWork>();

		protected Mock<ITagService> GetTagServiceMock()
		{
			return new Mock<ITagService>();
		}

		protected Mock<ISoundService> GetSoundServiceMock()
		{
			return new Mock<ISoundService>();
		}

		protected Mock<ICategoryService> GetCategoryServiceMock()
		{
			return new Mock<ICategoryService>();
		}

		protected IUserService GetUserService()
		{
			return new UserService(_userRepository.Object);
		}

		protected Mock<IUserService> GetUserServiceMock()
		{
			return new Mock<IUserService>();
		}

		protected IUserProfileService GetUserProfileService()
		{
			return new UserProfileService(_uow.Object, _userProfileRepository.Object, GetUserService());
		}

		protected Mock<IUserProfileService> GetUserProfileServiceMock()
		{
			return new Mock<IUserProfileService>();
		}
	}
}
