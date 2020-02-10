using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class DiscountCouponImpl : IDiscountCoupon
    {
        private readonly IDiscountCouponRepository _discountCouponRepository;
        public DiscountCouponImpl(IDiscountCouponRepository discountCouponRepository)
        {
            _discountCouponRepository = discountCouponRepository;
        }
        public int AddDiscountCoupon(BLModel.DiscountCoupon discountCoupon)
        {
            return _discountCouponRepository.Add((DLModel.DiscountCoupon)new DLModel.DiscountCoupon().InjectFrom(discountCoupon)).CouponID;
        }

        public int UpdateDiscountCoupon(BLModel.DiscountCoupon discountCoupon)
        {
            return _discountCouponRepository.Update((DLModel.DiscountCoupon)new DLModel.DiscountCoupon().InjectFrom(discountCoupon));
        }
        public void DeleteDiscountCoupon(int couponID)
        {
            _discountCouponRepository.Delete(_discountCouponRepository.GetById(couponID));
        }
        public BLModel.DiscountCoupon GetDiscountCouponByID(int couponID)
        {
            return (BLModel.DiscountCoupon)new BLModel.DiscountCoupon().InjectFrom(_discountCouponRepository.GetById(couponID));
        }

        public BLModel.DiscountCoupon GetDiscountCouponByCouponCode(string couponCode)
        {
            var _coupons = _discountCouponRepository.GetAll(discountCoupon => discountCoupon.CouponCode == couponCode).ToList();
            if (_coupons.Count > 0)
                return (BLModel.DiscountCoupon)new BLModel.DiscountCoupon().InjectFrom(_coupons.FirstOrDefault());
            else
                return new BLModel.DiscountCoupon();
        }

        public IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> GetDiscountCouponForCourses(int ClientID)
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> _discountCoupon = _discountCouponRepository.GetDiscountCouponForCourses(ClientID).ToList();
            return _discountCoupon;
         
        }

        public IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> GetDiscountCouponForProducts(int ClientID)
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> _discountCoupon = _discountCouponRepository.GetDiscountCouponForProducts(ClientID).ToList();
            return _discountCoupon;
        }

        public IEnumerable<BLModel.DiscountCoupon> getAllDiscountCoupons()
        {
            IEnumerable<BLModel.DiscountCoupon> _discountCoupon = _discountCouponRepository.GetAll().Select(discountCoupon => new BLModel.DiscountCoupon().InjectFrom(discountCoupon)).Cast<BLModel.DiscountCoupon>().OrderBy(discountCoupon => discountCoupon.CouponID).ToList();
            return _discountCoupon;
        }

        public int UpdateDiscountCouponStatus(string couponCode, bool value)
        {
            return _discountCouponRepository.UpdateDiscountCouponStatus(couponCode, value);
        }

        //*******************Lazy binding

        public BLModel.Paged.DiscountCoupan GetAllPagedDiscountCouponForCourse(int skip, int take, int ClientID)
        {
            return new BLModel.Paged.DiscountCoupan
            {
                TotalCount = _discountCouponRepository.GetDiscountCouponCountForCourse(ClientID),
                DiscountCoupansForCourse = _discountCouponRepository.GetAllPagedDiscountCouponForCourses(skip, take, ClientID).Select(discountCoupan => (HCRGUniversity.Core.Data.Model.DiscountCouponForCourses)new HCRGUniversity.Core.Data.Model.DiscountCouponForCourses().InjectFrom(discountCoupan)).ToList()
            };
        }

        public BLModel.Paged.DiscountCoupan GetAllPagedDiscountCoupon(int skip, int take)
        {
            return new BLModel.Paged.DiscountCoupan
            {
                TotalCount = _discountCouponRepository.GetDiscountCouponCount(),
                DiscountCoupans = _discountCouponRepository.GetAllPagedDiscountCoupon(skip, take).Select(discountCoupan => (BLModel.DiscountCoupon)new BLModel.DiscountCoupon().InjectFrom(discountCoupan)).ToList()
            };
        }
    }
}