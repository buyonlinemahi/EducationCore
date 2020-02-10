using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;


namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class NewsSectionConfiguration : EntityTypeConfiguration<NewsSection>
    {
       public NewsSectionConfiguration()
            : base()
        {
            ToTable("NewsSections", Constant.Consts.Schema.DBO);
            HasKey(newsSection => newsSection.NewsSectionID);
        }
    }
}
