using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class AboutUsConfiguration : EntityTypeConfiguration<About>
    {
        public AboutUsConfiguration()
            : base()
        {
            ToTable("AboutUs", Constant.Consts.Schema.DBO);
            HasKey(aboutUs => aboutUs.AboutUsID);
            Property(aboutUs => aboutUs.AboutUsID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(aboutUs => aboutUs.Description).IsRequired();
        }
    }
}
