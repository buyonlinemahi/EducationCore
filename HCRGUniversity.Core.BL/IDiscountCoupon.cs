using HCRGUniversity.Core.BL.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface IDiscountCoupon
    {
        int AddDiscountCoupon(DiscountCoupon discountCoupon);
        int UpdateDiscountCoupon(DiscountCoupon discountCoupon);
        void DeleteDiscountCoupon(int couponID);
        DiscountCoupon GetDiscountCouponByID(int couponID);
        IEnumerable<DiscountCoupon> getAllDiscountCoupons();
        DiscountCoupon GetDiscountCouponByCouponCode(string couponCode);
        int UpdateDiscountCouponStatus(string couponCode, bool value);
        IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> GetDiscountCouponForCourses(int ClientID);
        IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> GetDiscountCouponForProducts(int ClientID);
        BLModel.Paged.DiscountCoupan GetAllPagedDiscountCoupon(int skip, int take);
        BLModel.Paged.DiscountCoupan GetAllPagedDiscountCouponForCourse(int skip, int take, int OrganizationID);
      
    }
}