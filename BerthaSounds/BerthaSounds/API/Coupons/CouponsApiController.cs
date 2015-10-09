using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models.Dtos;
using API.Services;
using API.Services.Search;

namespace BerthaSounds.API.Coupons
{
	[RoutePrefix("api/Coupons")]
    public class CouponsApiController : ApiController
    {
		private readonly ICouponService _couponService;
		private readonly ICouponSearchService _searchService;

		public CouponsApiController(ICouponService couponService, ICouponSearchService searchService)
		{
			_couponService = couponService;
			_searchService = searchService;
		}

		[HttpGet]
		[Route("Search")]
		public HttpResponseMessage Search(string term = null, bool expired = false)
		{
			var coupons = term != null
				? _searchService.Search(x => x.Code.ToLower().Contains(term.ToLower()) ||
											 x.Name.ToLower().Contains(term.ToLower()), expired)
				: _searchService.GetAll();

			return Request.CreateResponse(HttpStatusCode.OK, coupons);
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

		[HttpGet]
		[Route("GetCouponTypes")]
		public HttpResponseMessage GetCouponTypes()
		{
			var couponTypes = _couponService.GetCouponTypes();
			return Request.CreateResponse(HttpStatusCode.OK, couponTypes);
		}
    }
}
