using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ProductQuantityConfiguration : EntityTypeConfiguration<ProductQuantity>
    {
        public ProductQuantityConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.ProductQuantity, Constant.Consts.Schema.DBO);
            HasKey(productqty => productqty.ProductQuantityID);
            Property(productqty => productqty.ProductQuantityID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
