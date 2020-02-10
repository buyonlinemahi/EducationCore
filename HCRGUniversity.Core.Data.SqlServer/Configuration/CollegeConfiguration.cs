using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class CollegeConfiguration : EntityTypeConfiguration<College>
    {
        public CollegeConfiguration()
            : base()
        {
            ToTable("Colleges", Constant.Consts.Schema.DBO);
            HasKey(college => college.CollegeID);
            Property(college => college.CollegeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(college => college.CollegeName).IsRequired();
        }
    }
}