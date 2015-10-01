using System;
using API.Models;
using API.Repositories;
using API.Services;
using APITests.Base_Classes;
using Moq;
using Xunit;

namespace APITests.Services
{
	public class TagServiceTests : BaseServiceTests
	{
		private Mock<IRepository<Tag>> _fakeTagRepository;

		public TagServiceTests()
		{
			_fakeTagRepository = new Mock<IRepository<Tag>>();
		}

		[Fact]
		public void Add_Tag_Test()
		{
			var service = GetTagService();
		}
	}
}
