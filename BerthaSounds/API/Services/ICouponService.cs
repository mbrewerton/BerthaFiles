using System.Collections.Generic;
using API.Models;
using API.Models.Dtos;

namespace API.Services
{
    public interface ICouponService
    {
        List<CouponDto> GetAllCoupons(bool getExpired = false);
        CouponDto AddCoupon(CouponDto coupon);
	    void DeleteCoupon(string name);
	    void DeleteCoupon(int id);
	    List<CouponTypeDto> GetCouponTypes();
    }
}