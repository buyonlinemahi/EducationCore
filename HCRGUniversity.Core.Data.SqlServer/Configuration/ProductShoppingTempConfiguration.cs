using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
  public  class ProductShoppingTempConfiguration: EntityTypeConfiguration<ProductShoppingTemp>
    {
        public ProductShoppingTempConfiguration()
            : base()
        {
            ToTable("ProductShoppingTemps", Constant.Consts.Schema.DBO);
            HasKey(table => table.ProductShoppingTempID);
        }
    }
}
