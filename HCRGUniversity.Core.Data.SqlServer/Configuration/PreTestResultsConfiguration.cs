using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class PreTestResultsConfiguration : EntityTypeConfiguration<PreTestResult>
    {
        public PreTestResultsConfiguration()
            : base()
        {
            ToTable(Tables.dbo.PreTestResult, Constant.Consts.Schema.DBO);
            HasKey(table => table.PreTestResultID);
        }
    }
}