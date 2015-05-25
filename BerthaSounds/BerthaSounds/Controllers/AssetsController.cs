using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SquishIt;
using SquishIt.Framework;

namespace BerthaSounds.Controllers
{
    public class AssetsController : Controller
    {
        // GET: Assets
        public ActionResult Css(string id)
        {
            Response.Cache.SetMaxAge(TimeSpan.FromDays(60));
            return Content(Bundle.Css().RenderCached(id), "text/css");
        }

        public ActionResult Js(string id)
        {
            Response.Cache.SetMaxAge(TimeSpan.FromDays(60));
            return Content(Bundle.JavaScript().RenderCached(id), "text/javascript");
        }
    }
}