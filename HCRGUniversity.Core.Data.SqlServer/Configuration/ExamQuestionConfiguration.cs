using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ExamQuestionConfiguration : EntityTypeConfiguration<ExamQuestion>
    {
       public ExamQuestionConfiguration()
            : base()
        {
            ToTable("ExamQuestions", Constant.Consts.Schema.DBO);
            HasKey(examQuestions => examQuestions.ExamQuestionID);          
        }
    }
}
