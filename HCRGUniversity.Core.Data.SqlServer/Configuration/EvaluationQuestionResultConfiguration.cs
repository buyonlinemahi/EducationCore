using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
   public class EvaluationQuestionResultConfiguration: EntityTypeConfiguration<EvaluationQuestionResult>
    {
       public EvaluationQuestionResultConfiguration()
            : base()
        {
            ToTable(Tables.dbo.EvaluationQuestionResult, Constant.Consts.Schema.DBO);
            HasKey(table => table.EvaluationQuestionResultID);
        }
    }
}
