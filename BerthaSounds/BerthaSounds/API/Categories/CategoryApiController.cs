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

namespace BerthaSounds.API.Categories
{
	[RoutePrefix("api/Category")]
    public class CategoryApiController : ApiController
    {
		private readonly ICategoryService _categoryService;

		public CategoryApiController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
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

		[HttpPost]
		[Route("DeleteCategory")]
		public HttpResponseMessage DeleteCategory(string name)
		{
			 _categoryService.DeleteCategory(name);
			return Request.CreateResponse(HttpStatusCode.OK);
		}
    }
}
