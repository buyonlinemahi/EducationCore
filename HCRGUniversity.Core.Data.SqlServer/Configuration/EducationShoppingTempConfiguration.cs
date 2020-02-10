using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationShoppingTempConfiguration : EntityTypeConfiguration<EducationShoppingTemp>
    {
        public EducationShoppingTempConfiguration()
            : base()
        {
            ToTable("EducationShoppingTemps", Constant.Consts.Schema.DBO);
            HasKey(table => table.EducationShoppingTempID);
        }
    }
}
