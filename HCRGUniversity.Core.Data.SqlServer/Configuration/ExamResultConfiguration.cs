using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Constant;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ExamResultConfiguration : EntityTypeConfiguration<ExamResult>
    {
        public ExamResultConfiguration()
            : base()
        {
            ToTable(Tables.dbo.ExamResult, Constant.Consts.Schema.DBO);
            HasKey(table => table.ExamResultID);
        }
    }
}