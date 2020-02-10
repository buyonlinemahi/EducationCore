using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
  public  class ProductConfiguration: EntityTypeConfiguration<Product>
    {
      public ProductConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.Product, Constant.Consts.Schema.DBO);
            HasKey(product => product.ProductID);
            Property(product => product.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(product => product.ProductName).IsRequired();
            Property(product => product.ProductDesc).IsRequired();
            Property(product => product.ProductPrice).IsRequired();
            Property(product => product.ProductImage);
            Property(product => product.ProductFile);
           
        }
    }
}
