using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EvaluationResultConfiguration : EntityTypeConfiguration<EvaluationResult>
    {
       public EvaluationResultConfiguration()
            : base()
        {
            ToTable(Tables.dbo.EvaluationResult, Constant.Consts.Schema.DBO);
            HasKey(table => table.EvaluationResultID);
        }
    }
}
