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
        private readonly ICouponService _couponService;

        public AdminApiController(ISoundService soundService, ICouponService couponService)
        {
            _soundService = soundService;
            _couponService = couponService;
        }

        [HttpGet]
        [Route("GetAllSounds")]
        public HttpResponseMessage GetAllSounds()
        {
            var sounds = _soundService.GetAllSounds();
            return Request.CreateResponse(HttpStatusCode.OK, sounds);
        }

        [HttpGet]
        [Route("GetAllCoupons")]
        public HttpResponseMessage GetAllCoupons()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _couponService.GetAllCoupons());
        }

        [HttpPost]
        [Route("SaveCoupon")]
        public HttpResponseMessage SaveCoupon(CouponDto couponDto)
        {
            _couponService.SaveCoupon(couponDto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

	    [HttpPost]
	    [Route("UploadSound")]
	    public Task<IEnumerable<object>> UploadSounds(HttpRequestMessage request)
	    {

		    return null;
	    }
    }
}
