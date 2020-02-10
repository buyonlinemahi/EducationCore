using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class DeliveryTermConfiguration : EntityTypeConfiguration<DeliveryTerm>
    {
        public DeliveryTermConfiguration()
            : base()
        {
            ToTable(Tables.dbo.DeliveryTerm, Constant.Consts.Schema.DBO);
            HasKey(table => table.DeliveryTermID);
        }
    }
}
