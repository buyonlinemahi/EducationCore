using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationFormatAvailableConfiguration : EntityTypeConfiguration<EducationFormatAvailable>
    {
        public EducationFormatAvailableConfiguration()
            : base()
        {
            ToTable("EducationFormatAvailables", Constant.Consts.Schema.LINK);
            HasKey(table => table.EducationAvailableID);
        }
    }
}