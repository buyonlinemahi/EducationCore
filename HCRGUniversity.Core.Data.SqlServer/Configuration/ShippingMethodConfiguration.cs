using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    class ShippingMethodConfiguration  : EntityTypeConfiguration<ShippingMethod>
    {
        public ShippingMethodConfiguration()
            : base()
        {
            ToTable("ShippingMethods", Constant.Consts.Schema.DBO);
            HasKey(table => table.ShippingMethodID);
        }
    }
}
