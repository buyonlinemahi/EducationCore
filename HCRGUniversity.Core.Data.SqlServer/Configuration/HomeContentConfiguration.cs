using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
  public  class HomeContentConfiguration: EntityTypeConfiguration<HomeContent>
    {
      public HomeContentConfiguration()
            : base()
        {
            ToTable("HomeContents", Constant.Consts.Schema.DBO);
            HasKey(homeContent => homeContent.HomeContentID);
            Property(homeContent => homeContent.HomeContentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
 
        }
    }
}
