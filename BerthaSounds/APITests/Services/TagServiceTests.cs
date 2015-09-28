using System;
using API.Models;
using API.Repositories;
using API.Services;
using Moq;
using Xunit;

namespace APITests.Services
{
	public class TagServiceTests
	{
		private Mock<IRepository<Tag>> _fakeTagRepository;

		public TagServiceTests()
		{
			_fakeTagRepository = new Mock<IRepository<Tag>>();
		}

		public Mock<ITagService> GetService()
		{
			return new Mock<ITagService>();
		}
	}
}
