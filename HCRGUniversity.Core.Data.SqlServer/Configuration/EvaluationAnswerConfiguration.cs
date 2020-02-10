using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
  public class EvaluationAnswerConfiguration : EntityTypeConfiguration<EvaluationAnswer>
    {
      public EvaluationAnswerConfiguration()
            : base()
        {
            ToTable(Tables.dbo.EvaluationAnswer, Constant.Consts.Schema.DBO);
            HasKey(table => table.EvaluationAnswerID);
        }
    }
}
