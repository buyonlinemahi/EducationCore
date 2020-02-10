using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducatoinProfessionConfiguration : EntityTypeConfiguration<EducationProfession>
    {
        public EducatoinProfessionConfiguration()
            : base()
        {
            ToTable("EducationProfessions", Constant.Consts.Schema.LINK);
            HasKey(table => table.EducationProfessionID);
        }
    }
}