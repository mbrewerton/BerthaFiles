using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Services;
using Moq;
using APITests.Base;

namespace APITests.Base_Classes
{
	public class BaseServiceTests : BaseTests
	{
		protected Mock<ITagService> GetTagService()
		{
			return new Mock<ITagService>();
		}

		protected Mock<ISoundService> GetSoundService()
		{
			return new Mock<ISoundService>();
		}

		protected Mock<ICategoryService> GetCategoryService()
		{
			return new Mock<ICategoryService>();
		}
	}
}
