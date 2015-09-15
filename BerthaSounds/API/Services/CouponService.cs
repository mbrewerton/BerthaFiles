using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using API.Exceptions;
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

        public List<CouponDto> GetAllCoupons(bool getExpired = false)
        {
	        var coupons = _couponRepository.GetAll()
				.ToList();

	        var mappedCoupons = Mapper.Map<List<Coupon>, List<CouponDto>>(coupons);
	        if (!getExpired)
		        mappedCoupons = mappedCoupons.Where(x => x.Expired == false).ToList();

	        return mappedCoupons;
        }

        public CouponDto AddCoupon(CouponDto couponDto)
        {
            if (couponDto.EndDate != null)
                couponDto.EndDate = (DateTime)couponDto.EndDate;

            if (couponDto.Code.Length > 10)
            {
                throw new InvalidActionException("Coupon code is too long.");
            }

			if (couponDto.StartDate == null)
				throw new InvalidActionException("Please enter a start date.");

	        var coupons = GetAllCoupons();
	        if (coupons.Any(x => x.Name.ToUpper() == couponDto.Name.ToUpper()))
		        throw new InvalidActionException("A coupon with that name already exists.");

	        if (coupons.Any(x => x.Code.ToUpper() == couponDto.Code.ToUpper()))
		        throw new InvalidActionException("A coupon with that code already exists.");

            var coupon = _mapper.Map<CouponDto, Coupon>(couponDto);
            _couponRepository.Add(coupon);
            _unitOfWork.Commit();

	        return Mapper.Map<Coupon, CouponDto>(coupon);
        }

		public void DeleteCoupon(string name)
		{
			var coupon = _couponRepository.GetSingleOrDefaultWhere(x => x.Name.ToLower() == name.ToLower());
			if (coupon == null)
				throw new NullReferenceException("A Coupon by that name does not exist.");

			_couponRepository.Delete(coupon);
			_unitOfWork.Commit();
		}

	    public void DeleteCoupon(int id)
	    {
		    var coupon = _couponRepository.GetById(id);
			if (coupon == null)
				throw new NullReferenceException(string.Format("A coupon with id '{0}' does not exist", id));

			_couponRepository.Delete(coupon);
			_unitOfWork.Commit();
	    }
    }
}
