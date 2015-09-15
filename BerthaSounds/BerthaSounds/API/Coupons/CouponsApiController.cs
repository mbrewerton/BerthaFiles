using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Dtos;
using API.Services;

namespace BerthaSounds.API.Coupons
{
	[RoutePrefix("api/Coupons")]
    public class CouponsApiController : ApiController
    {
		private readonly ICouponService _couponService;

		public CouponsApiController(ICouponService couponService)
		{
			_couponService = couponService;
		}

		[HttpGet]
		[Route("GetCoupons")]
		public HttpResponseMessage GetCoupons(bool expired = false	)
		{
			return Request.CreateResponse(HttpStatusCode.OK, _couponService.GetAllCoupons(expired));
		}

		[HttpPost]
		[Route("AddCoupon")]
		public HttpResponseMessage AddCoupon(CouponDto couponDto)
		{
			_couponService.AddCoupon(couponDto);
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpDelete]
		[Route("DeleteCoupon")]
		public HttpResponseMessage DeleteCoupon(int id)
		{
			_couponService.DeleteCoupon(id);
			return Request.CreateResponse(HttpStatusCode.OK);
		}
    }
}
