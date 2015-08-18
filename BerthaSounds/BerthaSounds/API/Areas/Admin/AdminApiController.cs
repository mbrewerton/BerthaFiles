using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Models;
using API.Models.Dtos;
using API.Services;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BerthaSounds.API.Areas.Admin
{
    [RoutePrefix("api/Admin")]
    public class AdminApiController : ApiController
    {
        private readonly ISoundService _soundService;

        public AdminApiController(ISoundService soundService)
        {
            _soundService = soundService;
        }

        [HttpGet]
        [Route("GetAllSounds")]
        public HttpResponseMessage GetAllSounds()
        {
            var sounds = _soundService.GetAllSounds();
            return Request.CreateResponse(HttpStatusCode.OK, sounds);
        }

	    [HttpPost]
	    [Route("UploadSound")]
	    public Task<IEnumerable<object>> UploadSounds(HttpRequestMessage request)
	    {

		    return null;
	    }
    }
}
