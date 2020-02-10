using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class FAQCategoryConfiguration : EntityTypeConfiguration<FAQCategory>
    {
        public FAQCategoryConfiguration()
            : base()
        {
            ToTable("FAQCategories", Constant.Consts.Schema.DBO);
            HasKey(faqCategories => faqCategories.FAQCatID);
          
        }
    }
}
