
using HCRGUniversity.Core.BL.Model.Base;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class DiscountCoupan : BasePaged
    {
        public IEnumerable<BLModel.DiscountCoupon> DiscountCoupans { get; set; }
        public IEnumerable<DiscountCouponForCourses> DiscountCoupansForCourse { get; set; }
    }
}
