using System.Collections.Generic;
using API.Models;

namespace API.Services
{
    public interface ICouponService
    {
        IEnumerable<Coupon> GetAllCoupons();
        void SaveCoupon(Coupon coupon);
    }
}