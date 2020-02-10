using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    class ShippingPaymentConfiguration : EntityTypeConfiguration<ShippingPayment>
    {
        public ShippingPaymentConfiguration()
            : base()
        {
            ToTable("ShippingPayments", Constant.Consts.Schema.DBO);
            HasKey(table => table.ShippingPaymentID);
        }
    }
}
