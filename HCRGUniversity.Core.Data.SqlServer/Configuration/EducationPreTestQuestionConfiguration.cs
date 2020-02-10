using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
  public   class EducationPreTestQuestionConfiguration: EntityTypeConfiguration<EducationPreTestQuestion>
    {
      public EducationPreTestQuestionConfiguration()
            : base()
        {
            ToTable("EducationPreTestQuestions", Constant.Consts.Schema.LINK);
            HasKey(educationPreTestQuestions => educationPreTestQuestions.CoursePreTestID);          
        }
    }
}
