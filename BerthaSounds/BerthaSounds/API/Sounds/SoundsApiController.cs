using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Exceptions;
using API.Models;
using API.Models.Dtos;
using API.Services;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BerthaSounds.API.Areas.Admin
{
    [RoutePrefix("api/Sounds")]
    public class SoundsApiController : ApiController
    {
        private readonly ISoundService _soundService;
        private readonly ICouponService _couponService;

        public SoundsApiController(ISoundService soundService, ICouponService couponService)
        {
            _soundService = soundService;
            _couponService = couponService;
        }

	    [HttpGet]
	    [Route("GetAllSounds")]
	    public HttpResponseMessage GetAllSounds()
	    {
		    var sounds = _soundService.GetAllSounds();
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

	    [HttpPost]
	    [Route("UploadSound")]
	    public Task<IEnumerable<object>> UploadSounds(HttpRequestMessage request)
	    {

		    return null;
	    }
    }
}
