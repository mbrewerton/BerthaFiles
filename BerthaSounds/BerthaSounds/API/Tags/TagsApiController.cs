﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using API.Models.Dtos;
using API.Repositories;
using API.Services;

namespace BerthaSounds.API.Tags
{
	[RoutePrefix("api/Tags")]
    public class TagsApiController : ApiController
    {
		private readonly ITagService _tagService;

		public TagsApiController(ITagService tagService)
		{
			_tagService = tagService;
		}

		[HttpGet]
		[Route("GetTags")]
		public HttpResponseMessage GetTags()
		{
			var tags = _tagService.GetAllTags();
			return Request.CreateResponse(HttpStatusCode.OK, tags);
		}

		[HttpPost]
		[Route("AddTag")]
		public HttpResponseMessage AddTag(TagDto dto)
		{
			var tag = _tagService.AddTag(dto.Name);
			return Request.CreateResponse(HttpStatusCode.OK, tag);
		}

		[HttpDelete]
		[Route("DeleteTag")]
		public HttpResponseMessage DeleteTag(int id)
		{
			_tagService.DeleteTag(id);
			return Request.CreateResponse(HttpStatusCode.OK);
		}
    }
}