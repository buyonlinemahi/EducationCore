using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class ExamConfiguration: EntityTypeConfiguration<Exam>
    {
        public ExamConfiguration()
            : base()
        {
            ToTable("Exams", Constant.Consts.Schema.DBO);
            HasKey(exams => exams.ExamID);          
        }
    }
}
