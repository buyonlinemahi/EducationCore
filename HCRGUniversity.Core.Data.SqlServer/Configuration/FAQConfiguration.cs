using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class FAQConfiguration : EntityTypeConfiguration<FAQ>
    {
        public FAQConfiguration()
            : base()
        {
            ToTable("FAQs", Constant.Consts.Schema.DBO);
            HasKey(faqs => faqs.FAQID);
          
        }
    }
}
