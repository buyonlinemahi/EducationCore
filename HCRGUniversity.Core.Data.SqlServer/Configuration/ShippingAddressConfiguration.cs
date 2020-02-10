using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ShippingAddressConfiguration  : EntityTypeConfiguration<ShippingAddress>
    {
        public ShippingAddressConfiguration()
            : base()
        {
            ToTable("ShippingAddresses", Constant.Consts.Schema.DBO);
            HasKey(table => table.ShippingAddressID);
        }
    }
}
