using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Services;

namespace BerthaSounds.API.Areas.Users
{
    [Route("api/Account")]
    public class AccountApiController : ApiController
    {
	    private readonly IUserService _userService;
	    public AccountApiController(IUserService userService)
	    {
		    _userService = userService;
	    }

	    public HttpResponseMessage Get()
	    {
		    return Request.CreateResponse(HttpStatusCode.OK);
	    }
    }
}
