using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationFormatConfiguration : EntityTypeConfiguration<EducationFormat>
    {
        public EducationFormatConfiguration()
            : base()
        {
            ToTable("EducationFormats", Constant.Consts.Schema.LOOKUP);
            HasKey(table => table.EducationFormatID);
        }
    }
}