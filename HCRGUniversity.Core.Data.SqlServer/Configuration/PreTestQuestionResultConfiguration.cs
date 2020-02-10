using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class PreTestQuestionResultConfiguration : EntityTypeConfiguration<PreTestQuestionResult>
    {
        public PreTestQuestionResultConfiguration()
            : base()
        {
            ToTable(Tables.dbo.PreTestQuestionResult, Constant.Consts.Schema.DBO);
            HasKey(table => table.PreTestQuestionResultID);
        }
    }
}