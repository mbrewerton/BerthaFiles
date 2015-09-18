using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using API.Models.Dtos;
using API.Repositories;
using API.Services;
using API.Services.Search;

namespace BerthaSounds.API.Categories
{
	[RoutePrefix("api/Categories")]
    public class CategoriesApiController : ApiController
    {
		private readonly ICategoryService _categoryService;
		private readonly ICategorySearchService _searchService;

		public CategoriesApiController(ICategoryService categoryService, ICategorySearchService searchService)
		{
			_categoryService = categoryService;
			_searchService = searchService;
		}

		[HttpGet]
		[Route("Search")]
		public HttpResponseMessage Search(string term = "")
		{
			var items = term != null
				? _searchService.Search(x => x.Name.ToLower().Contains(term.ToLower()) || 
											 x.Name.ToLower().Contains(term.ToLower()))
				: _searchService.GetAll();

			return Request.CreateResponse(HttpStatusCode.OK, items);
		}

		[HttpGet]
		[Route("GetCategories")]
		public HttpResponseMessage GetCategories()
		{
			var categories = _categoryService.GetAllCategories();
			return Request.CreateResponse(HttpStatusCode.OK, categories);
		}

		[HttpPost]
		[Route("AddCategory")]
		public HttpResponseMessage AddCategory(CategoryDto dto)
		{
			var category = _categoryService.AddCategory(dto.Name, dto.Description);
			return Request.CreateResponse(HttpStatusCode.OK, category);
		}

		[HttpDelete]
		[Route("DeleteCategory")]
		public HttpResponseMessage DeleteCategory(int id)
		{
			 _categoryService.DeleteCategory(id);
			return Request.CreateResponse(HttpStatusCode.OK);
		}
    }
}
