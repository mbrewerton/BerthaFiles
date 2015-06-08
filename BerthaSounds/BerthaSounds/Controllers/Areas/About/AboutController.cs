using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Models;
using API.Services;
using API.Models.DbContexts;
using API.Repositories;
using System.Diagnostics;

namespace BerthaSounds.Controllers.Areas.About
{
    [RoutePrefix("api/About")]
    public class AboutController : ApiController
    {
    }
}
