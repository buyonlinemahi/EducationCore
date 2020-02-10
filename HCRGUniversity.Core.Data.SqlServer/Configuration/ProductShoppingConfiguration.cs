using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
 public   class ProductShoppingConfiguration: EntityTypeConfiguration<ProductShopping>
    {
        public ProductShoppingConfiguration()
            : base()
        {
            ToTable("ProductShoppings", Constant.Consts.Schema.DBO);
            HasKey(table => table.ProductShoppingID);
        }
    }
}
