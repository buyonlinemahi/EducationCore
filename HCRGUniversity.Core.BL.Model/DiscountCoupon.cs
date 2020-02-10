using System;

namespace HCRGUniversity.Core.BL.Model
{
  public class DiscountCoupon
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public string CouponType { get; set; }
        public int CouponEducationID { get; set; }
        public int CouponProduactID { get; set; }
        public decimal  CouponDiscount { get; set; }
        public DateTime CouponExpiryDate { get; set; }
        public DateTime CouponIssueDate { get; set; }
        public bool CoupanValid { get; set; }
    }
}
