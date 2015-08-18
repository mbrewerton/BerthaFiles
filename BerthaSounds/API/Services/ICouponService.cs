using System.Collections.Generic;
using API.Models;
using API.Models.Dtos;

namespace API.Services
{
    public interface ICouponService
    {
        List<CouponDto> GetAllCoupons();
        CouponDto AddCoupon(CouponDto coupon);
    }
}