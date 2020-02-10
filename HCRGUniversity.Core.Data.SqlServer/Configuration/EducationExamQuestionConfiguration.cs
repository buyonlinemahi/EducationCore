using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
   public class EducationExamQuestionConfiguration: EntityTypeConfiguration<EducationExamQuestion>
    {
       public EducationExamQuestionConfiguration()
            : base()
        {
            ToTable("EducationExamQuestions", Constant.Consts.Schema.LINK);
            HasKey(educationExamQuestions => educationExamQuestions.CourseExamID);          
        }
    }
}
