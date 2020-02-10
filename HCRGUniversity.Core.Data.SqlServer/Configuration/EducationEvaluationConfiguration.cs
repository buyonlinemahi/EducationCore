using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    class EducationEvaluationConfiguration : EntityTypeConfiguration<EducationEvaluation>
    {
        public EducationEvaluationConfiguration()
            : base()
        {
            ToTable("EducationEvaluations", Constant.Consts.Schema.LINK);
            HasKey(educationEvaluationss => educationEvaluationss.CourseEvaluationID);          
        }
    }
}
