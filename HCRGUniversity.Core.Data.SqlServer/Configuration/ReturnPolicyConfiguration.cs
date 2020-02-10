using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ReturnPolicyConfiguration : EntityTypeConfiguration<ReturnPolicy>
    {
        public ReturnPolicyConfiguration()
            : base()
        {
            ToTable(Tables.dbo.ReturnPolicy, Constant.Consts.Schema.DBO);
            HasKey(table => table.ReturnPolicyID);
        }
    }
}
