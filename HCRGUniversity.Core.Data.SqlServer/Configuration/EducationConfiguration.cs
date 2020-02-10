using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationConfiguration : EntityTypeConfiguration<Education>
    {
        public EducationConfiguration()
            : base()
        {
            ToTable("Educations", Constant.Consts.Schema.DBO);
            HasKey(education => education.EducationID);
        }
    }
}