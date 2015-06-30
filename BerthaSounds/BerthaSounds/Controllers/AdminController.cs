using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using API.Services;

namespace BerthaSounds.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}