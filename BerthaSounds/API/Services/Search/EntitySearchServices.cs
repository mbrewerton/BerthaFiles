using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.Dtos;
using API.Repositories;
using AutoMapper;

namespace API.Services.Search
{
	public interface ICategorySearchService : ISearchService<Category, CategoryDto> {}
	public class CategorySearchService : SearchService<Category, CategoryDto>, ICategorySearchService
	{
		public CategorySearchService(IRepository<Category> repository) : base(repository) {}
	}

	public interface ISoundSearchService : ISearchService<Sound, SoundDto> { }
	public class SoundSearchService : SearchService<Sound, SoundDto>, ISoundSearchService
	{
		public SoundSearchService(IRepository<Sound> repository) : base(repository) { }
	}

	public interface ITagSearchService : ISearchService<Tag, TagDto> { }
	public class TagSearchService : SearchService<Tag, TagDto>, ITagSearchService
	{
		public TagSearchService(IRepository<Tag> repository) : base(repository) { }
	}

	public interface ICouponSearchService : ISearchService<Coupon, CouponDto> { }
	public class CouponSearchService : SearchService<Coupon, CouponDto>, ICouponSearchService
	{
		public CouponSearchService(IRepository<Coupon> repository) : base(repository) { }
	}
}
