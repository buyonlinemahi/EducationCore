using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class BillingAddressConfiguration : EntityTypeConfiguration<BillingAddress>
    {
        public BillingAddressConfiguration()
            : base()
        {
            ToTable("BillingAddresses", Constant.Consts.Schema.DBO);
            HasKey(table => table.BillingAddressID);
        }
    }
}
