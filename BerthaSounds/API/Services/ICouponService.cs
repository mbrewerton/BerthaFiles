using System.Collections.Generic;
using API.Models;
using API.Models.Dtos;

namespace API.Services
{
    public interface ICouponService
    {
        IEnumerable<Coupon> GetAllCoupons();
        void SaveCoupon(CouponDto coupon);
    }
}