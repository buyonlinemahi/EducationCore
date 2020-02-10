using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class EducationShoppingConfiguration : EntityTypeConfiguration<EducationShopping>
    {
        public EducationShoppingConfiguration()
            : base()
        {
            ToTable("EducationShoppings", Constant.Consts.Schema.DBO);
            HasKey(table => table.EducationShoppingID);
        }
    }
}
