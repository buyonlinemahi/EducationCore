using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationModuleFileConfiguration : EntityTypeConfiguration<EducationModuleFile>
    {
        public EducationModuleFileConfiguration()
            : base()
        {
            ToTable("EducationModuleFiles", Constant.Consts.Schema.DBO);
            HasKey(table => table.EducationModuleFileID);
        }
    }
}
