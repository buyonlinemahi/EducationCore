using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ProductShippingDetailConfiguration : EntityTypeConfiguration<ProductShippingDetail>
    {
        public ProductShippingDetailConfiguration()
            : base()
        {
            ToTable("ProductShippingDetails", Constant.Consts.Schema.DBO);
            HasKey(proshippingdet => proshippingdet.ProductShippingDetailID);
        }
    }
}
