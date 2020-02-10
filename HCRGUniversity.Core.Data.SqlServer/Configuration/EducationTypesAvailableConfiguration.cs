using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationTypesAvailableConfiguration : EntityTypeConfiguration<EducationTypesAvailable>
    {
        public EducationTypesAvailableConfiguration()
            : base()
        {
            ToTable("EducationTypesAvailables", Constant.Consts.Schema.LINK);
            HasKey(table => table.EducationTypeAID);
        }
    }
}