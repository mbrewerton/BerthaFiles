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

namespace BerthaSounds.Controllers.Areas.Admin
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private readonly SoundService _soundService;

        public AdminController()
        {
        }

        public AdminController(SoundService soundService)
        {
            _soundService = soundService;
        }

        [HttpGet]
        [GET("GetAllSounds")]
        public HttpResponseMessage GetAllSounds()
        {
            var service = new SoundService();
            var sounds = service.GetAllSounds();
            return Request.CreateResponse(HttpStatusCode.OK, sounds);
        }

        [HttpGet]
        [GET("GetAllCoupons")]
        public HttpResponseMessage GetAllCoupons()
        {
            var service = new CouponService();
            return Request.CreateResponse(HttpStatusCode.OK, service.GetAllCoupons());
        }

        [HttpPost]
        [POST("SaveCoupon")]
        public HttpResponseMessage SaveCoupon(Coupon couponDto)
        {
            var service = new CouponService();
            service.SaveCoupon(couponDto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [POST("UploadSound")]
        public HttpResponseMessage UploadSound(HttpPostedFileBase soundFile)
        {
            var service = new SoundService();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
