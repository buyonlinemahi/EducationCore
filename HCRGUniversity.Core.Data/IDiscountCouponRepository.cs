using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
namespace HCRGUniversity.Core.Data
{
    public interface IDiscountCouponRepository : IBaseRepository<DiscountCoupon>
    {
        int UpdateDiscountCouponStatus(string couponCode, bool value);
        IEnumerable<DiscountCouponForCourses> GetDiscountCouponForCourses(int ClientID);
        IEnumerable<DiscountCouponForCourses> GetDiscountCouponForProducts(int ClientID);       
        IEnumerable<DiscountCoupon> GetAllPagedDiscountCoupon(int skip, int take);
        IEnumerable<DiscountCouponForCourses> GetAllPagedDiscountCouponForCourses(int skip, int take, int OrganizationID);        
        int GetDiscountCouponCount();
        int GetDiscountCouponCountForCourse( int ClientID);
    }
}
