using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
   public class EvaluationQuestionConfiguration: EntityTypeConfiguration<EvaluationQuestion>
    {
       public EvaluationQuestionConfiguration()
            : base()
        {
            ToTable("EvaluationQuestions", Constant.Consts.Schema.DBO);
            HasKey(evaluationQuestion => evaluationQuestion.EvaluationQuestionID);          
        }
    }
}
