using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Models;
using AttributeRouting.Web.Http;
using API.Services;
using API.Models.DbContexts;
using API.Repositories;
using System.Diagnostics;

namespace BerthaSounds.Controllers.Areas.Admin
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private readonly ISoundService _soundService;
        private readonly ICouponService _couponService;

        public AdminController(ISoundService soundService, ICouponService couponService)
        {
            _soundService = soundService;
            _couponService = couponService;
        }

        [HttpGet]
        [GET("GetAllSounds")]
        public HttpResponseMessage GetAllSounds()
        {
            var sounds = _soundService.GetAllSounds();
            return Request.CreateResponse(HttpStatusCode.OK, sounds);
        }

        [HttpGet]
        [GET("GetAllCoupons")]
        public HttpResponseMessage GetAllCoupons()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _couponService.GetAllCoupons());
        }

        [HttpPost]
        [POST("SaveCoupon")]
        public HttpResponseMessage SaveCoupon(Coupon couponDto)
        {
            _couponService.SaveCoupon(couponDto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [POST("UploadSound")]
        public HttpResponseMessage UploadSound(HttpPostedFileBase soundFile)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
