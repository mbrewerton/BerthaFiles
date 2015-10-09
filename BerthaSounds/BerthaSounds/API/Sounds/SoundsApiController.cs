using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Dtos;
using API.Exceptions;
using API.Models;
using API.Models.Dtos;
using API.Services;
using API.Services.Search;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BerthaSounds.API.Sounds
{
    [RoutePrefix("api/Sounds")]
    public class SoundsApiController : ApiController
    {
        private readonly ISoundService _soundService;
	    private readonly ISoundSearchService _searchService;

	    public SoundsApiController(ISoundService soundService, ISoundSearchService searchService)
	    {
		    _soundService = soundService;
		    _searchService = searchService;
	    }

	    [HttpGet]
	    [Route("Search")]
	    public HttpResponseMessage Search(string term)
	    {
		    var sounds = term != null
			    ? _searchService.Search(x => x.Description.ToLower().Contains(term.ToLower()) ||
											 x.Name.ToLower().Contains(term.ToLower())) :
				_searchService.GetAll();
		    return Request.CreateResponse(HttpStatusCode.OK, sounds);
	    }

	    [HttpPost]
	    [Route("AddCategoryToSound")]
	    public HttpResponseMessage AddCategoryToSound(int soundId, int categoryId)
		{
		    try
		    {
				_soundService.AddCategoryToSound(soundId, categoryId);
			    return Request.CreateResponse(HttpStatusCode.OK);
		    }
		    catch (DuplicateItemException)
		    {
			    return Request.CreateResponse(HttpStatusCode.Conflict);
		    }
	    }

	    [HttpDelete]
	    [Route("RemoveCategoryFromSound")]
	    public HttpResponseMessage RemoveCategoryFromSound(int soundId, int categoryId)
	    {
		    _soundService.RemoveCategoryFromSound(soundId, categoryId);
		    return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpPost]
		[Route("AddTagToSound")]
		public HttpResponseMessage AddTagToSound(int soundId, int tagId)
		{
			try
			{
				_soundService.AddTagToSound(soundId, tagId);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (DuplicateItemException)
			{
				return Request.CreateResponse(HttpStatusCode.Conflict);
			}
			
		}

		[HttpDelete]
		[Route("RemoveTagFromSound")]
		public HttpResponseMessage RemoveTagFromSound(int soundId, int tagId)
		{
			_soundService.RemoveTagFromSound(soundId, tagId);
			return Request.CreateResponse(HttpStatusCode.OK);
		}
    }
}
