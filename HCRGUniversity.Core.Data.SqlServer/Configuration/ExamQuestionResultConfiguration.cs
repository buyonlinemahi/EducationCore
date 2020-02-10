using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ExamQuestionResultConfiguration : EntityTypeConfiguration<ExamQuestionResult>
    {
        public ExamQuestionResultConfiguration()
            : base()
        {
            ToTable(Tables.dbo.ExamQuestionResult, Constant.Consts.Schema.DBO);
            HasKey(table => table.ExamQuestionResultID);
        }
    }
}