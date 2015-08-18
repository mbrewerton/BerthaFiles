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
    public class CouponsController : ApiController
    {
		private readonly ICouponService _couponService;

		public CouponsController(ICouponService couponService)
		{
			_couponService = couponService;
		}

		[HttpGet]
		[Route("GetCoupons")]
		public HttpResponseMessage GetCoupons()
		{
			return Request.CreateResponse(HttpStatusCode.OK, _couponService.GetAllCoupons());
		}

		[HttpPost]
		[Route("AddCoupon")]
		public HttpResponseMessage AddCoupon(CouponDto couponDto)
		{
			_couponService.AddCoupon(couponDto);
			return Request.CreateResponse(HttpStatusCode.OK);
		}
    }
}
