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
        public ActionResult RenderCss(string identifier)
        {
            Response.Cache.SetMaxAge(TimeSpan.FromDays(60));
            return Content(Bundle.Css().RenderCached(identifier), "text/css");
        }

        public ActionResult RenderJs(string identifier)
        {
            Response.Cache.SetMaxAge(TimeSpan.FromDays(60));
            return Content(Bundle.JavaScript().RenderCached(identifier), "text/javascript");
        }
    }
}