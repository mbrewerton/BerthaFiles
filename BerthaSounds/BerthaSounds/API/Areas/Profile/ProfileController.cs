using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using API.Models;
using API.Services;

namespace BerthaSounds.API.Areas.Profile
{
    [RoutePrefix("api/Admin")]
    public class ProfileController : ApiController
    {
        private readonly ISoundService _soundService;
        private readonly ICouponService _couponService;

        public ProfileController(ISoundService soundService, ICouponService couponService)
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
        public HttpResponseMessage SaveCoupon(Coupon couponDto)
        {
            _couponService.SaveCoupon(couponDto);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("UploadSound")]
        public HttpResponseMessage UploadSound(HttpPostedFileBase soundFile)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
