using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
 public class EvaluationConfiguration: EntityTypeConfiguration<Evaluation>
    {
     public EvaluationConfiguration()
            : base()
        {
            ToTable("Evaluations", Constant.Consts.Schema.DBO);
            HasKey(evaluations => evaluations.EvaluationID);          
        }
    }
}
