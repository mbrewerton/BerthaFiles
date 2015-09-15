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
using API.Services.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BerthaSounds.API.Areas.Admin
{
    [RoutePrefix("api/File")]
    public class FileApiController : ApiController
    {
	    private readonly IAzureStorageService _storageService;

	    public FileApiController(IAzureStorageService storageService)
	    {
		    _storageService = storageService;
	    }

	    [HttpPost]
		[Route("UploadFile")]
	    public async Task<HttpResponseMessage> UploadFile()
	    {
			if (!Request.Content.IsMimeMultipartContent("form-data"))
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "Unsupported Media Type.");
			}

			try
			{
				var files = await _storageService.UploadFileToBlobContainer(Request);
				return Request.CreateResponse(HttpStatusCode.OK, files);
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
			} 
	    }
    }
}
