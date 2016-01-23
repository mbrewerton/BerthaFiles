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
	    private Mock<ITagService> _tagService;

		public TagServiceTests()
		{
            _fakeTagRepository = new Mock<IRepository<Tag>>();
		    _tagService = GetTagServiceMock();
		    _tagService.Setup(x => x.AddTag(It.IsAny<string>()));
		}

		[Fact]
		public void Add_Tag_Test()
		{
		    var tag = _tagService.Object.AddTag("Test");
            _uow.Verify();
		}
	}
}
