using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class DiscountCouponConfiguration : EntityTypeConfiguration<DiscountCoupon>
    {
        public DiscountCouponConfiguration()
            : base()
        {
            ToTable("DiscountCoupons", Constant.Consts.Schema.DBO);
            HasKey(discountCoupon => discountCoupon.CouponID);
            Property(discountCoupon => discountCoupon.CouponID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
    
        }
    }
}
