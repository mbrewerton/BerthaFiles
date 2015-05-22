using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using API.Models;
using API.Models.DbContexts;

namespace API.Services
{
    public class CouponService : ICouponService
    {
        public IEnumerable<Coupon> GetAllCoupons()
        {
            using (var db = new BerthaContext())
            {
                return db.Coupon.ToList();
            }
        }

        public void SaveCoupon(Coupon coupon)
        {

            if (coupon.EndDate != null)
                coupon.EndDate = (DateTime)coupon.EndDate;
            if (coupon.Code.Length > 10)
            {
                throw new Exception("Coupon code is too long.");
            }

            using (var db = new BerthaContext())
            {
                if (coupon.Id == 0)
                {
                    db.Coupon.Add(coupon);
                }
                else
                {
                }
                db.SaveChanges();
            }
        }
    }
}
