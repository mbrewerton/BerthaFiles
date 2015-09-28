using System;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APITests.Services
{
	[TestClass]
	public class TagServiceTests
	{
		private readonly IRepository<Tag> _tagRepository;
		private readonly IUnitOfWork uow;
		public ITagService GetService()
		{
			return new TagService(_tagRepository, uow);
		}

		[TestMethod]
		public void GetAllTagsTests()
		{
			var service = GetService();
			var tags = service.GetAllTags();
			Assert.IsNotNull(tags);
		}
	}
}
