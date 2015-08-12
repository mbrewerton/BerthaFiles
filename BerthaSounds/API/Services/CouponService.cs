using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using API.Models;
using API.Models.DbContexts;
using API.Models.Dtos;
using API.Repositories;
using AutoMapper;

namespace API.Services
{
    public class CouponService : ICouponService
    {
        private readonly IRepository<Coupon> _couponRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMappingEngine _mapper;

        public CouponService(IRepository<Coupon> couponRepository, IUnitOfWork unitOfWork, IMappingEngine mapper)
        {
            _couponRepository = couponRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Coupon> GetAllCoupons()
        {
            return _couponRepository.GetAll();
            //using (var db = new BerthaContext())
            //{
            //    return db.Coupon.ToList();
            //}
        }

        public void SaveCoupon(CouponDto couponDto)
        {

            if (couponDto.EndDate != null)
                couponDto.EndDate = (DateTime)couponDto.EndDate;
            if (couponDto.Code.Length > 10)
            {
                throw new Exception("Coupon code is too long.");
            }

            var coupon = _mapper.Map<CouponDto, Coupon>(couponDto);
            _couponRepository.Add(coupon);
            _unitOfWork.Commit();
            
            //using (var db = new BerthaContext())
            //{
            //    if (coupon.Id == 0)
            //    {
            //        db.Coupon.Add(coupon);
            //    }
            //    else
            //    {
            //    }
            //    db.SaveChanges();
            //}
        }
    }
}
