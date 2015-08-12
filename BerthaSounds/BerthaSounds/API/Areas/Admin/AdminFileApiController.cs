using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Models;
using API.Models.Dtos;
using API.Services;

namespace BerthaSounds.API.Areas.Admin
{
    [RoutePrefix("api/AdminFile")]
    public class AdminFileApiController : ApiController
    {
        private readonly ISoundService _soundService;

        public AdminFileApiController(ISoundService soundService)
        {
            _soundService = soundService;
        }

        [HttpPost]
	    public Task<IEnumerable<object>> Post()
	    {
		    return null;
	    }
    }
}
